using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    private GameObject startob,startob2;
    void Start()
    {
        startob = GameObject.Find("Portal");
        startob2 = GameObject.FindGameObjectWithTag("BlackMask");
    }
    void LoadScene0()
    {
         SceneManager.LoadScene(1);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startob2.GetComponent<Animator>().SetTrigger("Fadeout");
            // startob.GetComponentInChildren<Animator>().SetTrigger("start");
            Invoke("LoadScene0",2f);
           

        }
    }
}
