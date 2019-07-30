using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Interaction interaction = null;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Interact")
        {
            interaction = coll.GetComponent<Interaction>();
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        interaction = null;
    }

    public void CallInteraction()
    {
        if(interaction != null)
        {
            interaction.InteractWithObject();
        }
        else
        {
            Debug.Log("No object in range");
        }
    }
}
