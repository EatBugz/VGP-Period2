using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem dI = dropped.GetComponent<DraggableItem>();

        // get the current item in the inventory slot, if there is one
        Transform currentItem = null;
        if (transform.childCount != 0) currentItem = transform.GetChild(0);

        // empty inventory slot
        if (currentItem == null) dI.parent = transform;
        // if there is already an item, swap the positions
        else {
            currentItem.SetParent(dI.parent);
            dI.parent = transform;
        }  
    }
}
