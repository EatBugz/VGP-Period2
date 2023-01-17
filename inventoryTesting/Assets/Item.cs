using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType {
        None,
        Sword,
        Shield,
        Armor
    }
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

    /*
    public string getName() { 
        switch (this.itemType) {
            case this.itemType.Sword:
                return "Sword";
            case this.itemType.Shield:
                return "Shield";
            case this.itemType.Armor:
                return "Armor";
        }
    }
    */
}
