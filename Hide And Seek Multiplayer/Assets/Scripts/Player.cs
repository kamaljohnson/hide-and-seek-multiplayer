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

    [SyncVar(hook = nameof(OnChngeFrez))]
    public bool isFrozen;

    public GameObject freezBlock;

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

    [Client]
    public void Throw(EquippableObject obj, Vector3 directionVector)
    {
        CmdDrop();
        CmdThrow(obj.type, handTransform.position, directionVector);
    }

    [Command]
    public void CmdThrow(EquippableObjectType type, Vector3 initialPosition, Vector3 directionVector)
    {
        GameObject _obj = Instantiate(EquippableObjectCollection.instance.GetPrefab(type), handTransform.position, Quaternion.identity);
        NetworkServer.Spawn(_obj);
        var _objRb = _obj.GetComponent<Rigidbody>();
        _objRb.AddForce(_objRb.mass * 600 * (directionVector + new Vector3(0, 0.3f, 0)));
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
        if (!isLocalPlayer) return;
        if(other.tag == "ActionObject")
        {
            if (!other.GetComponent<ActionObject>().isAttached)
            {
                Action.instance.SetActionObjectNear(true);
                Action.instance.SetNearActionObject(other.gameObject.GetComponent<ActionObject>());
            }
        }
    }

    [Command]
    public void CmdDrop()
    {
        equppedObjectType = EquippableObjectType.None;
    }

    [Client]
    private void OnTriggerExit(Collider other)
    {
        if (!isLocalPlayer) return;
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
            if (isLocalPlayer)
            {
                Action.instance.AttachActionObject(obj.GetComponent<ActionObject>());

            }
            obj.GetComponent<ActionObject>().isAttached = true;
            obj.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    [Client]
    public void FreezPlayerWithColor(PlayerColor color)
    {
        CmdFreezPlayerWithColor(color);
    }

    [Client]
    public void FreezSelf()
    {
        CmdFreezPlayerWithColor(color);
    }

    [Command]
    public void CmdFreezPlayerWithColor(PlayerColor color)
    {
        GameManager.instance.FreezPlayerWithColor(color);
    }
    
    [Server]
    public void Freez()
    {
        isFrozen = true;
    }

    void OnChngeFrez(bool oldIsFreez, bool newIsFreez)
    {
        if (newIsFreez)
        {
            GetFrozen();
        }
    }

    void GetFrozen()
    {
        GetComponent<Movement>().canMove = false;
        freezBlock.SetActive(true);
        //start a timer and re-spawn and unFreez player
    }
}
