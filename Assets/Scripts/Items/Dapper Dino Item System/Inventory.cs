using DapperDino.Events.CustomEvents;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Items/Inventory")]
public class Inventory : ScriptableObject, IItemContainer
{
    [SerializeField] private VoidEvent onInventoryItemsUpdated = null;

    public ItemSlot GetSlotByIndex(int index) => itemSlots[index];

    private ItemSlot[] itemSlots = new ItemSlot[0];

    public void SetSize(int size) => itemSlots = new ItemSlot[size];

    public ItemSlot AddItem(ItemSlot itemSlot)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item != null)
            {
                if (itemSlots[i].item == itemSlot.item)
                {
                    int slotSpace = itemSlots[i].item.MaxStack - itemSlots[i].quantity;

                    if (itemSlot.quantity <= slotSpace)
                    {
                        itemSlots[i].quantity += itemSlot.quantity;

                        itemSlot.quantity = 0;

                        onInventoryItemsUpdated.Raise();

                        return itemSlot;
                    }
                    else if (slotSpace > 0)
                    {
                        itemSlots[i].quantity += slotSpace;

                        itemSlot.quantity -= slotSpace;
                    }
                }
            }
        }

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
            {
                if (itemSlot.quantity <= itemSlot.item.MaxStack)
                {
                    itemSlots[i] = itemSlot;

                    itemSlot.quantity = 0;

                    onInventoryItemsUpdated.Raise();

                    return itemSlot;
                }
                else
                {
                    itemSlots[i] = new ItemSlot(itemSlot.item, itemSlot.item.MaxStack);

                    itemSlot.quantity -= itemSlot.item.MaxStack;
                }
            }
        }

        onInventoryItemsUpdated.Raise();

        return itemSlot;
    }

    public int GetTotalQuantity(InventoryItem item)
    {
        int totalCount = 0;

        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (itemSlot.item == null) { continue; }
            if (itemSlot.item != item) { continue; }

            totalCount += itemSlot.quantity;
        }

        return totalCount;
    }

    public GameObject GetWorldItem(int slotIndex)
    {
        return itemSlots[slotIndex].item.WorldPrefab;
    }

    public bool HasItem(InventoryItem item)
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (itemSlot.item == null) { continue; }
            if (itemSlot.item != item) { continue; }

            return true;
        }

        return false;
    }

    public void RemoveAt(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex > itemSlots.Length - 1) { return; }

        ClearSlot(slotIndex);

        onInventoryItemsUpdated.Raise();
    }

    public void RemoveItem(ItemSlot itemSlot)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item = itemSlot.item)
            {
                if (itemSlots[i].quantity < itemSlot.quantity)
                {
                    itemSlot.quantity -= itemSlots[i].quantity;

                    ClearSlot(i);
                }

                else
                {
                    itemSlots[i].quantity -= itemSlot.quantity;

                    if (itemSlots[i].quantity == 0)
                    {
                        ClearSlot(i);

                        onInventoryItemsUpdated.Raise();

                        return;
                    }
                }
            }
        }
    }

    void ClearSlot(int i)
    {
        itemSlots[i] = new ItemSlot();
    }

    public void Swap(int indexOne, int indexTwo)
    {
        ItemSlot firstSlot = itemSlots[indexOne];
        ItemSlot secondSlot = itemSlots[indexTwo];

        if (firstSlot == secondSlot) { return; }

        if (secondSlot.item != null)
        {
            if (firstSlot.item == secondSlot.item)
            {
                int secondSlotSpace = secondSlot.item.MaxStack - secondSlot.quantity;

                if (firstSlot.quantity <= secondSlotSpace)
                {
                    itemSlots[indexTwo].quantity += firstSlot.quantity;

                    ClearSlot(indexOne);

                    onInventoryItemsUpdated.Raise();

                    return;
                }
            }
        }

        itemSlots[indexOne] = secondSlot;
        itemSlots[indexTwo] = firstSlot;

        onInventoryItemsUpdated.Raise();
    }
}
