using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private GameObject exit;
    void Start()
    {

        exit = GameObject.Find("Exit");
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collision");
        if(collider.tag=="Player")
        {
            Debug.Log("Playerin");
            if(PlayerInfo.PlayerInstance.GetComponent<CharacterChontrol>().itemControl.HaveMap())
            {
                Debug.Log("Have map");
                PlayerInfo.PlayerInstance.GetComponentInChildren<DialogController>().SetTemporaryText("The map shows is here. I heard that the objects in the land of the soul have no entity, and these stones should be fake.");
                exit.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                Debug.Log("dont Have map");
                PlayerInfo.PlayerInstance.GetComponentInChildren<DialogController>().SetTemporaryText("I can`t pass these stone");
            }
        }
    }
}
