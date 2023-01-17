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

        updateInventoryContents();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            string str = "";
            for (int i = 0; i < inventory.Length; i++) {
                //str += inventory[i].getName();
                Debug.Log("Pain");
            }
        }
    }

    // method that updates the inventory slots with the correct item
    public void updateInventoryContents() {
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
}
