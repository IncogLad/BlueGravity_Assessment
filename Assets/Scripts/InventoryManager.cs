using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private int selectedId = -1;

    [SerializeField] private GameObject invItemPrefab;
    [SerializeField] private GameObject invSlotContent;
    [SerializeField] private GameObject equipSlotContent;

    [SerializeField] private List<InventorySlot> inventorySlotList = new List<InventorySlot>();

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

    private void Start()
    {
        SetInvSlotsToList();
        SetInvItemListIds();
    }

    private void SetInvSlotsToList()
    {
        for (int i = 0; i < invSlotContent.transform.childCount; i++)
        {
            InventorySlot slot = invSlotContent.transform.GetChild(i).GetComponent<InventorySlot>();
            if (slot != null)
            {
                inventorySlotList.Add(slot);
            }
        }

        for (int i = 0; i < equipSlotContent.transform.childCount; i++)
        {
            InventorySlot slot = equipSlotContent.transform.GetChild(i).GetComponent<InventorySlot>();
            if (slot != null)
            {
                inventorySlotList.Add(slot);
            }
        }
    }

    private void SetInvItemListIds()
    {
        for (int i = 0; i < inventorySlotList.Count; i++)
        {
            inventorySlotList[i].SetItemId(i);
        }
    }

    private InventorySlot GetFirstEmptyInvSlot()
    {
        for (int i = 0; i < inventorySlotList.Count; i++)
        {
            if (inventorySlotList[i].item == null)
            {
                return inventorySlotList[i];
            }
        }

        Debug.Log("InventoryFull");
        return null;
    }

    public void SpawnInventoryItem(ShopItem shopItem)
    {
        GameObject newItem = Instantiate(invItemPrefab);
        InventorySlot newSlot = GetFirstEmptyInvSlot();
        Transform newParentSlot = newSlot.transform;

        newItem.transform.SetParent(newParentSlot, false);

        if (newItem.GetComponent<InventoryItem>() == null)
        {
            Debug.Log("ItemPrefab has no InventoryItemScript!");
        }

        InventoryItem invItem = newItem.GetComponent<InventoryItem>();
        invItem.SetInvItemVar(shopItem.GetItemSprite(), shopItem.GetItemName(), shopItem.GetItemCost(),
            shopItem.GetItemType());
        newSlot.SetItemInSlot(invItem);
        invItem.SetItemId(newSlot.id);

    }

    public void SetSelectedId(int id)
    {
        selectedId = id;
    }

    public int GetSelectedId()
    {
        return selectedId;
    }

    public InventorySlot GetInventorySlotOfIndex(int index)
    {
        return inventorySlotList[index];
    }

    public InventorySlot GetInventorySlotOfSelectedId()
    {
        return inventorySlotList[selectedId];
    }
    public InventoryItem GetInventoryItemOfSelectedId()
    {
        return inventorySlotList[selectedId].item;
    }

    public void SwapItem(int newSlotId)
    {
        //spawn new one in previous spot
        GameObject newItem = Instantiate(invItemPrefab);
        InventorySlot prevSlot = GetInventorySlotOfIndex(selectedId);
        Transform newParentSlot = prevSlot.transform;

        newItem.transform.SetParent(newParentSlot, false);

        if (newItem.GetComponent<InventoryItem>() == null)
        {
            Debug.Log("ItemPrefab has no InventoryItemScript!");
        }

        InventoryItem invItem = newItem.GetComponent<InventoryItem>();
        InventoryItem swapInvItem = GetInventorySlotOfIndex(newSlotId).item;

        invItem.SetInvItemVar(swapInvItem.GetItemSprite(), swapInvItem.GetItemName(), swapInvItem.GetItemCost(),
            swapInvItem.GetItemType());
        prevSlot.SetItemInSlot(invItem);
        invItem.SetItemId(prevSlot.id);

        //destroy the clone in the new spot
        Destroy(GetInventorySlotOfIndex(newSlotId).transform.GetChild(0).gameObject);
    }

}
