using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal2 : MonoBehaviour
{
 void OnTriggerEnter(Collider collider)
    {
        if(collider.tag=="Player")
        {
            Debug.Log("Potal_2");
        }

    }
}
