using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Huddle01.Core;
using Mediasoup;
using Huddle01.Core.Settings;
using Huddle01.Core.Services;
using Huddle01.Core.EventBroadcast;
using System;
using static Huddle01.Core.Services.WebSocketService;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.Android;


public class Huddle01Manager : MonoBehaviour
{
    public delegate void PeerJoined(RemotePeer remotePeer);
    public delegate void HuddleTokenReceived(string token);
    public delegate void JoinRoomReceived();
    public delegate void PeerMetadatUpdatedReceived(RemotePeer remotePeer);
    public delegate void WebSocketServerConnected();

    public static Huddle01Manager Instance;

    public DeviceHandler _deviceHandler;

    public LocalPeer LocalPeerObj;
    public Room RoomObj;

    private ServerSettings _serverSettings;
    private WebSocketEventsProcessor _webSocketEventsProcessor;
    private EventsBroadcaster _eventsBroadcaster;

    private WebSocketService _webSocketService;
    private RequestProcessor _requestProcessor;

    private Huddle01.Core.Permissions _permissions;

    private string _currentServerUrl;

    public string HuddleToken;

    private const string region = "ASI";
    private const string coutry = "IN";
    private const string version = "2";

    public static event PeerJoined OnPeerJoined;
    public static event HuddleTokenReceived OnHuddleTokenReceived;
    public static event JoinRoomReceived OnRoomJoined;
    public static event PeerMetadatUpdatedReceived OnPeerMetadataUpdated;
    public static event WebSocketServerConnected OnWebSocketServerConnected;

    public InGameUiManager GameUIManager;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Huddle01 SDK Initialized");
        _eventsBroadcaster = new EventsBroadcaster();
        _requestProcessor = new RequestProcessor();
        _permissions = new Huddle01.Core.Permissions();

        _serverSettings = new ServerSettings();

        _webSocketEventsProcessor = new WebSocketEventsProcessor(_eventsBroadcaster);

        _webSocketService = new WebSocketService(_serverSettings, _webSocketEventsProcessor, _requestProcessor);

        _webSocketService.Connected += OnWebsocketConnected;

        LocalPeerObj = LocalPeer.Instance.Init(_webSocketService, _eventsBroadcaster, _deviceHandler, _permissions);
        RoomObj = Room.Instance.Init(_webSocketService, _permissions, true);

        //LocalPeerObj.On("consume", async (args) => ConsumePeer(args));
        LocalPeerObj.On("connected-to-server", async (args) => ConsumePeer(args));

        if (!_permissions.CheckPermission(PermissionType.canProduce, null)) return;

        RoomObj.On("room-joined", async (args) => SetupRoomPeers());
        RoomObj.On("peer-metadata-updated", async (args) => OnPeerMetadataUpdatedReceived(args));

        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            Permission.RequestUserPermission(Permission.Camera);
    }

    // Update is called once per frame
    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        if (_webSocketService != null && _webSocketService.IsConnected)
        {
            _webSocketService._webSocket.DispatchMessageQueue();
        }
#endif
    }

    public void ConnectToHuddleRoomServer() 
    {
        ConnectToServer(_currentServerUrl);
    }

    private void OnWebsocketConnected()
    {
        OnWebSocketServerConnected?.Invoke();
    }

    public void SetHuddleToken() 
    {
        StartCoroutine(GetServerUrl(region, coutry, version));
    }

    public void StartMic()
    {
        _ = LocalPeerObj.EnableAudio();
    }

    public void StartCam()
    {
        _ = LocalPeerObj.EnableVideo();
    }

    public void StopMic()
    {
        _ = LocalPeerObj.StopProducing("audio");
    }

    public void StopCam()
    {
        _ = LocalPeerObj.StopProducing("video");
    }

    public async void ConsumePeer(object[] args)
    {
        string label = args[0] as string;
        string producerPeerId = args[1] as string;

        if (label.Equals("audio"))
        {
            //Instantiate an object and add audio source
        }

    }

    private void SetupRoomPeers()
    {
        GameUIManager.EnableBothButtons();
        OnRoomJoined?.Invoke();
        Debug.Log("Room Joined");
        foreach (var item in LocalPeerObj.RemotePeers)
        {
            AllPlayerDataManager.AllPeerData[item.Key] =  item.Value;
            OnPeerJoined?.Invoke(item.Value);
        }
    }

    private void OnPeerMetadataUpdatedReceived(object[] args) 
    {
        string peerId = args[0] as string;
        RemotePeer remotePeer = Room.Instance.GetRemotePeerById(peerId);
        if (remotePeer != null) 
        {
            OnPeerMetadataUpdated?.Invoke(remotePeer);
        }
    }

    private void ConnectToServer(string url)
    {
        _serverSettings.WebSocketUrl = url;
        _webSocketService.Connect();
    }

    public void JoinRoom()
    {
        SubscribeToEvents();
        LocalPeerObj.ConnectRoomRequest(Constants.HuddleRoomId);
    }

    private void SubscribeToEvents()
    {
        RoomObj.On("new-peer-joined", async (args) =>
        {
            RemotePeer remotePeer = args[0] as RemotePeer;
            AllPlayerDataManager.AllPeerData[remotePeer.PeerId] = remotePeer;
            OnNewPeerJoined(remotePeer);
        }); 
    }

    public void UpdateMetadata(PlayerMetadata metadata) 
    {
        LocalPeerObj.UpdateMetadata(JsonConvert.SerializeObject(metadata));
    }

    private void OnNewPeerJoined(RemotePeer remotePeer)
    {
        OnPeerJoined?.Invoke(remotePeer);
    }

    #region Get Token

    private string GetServerUrlWithParam(string url, string token, string version, string region, string country)
    {
        url += "?token=" + token;
        url += "&version=" + version;
        url += "&region=" + region;
        url += "&country=" + country;

        return url;
    }

    private void OnApplicationQuit()
    {
        Room.Instance.LeaveRoom();
    }

    IEnumerator GetServerUrl(string region, string country, string version)
    {
        yield return StartCoroutine(GetAndSetHuddleToken(Constants.HuddleRoomId, Constants.HuddleApiKey));

        Debug.Log("Connect to server");

        string apiServerUrl = "https://apira.huddle01.media/api/v1/getSushiUrl";
        //string apiServerUrl = "https://apira-testnet.huddle01.media/api/v1/getSushiUrl";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiServerUrl))
        {
            webRequest.SetRequestHeader("authorization", "Bearer " + HuddleToken);
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();
            Debug.Log($"response data {webRequest.downloadHandler.text}");
            Dictionary<string, string> responseData = JsonConvert.DeserializeObject<Dictionary<string, string>>(webRequest.downloadHandler.text);

            string response = responseData["url"];

            response = response.Replace("https://", "wss://");
            response += "/ws";

            _currentServerUrl = GetServerUrlWithParam(response, HuddleToken, version, region, country);
            OnHuddleTokenReceived?.Invoke(HuddleToken);
        }
    }

    IEnumerator GetAndSetHuddleToken(string roomId, string apiKey)
    {
        string apiUrl = Constants.HuddleGetTokenUrl + "apiKey=" + apiKey + "&role=guest&roomId=" + roomId;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                HuddleToken = webRequest.downloadHandler.text;
            }
        }
    }

    #endregion

}

