using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCenter : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {   
        if(collider.tag =="Boat")
        {
            Debug.Log("boat in");
            collider.transform.root.GetComponent<BoatControl>().GetOff();

            PlayerInfo.PlayerInstance.transform.SetParent(null,true);
            PlayerInfo.PlayerInstance.transform.position = PlayerInfo.PlayerInstance.transform.TransformPoint(PlayerInfo.PlayerInstance.transform.position);
           
            PlayerInfo.PlayerInstance.GetComponent<CharacterChontrol>().Movable = true;
            PlayerInfo.PlayerInstance.GetComponent<CharacterChontrol>().bootmodel = false;

        }
    }
}
