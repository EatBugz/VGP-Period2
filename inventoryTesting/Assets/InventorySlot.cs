using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    // get inventory
    private Inventory inventory;
    void Awake() {
        inventory = GameObject.Find("Inventory Manager").GetComponent<Inventory>();
    }

    // when an item gets dropped in this inventory slot
    public void OnDrop(PointerEventData eventData) {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem dI = dropped.GetComponent<DraggableItem>();

        // get the current item in the inventory slot, if there is one
        Transform currentItem = null;
        if (transform.childCount != 0) currentItem = transform.GetChild(0);

        // get the index in the inventory slot list
        int inventorySlotIndex = inventory.getInventorySlotIndex(gameObject);
        int dIInventorySlotIndex = inventory.getInventorySlotIndex(dI.parent.gameObject);

        // empty inventory slot
        if (currentItem == null) {
            dI.parent = transform;
            inventory.moveItemPlace(dIInventorySlotIndex, inventorySlotIndex);
        }
        // if there is already an item, swap the positions
        else {
            currentItem.SetParent(dI.parent);
            dI.parent = transform;
            inventory.switchItemPlace(dIInventorySlotIndex, inventorySlotIndex);
        }  
    }
}
