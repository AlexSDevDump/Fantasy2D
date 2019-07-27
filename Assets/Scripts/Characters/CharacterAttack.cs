using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public void Attack()
    {
        GunController gun = GetComponentInChildren<GunController>();
        if (gun != null)
        {
            gun.Fire();
        }
    }
}
