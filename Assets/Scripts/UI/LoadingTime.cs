using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingTime : MonoBehaviour
{
    public float Loadtime=1f;
    private Image go;
    private GameObject SceneControl;
    void Start()
    {
       go = this.GetComponent<Image>();
       SceneControl = GameObject.FindGameObjectWithTag("SceneController");
    }
    public void EndLoad()
    {
        Debug.Log(SceneControl.GetComponent<SceneController>().nowScene);
        switch(SceneControl.GetComponent<SceneController>().nowScene)
        {
            case 0:
            this.transform.root.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Chapter 0 :\n" +
        "The old man in the village once said that in the extreme south, I can reach the Land of Souls, and maybe I can find my lost wife there."; 
            break;
            case 2:
            this.transform.root.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Chapter 1 :\n" +
        "According to the legends of the village, it should be possible to reach the land of souls through this snow field. But I can't find the way in the snow, maybe this is the test of the master of the soul."; 
            break;
            case 3:
            this.transform.root.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Chapter 2 :\n" +
        "Sanskrit in ancient books turned out to be the direction of the land of the soul, and success was at hand";
            break;
        }
        
        if(go.fillAmount==1)
        {
            Invoke("LoadDelay",0.5f);      
        }
    }
    private void LoadDelay()
    {
        this.transform.root.GetChild(1).gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>().Clickable = true;
    }
    void Update()
    {
        go.fillAmount += 1/Loadtime*Time.deltaTime;
        EndLoad();
        
    }
}
