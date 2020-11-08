using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : NetworkBehaviour
{

    public GameObject startButton;

    private void Start()
    {
        if (!isClientOnly)
        {
            startButton.SetActive(true);
        }
    }

    public void StartGame()
    {
        ClientStartGame();
    }

    [ClientRpc]
    void ClientStartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
