using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType{
        Bow,
        Arrows,
        Fur,
        Food,
        Map,
    }
    public ItemType itemType;
    public int amount;
    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.Bow: return ItemAssets.instance.BowSprite;
            case ItemType.Fur: return ItemAssets.instance.Fursprite;
            case ItemType.Food: return ItemAssets.instance.Foodsprite;
            case ItemType.Map: return ItemAssets.instance.Mapsprite;
        }
    }
    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.Fur:
            case ItemType.Food:
            case ItemType.Arrows:
                return true;
            case ItemType.Bow:
            case ItemType.Map:
                return false;
        }
    }


    
}
