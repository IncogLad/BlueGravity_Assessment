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
        if (item != null)
        {
            InventoryManager.Instance.SwapItem(id);

            InventorySlot newSlot = InventoryManager.Instance.GetInventorySlotOfIndex(id);
            InventoryItem newInvItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            if (newInvItem != null)
            {
                newInvItem.SetItemId(id);
                newInvItem.SetItemSlot(newSlot.transform);
                newSlot.SetItemInSlot(newInvItem);
                item = newInvItem;
            }
        }
        else
        {
            InventoryItem newInvItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            if (newInvItem != null)
            {
                newInvItem.GetItemSlot().GetComponent<InventorySlot>().item = null;
                newInvItem.SetItemId(id);
                newInvItem.SetItemSlot(transform);
                item = newInvItem;
            }
        }

        

    }

    


}
