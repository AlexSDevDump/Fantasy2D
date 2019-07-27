using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : Interaction
{
    public override void InteractWithObject()
    {
        OpenChest();
    }

    void OpenChest()
    {
        Debug.Log("Open Chest");
    }
}
