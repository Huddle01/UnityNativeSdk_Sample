using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocalPeerMediaSection : MonoBehaviour
{
    public RawImage LocalPeerVideoStreaming;
    public AudioSource MicrophoneSource;
    public TMP_Text NameText;

    private void OnEnable()
    {
#if UNITY_IOS
    LocalPeerVideoStreaming.transform.localScale = new Vector3(1, -1, 1);
#endif
    }
}
