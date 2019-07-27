using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemRemoveFromInventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory = null;
    [SerializeField] private TextMeshProUGUI areYouSureText = null;
    [SerializeField] private Vector3 dropPos;
    [SerializeField] private float dropRadius = 5;

    private int slotIndex = 0;

    private void OnDisable() => slotIndex = -1;

    public void Activate(ItemSlot itemSlot, int slotIndex, Vector3 pos)
    {
        dropPos = pos;

        this.slotIndex = slotIndex;

        areYouSureText.text = $"Are you sure you wish to destroy {itemSlot.quantity} x {itemSlot.item.ColouredName}?";

        gameObject.SetActive(true);
    }

    public void RemoveFromInventory()
    {
        Vector3 playerPos = FindObjectOfType<PlayerController>().gameObject.transform.position;
        float distance = Vector3.Distance(dropPos, playerPos);

        if(distance > dropRadius)
        {
            Vector3 fromOriginToObject = dropPos - playerPos;
            fromOriginToObject *= dropRadius / distance;
            dropPos = playerPos + fromOriginToObject;
        }

        Instantiate(inventory.ItemContainer.GetWorldItem(slotIndex), dropPos, Quaternion.identity);

        inventory.ItemContainer.RemoveAt(slotIndex);

        gameObject.SetActive(false);
    }
}
