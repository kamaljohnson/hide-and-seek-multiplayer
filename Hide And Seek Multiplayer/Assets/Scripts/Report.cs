using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : MonoBehaviour
{

    public GameObject hiderPanel;
    public GameObject reportButton;

    public Transform hiderPanelGrid;
    public GameObject hiderPanelObjPrefab;

    public void InitHiderPanel(List<Player> hiders)
    {
        Debug.Log("Here");
        foreach (Player hider in hiders)
        {
            Debug.Log("hider: " + hider.ToString());
            GameObject hiderPanelObj = Instantiate(hiderPanelObjPrefab, hiderPanelGrid);
            hiderPanelObj.GetComponent<HiderColorReportButton>().SetColor(hider.color);
        }
    }

    public void ShowHiderPanel()
    {
        hiderPanel.SetActive(true);
        reportButton.SetActive(false);
    }

    public void HideHiderPanel()
    {
        hiderPanel.SetActive(false);
        reportButton.SetActive(true);
    }



}
