using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    public float fullHealth, currentHealth;
    public bool invincible;

    //public UnityEvent healthDamaged, healthHealed;

    public List<HealthEvent> healthEvents;

    void Start()
    {
        ResetHealth();
    }

    public void Damaged(int dam)
    {
        currentHealth -= dam;
        CheckHealth();
    }

    public void Healed()
    {
        currentHealth++;
        CheckHealth();
    }

    public void ZeroHealth()
    {
        GetComponent<DestroySelf>().Destroy();
    }

    public void ResetHealth()
    {
        currentHealth = fullHealth;
    }

    public void Injured()
    {
        Debug.Log("OOF");
    }

    private void CheckHealth()
    {
        foreach (HealthEvent hpEvent in healthEvents)
        {
            if(hpEvent.healthPercent >= (currentHealth / fullHealth))
            {
                hpEvent.Event.Invoke();
            }
        }
    }
}
