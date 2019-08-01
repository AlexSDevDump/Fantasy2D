using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public LayerMask whatIsEnemies;
    public LayerMask whatIsFriendlies;
    [SerializeField] private Weapon weapon = null;
    [SerializeField] private Transform weaponHand;
    private Vector2 attackPos;
    private float attackRadius = 1f;
    [SerializeField] private bool friendlyFire = false;

    public void SetWeapon(Weapon weap) { weapon = weap; }

    public void CheckForEnemies()
    {
        LayerMask whatToHit;
        if(friendlyFire) { whatToHit = whatIsEnemies | whatIsFriendlies; }
        else { whatToHit = whatIsEnemies; }
        attackPos = (Vector2)weaponHand.position + weapon.weaponDamagePos;
        attackRadius = weapon.weaponDamageRadius;
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos, attackRadius, whatToHit);
        DamageEnemies(enemiesToDamage);
    }

    private void DamageEnemies(Collider2D[] enemies)
    {
        foreach(Collider2D e in enemies)
        {
            
            e.GetComponent<Health>().Damaged(weapon.weaponDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        attackPos = (Vector2)weaponHand.position;
        if (weapon != null)
        {
            attackPos += weapon.weaponDamagePos;
            attackRadius = weapon.weaponDamageRadius;
        }
        Gizmos.DrawWireSphere(attackPos, attackRadius);
    }
}
