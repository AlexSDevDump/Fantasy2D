using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public Weapon weaponEquipped;
    public Weapon weaponToEquip;
    [SerializeField] private SpriteRenderer weaponRend;

    void Start()
    {
        Equip(weaponToEquip);
    }

    public void Equip(Weapon weapon)
    {
        GetComponent<MeleeAttack>().SetWeapon(weapon);
        weaponEquipped = weapon;
        weaponRend.sprite = weaponEquipped.weaponSprite;
    }
}
