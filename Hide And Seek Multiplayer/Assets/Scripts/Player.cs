using Mirror;
using UnityEngine;

public enum PlayerType
{
    None,
    Seeker,
    Hider
}

public class Player : NetworkBehaviour
{

    [SyncVar] public PlayerType type;

    [SyncVar] public PlayerColor color;

    public GameObject _camera;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!isLocalPlayer)
        {
            _camera.SetActive(false);
        } 
        else
        {
            JoinGame();
            GameManager.instance.localPlayer = this;
        }
    }

    private void OnDestroy()
    {
        if (isLocalPlayer)
        {
            LeaveGame();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collision>().collider);
        }
    }

    public void ChangePlayerType(PlayerType type)
    {
        this.type = type;
    }

    [Client]
    public void JoinGame()
    {
        CmdJoinGame();

    }

    [Command]
    public void CmdJoinGame()
    {
        GameManager.instance.AddPlayer(this);
    }

    [Client]
    public void LeaveGame()
    {
        CmdLeaveGame();
    }

    [Command]
    public void CmdLeaveGame()
    {
        GameManager.instance.RemovePlayer(this);

    }

    [Server]
    public void ChangePlayerColor(PlayerColor color)
    {
        this.color = color;
        ClientChangePlayerColor(color);
    }

    [ClientRpc]
    public void ClientChangePlayerColor(PlayerColor color)
    {
        //change the actual player material according to the new color
    }

    [Client]
    public void TriggerPlayerColorChange(PlayerColor color)
    {
        CmdTriggerPlayerColorChange(color);
    }

    [Command]
    public void CmdTriggerPlayerColorChange(PlayerColor color)
    {
        LobbyManager.instance.SetPlayerColor(this, color);
    }
}
