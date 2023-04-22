using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private GameObject storeItemView;
    [SerializeField] private Transform storeItemViewRoot;

    [SerializeField] private Button headItemsButton;
    [SerializeField] private Button upperItemsButton;
    [SerializeField] private Button lowerItemsButton;
    [SerializeField] private Button feetItemsButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button closeButton;

    [SerializeField] private Image headPreviewSlot;
    [SerializeField] private Image upperPreviewSlot;
    [SerializeField] private Image lowerPreviewSlot;
    [SerializeField] private Image feetPreviewSlot;

    [SerializeField] private TextMeshProUGUI playerMoneyField;

    [SerializeField] private StoreStockScriptableObject _storeStockContainer;

    private PlayerInvetory _playerInventory;

    private List<StoreItemView> _storeItemViews = new List<StoreItemView>();
    private int itemsMax;
    
    private Categories category;
    private int selectedIndex;

    public enum Categories
    {
        Head,
        Upper,
        Lower,
        Feet
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerInventory = FindObjectOfType<PlayerInvetory>();
        
        headItemsButton.onClick.AddListener(ShowHeadItems);
        upperItemsButton.onClick.AddListener(ShowUpperItems);
        lowerItemsButton.onClick.AddListener(ShowLowerItems);
        feetItemsButton.onClick.AddListener(ShowFeetItems);
        
        buyButton.onClick.AddListener(TryBuyItem);
        
        closeButton.onClick.AddListener(CloseStore);

        var maxAmout = GetMaxItemsAmount();
        for (int i = 0; i < maxAmout; i++)
        {
            var itemStoreGO = Instantiate(storeItemView, storeItemViewRoot);
            _storeItemViews.Add(itemStoreGO.GetComponent<StoreItemView>());
        }
        
        CloseStore();
    }

    private int GetMaxItemsAmount()
    {
        var headCount = _storeStockContainer.availableHeadItems.Count;
        var upperCount = _storeStockContainer.availableUpperItems.Count;
        var lowerCount = _storeStockContainer.availableLowerItems.Count;
        var feetCount = _storeStockContainer.availableFeetItems.Count;
        
        itemsMax = headCount;
        itemsMax = upperCount > itemsMax ? upperCount : itemsMax;
        itemsMax = lowerCount > itemsMax ? lowerCount : itemsMax;
        itemsMax = feetCount > itemsMax ? feetCount : itemsMax;

        return itemsMax;
    }

    [YarnCommand("open_store")]
    public void OpenStore()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        ShowHeadItems();
        UpdatePlayerMoney();
        Debug.Log("Open Store");
    }

    private void CloseStore()
    {
        ClearAllImages();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

    private void ClearAllImages()
    {
        foreach (var storeItemView in _storeItemViews)
        {
            storeItemView.ClearItem();
        }
    }

    private void UpdatePlayerMoney()
    {
        playerMoneyField.text = _playerInventory.money.ToString();
    }
    
    public void ShowHeadItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < _storeStockContainer.availableHeadItems.Count; i++)
        {
            _storeItemViews[i].SetupStoreItem(
                _storeStockContainer.availableHeadItems[i].itemImage,
                _storeStockContainer.availableHeadItems[i].price,
                SelectHeadItem,
                i);
            
            foreach (var item in _playerInventory.headItems)
            {
                if (_storeItemViews[i].wasBought) continue;
                
                _storeItemViews[i].ToggleBought(item.name);
            }
        }
    }
    
    private void SelectHeadItem(int index, bool wasBought)
    {
        category = Categories.Head;
        selectedIndex = index;
        headPreviewSlot.sprite = _storeStockContainer.availableHeadItems[index].itemImage;
        headPreviewSlot.color = Color.white;
        
        ToggleBuyButton(!wasBought);
    }
    
    public void ShowUpperItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < _storeStockContainer.availableUpperItems.Count; i++)
        {
            _storeItemViews[i].SetupStoreItem(
                _storeStockContainer.availableUpperItems[i].itemImage,
                _storeStockContainer.availableUpperItems[i].price,
                SelectUpperItem,
                i);
            
            foreach (var item in _playerInventory.upperItems)
            {
                if (_storeItemViews[i].wasBought) continue;
                
                _storeItemViews[i].ToggleBought(item.name);
            }
        }
    }

    private void SelectUpperItem(int index, bool wasBought)
    {
        category = Categories.Upper;
        selectedIndex = index;
        upperPreviewSlot.sprite = _storeStockContainer.availableUpperItems[index].itemImage;
        upperPreviewSlot.color = Color.white;
        
        ToggleBuyButton(!wasBought);
    }
    
    public void ShowLowerItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < _storeStockContainer.availableLowerItems.Count; i++)
        {
            _storeItemViews[i].SetupStoreItem(
                _storeStockContainer.availableLowerItems[i].itemImage,
                _storeStockContainer.availableLowerItems[i].price,
                SelectLowerItem,
                i);

            foreach (var item in _playerInventory.lowerItems)
            {
                if (_storeItemViews[i].wasBought) continue;
                
                _storeItemViews[i].ToggleBought(item.name);
            }
        }
    }
    
    private void SelectLowerItem(int index, bool wasBought)
    {
        category = Categories.Lower;
        selectedIndex = index;
        lowerPreviewSlot.sprite = _storeStockContainer.availableLowerItems[index].itemImage;
        lowerPreviewSlot.color = Color.white;
        
        ToggleBuyButton(!wasBought);
    }
    
    public void ShowFeetItems()
    {
        ClearAllImages();
        
        for (var i = 0; i < _storeStockContainer.availableFeetItems.Count; i++)
        {
            _storeItemViews[i].SetupStoreItem(
                _storeStockContainer.availableFeetItems[i].itemImage,
                _storeStockContainer.availableFeetItems[i].price,
                SelectFeetItem,
                i);
            
            foreach (var item in _playerInventory.feetItems)
            {
                if (_storeItemViews[i].wasBought) continue;
                
                _storeItemViews[i].ToggleBought(item.name);
            }
        }
    }
    
    private void SelectFeetItem(int index, bool wasBought)
    {
        category = Categories.Feet;
        selectedIndex = index;
        feetPreviewSlot.sprite = _storeStockContainer.availableFeetItems[index].itemImage;
        feetPreviewSlot.color = Color.white;

        ToggleBuyButton(!wasBought);
    }

    private void ToggleBuyButton(bool value)
    {
        buyButton.interactable = value;
    }
    
    private void TryBuyItem()
    {
        var success = false;
        
        switch (category)
        {
            case Categories.Head:
                success = TryBuyHeadItem();
                break;
            case Categories.Upper:
                success = TryBuyUpperItem();
                break;
            case Categories.Lower:
                success = TryBuyLowerItem();
                break;
            case Categories.Feet:
                success = TryBuyFeetItem();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (success)
        {
            UpdatePlayerMoney();
            ToggleBuyButton(false);
        }
    }

    private bool TryBuyHeadItem()
    {
        var price = _storeStockContainer.availableHeadItems[selectedIndex].price;
        
        if (price > _playerInventory.money) return false;

        _playerInventory.money -= price;
        _playerInventory.AddHeadItem(_storeStockContainer.availableHeadItems[selectedIndex].itemImage);
        ShowHeadItems();
        return true;
    }
    
    private bool TryBuyUpperItem()
    {
        var price = _storeStockContainer.availableUpperItems[selectedIndex].price;
        
        if (price > _playerInventory.money) return false;

        _playerInventory.money -= price;
        _playerInventory.AddUpperItem(_storeStockContainer.availableUpperItems[selectedIndex].itemImage);
        ShowUpperItems();
        return true;
    }
    
    private bool TryBuyLowerItem()
    {
        var price = _storeStockContainer.availableLowerItems[selectedIndex].price;
        
        if (price > _playerInventory.money) return false;

        _playerInventory.money -= price;
        _playerInventory.AddLowerItem(_storeStockContainer.availableLowerItems[selectedIndex].itemImage);
        ShowLowerItems();
        return true;
    }
    
    private bool TryBuyFeetItem()
    {
        var price = _storeStockContainer.availableFeetItems[selectedIndex].price;
        
        if (price > _playerInventory.money) return false;

        _playerInventory.money -= price;
        _playerInventory.AddFeetItem(_storeStockContainer.availableFeetItems[selectedIndex].itemImage);
        ShowFeetItems();
        return true;
    }
}
