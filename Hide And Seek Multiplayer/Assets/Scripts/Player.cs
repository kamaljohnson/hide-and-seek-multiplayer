using Mirror;
using System.Collections;
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

    public GameObject body;
    public FieldOfView fov;
    public GameObject fovObject;

    public Transform handTransform;

    [SyncVar(hook = nameof(OnChangeEquipment))]
    public EquippableObjectType equppedObjectType;

    public override string ToString()
    {
        return "type : " + type.ToString() + ", color: " + color.ToString();
    }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!isLocalPlayer)
        {
            _camera.SetActive(false);
            InitPlayerColor();
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

    [Client]
    public void ChangePlayerType(PlayerType type)
    {
        CmdChangePlayerType(type);
    }

    [Command]
    public void CmdChangePlayerType(PlayerType type)
    {
        ClientChangePlayerType(type);
    }

    [ClientRpc]
    public void ClientChangePlayerType(PlayerType type)
    {
        this.type = type;
    }

    [Client]
    public void SetupFovPlayerMasking()
    {
        CmdSetupFovPlayerMasking();
    }

    [Command]
    public void CmdSetupFovPlayerMasking()
    {
        ClientSetupFovPlayerMasking();
    }

    [ClientRpc]
    public void ClientSetupFovPlayerMasking()
    {
        if (type == GameManager.instance.localPlayer.type)
        {
            fovObject.SetActive(true);
            body.GetComponent<MaskableObject>().isAlwaysVisible = true;
        } else
        {
            body.GetComponent<MaskableObject>().isAlwaysVisible = false;
        }
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
        body.GetComponent<Renderer>().material = LobbyManager.instance.playerColorMaterials[(int)color];
    }

    [Client]
    public void InitPlayerColor()
    {
        body.GetComponent<Renderer>().material = LobbyManager.instance.playerColorMaterials[(int) color];
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

    [Client]
    public void Take(EquippableObject obj)
    {
        CmdTake(obj.type);
        CmdDestroyEquippableObject(obj.gameObject);
    }

    [Command]
    public void CmdDestroyEquippableObject(GameObject obj)
    {
        NetworkServer.Destroy(obj.gameObject);
    }

    [Command]
    public void CmdTake(EquippableObjectType type)
    {
        equppedObjectType = type;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ActionObject")
        {
            Action.instance.SetActionObjectNear(true);
            Action.instance.SetNearActionObject(other.gameObject.GetComponent<ActionObject>());
        }
    }

    [Client]
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ActionObject")
        {
            Action.instance.SetActionObjectNear(false);
        }
    }

    void OnChangeEquipment(EquippableObjectType oldEquippedItem, EquippableObjectType newEquippedItem)
    {
        ChangeEquipment(newEquippedItem);
    }

    void ChangeEquipment(EquippableObjectType newEquippedItem)
    {
        if(newEquippedItem == EquippableObjectType.None)
        {
            if (handTransform.childCount > 0)
            {
                Destroy(handTransform.GetChild(0).gameObject);
            }
        } else
        {
            GameObject obj = Instantiate(EquippableObjectCollection.instance.GetPrefab(newEquippedItem), handTransform);
            obj.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
