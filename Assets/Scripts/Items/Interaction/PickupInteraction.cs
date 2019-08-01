using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteraction : Interaction
{
    [SerializeField] private ItemSlot itemSlot;

    public override void InteractWithObject(GameObject interactor) => Pickup(interactor);

    void Pickup(GameObject interactor)
    {
        IItemContainer itemContainer = interactor.GetComponent<IItemContainer>();

        if (itemContainer == null) { return; }

        if (itemContainer.AddItem(itemSlot).quantity == 0) { GetComponentInParent<DestroySelf>().Destroy() ; }
    }
}
