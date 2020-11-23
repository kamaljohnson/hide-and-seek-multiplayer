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

    public PlayerInputManager playerInputManager;

    public void Start()
    {
        instance = this;
    }

    [Client]
    public void StartGame()
    {
        players = FindObjectsOfType<Player>().ToList();

        lobbyRoom.SetActive(false);
        gameBuilding.SetActive(true);

        localPlayer.SetupFovPlayerMasking();
        PlayerSpawner.instance.SpawnPlayer(localPlayer);

        if(localPlayer.type == PlayerType.Seeker)
        {
            playerInputManager.EnableReportUi();
            playerInputManager.InitReportUi(GetHiders(players));
        }
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


    /*
     * Helper functions
     */
    public List<Player> GetHiders(List<Player> players)
    {
        return players.Where(player => player.type == PlayerType.Hider).ToList();
    }

    public List<Player> GetSeekers(List<Player> players)
    {
        return players.Where(player => player.type == PlayerType.Seeker).ToList();
    }

}
