using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : NetworkBehaviour
{

    public List<Transform> hiderSpawnLocations;
    public List<Transform> seekerSpawnLocations;

    public static PlayerSpawner instance;

    public void Start()
    {
        instance = this;
    }

    [Client]
    public void SpawnPlayer(Player player)
    {
        if(player.type == PlayerType.Hider)
        {
            player.transform.position = hiderSpawnLocations[Random.Range(0, hiderSpawnLocations.Count)].position;
        } else
        {
            player.transform.position = seekerSpawnLocations[Random.Range(0, seekerSpawnLocations.Count)].position;
        }
    }

    [Client]
    public IEnumerator SpawnPlayer(Player player, float time)
    {
        yield return new WaitForSeconds(time);
        SpawnPlayer(player);
    }
}
