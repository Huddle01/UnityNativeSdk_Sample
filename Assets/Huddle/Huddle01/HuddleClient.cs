
using Huddle01.Core;
using Huddle01.Core.Services;
using UnityEngine;

namespace Assets.Huddle01
{
    public class HuddleClient
    {
    // Connection Manager Instance, Handler socket connection and stores information about the connection
    private WebSocketService _socket;
    // Room Instance, Handles the room and its connection
    private Room _room;
    // Local Peer Instance, Handles the local peer and its connection
    private LocalPeer _localPeer;
    /// Project Id of the Huddle01 Project
    public string ProjectId { get; set; }
    /// Returns the room instance
    public Room Room => _room;

    /// Returns the localPeer
    public LocalPeer LocalPeer => _localPeer;

    /// Room Id of the current room
    public string RoomId => _room?.RoomId;

    /// Set a new region for the Huddle01 Media Servers
    public void SetRegion(string region)
    {
        Debug.Log($"Setting a new region: {region}");
    }

    public HuddleClient(string projectId, bool? autoConsume = null)
    { }
        
    }
}