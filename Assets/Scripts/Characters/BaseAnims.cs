using UnityEngine;

public class BaseAnims : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void WalkingAnim(bool value)
    {
        anim.SetBool("isWalking", value);
    }

    public virtual void AttackingAnim(bool value)
    {
        anim.SetBool("isAttacking", value);
    }

    public virtual void AttackEvent()
    {
        GetComponentInParent<MeleeAttack>().CheckForEnemies();
    }

    public virtual void AttackingEnd()
    {
        anim.SetBool("isAttacking", false);
        GetComponentInParent<CharacterAttack>().AttackEnded();
    }

    public virtual void DeathAnim()
    {
        anim.SetBool("isDeath", true);
    }

    public virtual void HitAnim(bool value)
    {
        anim.SetBool("isHit", value);
    }

    public virtual void HitEnd()
    {
        anim.SetBool("isHit", false);
    }
}
