using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class CharacterSelectionManager : MonoBehaviour
{
    public string GameSceneName;

    [SerializeField]
    private GameObject _mainMenu;

    [Header("Character prefabs")]
    [SerializeField]
    private GameObject[] _characters;

    [SerializeField]
    private Image[] _characterButtons;

    [SerializeField]
    private Color _highlilghtColor;

    [SerializeField]
    private TMP_InputField _nameInputField;

    [SerializeField] 
    private Dropdown dropdownMicrophoneDevices;

    [SerializeField]
    private Dropdown dropdownCameraDevices;

    private int _selectedCharacterId = 0;

    private string m_deviceName = null;
    private string cameraDeviceName = null;

    // Start is called before the first frame update
    void Start()
    {
        Constants.SelectedAudioDevice = Microphone.devices[0];
        Constants.SelectedCameraDevice = WebCamTexture.devices[0].name;

        dropdownMicrophoneDevices.options =
            Microphone.devices.Select(name => new Dropdown.OptionData(name)).ToList();
        dropdownMicrophoneDevices.onValueChanged.AddListener(OnDeviceChanged);

        dropdownCameraDevices.options =
           WebCamTexture.devices.Select(device => new Dropdown.OptionData(device.name)).ToList();
        dropdownCameraDevices.onValueChanged.AddListener(OnCameraDeviceChanged);

        OnCharacterButtonClick(0);
    }

    public void OnCharacterButtonClick(int index)
    {
        _selectedCharacterId = index;

        for (int i = 0; i < _characters.Length; i++)
        {
            if (i == index)
            {
                _characters[i].SetActive(true);
                _characterButtons[i].color = _highlilghtColor;
                _characterButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
            }
            else
            {
                _characters[i].SetActive(false);
                _characterButtons[i].color = Color.white;
                _characterButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
            }
        }
    }

    public void LoadGameScene() 
    {
        if (string.IsNullOrEmpty(_nameInputField.text))
        {
            Sample.Constants.Username = "Guest";
        }
        else 
        {
            Sample.Constants.Username = _nameInputField.text;
        }

        Constants.PlayerCharacterId = _selectedCharacterId;
        SceneManager.LoadScene(GameSceneName);
    }

    void OnDeviceChanged(int value)
    {
        if (dropdownMicrophoneDevices.options.Count == 0)
            return;
        m_deviceName = dropdownMicrophoneDevices.options[value].text;
        Microphone.GetDeviceCaps(m_deviceName, out int minFreq, out int maxFreq);
        Constants.SelectedAudioDevice = m_deviceName;
    }


    void OnCameraDeviceChanged(int value)
    {
        if (dropdownCameraDevices.options.Count == 0)
            return;
        cameraDeviceName = dropdownCameraDevices.options[value].text;
        Constants.SelectedCameraDevice = cameraDeviceName;
    }
}
