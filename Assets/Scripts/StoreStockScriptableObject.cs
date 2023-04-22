using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoreStockContainer", menuName = "ScriptableObjects/StoreStockScriptableObject")]
public class StoreStockScriptableObject : ScriptableObject
{
    [Serializable]
    public class SellableItem
    {
        public Sprite itemImage;
        public int price;
    }

    public List<SellableItem> availableHeadItems;
    public List<SellableItem> availableUpperItems;
    public List<SellableItem> availableLowerItems;
    public List<SellableItem> availableFeetItems;
}
