using Mirror;
using System;
using UnityEngine;
using UnityEngine.Events;

public enum ActionInputType {
    Button,
    Joystick
}

public class ActionObject : NetworkBehaviour
{
    public ActionInputType actionInputType;
    [SyncVar] public bool isAttached;

    [Serializable]
    public class OnActionInvoke : UnityEvent { }

    [SerializeField]
    private OnActionInvoke onAttach = new OnActionInvoke();
    public OnActionInvoke attachEvent { get { return onAction; } set { onAction = value; } }

    [SerializeField]
    private OnActionInvoke onAction = new OnActionInvoke();
    public OnActionInvoke actionEvent { get { return onAction; } set { onAction = value; } }

    public void DoAction()
    {
        Debug.Log("DoAction from ActionObject");
        onAction.Invoke();
    }

    public ActionObject Attach()
    {
        onAttach.Invoke();
        isAttached = true;
        return this;
    }
}
