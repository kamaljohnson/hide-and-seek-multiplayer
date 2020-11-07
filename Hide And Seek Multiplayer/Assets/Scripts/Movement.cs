using Mirror;
using UnityEngine;

public class Movement : NetworkBehaviour
{

    public int speed;

    void Update()
    {
        if(isLocalPlayer)
        {
            var inputX = Input.GetAxis("Horizontal");
            var inputY = Input.GetAxis("Vertical");
            transform.position += new Vector3(inputX, 0, inputY) * Time.deltaTime * speed;
        }
    }
}
