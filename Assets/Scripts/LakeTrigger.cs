using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LakeTrigger : MonoBehaviour
{
    public GameObject DialogPanel; 
    public GameObject Boat; 
    private Vector3 a ;
    public float BackDistance=10;

    void Start()
    {
     
        Boat = GameObject.Find("BoatControl");
    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.tag=="Boat")
        {
            Debug.Log("Go out");
            DialogPanel.SetActive(true);
            DialogPanel.GetComponentInChildren<TextMeshProUGUI>().SetText("I should go to the center of the lake");
            DialogPanel.GetComponent<DialogFadeout>().alpha=0.5f;
            DialogPanel.GetComponentInChildren<TextMeshProUGUI>().alpha = 0.5f;
            
            Boat.transform.Translate(0,0,-BackDistance);
        }
    }
}
