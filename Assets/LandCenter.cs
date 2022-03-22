using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCenter : MonoBehaviour
{
    public GameObject Boat;
    void Start()
    {

    }
    void OnTriggerEnter(Collider collider)
    {   
        if(collider.tag =="Boat")
        {
            Debug.Log("boat in");
            Boat.GetComponent<BoatControl>().GetOff();
           
            PlayerInfo.PlayerInstance.GetComponent<CharacterChontrol>().Movable = true;
            PlayerInfo.PlayerInstance.GetComponent<CharacterChontrol>().bootmodel = false;
            PlayerInfo.PlayerInstance.GetComponentInChildren<ItemAction>().boatmodel = false;
        }
    }
}
