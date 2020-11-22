using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskableObject : MonoBehaviour
{
    public bool isAlwaysVisible = false;

    [HideInInspector]
    public bool isVisible = false;
    
    public float visiblityPeriod = 0.1f;
    
    Renderer renderer;
    float visibilityTimer;

    bool visibilitySwitchFlag = false;

    public void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        if (isAlwaysVisible)
        {
            if (!visibilitySwitchFlag)
            {
                renderer.enabled = true;
            }
            visibilitySwitchFlag = true;

            return;
        } else
        {
            if(visibilitySwitchFlag)
            {
                isVisible = true;
            }

            visibilitySwitchFlag = false;
        }

        if (isVisible)
        {
            visibilityTimer -= Time.deltaTime;
        }

        if(visibilityTimer <= 0 && isVisible)
        {
            isVisible = false;
            renderer.enabled = false;
        }
    }

    public void setAsVisible()
    {
        if (isAlwaysVisible) return;
        if (!isVisible)
        {
            isVisible = true;
            renderer.enabled = true;
        }

        visibilityTimer = visiblityPeriod;
    }
}
