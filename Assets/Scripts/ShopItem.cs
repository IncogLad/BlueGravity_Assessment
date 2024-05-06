using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private int id;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemCost;
    [SerializeField] private ItemType itemType;

    [SerializeField] private GameObject soldOutIndicator;
    private bool isSold = false;

    public void SetItemId(int id) { this.id = id; }
    public int GetItemId() { return id; }
    public string GetItemName() { return itemName.text; }

    public void SetShopItemInfo(Sprite sprite, string name, int cost, ItemType type)
    {
        this.itemIcon.sprite = sprite;
        this.itemName.text = name;
        this.itemCost.text = cost.ToString();
        this.itemType = type;
    }

    public void SetToSoldOut()
    {
        if (isSold) { return;}

        soldOutIndicator.SetActive(true);
    }

    public void OnClickShopItem()
    {
        ShopManager.Instance.SetSelectedId(this.id);
        ShopManager.Instance.ItemConfirmPanel();
    }




}
