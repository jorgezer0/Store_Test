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

    private InventoryViewData inventoryViewData;
    
    public class InventoryViewData
    {
        public int Money;
        
        public List<Sprite> HeadItems;
        public List<Sprite> UpperItems;
        public List<Sprite> LowerItems;
        public List<Sprite> FeetItems;

        public string HeadEquippedId;
        public string UpperEquippedId;
        public string LowerEquippedId;
        public string FeetEquippedId;

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
        inventoryViewData = viewData;
        moneyField.text = inventoryViewData.Money.ToString();
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

    private void ShowHeadItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < inventoryViewData.HeadItems.Count; i++)
        {
            itemViews[i].SetItemImage(inventoryViewData.HeadItems[i], inventoryViewData.EquipHead, i);
            itemViews[i].ToggleEquipped(inventoryViewData.HeadItems[i].name == inventoryViewData.HeadEquippedId);
        }
    }

    public void UpdateEquippedHead(string id)
    {
        inventoryViewData.HeadEquippedId = id;
        for (var i = 0; i < inventoryViewData.HeadItems.Count; i++)
        {
            itemViews[i].ToggleEquipped(inventoryViewData.HeadItems[i].name == inventoryViewData.HeadEquippedId);
        }
    }

    private void ShowUpperItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < inventoryViewData.UpperItems.Count; i++)
        {
            itemViews[i].SetItemImage(inventoryViewData.UpperItems[i], inventoryViewData.EquipUpper, i);
            itemViews[i].ToggleEquipped(inventoryViewData.UpperItems[i].name == inventoryViewData.UpperEquippedId);
        }
    }
    
    public void UpdateEquippedUpper(string id)
    {
        inventoryViewData.UpperEquippedId = id;
        for (var i = 0; i < inventoryViewData.UpperItems.Count; i++)
        {
            itemViews[i].ToggleEquipped(inventoryViewData.UpperItems[i].name == inventoryViewData.UpperEquippedId);
        }
    }

    private void ShowLowerItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < inventoryViewData.LowerItems.Count; i++)
        {
            itemViews[i].SetItemImage(inventoryViewData.LowerItems[i], inventoryViewData.EquipLower, i);
            itemViews[i].ToggleEquipped(inventoryViewData.LowerItems[i].name == inventoryViewData.LowerEquippedId);
        }
    }
    
    public void UpdateEquippedLower(string id)
    {
        inventoryViewData.LowerEquippedId = id;
        for (var i = 0; i < inventoryViewData.LowerItems.Count; i++)
        {
            itemViews[i].ToggleEquipped(inventoryViewData.LowerItems[i].name == inventoryViewData.LowerEquippedId);
        }
    }

    private void ShowFeetItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < inventoryViewData.FeetItems.Count; i++)
        {
            itemViews[i].SetItemImage(inventoryViewData.FeetItems[i], inventoryViewData.EquipFeet, i);
            itemViews[i].ToggleEquipped(inventoryViewData.FeetItems[i].name == inventoryViewData.FeetEquippedId);
        }
    }

    public void UpdateEquippedFeet(string id)
    {
        inventoryViewData.FeetEquippedId = id;
        for (var i = 0; i < inventoryViewData.FeetItems.Count; i++)
        {
            itemViews[i].ToggleEquipped(inventoryViewData.FeetItems[i].name == inventoryViewData.FeetEquippedId);
        }
    }
}
