using Mirror;
using UnityEngine;

public class Action : MonoBehaviour
{
    bool isActive;  //if the action is attached to an actionanable object.
    
    public ActionObject actionObject;
    [HideInInspector]
    public ActionObject actionObjectNear;
    [HideInInspector]
    public bool isActionObjectNear;

    public GameObject ActionAttachButton;
    public GameObject ActionDoButton;
    public GameObject ActionJoystick;

    public PlayerAction playerAction;
    [HideInInspector]
    public Vector2 actionJoystickInput;
    private Vector2 tempActionJoystickInput;
    private bool joystickReleased;
    public float joystickThreshold;

    public static Action instance;

    public void Awake()
    {
        playerAction = new PlayerAction();
        instance = this;
    }

    void OnEnable()
    {
        playerAction.Enable();
        playerAction.Main.ActionJoystickRelease.canceled += ctx => joystickReleased = true;

    }

    void OnDisable()
    {
        playerAction.Disable();
    }

    public void Update()
    {
        if (isActive)
        {
            switch (actionObject.actionInputType)
            {
                case ActionInputType.Button:
                    break;
                case ActionInputType.Joystick:
                    HandleActionJoystickInput();
                    break;
            }
        }
        joystickReleased = false;
    }

    public void HandleActionJoystickInput()
    {
        Vector2 input = playerAction.Main.ActionJoystick.ReadValue<Vector2>();
        if (input != Vector2.zero)
        {
            tempActionJoystickInput = input;
        }
        if (joystickReleased)
        {
            if (tempActionJoystickInput.magnitude > joystickThreshold)
            {
                actionJoystickInput = tempActionJoystickInput;
                DoAction();
            }
            tempActionJoystickInput = Vector2.zero;
        }
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
        actionObjectNear.Attach();
        ActionAttachButton.SetActive(false);
    }

    public void AttachActionObject(ActionObject actionObject)
    {
        isActive = true;
        this.actionObject = actionObject;
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
        isActive = false;
        actionObject.DoAction();

        ActionAttachButton.SetActive(true);
        ActionDoButton.SetActive(false);
        ActionJoystick.SetActive(false);
    }

    public Vector3 GetJoystickValue()
    {
        Vector3 joystickValue = actionJoystickInput;
        actionJoystickInput = Vector3.zero;
        return joystickValue;
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
