using System.Collections.Generic;
using UnityEngine;

public class Report : MonoBehaviour
{
    public GameObject hiderPanel;
    public GameObject reportButton;

    public Transform hiderPanelGrid;
    public GameObject hiderPanelObjPrefab;

    public static Report instance;
    public float coolDownTime;
    float coolDownTimer;

    public void Start()
    {
        coolDownTimer = coolDownTime;
        instance = this;
    }

    public void Update()
    {
        if (coolDownTimer >= 0)
        {
            coolDownTimer -= Time.deltaTime;
            if(reportButton.activeSelf)
            {
                DissableReportButton();
            }
            return;
        }
        if(!reportButton.activeSelf)
        {
            EnableReportButton();
        }
    }

    public void InitHiderPanel(List<Player> hiders)
    {
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

    public void ReportColor(PlayerColor color)
    {
        bool hiderVisible = HiderScanner.instance.CheckIfHiderIsVisible(color);
        if (hiderVisible)
        {
            Debug.Log("hider : " + color + " is visible and reported corectly");
            GameManager.instance.localPlayer.FreezPlayerWithColor(color);
        } else
        {
            Debug.Log("hider : " + color + " is not visible and reported incorrectly corectly");
            GameManager.instance.localPlayer.FreezSelf();
        }
    }

    public void EnableReportButton()
    {
        reportButton.SetActive(true);
    }

    public void DissableReportButton()
    {
        reportButton.SetActive(false);
    }

}
