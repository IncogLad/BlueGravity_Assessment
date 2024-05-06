using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private List<InventoryItem> inventoryItemList = new List<InventoryItem>();

    [SerializeField] private List<GameObject> inventoryItemSlot = new List<GameObject>();

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

    private void SetInvItemListIds()
    {
        for (int i = 0; i < inventoryItemList.Count; i++)
        {
            inventoryItemList[i].SetItemId(i);
        }
    }

}
