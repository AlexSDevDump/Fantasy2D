using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Interaction interaction = null;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(interaction == null)
        {
            interaction = coll.GetComponent<Interaction>();
            if(interaction == null)
                Debug.LogError("INTERACTION COMPONENT MISSING");
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        interaction = null;
    }

    public void CallInteraction()
    {
        if (interaction != null) { interaction.InteractWithObject(transform.root.gameObject); }
        else { Debug.Log("No object in range"); }
    }
}
