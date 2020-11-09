using Mirror;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public GameObject gameBuilding;
    public GameObject lobbyRoom;

    public static GameManager instance;

    public Player localPlayer;

    public void Start()
    {
        instance = this;
    }

    public void StartGame()
    {
        lobbyRoom.SetActive(false);
        gameBuilding.SetActive(true);

        PlayerSpawner.instance.SpawnPlayer(localPlayer);
    }

}
