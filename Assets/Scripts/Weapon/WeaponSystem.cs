using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] int WeaponNum;
    public GameObject NowWeapon;

    public void ChangeWeapon()
    {
        
        WeaponNum = this.transform.childCount;
        for (int i = 0; i < WeaponNum; i++)
        {
            if(i == WeaponNum-1)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
                this.transform.GetChild(0).gameObject.SetActive(true);   
                NowWeapon = this.transform.GetChild(0).gameObject;
                this.transform.root.GetComponent<AnimatorAction>().SetAnimator(this.transform.GetChild(0).GetComponent<Animator>());
                return;
            }
            if(this.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
                this.transform.GetChild(i+1).gameObject.SetActive(true);   
                NowWeapon  = this.transform.GetChild(i+1).gameObject;
                this.transform.root.GetComponent<AnimatorAction>().SetAnimator(this.transform.GetChild(0).GetComponent<Animator>());
                return;
            }
            
        }
         
    }
}
