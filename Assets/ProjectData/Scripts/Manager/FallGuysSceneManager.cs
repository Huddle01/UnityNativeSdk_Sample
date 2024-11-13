using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FallGuysSceneManager : MonoBehaviour
{
    [Header("Networking Ref")]
    [SerializeField]
    private NetworkManager _networkManager;

    private void Start()
    {
        Invoke("EnterInRoom", 3);
    }

    public void EnterInRoom()
    {
        //Start client
        _networkManager.StartClient();
    }


}
