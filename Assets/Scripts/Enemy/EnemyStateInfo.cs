using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateInfo : MonoBehaviour
{
    public float HP =200;
    public float MaxHP = 200;
    [HideInInspector]
    public bool getDamage = false;
    public void Damage(float amount)
    {
        HP -= amount;
        this.getDamage = true;
        if(this.GetComponent<NavEnemyAI>()!=null)
        this.GetComponent<NavEnemyAI>().BeatedState();
        // if(this.GetComponent<EnemyAI>()!=null)
        // this.GetComponent<EnemyAI>().BeatedState();
      
    }
    public void Death()
    {

        this.enabled = false;
 
    }

}
