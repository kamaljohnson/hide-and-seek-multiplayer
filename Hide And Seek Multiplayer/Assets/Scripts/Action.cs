using UnityEngine;

public class Action : MonoBehaviour
{
    bool isActive;  //if the action is attached to an actionanable object.
    public ActionObject actionObject;

    public ActionObject actionObjectNear;
    public bool isActionObjectNear;

    public GameObject ActionAttachButton;
    public GameObject ActionDoButton;
    public GameObject ActionJoystick;

    public static Action instance;

    public void Start()
    {
        instance = this;
    }

    public void OnActionButtonPress()
    {
        if (isActive)
        {
            DoAction();
        } else
        {
            AttachAction();
        }
    }

    private void AttachAction()
    {
        actionObject = actionObjectNear.Attach();
        isActive = true;
        
        ActionAttachButton.SetActive(false);
        
        switch (actionObject.actionInputType)
        {
            case ActionInputType.Button:
                ActionDoButton.SetActive(true);
                break;
            case ActionInputType.Joystick:
                ActionJoystick.SetActive(true);
                break;
        }
    }

    private void DoAction()
    {
        actionObject.DoAction();
        isActive = false;

        ActionAttachButton.SetActive(true);
        ActionDoButton.SetActive(false);
        ActionJoystick.SetActive(false);
    }

    public Vector3 GetJoystickDirection()
    {
        //TODO return the joystick input vector
        return Vector3.zero;
    }

    public void SetNearActionObject(ActionObject obj)
    {
        actionObjectNear = obj;
    }

    public void SetActionObjectNear(bool isNear)
    {
        isActionObjectNear = isNear;
        if (!isActive)
        {
            ActionAttachButton.SetActive(isNear);
        }

    }
}
