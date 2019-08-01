using UnityEngine;

public class HumanAnims : BaseAnims
{
    public override void WalkingAnim(bool value)
    {
        anim.SetBool("isWalking", value);
    }

    public override void AttackingAnim(bool value)
    {
        anim.SetBool("isAttacking", value);
    }

    public override void AttackEvent()
    {
        GetComponentInParent<MeleeAttack>().CheckForEnemies();
    }

    public override void AttackingEnd()
    {
        anim.SetBool("isAttacking", false);
        GetComponentInParent<CharacterAttack>().AttackEnded();
    }

    public override void DeathAnim()
    {
        anim.SetBool("isDeath", true);
    }

    public override void HitAnim(bool value)
    {
        anim.SetBool("isHit", value);
    }

    public override void HitEnd()
    {
        anim.SetBool("isHit", false);
    }
}
