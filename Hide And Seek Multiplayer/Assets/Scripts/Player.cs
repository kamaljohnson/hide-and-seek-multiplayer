using Mirror;
using UnityEngine;

public enum PlayerType
{
    Seeker,
    Hider
}

public class Player : NetworkBehaviour
{

    public PlayerType type;
    public GameObject camera;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!isLocalPlayer)
        {
            camera.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
