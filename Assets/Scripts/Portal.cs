using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public float  rotatespeed = 0.1f;
    private GameObject blackmask;
    void Start()
    {
        blackmask = GameObject.FindGameObjectWithTag("BlackMask");
    }
    public void LookRotation(Vector3 targetPos)
    {
        // targetpos should be a Vector   
        Quaternion look =  Quaternion.LookRotation(targetPos);
        Quaternion lookLerp = Quaternion.Slerp(this.transform.rotation, look,rotatespeed);
        this.transform.rotation = lookLerp;
    
        // this.transform.LookAt(targetPos);

    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag=="Player")
        {
            Debug.Log("Potal_1");
            blackmask.GetComponent<Animator>().SetTrigger("Fadeout");
            Invoke("LoadScene1",2f);
        }
    }
    void LoadScene1()
    {
        SceneManager.LoadScene(5);
    }
    void Update()
    {
        
        
    }
}
