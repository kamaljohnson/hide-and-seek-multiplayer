using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public GameObject reportUi;
    public GameObject actionUi;

    public List<Player> hiders;

    public void DisableActionUi()
    {
        actionUi.SetActive(false);
    }

    public void EnableActionUi()
    {
        actionUi.SetActive(true);
    }

    public void InitReportUi(List<Player> hiders)
    {
        Debug.Log("List of hiders : " + hiders.ToString());
        this.hiders = hiders;
        reportUi.GetComponent<Report>().InitHiderPanel(this.hiders);
    }

    public void DisableReportUi()
    {
        reportUi.SetActive(false);
    }

    public void EnableReportUi()
    {
        reportUi.SetActive(true);
    }
}