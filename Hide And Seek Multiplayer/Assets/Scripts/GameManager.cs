using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public GameObject gameBuilding;
    public GameObject lobbyRoom;

    public static GameManager instance;

    public void Start()
    {
        instance = this;
    }

    public void StartGame()
    {
        lobbyRoom.SetActive(false);
        gameBuilding.SetActive(true);
    }
    
}
