using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteraction : Interaction
{
    public Transform hand;

    public override void InteractWithObject()
    {
        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Pickup Item");
        transform.root.SetParent(hand);
        transform.parent.localPosition = new Vector3(1.2f, 1.6f, 0);
        gameObject.SetActive(false);
    }
}
