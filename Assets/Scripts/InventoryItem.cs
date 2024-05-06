using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private int id;
    private int cost;
    private string itemName;
    private ItemType itemType;

    [SerializeField] private Image itemIcon;

    public void SetItemId(int id) { this.id = id; }
    public int GetItemId() { return id; }
    public ItemType GetItemType() { return itemType; }
    public int GetItemCost() { return this.cost; }


    public void SetShopItemInfo(Sprite sprite, string name, int cost, ItemType type)
    {
        this.itemIcon.sprite = sprite;
        this.itemName = name;
        this.cost = cost;
        this.itemType = type;
    }
    
    public void OnClickInvItem(BaseEventData eventData)
    {
        ShopManager.Instance.SetSelectedId(this.id);
        ShopManager.Instance.ItemConfirmPanel();
    }

    public void RemoveOnClickEvent()
    {
        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        if (eventTrigger != null)
        {
            eventTrigger.triggers.Clear();
        }
    }

    public void AddOnClickEvent()
    {
        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        if (eventTrigger != null)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            UnityAction<BaseEventData> callback = new UnityAction<BaseEventData>(OnClickInvItem);
            entry.callback.AddListener(callback);
            eventTrigger.triggers.Add(entry);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

}
