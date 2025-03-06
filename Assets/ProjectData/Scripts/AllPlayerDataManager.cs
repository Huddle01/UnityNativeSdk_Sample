using Huddle01.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayerDataManager
{
    //peerID and Remote peer
    public static Dictionary<string, RemotePeer> AllPeerData = new Dictionary<string, RemotePeer>();

    //NetId and Thirdperson gameobject;
    public static Dictionary<string, GameObject> AllThirdpersonPlayerData = new Dictionary<string, GameObject>();
}
