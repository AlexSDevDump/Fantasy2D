using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public bool isAttacking = false;

    public void Attack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            GetComponentInChildren<CharacterAnims>().AttackingAnim();
        }
    }

    public void AttackEnded()
    {
        isAttacking = false;
    }
}
