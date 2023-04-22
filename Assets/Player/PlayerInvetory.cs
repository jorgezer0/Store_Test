using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInvetory : MonoBehaviour
{
    private InventoryView _inventoryView;
    
    [SerializeField] private List<Sprite> headItems;
    [SerializeField] private List<Sprite> upperItems;
    [SerializeField] private List<Sprite> lowerItems;
    [SerializeField] private List<Sprite> feetItems;

    [SerializeField] private SpriteRenderer headSlot;
    [SerializeField] private SpriteRenderer upperSlot;
    [SerializeField] private SpriteRenderer lowerSlot;
    [SerializeField] private SpriteRenderer feetSlot;

    private void Start()
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
                headItems = headItems,
                upperItems = upperItems,
                lowerItems = lowerItems,
                feetItems = feetItems,
                headEquippedId = headSlot.sprite.name,
                upperEquippedId = upperSlot.sprite.name,
                lowerEquippedId = lowerSlot.sprite.name,
                feetEquippedId = feetSlot.sprite.name,
                EquipHead = EquipHead,
                EquipUpper = EquipUpper,
                EquipLower = EquipLower,
                EquipFeet = EquipFeet
            };

            _inventoryView.OpenInventory(inventoryData);
        }
        else
        {
            _inventoryView.CloseInventory();
        }
    }

    public void EquipHead(int index)
    {
        headSlot.sprite = headItems[index];
        _inventoryView.UpdateEquippedHead(headSlot.sprite.name);
    }
    
    public void EquipUpper(int index)
    {
        upperSlot.sprite = upperItems[index];
        _inventoryView.UpdateEquippedUpper(upperSlot.sprite.name);
    }
    
    public void EquipLower(int index)
    {
        lowerSlot.sprite = lowerItems[index];
        _inventoryView.UpdateEquippedLower(lowerSlot.sprite.name);
    }
    
    public void EquipFeet(int index)
    {
        feetSlot.sprite = feetItems[index];
        _inventoryView.UpdateEquippedFeet(feetSlot.sprite.name);
    }
}
