using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private bool isAttacking = false;

    public void Attack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            GetComponentInChildren<BaseAnims>().AttackingAnim(true);
        }
    }

    public void AttackEnded()
    {
        isAttacking = false;
    }
}
