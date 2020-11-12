using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomizer : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player.isLocalPlayer)
            {
                LobbyManager.instance.ShowCustomizeSettingsButton();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player.isLocalPlayer)
            {
                LobbyManager.instance.HideCustomizeSettingsButton();
            }
        }
    }
}
