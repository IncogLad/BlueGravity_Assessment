using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private int cost;
    private string itemName;
    private ItemType itemType;
    private Transform itemSlot;

    private int slotId;
    public int equipId;
    [SerializeField] private Image itemIcon;

    public void SetItemId(int id) { this.slotId = id; }
    public void SetItemSlot(Transform transform) { itemSlot = transform; }
    public int GetItemId() { return slotId; }
    public string GetItemName() { return itemName; }
    public int GetEquipId() { return equipId; }
    public ItemType GetItemType() { return itemType; }
    public int GetItemCost() { return this.cost; }
    public Transform GetItemSlot() { return itemSlot; }
    public Sprite GetItemSprite() { return itemIcon.sprite; }

    public void SetInvItemVar(Sprite sprite, string name, int cost, ItemType type, int equipId)
    {
        this.itemIcon.sprite = sprite;
        this.itemName = name;
        this.cost = cost;
        this.itemType = type;
        this.equipId =equipId;
        //is set after item is spawned in the inventory
        itemSlot = transform.parent;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        InventoryManager.Instance.SetSelectedId(slotId);
        ShopManager.Instance.GetShopDropSell().gameObject.SetActive(true);
        itemSlot = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        itemIcon.raycastTarget = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(itemSlot);
        itemIcon.raycastTarget = true;
        ShopManager.Instance.GetShopDropSell().gameObject.SetActive(false);

    }

}
