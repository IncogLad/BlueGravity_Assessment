using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfirmationPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI confirmationText;
    [SerializeField] private TextMeshProUGUI warningText;

    public void ItemConfirmation(string itemName)
    {
        gameObject.SetActive(true);
        confirmationText.text = "Buy " + itemName + "?";
    }

    public void BuyItem()
    {
        int gold = ResourceManager.Instance.gold;
        int cost = ShopManager.Instance.GetSelectedShopItem().GetItemCost();

        if (gold < cost)
        {
            warningText.gameObject.SetActive(true);
            return;
        }

        ResourceManager.Instance.UpdateGold(-cost);
        ShopManager.Instance.GetSelectedShopItem().SetToSoldOut();
        CloseMenu();

    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
        warningText.gameObject.SetActive(false);
        ShopManager.Instance.SetSelectedId(-1);
    }

}
