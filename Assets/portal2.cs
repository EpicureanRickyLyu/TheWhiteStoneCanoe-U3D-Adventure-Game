using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class portal2 : MonoBehaviour
{
private GameObject blackmask;
void Start()
{
    blackmask = GameObject.FindGameObjectWithTag("BlackMask");
}
void LoadScene1()
{
        SceneManager.LoadScene(5);
}
 void OnTriggerEnter(Collider collider)
    {
        if(collider.tag=="Player")
        {
            Debug.Log("Potal_2");
            blackmask.GetComponent<Animator>().SetTrigger("Fadeout");
            Invoke("LoadScene1",2f);
        }

    }
}
