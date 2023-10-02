using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItemHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryUIInteraction draggableItem = dropped.GetComponent<InventoryUIInteraction>();
        Slot slot = draggableItem.draggedItemParent.GetComponent<Slot>();

        GameObject player = GameObject.FindGameObjectWithTag("whatIsPlayer");

        GameObject droppedItem = Instantiate(slot.ItemInSlot.prefab, player.transform.position, Quaternion.identity);
        droppedItem.GetComponent<ItemObject>().amount = slot.AmountInSlot;
        slot.ItemInSlot = null;
        slot.AmountInSlot = 0;
    }

    public void DelItem(PointerEventData eventData)
    {
        GameObject deleted = eventData.pointerClick;
        InventoryUIInteraction deletetableItem = deleted.GetComponent<InventoryUIInteraction>();
        Slot slot = deletetableItem.draggedItemParent.GetComponent<Slot>();
        slot.ItemInSlot = null;
        slot.AmountInSlot = 0;
    }
}
