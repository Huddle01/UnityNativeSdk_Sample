using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSpawner : NetworkBehaviour
{
    [SerializeField]
    private GameObject[] _charactersPrefab;

    [ClientCallback]
    private void Start()
    {
        CmdSpawnPlayer(Constants.PlayerCharacterId, Sample.Constants.SpawnPosition);
    }

    [Command]
    private void CmdSpawnPlayer(int characterId, Vector3 position)
    {
        Vector3 spawnPos = this.transform.position;
        if (position != Vector3.zero)
            spawnPos = position;
        GameObject unitInstance = null;
        switch (characterId) 
        {
            case 0:
                unitInstance = Instantiate(
                _charactersPrefab[characterId],
                spawnPos,
                this.transform.rotation);
                NetworkServer.Spawn(unitInstance, connectionToClient);

                break;

            case 1:
                unitInstance = Instantiate(
                _charactersPrefab[characterId],
                spawnPos,
                this.transform.rotation);
                NetworkServer.Spawn(unitInstance, connectionToClient);
                break;

            case 2:
                unitInstance = Instantiate(
                _charactersPrefab[characterId],
                spawnPos,
                this.transform.rotation);
                NetworkServer.Spawn(unitInstance, connectionToClient);
                break;
        }
    }
}
