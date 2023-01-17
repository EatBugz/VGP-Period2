using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Item[] inventory = new Item[1];
    public List<GameObject> inventorySlots = new List<GameObject>();

    public GameObject itemPrefab;
    private GameObject canvas;

    private AssetManager aM;

    // get stuff
    void Awake() {
        aM = GameObject.Find("Assets Manager").GetComponent<AssetManager>();
        canvas = GameObject.Find("Canvas");
        updateInventorySize();
    }

    void Start() {
        inventory[0] = new Item(aM.ItemSprites[0], Item.ItemType.Sword);
        inventory[3] = new Item(aM.ItemSprites[1], Item.ItemType.Shield);
        inventory[2] = new Item(aM.ItemSprites[2], Item.ItemType.Armor);

        updateInventoryUIContents();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            string str = "";
            for (int i = 0; i < inventory.Length; i++) {
                if (inventory[i] != null) str += inventory[i].getItemType().ToString() + " ";
                else str += "None ";
            }
            Debug.Log(str);
        }
    }

    // method that updates the inventory slots with the correct item
    public void updateInventoryUIContents() {
        // reset ui contents already there
        for (int i = 0; i < inventorySlots.Count; i++) {
            if (inventorySlots[i].transform.childCount != 0) Destroy(inventorySlots[i].transform.GetChild(0).gameObject);
        }

        // add new ui items
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i] != null) {
                // create the item
                GameObject foo = Instantiate(itemPrefab, canvas.transform);
                // set correct parent inventory slot
                foo.transform.SetParent(inventorySlots[i].transform);
                // set the correct item sprite
                foo.GetComponent<Image>().sprite = inventory[i].getSprite();
            }
        }
    }

    // method that updates the inventory slots to match the inventory size
    public void updateInventorySize() {
        Item[] newList = new Item[inventorySlots.Count];

        for (int i = 0; i < inventory.Length; i++) {
            newList[i] = inventory[i];
        }

        inventory = newList;
    }

    // method that swaps the position of the items in the inventory
    public void switchItemPlace(int itemIndex1, int itemIndex2) {
        Item foo = inventory[itemIndex1];
        inventory[itemIndex1] = inventory[itemIndex2];
        inventory[itemIndex2] = foo;
    }

    // method that moves the position of an item in the inventory
    public void moveItemPlace(int origin, int destination) {
        inventory[destination] = inventory[origin];
        inventory[origin] = null;
    }

    // method that gets the index of the inventorySlot in the inventorySlots list
    public int getInventorySlotIndex(GameObject slot) {
        for (int i = 0; i < inventorySlots.Count; i++) {
            if (inventorySlots[i] == slot) return i;
        }
        return -1;
    }
}
