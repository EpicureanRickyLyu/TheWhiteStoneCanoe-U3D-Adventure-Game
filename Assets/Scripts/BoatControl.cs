using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControl : MonoBehaviour
{
    public float rotateSpeed,movespeed;

    public bool drivemodel=false;

      private void ThridViewMoveCharacter()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        if(MoveX!=0||MoveY!=0)
        {
        this.transform.Rotate(new Vector3(0,MoveX,0));
        // Quaternion rot = Quaternion.Euler(MoveX*Time.deltaTime,0,0);
        // Quaternion rot2 = Quaternion.Lerp(this.transform.rotation,rot,rotateSpeed);
        // this.transform.rotation = rot2;
        
        this.transform.Translate(0,0,MoveY*movespeed*Time.deltaTime);
        GetComponentInChildren<Animator>().SetBool("Driving",true);

        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("Driving",false);

        }
        

    }
    public void GetOff()
    {
        drivemodel = false;
        GetComponentInChildren<Animator>().SetBool("Driving",false);
    }
    void Update()
    {
        if(drivemodel)
        ThridViewMoveCharacter();
        

    }
}
