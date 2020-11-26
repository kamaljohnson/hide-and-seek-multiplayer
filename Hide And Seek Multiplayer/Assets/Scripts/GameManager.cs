using Mirror;
using System.Collections;
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

        SpawnLocalPlayer();

        localPlayer.fov.SetUpFovPlayerType(localPlayer.type);

        if (localPlayer.type == PlayerType.Seeker)
        {
            playerInputManager.EnableReportUi();
            playerInputManager.InitReportUi(GetHiders(players));
            localPlayer.GetComponent<HiderScanner>().enabled = true;
            localPlayer.GetComponent<HiderScanner>().InitAllHiders(GetHiders(players));
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

    public List<Player> GetHiders()
    {
        return (GetHiders(players));
    }

    public List<Player> GetSeekers(List<Player> players)
    {
        return players.Where(player => player.type == PlayerType.Seeker).ToList();
    }

    public Player GetPlayerWithColor(PlayerColor color)
    {
        return players.Find(x => x.color == color);
    }

    [Server]
    public void FreezPlayerWithColor(PlayerColor color)
    {
        Player player = GetPlayerWithColor(color);
        player.Freez();
        StartCoroutine("UnFreezPlayer", player);
    }

    [Server]
    IEnumerator UnFreezPlayer(Player player)
    {
        yield return new WaitForSeconds(GetPlayerCoolDownTime(player));

        player.SpawnPlayer();
        player.UnFreez();
    }

    [Client]
    public void SpawnLocalPlayer()
    {
        PlayerSpawner.instance.SpawnPlayer(localPlayer);
    }

    [Server]
    public float GetPlayerCoolDownTime(Player player)
    {
        //TODO: update the cooldown time of the player
        return player.coolDownTime;
    }
}
