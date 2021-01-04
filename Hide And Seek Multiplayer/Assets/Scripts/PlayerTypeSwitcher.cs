using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTypeSwitcher : MonoBehaviour
{

    public PlayerType zoneType;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player.isLocalPlayer)
            {
                player.ChangePlayerType(zoneType);
            }
        }
    }
}
