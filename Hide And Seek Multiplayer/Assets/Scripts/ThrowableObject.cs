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
        Vector2 directionVector2 = Action.instance.GetJoystickValue();
        Vector3 directionVector3 = new Vector3(directionVector2.x, 0, directionVector2.y);
        /*transform.parent = null;
        rigidbody.isKinematic = false;
        actionObject.isAttached = false;
        rigidbody.AddForce(directionVector3 * rigidbody.mass * throwAccelerationFactor);*/
        GameManager.instance.localPlayer.Throw(equippableObject, directionVector3);
    }
}
