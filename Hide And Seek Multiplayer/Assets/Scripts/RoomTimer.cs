using Mirror;
using TMPro;
using UnityEngine;

public class RoomTimer : NetworkBehaviour
{
    public int hiderAllowedInRoomTime;
    [SyncVar] private float hiderAllowedInRoomTimer;

    public int coolDownTime;
    [SyncVar] private float coolDownTimer;

    public TMP_Text hiderAllowedInRoomTimerText;
    public TMP_Text coolDownTimerText;

    [SyncVar] public bool seekerInRoom;

    [SyncVar] public bool roomLocked;
    [SyncVar] public bool isCooledDown;

    void Start()
    {
        seekerInRoom = false;
        isCooledDown = true;
    }

    void Update()
    {
        bool cooldown = roomLocked || !seekerInRoom;

        if (isServer)
        {
            GameManager.instance.localPlayer.PrintToLocalPlayerFromServer("HERE");
            ServerUpdate(cooldown);
        }

        if (cooldown)
        {
            coolDownTimerText.text = ((int)coolDownTimer).ToString();
        }
        else
        {
            coolDownTimerText.gameObject.SetActive(false);
        }

        if (!isCooledDown)
        {
            coolDownTimerText.gameObject.SetActive(true);
        }

        if(coolDownTimer <= 0)
        {
            coolDownTimerText.gameObject.SetActive(false);
        }

        hiderAllowedInRoomTimerText.text = ((int)hiderAllowedInRoomTimer).ToString();

    }

    [Server]
    public void ServerUpdate(bool cooldown)
    {
        if (seekerInRoom)
        {
            isCooledDown = false;
            coolDownTimer = coolDownTime;
            if (!cooldown)
            {
                hiderAllowedInRoomTimer -= Time.deltaTime;
            }
            if (hiderAllowedInRoomTimer <= 0)
            {
                FreezSeekersInRoom();
                CloseRoomForSeekers();

                roomLocked = true;
            }
        }

        if (cooldown)
        {
            if (!isCooledDown)
            {
                coolDownTimer -= Time.deltaTime;
            }
            if (coolDownTimer <= 0)
            {
                OpenRoomForSeekers();

                roomLocked = false;
                coolDownTimer = coolDownTime;
                hiderAllowedInRoomTimer = hiderAllowedInRoomTime;
                isCooledDown = true;
            }
        }
    }

    [Server]
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.gameObject.GetComponent<Player>().type == PlayerType.Seeker)
            {
                seekerInRoom = true;
            }
        }
    }

    [Server]
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<Player>().type == PlayerType.Seeker)
            {
                seekerInRoom = false;
            }
        }
    }

    public void FreezSeekersInRoom()
    {

    }

    public void CloseRoomForSeekers()
    {

    }

    public void OpenRoomForSeekers()
    {

    }

}
