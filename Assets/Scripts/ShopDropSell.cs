using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopDropSell : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem newInvItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (newInvItem != null)
        {
            int cost = InventoryManager.Instance.GetInventoryItemOfSelectedId().GetItemCost();
            ResourceManager.Instance.UpdateGold(cost);

            newInvItem.GetItemSlot().GetComponent<InventorySlot>().SetItemInSlot(null);

            Destroy(newInvItem.gameObject);
        }
        ShopManager.Instance.GetShopDropSell().gameObject.SetActive(false);
        AudioManager.Instance.PlayAudio(SoundEffect.GOLD);

    }

}
