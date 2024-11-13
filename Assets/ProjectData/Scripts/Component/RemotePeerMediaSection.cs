using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.WebRTC;
using Huddle01.Core;
using Mediasoup;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class RemotePeerMediaSection : MonoBehaviour
{
    public RemotePeer RemotePeerRef;

    List<Tuple<Action<Consumer<Mediasoup.Types.AppData>, string>, Consumer<Mediasoup.Types.AppData>, string>> ConsumeTasks =
                            new List<Tuple<Action<Consumer<Mediasoup.Types.AppData>, string>, Consumer<Mediasoup.Types.AppData>, string>>();
    List<Tuple<Action<string, string>, string, string>> CloseConsumerTasks =
                            new List<Tuple<Action<string, string>, string, string>>();

    public RawImage _videoTexture;

    private VideoStreamTrack _videotrack;

    [SerializeField]
    private Texture2D _defaultTextureForVideo;

    private GameObject _audioRef;

    public TMP_Text NameText;

    public AudioMixerGroup MicrophoneGroup;

    public bool IsInit = false;

    public GameObject AudioSourcePrfab;

    [SerializeField]
    private Image _muteMicImage;
    [SerializeField]
    private Sprite _mutedMicImage;
    [SerializeField]
    private Sprite _unmutedMicImage;

    [SerializeField]
    private AudioSource _remotePeerAudioSource;


    void Start()
    {
        StartCoroutine(WebRTC.Update());
    }

    // Update is called once per frame
    void Update()
    {
        while (ConsumeTasks.Count > 0)
        {
            ConsumeTasks[0].Item1.Invoke(ConsumeTasks[0].Item2, ConsumeTasks[0].Item3);
            ConsumeTasks.RemoveAt(0);
        }

        while (CloseConsumerTasks.Count > 0)
        {
            CloseConsumerTasks[0].Item1.Invoke(CloseConsumerTasks[0].Item2, CloseConsumerTasks[0].Item3);
            CloseConsumerTasks.RemoveAt(0);
        }

        if (_videotrack != null && _videotrack.ReadyState == TrackState.Live && _videotrack.Enabled)
        {
            Debug.Log($"tex format {_videotrack.Texture == null}");

            _videoTexture.texture = _videotrack.Texture;
        }
    }

    public void Init(RemotePeer remotePeer)
    {
        RemotePeerRef = remotePeer;

        remotePeer.On("stream-playable", async (arg) =>
        {
            Debug.Log("Play stream");
            try
            {
                Consumer<Mediasoup.Types.AppData> consumer = arg[0] as Consumer<Mediasoup.Types.AppData>;
                string label = arg[1] as string;

                Debug.Log(consumer.track.ReadyState);

                if (label.Equals("audio"))
                {
                    var temp = new Tuple<Action<Consumer<Mediasoup.Types.AppData>, string>, Consumer<Mediasoup.Types.AppData>, string>(PlayAudioStream, consumer, label);
                    ConsumeTasks.Add(temp);
                }
                else if (label.Equals("video"))
                {
                    var temp = new Tuple<Action<Consumer<Mediasoup.Types.AppData>, string>, Consumer<Mediasoup.Types.AppData>, string>(PlayVideoStream, consumer, label);
                    ConsumeTasks.Add(temp);
                }

            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        });

        remotePeer.On("stream-closed", async (arg) =>
        {
            Debug.Log("Close stream");
            var temp = new Tuple<Action<string, string>, string, string>(CloseAudioTrack, arg[0] as string, arg[1] as string);
            CloseConsumerTasks.Add(temp);
        });

        Room.Instance.On("peer-left", async (arg) => DestroyThisObject());

        IsInit = true;
    }

    private void CloseAudioTrack(string label, string peerId)
    {
        if (label.Equals("audio"))
        {
            _remotePeerAudioSource.Stop();
            //Destroy(_audioRef);
            //_audioRef = null;
            _muteMicImage.sprite = _mutedMicImage;
            // _micStatus.color = Color.red;
        }

        if (label.Equals("video"))
        {
            _videotrack.OnVideoReceived -= (tex) => { _videoTexture.texture = tex; };
            _videotrack.Enabled = false;

            _videoTexture.texture = _defaultTextureForVideo;
        }
    }

    private void PlayAudioStream(Consumer<Mediasoup.Types.AppData> consumer, string label)
    {
        SetAudioSource(consumer.track);
        //_micStatus.color = Color.green;
    }

    private void PlayVideoStream(Consumer<Mediasoup.Types.AppData> consumer, string label)
    {
        Debug.Log("Play video stream");
        try
        {
            _videotrack = consumer.track as VideoStreamTrack;
            _videotrack.OnVideoReceived += (tex) =>
            {
                Debug.Log($"tex format {tex.graphicsFormat}");
                _videoTexture.texture = tex;

            };
            _videotrack.Enabled = true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Texture format issue {ex}");
        }
    }

    public void SetAudioSource(MediaStreamTrack track)
    {
        try
        {
           // _audioRef = Instantiate(AudioSourcePrfab);
           // _audioRef.transform.SetParent(this.transform);
           // _audioRef.transform.localPosition = new Vector3(0, 0, 0);
           // AudioSource aud = _audioRef.GetComponent<AudioSource>();
            AudioStreamTrack audioTrack = track as AudioStreamTrack;

            _remotePeerAudioSource.SetTrack(audioTrack);
            //aud.outputAudioMixerGroup = MicrophoneGroup;

            _remotePeerAudioSource.loop = true;
            _remotePeerAudioSource.Play();

            _muteMicImage.sprite = _unmutedMicImage;

        }
        catch (Exception ex)
        {
            Debug.LogError($"Cant play audio {ex}");
        }
    }

    private void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
       /* if (_audioRef != null) 
        {
            if (_audioRef.GetComponent<AudioSource>().isPlaying) 
            {
                _audioRef.GetComponent<AudioSource>().Stop();
            }
        }*/

        if (_remotePeerAudioSource.isPlaying)
        {
            _remotePeerAudioSource.Stop();
        }
    }
}
