using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image itemSprite;

    [SerializeField] private Image itemBg;
    [SerializeField] private Sprite equippedBg;
    [SerializeField] private Sprite normalBg;

    [SerializeField] private Button equipButton;

    public void SetItemImage(Sprite sprite, UnityAction<int> equipMethod ,int index)
    {
        itemSprite.sprite = sprite;
        gameObject.SetActive(true);
        equipButton.onClick.AddListener(() => equipMethod(index));
    }

    public void ToggleEquipped(bool isEquipped)
    {
        itemBg.sprite = isEquipped ? equippedBg : normalBg;
    }

    public void ClearItemImage()
    {
        itemSprite.sprite = null;
        gameObject.SetActive(false);
        equipButton.onClick.RemoveAllListeners();
    }
}
