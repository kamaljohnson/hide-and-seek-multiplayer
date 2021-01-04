using Mirror;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator anim;
    public NetworkAnimator networkAnim;
    
    public void Walk()
    {
        anim.SetTrigger("Walk");
        networkAnim.SetTrigger("Walk");
    }

    public void Idle()
    {
        anim.SetTrigger("Idle");
        networkAnim.SetTrigger("Idle");
    }
}
