using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItem : Item
{
    [Header("Item data")]
    //[SerializeField] private Rarity
    [SerializeField] [Min(0)] private int sellPrice = 1;
    [SerializeField][Min(1)] private int maxStack = 1;
    [SerializeField] private GameObject worldPrefab;

    public override string ColouredName
    {
        get
        {
            return Name;
        }
    }
    public int SellPrice => sellPrice;
    public int MaxStack => maxStack;
    public GameObject WorldPrefab => worldPrefab;


}
