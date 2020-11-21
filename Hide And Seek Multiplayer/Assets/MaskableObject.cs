using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskableObject : MonoBehaviour
{

    [HideInInspector]
    public bool isVisible = false;
    
    public float visiblityPeriod = 0.1f;
    
    Renderer renderer;
    float visibilityTimer;

    public void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
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
        if (!isVisible)
        {
            isVisible = true;
            renderer.enabled = true;
        }

        visibilityTimer = visiblityPeriod;
    }
}
