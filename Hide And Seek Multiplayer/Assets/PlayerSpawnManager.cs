using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : NetworkBehaviour
{

    public List<Transform> hiderSpawnLocations;
    public List<Transform> seekerSpawnLocations;

    public void Start()
    {
        if (isServer)
        {

        }
    }

    public void SpawnHider()
    {

    }

    public void SpawnSeeker()
    {

    }

}
