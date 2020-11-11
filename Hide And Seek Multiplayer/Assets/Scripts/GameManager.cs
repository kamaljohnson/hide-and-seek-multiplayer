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

    public List<Player> players;

    public void Start()
    {
        instance = this;
    }

    [Client]
    public void StartGame()
    {
        lobbyRoom.SetActive(false);
        gameBuilding.SetActive(true);

        PlayerSpawner.instance.SpawnPlayer(localPlayer);
    }

    [Server]
    public void AddPlayer(Player player)
    {
        players.Add(player);
        LobbyManager.instance.SetPlayerColor(player);
    }

    [Server]
    public void RemovePlayer(Player player)
    {
        players.Remove(player);
    }

}
