﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ActionInputType {
    Button,
    Joystick
}

public class ActionObject : MonoBehaviour
{
    public ActionInputType actionInputType;

    [Serializable]
    public class OnActionInvoke : UnityEvent { }

    [SerializeField]
    private OnActionInvoke onAttach = new OnActionInvoke();
    public OnActionInvoke attachEvent { get { return actions; } set { actions = value; } }

    [SerializeField]
    private OnActionInvoke actions = new OnActionInvoke();
    public OnActionInvoke actionEvent { get { return actions; } set { actions = value; } }

    public void DoAction()
    {
        actions.Invoke();
    }

    public ActionObject Attach()
    {
        onAttach.Invoke();
        return this;
    }
}