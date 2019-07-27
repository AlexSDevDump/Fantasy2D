using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemDragHandler : ItemDragHandler
{
    [SerializeField] private ItemRemoveFromInventory itemRemoveFromInventory = null;

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            base.OnPointerUp(eventData);

            if (eventData.hovered.Count == 0)
            {
                InventorySlot thisSlot = itemSlotUI as InventorySlot;
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos = new Vector3(pos.x, pos.y, 0);
                itemRemoveFromInventory.Activate(thisSlot.ItemSlot, thisSlot.SlotIndex, pos);
            }
        }
    }
}
