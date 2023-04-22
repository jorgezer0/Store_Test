using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private TextMeshProUGUI moneyField;
    
    [SerializeField] private Button headButton;
    [SerializeField] private Button upperButton;
    [SerializeField] private Button lowerButton;
    [SerializeField] private Button feetButton;

    [SerializeField] private Transform contentPanel;

    private InventoryViewData _inventoryViewData;
    
    public class InventoryViewData
    {
        public int money;
        
        public List<Sprite> headItems;
        public List<Sprite> upperItems;
        public List<Sprite> lowerItems;
        public List<Sprite> feetItems;

        public string headEquippedId;
        public string upperEquippedId;
        public string lowerEquippedId;
        public string feetEquippedId;

        public UnityAction<int> EquipHead;
        public UnityAction<int> EquipUpper;
        public UnityAction<int> EquipLower;
        public UnityAction<int> EquipFeet;
    }

    [SerializeField] private ItemView[] itemViews;

    // Start is called before the first frame update
    void Start()
    {
        headButton.onClick.AddListener(ShowHeadItems);
        upperButton.onClick.AddListener(ShowUpperItems);
        lowerButton.onClick.AddListener(ShowLowerItems);
        feetButton.onClick.AddListener(ShowFeetItems);

        canvasGroup.alpha = 0;
    }

    public bool IsInventoryOpen()
    {
        return canvasGroup.alpha == 1;
    }
    
    public void OpenInventory(InventoryViewData viewData)
    {
        canvasGroup.alpha = 1;
        _inventoryViewData = viewData;
        moneyField.text = _inventoryViewData.money.ToString();
        ShowHeadItems();
    }
    
    public void CloseInventory()
    {
        canvasGroup.alpha = 0;
        ClearAllImages();
    }

    private void ClearAllImages()
    {
        foreach (var item in itemViews)
        {
            item.ClearItemImage();
        }
    }

    public void ShowHeadItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < _inventoryViewData.headItems.Count; i++)
        {
            itemViews[i].SetItemImage(_inventoryViewData.headItems[i], _inventoryViewData.EquipHead, i);
            itemViews[i].ToggleEquipped(_inventoryViewData.headItems[i].name == _inventoryViewData.headEquippedId);
        }
    }

    public void UpdateEquippedHead(string id)
    {
        _inventoryViewData.headEquippedId = id;
        for (var i = 0; i < _inventoryViewData.headItems.Count; i++)
        {
            itemViews[i].ToggleEquipped(_inventoryViewData.headItems[i].name == _inventoryViewData.headEquippedId);
        }
    }

    public void ShowUpperItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < _inventoryViewData.upperItems.Count; i++)
        {
            itemViews[i].SetItemImage(_inventoryViewData.upperItems[i], _inventoryViewData.EquipUpper, i);
            itemViews[i].ToggleEquipped(_inventoryViewData.upperItems[i].name == _inventoryViewData.upperEquippedId);
        }
    }
    
    public void UpdateEquippedUpper(string id)
    {
        _inventoryViewData.upperEquippedId = id;
        for (var i = 0; i < _inventoryViewData.upperItems.Count; i++)
        {
            itemViews[i].ToggleEquipped(_inventoryViewData.upperItems[i].name == _inventoryViewData.upperEquippedId);
        }
    }
    
    public void ShowLowerItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < _inventoryViewData.lowerItems.Count; i++)
        {
            itemViews[i].SetItemImage(_inventoryViewData.lowerItems[i], _inventoryViewData.EquipLower, i);
            itemViews[i].ToggleEquipped(_inventoryViewData.lowerItems[i].name == _inventoryViewData.lowerEquippedId);
        }
    }
    
    public void UpdateEquippedLower(string id)
    {
        _inventoryViewData.lowerEquippedId = id;
        for (var i = 0; i < _inventoryViewData.lowerItems.Count; i++)
        {
            itemViews[i].ToggleEquipped(_inventoryViewData.lowerItems[i].name == _inventoryViewData.lowerEquippedId);
        }
    }
    
    public void ShowFeetItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < _inventoryViewData.feetItems.Count; i++)
        {
            itemViews[i].SetItemImage(_inventoryViewData.feetItems[i], _inventoryViewData.EquipFeet, i);
            itemViews[i].ToggleEquipped(_inventoryViewData.feetItems[i].name == _inventoryViewData.feetEquippedId);
        }
    }

    public void UpdateEquippedFeet(string id)
    {
        _inventoryViewData.feetEquippedId = id;
        for (var i = 0; i < _inventoryViewData.feetItems.Count; i++)
        {
            itemViews[i].ToggleEquipped(_inventoryViewData.feetItems[i].name == _inventoryViewData.feetEquippedId);
        }
    }
}
