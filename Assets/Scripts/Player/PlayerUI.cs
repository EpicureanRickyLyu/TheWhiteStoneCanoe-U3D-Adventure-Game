using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject HpBar,EnduranceBar,ColdBar,AttackedPanel;
    public float ColdLoseSpeed,EndurLossSpeed;
    void Start()
    {
        HpBar=this.transform.GetChild(0).gameObject;
        EnduranceBar = this.transform.GetChild(1).gameObject;
        ColdBar = this.transform.GetChild(2).gameObject;
        AttackedPanel = this.transform.GetChild(3).gameObject;
        
    }
    public void AttackedEffect()
    {
        AttackedPanel.SetActive(true);
        Invoke("AttackedEffectgone",0.2f);

    }
    private void AttackedEffectgone()
    {
        AttackedPanel.SetActive(false);
    }
    public void UpdateHealthBar()
    {
        if(HpBar!=null)
        HpBar.transform.GetChild(0).GetComponent<Image>().fillAmount = (float)(PlayerInfo.PlayerInstance.HP/PlayerInfo.PlayerInstance.MaxHP);

    }
    public void UpdateEnduranceBar()
    {
        
        float value = Time.deltaTime*EndurLossSpeed;
        if(EnduranceBar!=null)
        EnduranceBar.transform.GetChild(0).GetComponent<Image>().fillAmount += value;
    }
    public void DecreaceEndurance()
    {
        float value = Time.deltaTime*EndurLossSpeed;
        EnduranceBar.transform.GetChild(0).GetComponent<Image>().fillAmount -= value;
    }
    public void UpdateColdBar()
    {
        float value = Time.deltaTime*ColdLoseSpeed;
        ColdBar.transform.GetChild(0).GetComponent<Image>().fillAmount -= value;
    }
    public void GetWorm(float value)
    {
        ColdBar.transform.GetChild(0).GetComponent<Image>().fillAmount+=value;
    }
    void Update()
    {
        UpdateHealthBar();
        UpdateColdBar();
        if(Input.GetKey(KeyCode.LeftShift))
        {
           DecreaceEndurance();
        }
        else
        UpdateEnduranceBar();
        
    }
}
