using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using StarterAssets;

public class MyNetworkManager : NetworkManager
{
    [SerializeField]
    private GameObject _playerSpawnerPrefab = null;

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        Debug.Log($"I connected to server");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        GameObject unitSpawnerInstance = Instantiate(
            _playerSpawnerPrefab,
            conn.identity.transform.position,
            conn.identity.transform.rotation);

        NetworkServer.Spawn(unitSpawnerInstance, conn);
    }
}
