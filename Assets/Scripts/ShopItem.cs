using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private int id;
    private int cost;
    private int equipId;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemCost;
    [SerializeField] private ItemType itemType;

    [SerializeField] private GameObject soldOutIndicator;
    private bool isSold = false;

    public void SetItemId(int id) { this.id = id; }
    public Sprite GetItemSprite() { return itemIcon.sprite; }
    public int GetEquipId() { return equipId; }
    public int GetItemId() { return id; }
    public string GetItemName() { return itemName.text; }
    public ItemType GetItemType() { return itemType; }
    public int GetItemCost() { return this.cost; }


    public void SetShopItemInfo(Sprite sprite, string name, int cost, ItemType type, int equipId)
    {
        this.itemIcon.sprite = sprite;
        this.itemName.text = name;
        this.cost = cost;
        this.itemCost.text = "Cost: "+cost.ToString();
        this.itemType = type;
        this.equipId = equipId;
    }

    public void SetToSoldOut()
    {
        if (isSold) { return;}

        soldOutIndicator.SetActive(true);
        RemoveOnClickEvent();
    }

    public void OnClickShopItem(BaseEventData eventData)
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
            UnityAction<BaseEventData> callback = new UnityAction<BaseEventData>(OnClickShopItem);
            entry.callback.AddListener(callback);
            eventTrigger.triggers.Add(entry);
        }
    }


}
