using UnityEngine;
using UnityEngine.UI;

public class HiderColorReportButton : MonoBehaviour
{
    public PlayerColor color;
    Image bgColor;
    
    public PlayerColor GetColor()
    {
        return color;
    }

    public void SetColor(PlayerColor color)
    {
        bgColor = GetComponent<Image>();

        this.color = color;
        switch (color)
        {
            case PlayerColor.Black:
                bgColor.color = Color.black;
                break;
            case PlayerColor.White:
                bgColor.color = Color.white;
                break;
            case PlayerColor.Orange:
                bgColor.color = new Color32(255, 166, 0, 255);
                break;
            case PlayerColor.Green:
                bgColor.color = Color.green;
                break;
            case PlayerColor.Cyan:
                bgColor.color = Color.cyan;
                break;
            case PlayerColor.DarkGreen:
                bgColor.color = new Color32(23, 115, 52, 255);
                break;
            case PlayerColor.Purple:
                bgColor.color = new Color32(102, 22, 222, 255);
                break;
            case PlayerColor.Brown:
                bgColor.color = new Color32(179, 111, 4, 255);
                break;
            case PlayerColor.Pink:
                bgColor.color = new Color32(255, 0, 221, 255);
                break;
            case PlayerColor.Red:
                bgColor.color = Color.red;
                break;
        }
    }
}
