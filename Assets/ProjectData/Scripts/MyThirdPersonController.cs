using Mirror;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Sample;
using Huddle01.Core;
using System;
using Newtonsoft.Json;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class MyThirdPersonController : ThirdPersonController
{
    [SyncVar(hook = nameof(HandleDisplayNameUpdated))]
    [SerializeField]
    private string _displayName;

    [SyncVar(hook = nameof(OnHuddleTokenReceivedFromServer))]
    private string _huddleToken;

    [SyncVar(hook = nameof(HandlePeerUpdated))]
    [SerializeField]
    private string _peerId;

    [Header("References for setup")]
    [SerializeField]
    private GameObject _characterMainCamera;
    [SerializeField]
    private GameObject _characterVirtualCamera;

    [SerializeField]
    private GameObject _uiEventSystem;
    [SerializeField]
    private GameObject _joyStickUI;


    public RemotePeer RemotePeerData;
    public LocalPeer LocalPeerData;

    public LocalPeerMediaSection LocalPeerSection;
    public RemotePeerMediaSection RemotePeerSection;

    public PlayerMetadata Metadata = new PlayerMetadata();

    private void Start()
    {
        if (!isOwned)
        {
            _characterMainCamera.gameObject.SetActive(false);
            _characterVirtualCamera.gameObject.SetActive(false);
            _uiEventSystem.SetActive(false);
            NetworkManager.AllPlayersMap[netId.ToString()] = this.gameObject;
            AllPlayerDataManager.AllThirdpersonPlayerData[netId.ToString()] = this.gameObject;
            RemotePeerSection.gameObject.SetActive(true);
            _joyStickUI.SetActive(false);
            SubscribeEventsForRemotePlayer();
            return;
        }
        Debug.Log("Locallllllllllll player");
        SubscribeEventsForLocalPlayer();
        Metadata.NetId = netId.ToString();
        UnityEngine.InputSystem.PlayerInput playerInput = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        playerInput.enabled = true;
        LocalPeerSection.gameObject.SetActive(true);
        Huddle01Manager.Instance._deviceHandler._rawImage = LocalPeerSection.LocalPeerVideoStreaming;
        Huddle01Manager.Instance._deviceHandler.inputAudioSource = LocalPeerSection.MicrophoneSource;
        CmdSetDisplayName(Sample.Constants.Username);
        Setup();
        Huddle01Manager.Instance.SetHuddleToken();
    }

    private void OnPeerJoined(RemotePeer remotePeer)
    {
        Debug.Log(JsonConvert.SerializeObject(remotePeer));
        Debug.Log("Peeeeeeeeeeeeeer joined");
        if (remotePeer.PeerId == Huddle01Manager.Instance.LocalPeerObj.PeerId) return;
        Debug.Log("not local Peeeeeeeeeeeeeer joined");
        string remotePeerMetaData = remotePeer.Metadata;
        if (string.IsNullOrEmpty(remotePeerMetaData)) return;

        PlayerMetadata playerMetadata = JsonConvert.DeserializeObject<PlayerMetadata>(remotePeerMetaData);
        Debug.Log(remotePeerMetaData);
        if (playerMetadata.NetId == netId.ToString()) 
        {
            RemotePeerData = remotePeer;
            RemotePeerSection.Init(remotePeer);
        }
    }

    private void OnMetadataUpdated(RemotePeer remotePeer) 
    {
        if (remotePeer == null) return;
        string remotePeerMetaData = remotePeer.Metadata;
        if (string.IsNullOrEmpty(remotePeerMetaData)) return;
        PlayerMetadata playerMetadata = null;
        try 
        {
            playerMetadata = JsonConvert.DeserializeObject<PlayerMetadata>(remotePeerMetaData);
        } catch (Exception ex) 
        {
            throw new Exception(ex.Message);
        }

        if (playerMetadata.NetId == netId.ToString())
        {
            if (RemotePeerSection.IsInit) return;
            RemotePeerData = remotePeer;
            RemotePeerSection.Init(remotePeer);
        }
    }

    private void OnHuddleTokenReceived(string token) 
    {
        CmdSetHuddleToken(token);
    }

    #region Unity Udpate and LateUpdate

    public override void LateUpdate()
    {
        if (!isOwned) return;
        base.LateUpdate();
    }

    public override void Update()
    {
        if (!isOwned) return;
        base.Update();
    }

    #endregion

    #region Command

    [Command]
    public void CmdSetDisplayName(string username)
    {
        Debug.Log("Seting Up name");
        SetDisplayName(username);
    }

    [Command]
    public void CmdSetPeerId(string peerId)
    {
        Debug.Log("Seting Up name");
        SetPeerIdName(peerId);
    }

    [Command]
    public void CmdSetHuddleToken(string token)
    {
        Debug.Log("Seting Up name");
        SetHuddleToken(token);
    }


    #endregion

    #region Server

    [Server]
    public void SetDisplayName(string username)
    {
        _displayName = username;
    }

    [Server]
    public void SetPeerIdName(string peerId)
    {
        _peerId = peerId;
    }

    [Server]
    public void SetHuddleToken(string huddleToken)
    {
        _huddleToken = huddleToken;
    }

    #endregion


    private void HandleDisplayNameUpdated(string oldName, string newName)
    {
        RemotePeerSection.NameText.text = newName;
        LocalPeerSection.NameText.text = newName;
    }

    private void HandlePeerUpdated(string oldPeerId, string newPeerId)
    {
        Debug.Log(newPeerId);
    }

    private void OnDestroy()
    {
        if (!isOwned)
        {
            UnSubscribeEventsForRemotePlayer();
        }
        else 
        {
            UnSubscribeEventsForLocalPlayer();
        }
    }


    public void OnHuddleTokenReceivedFromServer(string oldHuddleToken,string newHuddleToken) 
    {
        if (isOwned) 
        {
            Debug.Log("Connect to server");
            Huddle01Manager.Instance.ConnectToHuddleRoomServer();
        }
        
    }
    private void OnWebsocketConnected()
    {
        Huddle01Manager.Instance.JoinRoom();
    }


    public void SetMetadata() 
    {
        Metadata.PeerId = Huddle01Manager.Instance.LocalPeerObj.PeerId;
        Huddle01Manager.Instance.UpdateMetadata(Metadata);
    }

    public void OnRoomJoinedReceived() 
    {
        Debug.Log("Room Joined");
        Debug.Log("Set metadata");
        SetMetadata();
    }

    public void SubscribeEventsForLocalPlayer() 
    {
        Huddle01Manager.OnHuddleTokenReceived += OnHuddleTokenReceived;
        Huddle01Manager.OnRoomJoined += OnRoomJoinedReceived;
        Huddle01Manager.OnWebSocketServerConnected += OnWebsocketConnected;

    }

    
    public void UnSubscribeEventsForLocalPlayer()
    {
        Huddle01Manager.OnHuddleTokenReceived -= OnHuddleTokenReceived;
        Huddle01Manager.OnRoomJoined -= OnRoomJoinedReceived;
        Huddle01Manager.OnWebSocketServerConnected -= OnWebsocketConnected;
    }

    public void SubscribeEventsForRemotePlayer()
    {
        Huddle01Manager.OnPeerJoined += OnPeerJoined;
        Huddle01Manager.OnPeerMetadataUpdated += OnMetadataUpdated;
    }

    public void UnSubscribeEventsForRemotePlayer()
    {
        Huddle01Manager.OnPeerJoined -= OnPeerJoined;
        Huddle01Manager.OnPeerMetadataUpdated -= OnMetadataUpdated;
    }


}
