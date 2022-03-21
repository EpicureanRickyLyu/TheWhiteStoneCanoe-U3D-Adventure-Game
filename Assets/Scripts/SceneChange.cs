using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject BlackMask;
    public float loaddelay;
    void OnTriggerEnter(Collider collider)
    {
        
        if(collider.transform.root.tag == "Player")
        {
        BlackMask = GameObject.FindGameObjectWithTag("BlackMask");
        BlackMask.GetComponent<Animator>().SetTrigger("Fadeout");
        print("ChangeScene");
        Invoke("LoadDelay",loaddelay);
        }
        
    }
    private void LoadDelay()
    {
        SceneManager.LoadScene(0);
    }
}
