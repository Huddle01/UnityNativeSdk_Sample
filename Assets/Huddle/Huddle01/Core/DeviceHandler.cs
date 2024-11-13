using Mediasoup.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.WebRTC;
using UnityEngine;
using Huddle01.Core.Models;

namespace Huddle01.Core 
{
    public class DeviceHandler : MonoBehaviour
    {
        public AudioSource inputAudioSource;

        private AudioClip _m_clipInput;
        private int m_samplingFrequency = 48000;
        private int m_lengthSeconds = 1;
        private string _selectedAudioDevice;

        private WebCamTexture _webCamTexture;

        public UnityEngine.UI.RawImage _rawImage;

        public static Dictionary<MediaDeviceType, List<MediaDeviceInfo>> MediaDevices =
        new Dictionary<MediaDeviceType, List<MediaDeviceInfo>>();

        VideoStreamTrack videoStreamTrack;

        [SerializeField]
        private Texture2D _defaultVideoTexture;

        RenderTexture renderTexture;

        private void Start()
        {
            StartCoroutine(WebRTC.Update());
        }

        public async Task<Dictionary<MediaDeviceType,List<MediaDeviceInfo>>> LoadMediaDevices(List<MediaDeviceInfo> devices)
        {
            UpdateDeviceList(devices);
            return null;
        }

        public MediaDeviceInfo GetSpeakerDevice() 
        {
            if (MediaDevices.TryGetValue(MediaDeviceType.AudioOutput, out List<MediaDeviceInfo> audioOutputDevices))
            {
                MediaDeviceInfo speaker = audioOutputDevices.FirstOrDefault(device => device.DeviceId.ToLower() == "speaker");
                return speaker;
            }

            return null;
        }

        public void UpdateDeviceList(List<MediaDeviceInfo> devices)
        {
            MediaDevices[MediaDeviceType.AudioInput] = new List<MediaDeviceInfo>();
            MediaDevices[MediaDeviceType.AudioOutput] = new List<MediaDeviceInfo>();
            MediaDevices[MediaDeviceType.VideoInput] = new List<MediaDeviceInfo>();

            Debug.Log($"Device List: {devices.Count} devices");

            // Add devices to the appropriate list based on type
            foreach (var device in devices)
            {
                switch (device.Kind)
                {
                    case "audioinput":
                        MediaDevices[MediaDeviceType.AudioInput].Add(device);
                        break;
                    case "audiooutput":
                        MediaDevices[MediaDeviceType.AudioOutput].Add(device); // No built-in support in Unity
                        break;
                    case "videoinput":
                        MediaDevices[MediaDeviceType.VideoInput].Add(device);
                        break;
                    default:
                        break;
                }
            }
        }

        public async Task<List<MediaDeviceInfo>> GetAudioInputs() 
        {
            string[] audioInputDevices = Microphone.devices;
            List<MediaDeviceInfo> devices = new List<MediaDeviceInfo>();

            await LoadMediaDevices(devices);

            foreach (var device in audioInputDevices)
            {
                devices.Add(new MediaDeviceInfo { DeviceId = device, Kind = "audioinput" });
            }

            return devices;

        }

        public void Stop(MediaStream stream)
        {
            if (stream == null)
            {
                return;
            }

            foreach (MediaStreamTrack track in stream.GetTracks()) 
            {
                track.Stop();
            }
        }

        

        private void Update()
        {
            if (_webCamTexture!=null && _webCamTexture.isPlaying) 
            {
                Graphics.Blit(_webCamTexture, renderTexture);

                if (videoStreamTrack != null && videoStreamTrack.Enabled) 
                {
                    _rawImage.texture = videoStreamTrack.Texture;
                }
            }
        }

        public async Task<MediaStream> FetchStream(string deviceId,string label) 
        {
            if (label == "video") 
            {
                var tcs = new TaskCompletionSource<bool>();

                StartCoroutine(CaptureWebCamAndSetTcs(deviceId, tcs));
                await tcs.Task;
                Debug.Log("Creating web camera from web camera");
                try 
                {
                    videoStreamTrack = new VideoStreamTrack(renderTexture);
                    videoStreamTrack.Enabled = true;
                    MediaStream mediaStream = new MediaStream();
                    mediaStream.AddTrack(videoStreamTrack);
                    return mediaStream;
                } 
                catch (System.Exception ex) 
                {
                    Debug.LogError($"Cant fetch stream {ex}");
                    throw new System.Exception(ex.Message);
                }
            }

            if (label == "audio") 
            {
                if (deviceId.Equals("0"))
                {
                    deviceId = Constants.SelectedAudioDevice;
                }

                _m_clipInput = Microphone.Start(deviceId,true,m_lengthSeconds,m_samplingFrequency);

                while (!(Microphone.GetPosition(deviceId) > 0)) { }
                inputAudioSource.loop = true;
                inputAudioSource.clip = _m_clipInput;
                inputAudioSource.Play();

                MediaStream mediaStream = new MediaStream();
                AudioStreamTrack audioStreamTrack = new AudioStreamTrack(inputAudioSource);
                audioStreamTrack.Enabled = true;
                mediaStream.AddTrack(audioStreamTrack);

                //_audioSpectrum._audioTrack = audioStreamTrack;
                //_audioSpectrum.StartGraph = true;

                return mediaStream;
            }

            return null;
        }

