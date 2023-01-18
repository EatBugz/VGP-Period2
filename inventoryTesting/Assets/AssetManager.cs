using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    [Header("Item Sprites")]
    public List<Sprite> ItemSprites = new List<Sprite>();
    // pre-made items
    public static Item sword;
    public static Item shield;
    public static Item armor;

    void Awake() {
        sword = new Item(ItemSprites[0], Item.ItemType.Sword);
        shield = new Item(ItemSprites[1], Item.ItemType.Shield);
        armor = new Item(ItemSprites[2], Item.ItemType.Armor);
    }
}
