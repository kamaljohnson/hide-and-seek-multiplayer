using System.Collections.Generic;
using UnityEngine;

public class HiderScanner : MonoBehaviour
{
    public List<Player> allHiders;
    
    private Dictionary<Player, float> visibleHidersDict;
    public List<Player> visibleHiders;

    public float delayWindow;   //the offset time period of the reportable window for a hider after the hider was visible to the seeker

    public bool canScan;

    public void Update()
    {
        if (canScan)
        {
            Scan();
        }
    }

    public void InitAllHiders(List<Player> hiders)
    {
        allHiders = hiders;
        canScan = true;
        visibleHidersDict = new Dictionary<Player, float>();
    }

    public void Scan()
    {
        foreach(Player hider in allHiders)
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
        return GetVisibleHiders().Contains(allHiders.Find(x => x.color == color));
    }

    public List<Player> GetVisibleHiders()
    {
        return new List<Player>(visibleHidersDict.Keys);
    }
}
