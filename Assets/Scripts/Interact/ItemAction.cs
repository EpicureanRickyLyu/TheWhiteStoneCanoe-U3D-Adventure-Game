using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour
{
public float FoodValue;
private Inventory inventory;
 [SerializeField] private UI_Inventory uI_Inventory;
private DialogController Dialog;
private bool door,box,Updraw,DownDraw;
void Start()
{
    
    inventory = new Inventory(UseItem);
    Dialog = GetComponent<DialogController>();
    if(uI_Inventory!=null)
    uI_Inventory.SetInventory(inventory);
}
public void UseItem(Item item)
{
    switch(item.itemType)
    {
        case Item.ItemType.Fur:
            if(inventory.RemoveItem(new Item{itemType =Item.ItemType.Fur,amount=1}))
            PlayerInfo.PlayerInstance.GetComponent<CharacterChontrol>().GetWorm(0.15f);
            break;
        case Item.ItemType.Food:
            if(inventory.RemoveItem(new Item{itemType =Item.ItemType.Food,amount=1}))
            PlayerInfo.PlayerInstance.HP += FoodValue;
            break;
    }
}
public bool HaveBow()
{
    return inventory.HaveBow();
}
public bool HaveMap()
{
    return inventory.HaveMap();
}
public bool HaveFood()
{
    return inventory.HaveFood();
}
public bool HaveFur()
{
    return inventory.HaveFur();
}
public void AddInBag(Item.ItemType item,GameObject ob)
{
    inventory.Additem(new Item{itemType=item,amount=1});
    // uI_Inventory.RefreshInventoryItems();
    if(ob.name=="bows")
    Destroy(ob.transform.parent.gameObject);
    else
    Destroy(ob);
    
  
}
public void DOAction(GameObject ob)
{
        switch(ob.name)
    {
        case "door":
        if(HaveBow()&&HaveFur()&&HaveFood())
        {
        if(!door)
        {
            ob.GetComponent<Animator>().SetBool("Open",true);
            door = true;
        }
        else
        {
            ob.GetComponent<Animator>().SetBool("Open",false);
            door = false;
        }   
        }
        else 
        {
            Dialog.ShowDialog(ob.name);
        }
        break;
        case "bed":
        Dialog.ShowDialog(ob.name);
        break;
        case "bows":
        Dialog.ShowDialog(ob.name);
        AddInBag(Item.ItemType.Bow,ob);
        break;
        case "box":
        Dialog.ShowDialog(ob.name);
        if(!box)
        {
            ob.GetComponentInParent<Animator>().SetBool("Open",true);
            box = true;
        }
        else
        {
            ob.GetComponentInParent<Animator>().SetBool("Open",false);
            box = false;
        }  
        break;
        case "UpDrawer":
        Dialog.ShowDialog(ob.name);
        if(!Updraw)
        {
            ob.GetComponentInParent<Animator>().SetBool("UpOpen",true);
            Updraw = true;
        }
        else
        {
            ob.GetComponentInParent<Animator>().SetBool("UpOpen",false);
            Updraw = false;
        }
        break;
        case "DownDrawer":
         if(!DownDraw)
        {
            ob.GetComponentInParent<Animator>().SetBool("DownOpen",true);
            DownDraw = true;
        }
        else
        {
            ob.GetComponentInParent<Animator>().SetBool("DownOpen",false);
            DownDraw = false;
        } 
        break;
        case "photo":
        Dialog.ShowDialog(ob.name);
        break;
        case "book":
        Dialog.ShowDialog(ob.name);
        break;
        case "Latern":
        Dialog.ShowDialog(ob.name);
        break;
        case "fur(Clone)":
        Dialog.ShowDialog(ob.name);
        AddInBag(Item.ItemType.Fur,ob);
        break;
        case "fur":
        Dialog.ShowDialog(ob.name);
        AddInBag(Item.ItemType.Fur,ob);
        break;
        case "Food":
        Dialog.ShowDialog(ob.name);
        AddInBag(Item.ItemType.Food,ob);
        break;
        case "Food(Clone)":
        Dialog.ShowDialog(ob.name);
        AddInBag(Item.ItemType.Food,ob);
        break;
        case "Ghost":
        Dialog.ShowDialog(ob.name);
        break;
        case "Map":
        Dialog.ShowDialog(ob.name);
        AddInBag(Item.ItemType.Map,ob);
        break;
    }
}
void Update()
{
    if(Input.GetKeyDown(KeyCode.Alpha2))
    {
        UseItem(new Item{itemType=Item.ItemType.Fur,amount=1});
    }
    if(Input.GetKeyDown(KeyCode.Alpha1))
    {
        UseItem(new Item{itemType=Item.ItemType.Food,amount=1});
    }
}

}
