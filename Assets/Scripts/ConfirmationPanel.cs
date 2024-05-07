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
        ShopItem selectedShopItem = ShopManager.Instance.GetSelectedShopItem();
        
        int gold = ResourceManager.Instance.gold;
        int cost = selectedShopItem.GetItemCost();

        if (gold < cost)
        {
            warningText.gameObject.SetActive(true);
            return;
        }

        ResourceManager.Instance.UpdateGold(-cost);
        InventoryManager.Instance.SpawnInventoryItem(selectedShopItem);
        selectedShopItem.SetToSoldOut();
        AudioManager.Instance.PlayAudio(SoundEffect.GOLD);
        CloseMenu();

    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
        warningText.gameObject.SetActive(false);
        ShopManager.Instance.SetSelectedId(-1);
        
    }

}
