using System.Collections.Generic;
using UnityEngine;

public class HiderScanner : MonoBehaviour
{
    private Dictionary<Player, float> visibleHidersDict;
    public List<Player> visibleHiders;

    public float delayWindow;   //the offset time period of the reportable window for a hider after the hider was visible to the seeker

    public bool canScan;

    public static HiderScanner instance;

    public void Start()
    {
        instance = this;
    }

    public void Update()
    {
        if (canScan)
        {
            Scan();
        }
    }

    public void InitAllHiders(List<Player> hiders)
    {
        canScan = true;
        visibleHidersDict = new Dictionary<Player, float>();
    }

    public void Scan()
    {
        foreach(Player hider in GameManager.instance.GetHiders())
        {
            if (hider.transform.GetChild(0).GetComponent<Renderer>().isVisible)
            {
                visibleHidersDict[hider] = delayWindow;
                Debug.Log("hider: " + hider + " is visible, dictionary: " + visibleHidersDict.ToString());  
            }
        }

        List<Player> visibleHidersList = GetVisibleHiders();

        foreach (Player h in visibleHidersList)
        {
            var visibilityWindow = visibleHidersDict[h];
            var newVisibilityWindow = visibilityWindow - Time.deltaTime;
            visibleHidersDict[h] = newVisibilityWindow;

            if(newVisibilityWindow <= 0)
            {
                visibleHidersDict.Remove(h);
            }
        }

        visibleHiders = GetVisibleHiders();
    }

    public bool CheckIfHiderIsVisible(PlayerColor color)
    {
        return GetVisibleHiders().Contains(GameManager.instance.GetHiders().Find(x => x.color == color));
    }

    public List<Player> GetVisibleHiders()
    {
        return new List<Player>(visibleHidersDict.Keys);
    }
}
