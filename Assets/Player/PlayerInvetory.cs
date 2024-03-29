using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInvetory : MonoBehaviour
{
    private InventoryView _inventoryView;
    
    public List<Sprite> headItems;
    public List<Sprite> upperItems;
    public List<Sprite> lowerItems;
    public List<Sprite> feetItems;

    [SerializeField] private SpriteRenderer headSlot;
    [SerializeField] private SpriteRenderer upperSlot;
    [SerializeField] private SpriteRenderer lowerSlot;
    [SerializeField] private SpriteRenderer feetSlot;

    public int money = 1000;

    private void Awake()
    {
        _inventoryView = FindObjectOfType<InventoryView>();
        
        if (headItems.Count > 0) headSlot.sprite = headItems[0];
        if (upperItems.Count > 0) upperSlot.sprite = upperItems[0];
        if (lowerItems.Count > 0) lowerSlot.sprite = lowerItems[0];
        if (feetItems.Count > 0) feetSlot.sprite = feetItems[0];
        
    }

    private void OnInventory(InputValue inputValue)
    {
        if (!_inventoryView.IsInventoryOpen())
        {
            var inventoryData = new InventoryView.InventoryViewData()
            {
                HeadItems = headItems,
                UpperItems = upperItems,
                LowerItems = lowerItems,
                FeetItems = feetItems,
                HeadEquippedId = headSlot.sprite.name,
                UpperEquippedId = upperSlot.sprite.name,
                LowerEquippedId = lowerSlot.sprite.name,
                FeetEquippedId = feetSlot.sprite.name,
                EquipHead = EquipHead,
                EquipUpper = EquipUpper,
                EquipLower = EquipLower,
                EquipFeet = EquipFeet,
                Money = money
            };

            _inventoryView.OpenInventory(inventoryData);
        }
        else
        {
            _inventoryView.CloseInventory();
        }
    }

    private void EquipHead(int index)
    {
        headSlot.sprite = headItems[index];
        _inventoryView.UpdateEquippedHead(headSlot.sprite.name);
    }

    private void EquipUpper(int index)
    {
        upperSlot.sprite = upperItems[index];
        _inventoryView.UpdateEquippedUpper(upperSlot.sprite.name);
    }

    private void EquipLower(int index)
    {
        lowerSlot.sprite = lowerItems[index];
        _inventoryView.UpdateEquippedLower(lowerSlot.sprite.name);
    }

    private void EquipFeet(int index)
    {
        feetSlot.sprite = feetItems[index];
        _inventoryView.UpdateEquippedFeet(feetSlot.sprite.name);
    }

    public string GetHeadEquipped()
    {
        return headSlot.sprite.name;
    }
    public string GetUpperEquipped()
    {
        return upperSlot.sprite.name;
    }
    public string GetLowerEquipped()
    {
        return lowerSlot.sprite.name;
    }
    public string GetFeetEquipped()
    {
        return feetSlot.sprite.name;
    }

    public void AddHeadItem(Sprite item)
    {
        headItems.Add(item);
    }
    
    public void AddUpperItem(Sprite item)
    {
        upperItems.Add(item);
    }
    
    public void AddLowerItem(Sprite item)
    {
        lowerItems.Add(item);
    }
    
    public void AddFeetItem(Sprite item)
    {
        feetItems.Add(item);
    }
}
