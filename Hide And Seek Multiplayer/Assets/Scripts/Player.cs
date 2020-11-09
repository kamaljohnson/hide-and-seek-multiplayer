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
    public GameObject _camera;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!isLocalPlayer)
        {
            _camera.SetActive(false);
        } 
        else
        {
            GameManager.instance.localPlayer = this;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collision>().collider);
        }
    }
}
