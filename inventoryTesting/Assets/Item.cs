using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // item type
    public enum ItemType {
        None,
        Sword,
        Shield,
        Armor
    }
    // other attributes
    private int amount;
    private Sprite itemSprite;
    private ItemType itemType;

    ///   Constructors   \\\
    public Item(Sprite s, ItemType iT) { 
        this.amount = 1; 
        this.itemSprite = s;
        this.itemType = iT;
    }
    public Item(Sprite s, ItemType iT, int n) { 
        this.amount = n; 
        this.itemSprite = s;
        this.itemType = iT;
    }

    ///   Accessability Methods   \\\
    public Sprite getSprite() { return this.itemSprite; }
    public ItemType getItemType() { return this.itemType; }
    public int getAmount() { return this.amount; }
}
