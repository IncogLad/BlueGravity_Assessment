using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int id { private set; get; }
    public InventoryItem item { private set; get; }
    [SerializeField] private ItemType itemType = ItemType.None;

    public void SetItemId(int id) { this.id = id; }
    public void SetItemInSlot(InventoryItem item) { this.item = item; }
    
    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem newInvItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (newInvItem == null) return;

        if (this.itemType != ItemType.None)
        {
            if(newInvItem.GetItemType() != this.itemType)
                return;
        }

        if (item != null)
        {
            if (InventoryManager.Instance.GetInventorySlotOfSelectedId().itemType != ItemType.None)
            {
                if (InventoryManager.Instance.GetInventoryItemOfSelectedId().GetItemType() != this.itemType)
                    return;
            }

            InventoryManager.Instance.SwapItem(id);
            InventorySlot newSlot = InventoryManager.Instance.GetInventorySlotOfIndex(id);
            newInvItem.SetItemId(id);
            newInvItem.SetItemSlot(newSlot.transform);
            newSlot.SetItemInSlot(newInvItem);
            item = newInvItem;
        }
        else
        {
            newInvItem.GetItemSlot().GetComponent<InventorySlot>().item = null;
            newInvItem.SetItemId(id);
            newInvItem.SetItemSlot(transform);
            item = newInvItem;
        }
        UpdateEquipmentSlots();
    }

    void UpdateEquipmentSlots()
    {
        if (this.itemType != ItemType.None)
        {
            PlayerSkeleton ps = FindObjectOfType<PlayerSkeleton>();
            if (item == null)
            {
                ps.UpdateEquipment(itemType, -1);
            }
            else
            {
                ps.UpdateEquipment(itemType, item.equipId);
            }
        }

        InventoryItem otherInvItem = InventoryManager.Instance.GetInventoryItemOfSelectedId();
        InventorySlot otherInvSlot = InventoryManager.Instance.GetInventorySlotOfSelectedId();
        if (otherInvSlot.itemType != ItemType.None)
        {
            PlayerSkeleton ps = FindObjectOfType<PlayerSkeleton>();
            if (otherInvItem == null)
            {
                ps.UpdateEquipment(otherInvSlot.itemType, -1);
            }
            else
            {
                ps.UpdateEquipment(otherInvSlot.itemType, otherInvItem.equipId);
            }

        }
    }

}
