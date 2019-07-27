using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float velocity;
    public int damage;
    public float destroyTimer;
    public GameObject owner;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * velocity;
        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject != owner)
        {
            Debug.Log("Hit " + coll.gameObject);
            Health hp = coll.GetComponent<Health>();
            if(hp != null)
            {
                hp.Damaged(damage);
            }
            Destroy(gameObject);
            return;
        }
    }

    public void Setup(GameObject _owner, int dam)
    {
        owner = _owner;
        damage = dam;
    }
}
