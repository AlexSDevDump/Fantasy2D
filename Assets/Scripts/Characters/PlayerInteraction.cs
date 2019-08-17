using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Interaction interaction = null;
    [SerializeField] private List<Collider2D> interactionList = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D coll)
    {
        interactionList.Add(coll);
    }

    void Update()
    {
        if (interactionList.Count > 0)
            GetClosestInteraction();
        else
            interaction = null;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        interactionList.Remove(coll);
    }

    public void CallInteraction()
    {
        if (interaction != null) { interaction.InteractWithObject(transform.root.gameObject); }
        else { Debug.Log("No object in range"); }
    }

    private void GetClosestInteraction()
    {
        Collider2D closestInteract = null;
        if(interactionList.Count != 0)
        {
            foreach(Collider2D t in interactionList)
            {
                if (closestInteract == null) { closestInteract = t; }
                else
                {
                    float dist = Vector3.Distance(t.bounds.min, transform.position);
                    if(dist < Vector3.Distance(closestInteract.bounds.min, gameObject.GetComponent<Collider2D>().bounds.min))
                    {
                        closestInteract = t;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("INTERACTION LIST EMPTY");
        }

        interaction = closestInteract.GetComponent<Interaction>();
        if (interaction == null)
            Debug.LogError("INTERACTION COMPONENT MISSING");
    }
}
