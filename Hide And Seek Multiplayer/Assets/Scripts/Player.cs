using Mirror;

public enum PlayerType
{
    Seeker,
    Hider
}

public class Player : NetworkBehaviour
{

    public PlayerType type;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}
