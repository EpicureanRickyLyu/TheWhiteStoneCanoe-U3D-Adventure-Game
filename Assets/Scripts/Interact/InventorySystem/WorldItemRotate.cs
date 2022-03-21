using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemRotate : MonoBehaviour
{
    public float RotateSpeed;
      public void LookRotation(Vector3 targetPos)
    {
        float angle = Vector3.Angle(this.transform.up,targetPos-this.transform.position);
        Debug.Log(angle);
        float Remainangle = Mathf.LerpAngle(angle,0,RotateSpeed);
        if(angle!=0)
        this.transform.Rotate(new Vector3(RotateSpeed,0,0));
    

        // targetpos should be a Vector   
        // Quaternion look =  Quaternion.LookRotation(targetPos);
        // Quaternion lookLerp = Quaternion.Slerp(this.transform.rotation, look,RotateSpeed);
        // this.transform.rotation = lookLerp;
    
        // this.transform.LookAt(targetPos);

    }
    void Update()
    {
        
        
    }
}
