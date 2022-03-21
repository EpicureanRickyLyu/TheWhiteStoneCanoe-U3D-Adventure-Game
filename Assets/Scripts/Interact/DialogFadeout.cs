using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogFadeout : MonoBehaviour
{
    public float alpha=1,FadeSpeed;
    void Start()
    {
        
    }
    void Fadeout()
    {
     
        alpha -= Time.deltaTime*FadeSpeed;
        gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, alpha); 
        if(alpha<=0)
        this.gameObject.SetActive(false);
     
    }
    void Update()
    {
        Fadeout();
    }
}
