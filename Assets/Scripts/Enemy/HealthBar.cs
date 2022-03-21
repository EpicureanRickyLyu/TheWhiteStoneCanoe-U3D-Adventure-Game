using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthBar : MonoBehaviour
{
    public GameObject HealthBarPrefab;
    public Transform HealthBarPos;

    Image HealthSlidertf;
    private Transform UIBar;
    Transform camtf;
    public bool AlwaysVisable;
    public float Visabletime=5f;
    [HideInInspector]
    public float RestVisabletime=0;
    private EnemyStateInfo enemyinfo;
    void Start()
    {
        enemyinfo = GetComponent<EnemyStateInfo>();
        camtf = Camera.main.transform;

    }
    public void OnEnable()
    {
        foreach (Canvas item in FindObjectsOfType<Canvas>())
        {
            if(item.renderMode == RenderMode.WorldSpace)
            {
                if(item.name =="WorldCanvas")
                {
                UIBar = Instantiate(HealthBarPrefab,item.transform).transform;
                HealthSlidertf = UIBar.GetChild(0).GetComponent<Image>();
                UIBar.gameObject.SetActive(AlwaysVisable);
                }
            }
        }
        
    }
    public void UpdateHealthBar()
    {
        if(enemyinfo.HP<=0)
        Destroy(UIBar.gameObject);
        

      
        UIBar.gameObject.SetActive(true);

        float a = (float)(enemyinfo.HP/enemyinfo.MaxHP);
        HealthSlidertf.fillAmount = a;

        RestVisabletime = Visabletime;
        enemyinfo.getDamage = false;

    }
    public void DelayDisapper()
    {
        if(RestVisabletime<=0&&!AlwaysVisable)
        {
          
            UIBar.gameObject.SetActive(false);
        }
        else
        {
            RestVisabletime-=Time.deltaTime;
        }
    }
    void LateUpdate()
    {
        if(UIBar!=null)
        {
        UIBar.position = HealthBarPos.position;
        UIBar.forward = -camtf.forward;
        if(enemyinfo.getDamage)
        UpdateHealthBar();

        DelayDisapper();

        }

 
    }
}
