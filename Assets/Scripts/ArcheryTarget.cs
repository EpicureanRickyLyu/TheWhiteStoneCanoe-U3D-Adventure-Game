using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcheryTarget : MonoBehaviour
{
    public GameObject arrow;
    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.parent.name=="arrows(Clone)")
        {
           
            Debug.Log("shoot");
            arrow.SetActive(true);

        }

    }
}
