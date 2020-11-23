using UnityEngine;

public class ThrowableObject : MonoBehaviour
{

    EquippableObject equippableObject;

    public void Start()
    {
        equippableObject = GetComponent<EquippableObject>();
    }

    public void Take()
    {
        //TODO attach the gameobject to player hand
        GameManager.instance.localPlayer.Take(equippableObject);
    }

    public void Throw()
    {
        //TODO get action joystick direction and throw
        Vector3 direction = Action.instance.GetJoystickDirection();
    }
}
