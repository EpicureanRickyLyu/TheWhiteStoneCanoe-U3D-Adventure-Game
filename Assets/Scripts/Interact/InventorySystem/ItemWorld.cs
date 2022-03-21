using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position,Item item)
    {
        if(item.itemType ==Item.ItemType.Fur)
        {
        Transform transform = Instantiate(ItemAssets.instance.Fur,position,Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
        }
        else
        {
        Transform transform = Instantiate(ItemAssets.instance.Food,position,Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
        }
      

    }
    public Item item;
    private SpriteRenderer spriteRenderer;  
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    public void SetItem(Item item)
    {
        this.item = item;
        
        spriteRenderer.sprite = item.GetSprite();
    }

    
}
