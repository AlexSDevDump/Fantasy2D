using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : WeaponController
{
    public GunObject gunEquipped;
    public BulletController bullet;
    public int maxCapacity, currentCapacity;
    public float rateOfFire, reloadTime;
    private float fireCountdown;
    public bool isReloading, isEmpty;

    void Start()
    {
        maxCapacity = gunEquipped.maxCapacity;
        currentCapacity = maxCapacity;
        rateOfFire = gunEquipped.rateOfFire;
        reloadTime = gunEquipped.reloadTime;

        fireCountdown = rateOfFire;
    }

    void Update()
    {

        if (fireCountdown > 0)
        {
            fireCountdown -= Time.deltaTime;
            return;
        }

        isReady = true;
    }

    public void Fire()
    {
        if (!isReloading)
        {
            if (!isEmpty)
            {
                if(isReady)
                {
                    BulletController clone = Instantiate(bullet, transform.position, transform.rotation);
                    GameObject owner = this.transform.root.gameObject;
                    clone.Setup(owner, damage);
                    clone.destroyTimer = 5f;

                    fireCountdown = rateOfFire;
                    isReady = false;

                    currentCapacity--;

                    if (currentCapacity <= 0)
                        isEmpty = true;
                }
            }
            else
                Reload();
        }
    }

    public void SecondaryFire()
    {
        Debug.Log("SecondaryFire Not Implemented");
    }

    public void Reload()
    {
        isReloading = true;
        StartCoroutine("ReloadTime");
    }

    private IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(reloadTime);
        currentCapacity = maxCapacity;
        isReloading = false;
        isEmpty = false;
    }
}
