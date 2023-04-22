using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StoreItemView : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Image buttonImage;
    [SerializeField] private Button itemButton;
    [SerializeField] private TextMeshProUGUI itemPrice;

    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite equippedSprite;

    public bool wasBought;
    
    public void SetupStoreItem(Sprite sprite, int price, UnityAction<int, bool> onStoreItemSelected, int index)
    {
        gameObject.SetActive(true);
        
        itemImage.sprite = sprite;
        itemPrice.text = price.ToString();
        itemButton.onClick.AddListener(() => onStoreItemSelected(index, wasBought));
    }

    public void ToggleBought(string id)
    {
        wasBought = itemImage.sprite.name.Equals(id);
        buttonImage.sprite = wasBought ? equippedSprite : normalSprite;
    }

    public void ClearItem()
    {
        itemImage.sprite = null;
        itemPrice.text = "0";
        itemButton.onClick.RemoveAllListeners();
        wasBought = false;
        buttonImage.sprite = normalSprite;
        gameObject.SetActive(false);
    }

}
