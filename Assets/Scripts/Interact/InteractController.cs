using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractController : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask layerMask;
    private GameObject target;
    public GameObject InfoPanel;
    public float interactDistance;
    private bool PressEnable;
    private ItemAction itemAction;

    void Start()
    {
        itemAction = GetComponent<ItemAction>();
    }
    public void RaycastResult()
    {
      // how to clean hit,or target???
        if(Physics.Raycast(this.transform.position,this.transform.forward,out hit,interactDistance,layerMask))
        {
            target = hit.collider.gameObject;
        }
        HidePanel();
        if(target!=null)
        ShowInfo();
    }

    public void ShowPanel()
    {
        PressEnable = true;
        InfoPanel.SetActive(true);

        switch(target.name)
        {
          case "fur(Clone)":
          SetText("Fur");
          break;
          case "Ghost":
          SetText("GOD OF LIFE");
          break;
          case "DownDrawer":
          SetText("Drawer");
          break;
          case "UpDrawer":
          SetText("Drawer");
          break;
          case "Food(Clone)":
          SetText("Food");
          break;
          default:
          SetText(target.name);
          break;

        }


        // iTween.FadeTo(InfoPanel,255,2f);
        
    }
    public void HidePanel()
    {
        PressEnable = false;
        // iTween.FadeTo(InfoPanel,0,2f);
        if(InfoPanel!=null)
        InfoPanel.SetActive(false);
    }

    public void SetText(string name)
    {
        InfoPanel.GetComponentInChildren<TextMeshProUGUI>().text =
         name +" Press E to Interact";
    }
    public bool driveboat = true;
    public void ShowInfo()
    {
      
        switch(target.name)
        {
            case "door":
            ShowPanel();
            break;
            case "bed":
              ShowPanel();
            
            break;
            case "bows":
              ShowPanel();
          
            break;
            case "box":
              ShowPanel();
      
            break;
            case "DownDrawer":
              ShowPanel();
         
            break;
            case "UpDrawer":
              ShowPanel();
         
            break;
            case "photo":
              ShowPanel();
        
            break;
            case "book":
              ShowPanel();
    
            break;
            case "Latern":
              ShowPanel();
         
            break;
            case "fur(Clone)":
              ShowPanel();
            break;
            case "fur":
              ShowPanel();
            break;
            case "Food":
              ShowPanel();
              break;
            case "Food(Clone)":
             ShowPanel();
             break;
            case "Ghost":
            ShowPanel();
            break;
            case "Map":
            ShowPanel();
            break;
            case "Boat":
            if(driveboat)
            {
              ShowPanel();
            }
            break;
            case "Collider":
              HidePanel();
            break;
            default:
            HidePanel();
            break;
        }
    }
  
   
    void Update()
    {
        RaycastResult();
        if(PressEnable==true&&Input.GetKeyDown(KeyCode.E))
        {
            itemAction.DOAction(target);
            
        }
        Debug.DrawLine(this.transform.position,this.transform.forward*100,Color.red);
    }



}
