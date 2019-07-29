using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnims : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void IdleAnim()
    {
        anim.SetBool("isWalking", false);
    }

    public void WalkingAnim()
    {
        anim.SetBool("isWalking", true);
    }

    public void AttackingAnim()
    {
        Debug.Log("Attack Anim");
        anim.SetBool("isAttacking", true);
    }

    public void AttackEvent()
    {
        GetComponent<MeleeAttack>().CheckForEnemies();
    }

    public void AttackingEnd(string message)
    {
        if(message.Equals("AttackAnimationEnded"))
        {
            Debug.Log("Attack Ended");
            anim.SetBool("isAttacking", false);
        }
        GetComponentInParent<CharacterAttack>().AttackEnded();
    }
}
