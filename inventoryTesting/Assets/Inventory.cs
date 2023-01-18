using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{
    private Item[] inventory = new Item[5];
    public List<GameObject> inventorySlots = new List<GameObject>();

    [Header("Prefabs")]
    public GameObject itemPrefab;
    public GameObject inventorySlotPrefab;
    private GameObject canvas;
    private GameObject inventorySpace;

    private AssetManager aM;

    // get stuff
    void Awake() {
        aM = GameObject.Find("Assets Manager").GetComponent<AssetManager>();
        canvas = GameObject.Find("Canvas");
        inventorySpace = GameObject.Find("Inventory Space");
        updateInventorySize();
    }

    void Start() {
        addItems(new List<Item>() {AssetManager.sword, AssetManager.shield, AssetManager.armor});
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) printInventory();

       if (Input.GetKeyDown(KeyCode.H)) updateInventoryUIContents();

        if (Input.GetKeyDown(KeyCode.K)) {
            addItem(AssetManager.sword);
            updateInventoryUIContents();
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            addItem(AssetManager.shield);
            updateInventoryUIContents();
        }
    }

    // method that adds an item to the "code" inventory
    public void addItem(Item item) {
        int freeSpaces = 0;
        // check for free space
        for (int i = 0; i < inventory.Length; i++) if (inventory[i] == null) freeSpaces++;
        if (freeSpaces == 0) {
            Debug.LogError("No space for item!");
            return;
        }

        // if there's a free space
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i] == null) {
                inventory[i] = item;
                break;
            }
        }
    }

    // method that adds multiple items to the inventory
    public void addItems(List<Item> itemList) {
        // add list of items to inventory
        for (int i = 0; i < itemList.Count; i++) {
            addItem(itemList[i]);
        }

        // update the UI
        updateInventoryUIContents();
    }

    // method that updates the inventory slots with the correct item
    public void updateInventoryUIContents() {
        // reset ui contents already there
        for (int i = 0; i < inventorySlots.Count; i++) {
            if (inventorySlots[i].transform.childCount != 0) {
                for (int j = 0; j < inventorySlots[i].transform.childCount; j++) {
                    Destroy(inventorySlots[i].transform.GetChild(0).gameObject);
                }
            }
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

    // method that updates the ui inventory size to match the inventory size of the "code"
    public void updateInventorySize() {
        // reset
        for (int i = 0; i < inventorySpace.transform.childCount; i++) {
            Destroy(inventorySpace.transform.GetChild(0));
            inventorySlots.RemoveAt(0);
        }

        // instantiate new inventory slots
        for (int i = 0; i < inventory.Length; i++) {
            GameObject foo = Instantiate(inventorySlotPrefab, inventorySpace.transform);
            inventorySlots.Add(foo);
        }
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

    // method that prints the contents of the inventory
    public void printInventory() {
        string str = "";
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i] != null) str += inventory[i].getItemType().ToString() + " ";
            else str += "None ";
        }
        Debug.Log(str);
    }
}
