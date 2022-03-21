using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Inventory 
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    private Action<Item> useItemAction;
    public Inventory(Action<Item> useItemAction){

        this.useItemAction = useItemAction;
        itemList = new List<Item>();
        Debug.Log("Inventory");
        // Additem(new Item{itemType=Item.ItemType.Hand,amount=1});
        if(SceneManager.GetActiveScene().name=="SampleScene")
        {
        Additem(new Item{itemType=Item.ItemType.Bow,amount=1});
        Additem(new Item{itemType=Item.ItemType.Fur,amount=1});
        Additem(new Item{itemType=Item.ItemType.Food,amount=1});
        }
      

       

    }
    public bool HaveBow()
    {
        foreach (Item inventoryitem in itemList)
        {
            if(inventoryitem.itemType == Item.ItemType.Bow)
            {
                return true;
            }
            
        }
        return false;
    }
    public bool HaveMap()
    {
        foreach (Item inventoryitem in itemList)
        {
            if(inventoryitem.itemType == Item.ItemType.Map)
            {
                return true;
            }
            
        }
        return false;
    }
    public bool HaveFur()
    {
        foreach (Item inventoryitem in itemList)
        {
            if(inventoryitem.itemType == Item.ItemType.Fur)
            {
                return true;
            }
            
        }
        return false;
    }
    public bool HaveFood()
    {
        foreach (Item inventoryitem in itemList)
        {
            if(inventoryitem.itemType == Item.ItemType.Food)
            {
                return true;
            }
            
        }
        return false;
    }
    public void Additem(Item item)
    {
        if(item.IsStackable())
        {
            bool itemAlreadyinInventory = false;
            foreach (Item inventoryitem in itemList)
            {
                if(inventoryitem.itemType == item.itemType)
                {
                    inventoryitem.amount += item.amount;
                    itemAlreadyinInventory = true;
                }
                
            }
            if(!itemAlreadyinInventory)
            {
                itemList.Add(item);
            }

        }
        else{
             itemList.Add(item);
        }
       
        OnItemListChanged?.Invoke(this,EventArgs.Empty); 
    }
    public bool RemoveItem(Item item)
    {
       
        if(item.IsStackable())
        {
            Item itemInIninventory = null;
            foreach (Item inventoryitem in itemList)
            {
                if(inventoryitem.itemType == item.itemType)
                {
                    inventoryitem.amount -= 1;
                    itemInIninventory = inventoryitem;
                }
                
            }
            if(itemInIninventory == null)
            {
                return false;
            }
            if(itemInIninventory!= null&&itemInIninventory.amount<=0)
            {
               
                itemList.Remove(itemInIninventory);
              
            }
        }
        else{
             itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this,EventArgs.Empty);    
        return true;

    }
    public void UseItem(Item item)
    {
        useItemAction(item);
    }

    public List<Item> GetItemList(){
        return itemList;
    }
}
