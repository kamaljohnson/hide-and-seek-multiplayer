using Mirror;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerColor
{
    Black,
    White,
    Orange,
    Green,
    Cyan,
    DarkGreen,
    Purple,
    Brown,
    Pink,
    Red
}


public class LobbyManager : NetworkBehaviour
{

    public GameObject startButton;
    public GameObject customizSettingsPanel;

    public static LobbyManager instance;

    public List<PlayerColor> selectableColors;

    private void Start()
    {
        instance = this;

        if (isServer)
        {
            selectableColors = new List<PlayerColor>()
            {
                PlayerColor.Black,
                PlayerColor.White,
                PlayerColor.Orange,
                PlayerColor.Green,
                PlayerColor.Cyan,
                PlayerColor.DarkGreen,
                PlayerColor.Purple,
                PlayerColor.Brown,
                PlayerColor.Pink,
                PlayerColor.Red
            };
        }

        if (!isClientOnly)
        {
            startButton.SetActive(true);
        }
    }

    public void StartGame()
    {
        ClientStartGame();
        startButton.SetActive(false);
    }

    [ClientRpc]
    void ClientStartGame()
    {
        GameManager.instance.StartGame();
    }

    [Client]
    public void ShowCustomizSettingsButton()
    {
        customizSettingsPanel.SetActive(true);
    }

    [Client]    //Triggerd from unity Button event
    public void ClientChangeColor(PlayerColor color)
    {
        GameManager.instance.localPlayer.TriggerPlayerColorChange(color);
    }


    [Server]
    public void SetPlayerColor(Player player)
    {
        player.ChangePlayerColor(PlayerColor.Brown);
    }

    [Server]
    public void SetPlayerColor(Player player, PlayerColor color)
    {

    }
}
