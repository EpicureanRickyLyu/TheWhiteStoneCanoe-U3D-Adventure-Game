using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropIntoWater : MonoBehaviour
{
    public GameObject BlackMask;
    void Start()
    {
        BlackMask = GameObject.FindGameObjectWithTag("BlackMask");
    }
    void OnTriggerEnter(Collider collider)
    {   
        if(collider.tag =="Player")
        {
            BlackMask.GetComponent<Animator>().SetTrigger("Fadeout");
            BlackMask.GetComponent<Animator>().speed = 2f;
            Invoke("ReLoad",1f);
            
        }
    }
    void ReLoad()
    {
        SceneManager.LoadScene(3);

    }
}