        private IEnumerator CaptureWebCamAndSetTcs(string deviceId, TaskCompletionSource<bool> tcs)
        {
            yield return CaptureWebCamVideo(Constants.SelectedCameraDevice);

            yield return new WaitForSeconds(0.1f);

            tcs.SetResult(true);
        }


        public void StopStream(MediaStream stream,string label) 
        {
            Debug.Log($"Stop all streamsssss");
            if (stream == null) return;

            if (label == "audio") 
            {
                if (Microphone.IsRecording(Constants.SelectedAudioDevice))
                {
                    Microphone.End(Constants.SelectedAudioDevice);
                }

                foreach (var item in stream.GetTracks())
                {
                    item.Stop();
                    item.Dispose();
                }


                // _audioSpectrum._audioTrack = null;
                //_audioSpectrum.StartGraph = false;
            }

            if (label == "video")
            {
                if (_webCamTexture.isPlaying)
                {
                    _webCamTexture.Stop();
                    _rawImage.texture = _defaultVideoTexture;
                }

                foreach (var item in stream.GetTracks())
                {
                    item.Stop();
                }
            }
        }

        public async Task<MediaStream> FetchAudioStream(string deviceId)
        {
            if (deviceId.Equals("0"))
            {
                deviceId = Microphone.devices[0];
            }

            _m_clipInput = Microphone.Start(deviceId, true, m_lengthSeconds, m_samplingFrequency);

            inputAudioSource.loop = true;
            inputAudioSource.clip = _m_clipInput;
            inputAudioSource.Play();

            while (!(Microphone.GetPosition(deviceId) > 0)) { }

            MediaStream mediaStream = new MediaStream();
            AudioStreamTrack audioStreamTrack = new AudioStreamTrack(inputAudioSource);
            audioStreamTrack.Enabled = true;
            mediaStream.AddTrack(audioStreamTrack);

            return mediaStream;
        }

        private IEnumerator CaptureWebCamVideo(string deviceId)
        {
            if (deviceId.Equals("0"))
            {
                deviceId = WebCamTexture.devices[0].name;
            }

            WebCamDevice userCameraDevice = GetVideoDeviceById(deviceId);
            _webCamTexture = new WebCamTexture(userCameraDevice.name, 1280, 720, 30);
            _webCamTexture.Play();

            yield return new WaitUntil(() => _webCamTexture.didUpdateThisFrame);

            // Create a RenderTexture with a compatible format
            renderTexture = new RenderTexture(1280, 720, 30, RenderTextureFormat.BGRA32);
            renderTexture.Create();

            // Blit the WebCamTexture to the RenderTexture
            Graphics.Blit(_webCamTexture, renderTexture);

            _rawImage.texture = renderTexture;
        }

        private WebCamDevice GetVideoDeviceById(string deviceId) 
        {
            foreach (WebCamDevice device in WebCamTexture.devices)
            {
                if (device.name.Equals(deviceId)) 
                {
                    return device;
                }
            }

            return WebCamTexture.devices[0];
        }

        private string GetMicrophoneDevideById(string deviceId) 
        {
            foreach (string device in Microphone.devices)
            {
                if (device.Equals(deviceId))
                {
                    return device;
                }
            }

            return Microphone.devices[0];
        }

    }

    #region CustomMediaDevice
    public enum CustomMediaDevice
    {
        Mic,
        Cam
    }

    public static class CustomMediaDeviceExtension
    {
        public static string GetValue(this CustomMediaDevice device)
        {
            switch (device)
            {
                case CustomMediaDevice.Mic:
                    return "mic";
                case CustomMediaDevice.Cam:
                    return "cam";
                default:
                    return "unknown";
            }
        }
    }

    #endregion

    #region MediaDeviceType

    public enum MediaDeviceType
    {
        AudioInput,
        AudioOutput,
        VideoInput
    }

    public static class MediaDeviceTypeExtension
    {
        public static string GetValue(this MediaDeviceType deviceType)
        {
            switch (deviceType)
            {
                case MediaDeviceType.AudioInput:
                    return "audioInput";
                case MediaDeviceType.AudioOutput:
                    return "audioOutput";
                case MediaDeviceType.VideoInput:
                    return "videoInput";
                default:
                    return "unknown";
            }
        }
    }

    #endregion

}


