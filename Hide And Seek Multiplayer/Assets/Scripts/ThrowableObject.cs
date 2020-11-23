using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public void Take()
    {
        //TODO attach the gameobject to player hand
        GameManager.instance.localPlayer.Take(gameObject);
    }

    public void Throw()
    {
        //TODO get action joystick direction and throw
        Vector3 direction = Action.instance.GetJoystickDirection();
    }
}
