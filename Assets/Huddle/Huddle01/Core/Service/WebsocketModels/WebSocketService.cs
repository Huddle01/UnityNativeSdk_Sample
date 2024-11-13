using NativeWebSocket;
using Huddle01.Core.Settings;
using UnityEngine;
using System.Collections.Generic;
using Google.Protobuf;

namespace Huddle01.Core.Services
{
    public class WebSocketService
    {
        public WebSocket _webSocket { get; private set; }
        public WebSocketState CurrentWebSocketState => _webSocket.State;

        public string AuthToken { get; set; }

        public bool IsConnected => _webSocket != null && _webSocket.State == WebSocketState.Open;
        public bool IsConnecting => _webSocket != null && _webSocket.State == WebSocketState.Connecting;

        private ServerSettings _serverSettings;
        private WebSocketEventsProcessor _webSocketEventsProcessor;

        public RequestProcessor RequestPublisher => _requestPublisher;
        public RequestProcessor _requestPublisher;

        public delegate void ConnectionCallback();
        public delegate void DisconnectCallback(WebSocketCloseCode closeCode);
        public delegate void ErrorCallback(string errorCode);
        public delegate void OnMessageReceived(byte[] message);

        public event OnMessageReceived MessageReceived;
        public event ConnectionCallback Connected;
        public event DisconnectCallback Disconnected;
        public event ErrorCallback ErrorReceived;

        public WebSocketService(ServerSettings serverSettings, WebSocketEventsProcessor webSocketEventsProcessor, RequestProcessor requestPublisher)
        {
            _serverSettings = serverSettings;
            _webSocketEventsProcessor = webSocketEventsProcessor;
            _requestPublisher = requestPublisher;
        }

        ~WebSocketService()
        {
            if (_webSocket != null)
            {
                _webSocket.Close();
            }
        }

        public async void Connect()
        {
            if (_webSocket == null)
            {
                InitializeWebSocket();
            }

            Debug.Log("Connect");
            // waiting for messages
            await _webSocket.Connect();
            Debug.Log("Connected");
        }

        private void InitializeWebSocket()
        {
            Debug.Log("Init Socket");
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("User-Agent", "Unity3D");

            _webSocket = new WebSocket(_serverSettings.WebSocketUrl, header);

            _webSocket.OnOpen += OnConnected;
            _webSocket.OnError += OnErrorReceive;
            _webSocket.OnClose += OnConnectionClose;
            _webSocket.OnMessage += OnMessageReceive;
        }

        private void OnErrorReceive(string errorCode)
        {
            Debug.LogError($"Error received : {errorCode}");
            ErrorReceived?.Invoke(errorCode);
        }

        private void OnConnected()
        {
            Connected?.Invoke();
        }

        public async void SendMessage(string message)
        {
#if  UNITY_EDITOR
            _webSocket.DispatchMessageQueue();
#endif
            if (_webSocket.State == WebSocketState.Open)
            {
                await _webSocket.SendText(message);
            }
        }

        public async void SendMessage(byte[] message)
        {
#if  UNITY_EDITOR
            _webSocket.DispatchMessageQueue();
#endif
            if (_webSocket.State == WebSocketState.Open)
            {
                await _webSocket.Send(message);
            }
        }

        public void SendRequest(Request request)
        {
            byte[] messageArray = request.ToByteArray();
            SendMessage(messageArray);
        }

        public void SendRequestWithoutWait(Request request) 
        {
            byte[] messageArray = request.ToByteArray();
            SendMessageWithoutWait(messageArray);
        }

        public void SendMessageWithoutWait(byte[] message)
        {
            if (_webSocket.State == WebSocketState.Open)
            {
                _webSocket.Send(message);
            }
        }


        public async void CloseSocketConnnection()
        {
            if (_webSocket.State == WebSocketState.Open)
            {
                await _webSocket.Close();
            }
        }

        private void OnMessageReceive(byte[] message)
        {
            Debug.Log($"Received msg : {System.Text.Encoding.UTF8.GetString(message)}");    
            _webSocketEventsProcessor.ProcessWebSocketEvents(message);
        }

        private void OnConnectionClose(WebSocketCloseCode closeCode)
        {
            Disconnected?.Invoke(closeCode);
        }

    }
}


