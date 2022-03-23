using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogController : MonoBehaviour
{
    public GameObject DialogPanel;
    public float StartAlpha=0.5f,FadeSpeed=0.2f;
    void Start()
    {
     
    }
    public void SetTemporaryText(string st)
    {
        DialogPanel.SetActive(true);
        DialogPanel.GetComponent<DialogFadeout>().alpha = 0.5f;
        DialogPanel.GetComponentInChildren<TextMeshProUGUI>().alpha = 0.5f;
        DialogPanel.GetComponentInChildren<TextMeshProUGUI>().SetText(st);


    }
    public void ShowDialog(string name)
    {
        DialogPanel.SetActive(true);
        DialogPanel.GetComponent<DialogFadeout>().alpha=0.5f;
        DialogPanel.GetComponentInChildren<TextMeshProUGUI>().alpha = 0.5f;
        TextMeshProUGUI go = DialogPanel.GetComponentInChildren<TextMeshProUGUI>();
        switch(name)
    {
        case "door":
        go.SetText("I should bring some items for the long trek");
        break;
        case "bed":
        go.SetText("I have no time for this");
        break;
        case "bows":
        go.SetText("I used to be a great archer");
        break;
        case "box":
        go.SetText("If there will be any useful items");
        break;
        case "UpDrawer":
        go.SetText("If there will be any useful items");
        break;
        case "photo":
        go.SetText("My dear, wish you are all well in the land of souls ");
        break;
        case "book":
        go.SetText("The land of the soul is mentioned in the book,it`s called - आत्मा");
        break;
        case "Latern":
        go.SetText("I have no time for this");
        break;
        case "fur(Clone)":
        go.SetText("This will keep me warm");
        break;
        case "fur":
        go.SetText("This will keep me warm");
        break;
        case "Food":
        go.SetText("Food is necessary");
        break;
        case "Food(Clone)":
        go.SetText("This can rejuvenate me");
        break;
        case "Ghost":
 
        break;
        case "Map":
        go.SetText("Seems like the location of the land of the soul is recorded on it");
        break;
        case "Boat":
        go.SetText("I can reach the center of the lake by this canoe");
        break;
    }
        
       
    }
    void Fadeout2()
    {
        TextMeshProUGUI go = DialogPanel.GetComponentInChildren<TextMeshProUGUI>();
        go.alpha-= Time.deltaTime*FadeSpeed;
        go.color = new Color(go.color.r, go.color.g, go.color.b,  go.alpha); 
     
    }
    void Update()
    {
        Fadeout2();

    }
}
