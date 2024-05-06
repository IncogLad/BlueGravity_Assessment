using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    private int selectedId = -1;

    [SerializeField] private ConfirmationPanel confirmationPanel;
    [SerializeField] private ShopDropSell shopDropSell;

    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private GameObject shopContentParent;
    [SerializeField] private List<ShopItem> shopItemList = new List<ShopItem>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        InitializeShopItems();
        SetShopItemListIds();
    }

    private void SetShopItemListIds()
    {
        for (int i = 0; i < shopItemList.Count; i++)
        {
            shopItemList[i].SetItemId(i);
        }
    }

    private void InitializeShopItems()
    {
        foreach (var item in EquipmentManager.Instance.armEquipmentList)
        {
            ShopItem shopItem = SpawnShopItem();
            shopItem.SetShopItemInfo(item.iconSprite, item.name, item.cost, item.itemType);
            shopItemList.Add(shopItem);
        }

        foreach (var item in EquipmentManager.Instance.headEquipmentList)
        {
            ShopItem shopItem = SpawnShopItem();
            shopItem.SetShopItemInfo(item.iconSprite, item.name, item.cost, item.itemType);
            shopItemList.Add(shopItem);
        }

        foreach (var item in EquipmentManager.Instance.chestEquipmentList)
        {
            ShopItem shopItem = SpawnShopItem();
            shopItem.SetShopItemInfo(item.iconSprite, item.name, item.cost, item.itemType);
            shopItemList.Add(shopItem);
        }

        foreach (var item in EquipmentManager.Instance.legEquipmentList)
        {
            ShopItem shopItem = SpawnShopItem();
            shopItem.SetShopItemInfo(item.iconSprite, item.name, item.cost, item.itemType);
            shopItemList.Add(shopItem);
        }

    }
    public ShopItem GetSelectedShopItem()
    {
        return shopItemList[selectedId];
    }

    public ShopDropSell GetShopDropSell()
    {
        return shopDropSell;
    }

    public ShopItem SpawnShopItem()
    {
        GameObject newItem = Instantiate(shopItemPrefab);
        newItem.transform.SetParent(shopContentParent.transform, false);

        if (newItem.GetComponent<ShopItem>() == null)
        {
            Debug.Log("ItemPrefab has no ShopItemScript!");
            return null;
        }

        ShopItem shopItem = newItem.GetComponent<ShopItem>();

        return shopItem;
    }

    public void SetSelectedId(int id)
    {
        selectedId = id;
    }

    public int GetSelectedId()
    {
        return selectedId;
    }

    public void ItemConfirmPanel()
    {
        if (selectedId < 0)
        {
            Debug.LogError("No Selected ID!");
            return;
        }

        string itemName = shopItemList[selectedId].GetItemName();
        confirmationPanel.ItemConfirmation(itemName);
    }

}
