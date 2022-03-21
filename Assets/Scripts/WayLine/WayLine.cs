using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayLine
{
    public Vector3[] WayPoint{get;set;}

    
    public bool IsUsable{get;set;}

    public WayLine(int watPointNum)
    {
        WayPoint =new Vector3[watPointNum];
        IsUsable = true;
    
    }


    

}
