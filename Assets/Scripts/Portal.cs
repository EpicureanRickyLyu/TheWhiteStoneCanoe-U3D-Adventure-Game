using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float  rotatespeed = 0.1f;
    public void LookRotation(Vector3 targetPos)
    {
        // targetpos should be a Vector   
        Quaternion look =  Quaternion.LookRotation(targetPos);
        Quaternion lookLerp = Quaternion.Slerp(this.transform.rotation, look,rotatespeed);
        this.transform.rotation = lookLerp;
    
        // this.transform.LookAt(targetPos);

    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag=="Player")
        {
            Debug.Log("Potal_1");
        }

    }
    void Update()
    {
        
        
    }
}
