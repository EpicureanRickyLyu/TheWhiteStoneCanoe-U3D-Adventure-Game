    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemcontainer;
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender,System.EventArgs e)
    {
        RefreshInventoryItems();
    }
    private void DestroyChild()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
    public void RefreshInventoryItems(){
       DestroyChild();
        foreach(Item item in inventory.GetItemList()){
          Transform go = Instantiate(itemcontainer,this.transform);
          go.GetComponent<Image>().sprite = item.GetSprite();
          if(item.amount>1)
          go.GetComponentInChildren<TextMeshProUGUI>().SetText(item.amount.ToString());
        }
    }



}
