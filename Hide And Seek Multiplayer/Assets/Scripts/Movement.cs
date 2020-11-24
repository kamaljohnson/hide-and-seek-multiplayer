using Mirror;
using UnityEngine;

public class Movement : NetworkBehaviour
{
    public int speed;
    public PlayerAction playerAction;

    public void Awake()
    {
        playerAction = new PlayerAction();
    }

    void OnEnable()
    {
        playerAction.Enable();
    }

    void OnDisable()
    {
        playerAction.Disable();
    }

    void Update()
    {
        if(isLocalPlayer)
        {
            Vector2 input = playerAction.Main.Move.ReadValue<Vector2>();

            var inputX = input.x;
            var inputY = input.y;

            transform.position += new Vector3(inputX, 0, inputY) * Time.deltaTime * speed;
        }
    }
}
