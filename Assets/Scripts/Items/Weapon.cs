using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : ScriptableObject
{
    public int weaponDamage;
    public float weaponDamageRadius;
    public Vector2 weaponDamagePos;
    public Sprite weaponSprite;
}
