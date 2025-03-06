using Huddle01.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUiManager : MonoBehaviour
{
    public bool IsMicOn=>_isMicOn;
    private bool _isMicOn = false;

    public bool IsCameraOn=>_isCameraOn;
    private bool _isCameraOn = false;

    [Header("Button References")]
    [SerializeField]
    private Button _micButton;
    [SerializeField]
    private Button _cameraButton;
    [SerializeField]
    private Button _leaveButton;

    [Space(10)]
    [Header("Button References")]
    [SerializeField]
    private Image _micButtonImage;
    [SerializeField]
    private Image _cameraButtonImage;

    [Space(10)]
    [SerializeField]
    private GameObject _quitPopup;

    [Header("Sprite references")]
    [SerializeField]
    private Sprite _muteMicIcon;
    [SerializeField]
    private Sprite _unmuteMicIcon;
    [SerializeField]
    private Sprite _videoEnabledIcon;
    [SerializeField]
    private Sprite _videoDisabledIcon;


    private void Start()
    {
        _micButton.interactable = false;
        _cameraButton.interactable = false;
        _leaveButton.interactable = false;
    }

    public void EnableBothButtons() 
    {
        _micButton.interactable = true;
        _cameraButton.interactable = true;
        _leaveButton.interactable = true;
    }

    public void ToggleMic() 
    {
        StartCoroutine(EnableInteractionWithButtonAfterDelay(_micButton));
        
        if (IsMicOn)
        {
            Huddle01Manager.Instance.StopMic();
            _isMicOn = false;
            //_micButton.image.color = Color.red;
            _micButtonImage.sprite = _muteMicIcon;
        }
        else 
        {
            Huddle01Manager.Instance.StartMic();
            _isMicOn = true;
            //_micButton.image.color = Color.green;
            _micButtonImage.sprite = _unmuteMicIcon;
        }
    }

    public void ToggleCamera() 
    {
        StartCoroutine(EnableInteractionWithButtonAfterDelay(_cameraButton));
        
        if (_isCameraOn)
        {
            Huddle01Manager.Instance.StopCam();
            _isCameraOn = false;
            // _cameraButton.image.color = Color.red;
            _cameraButtonImage.sprite = _videoDisabledIcon;
        }
        else
        {
            Huddle01Manager.Instance.StartCam();
            _isCameraOn = true;
            _cameraButtonImage.sprite = _videoEnabledIcon;
            // _cameraButton.image.color = Color.green;
        }
    }

    IEnumerator EnableInteractionWithButtonAfterDelay(Button button) 
    {
        button.interactable = false;
        yield return new WaitForSeconds(3);
        button.interactable = true;
    }

    public void OpenCloseApplicationPopup() 
    {
        _quitPopup.SetActive(true);
    }

    public void QuitApplication() 
    {
        Application.Quit();
    }

}
