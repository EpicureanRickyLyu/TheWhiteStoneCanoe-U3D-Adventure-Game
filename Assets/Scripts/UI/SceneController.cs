using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public int nowScene;
    public bool Clickable;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void ChangeScene()
    {
        if(nowScene==0)
        nowScene += 2;
        else
        nowScene+=1;
        SceneManager.LoadScene(nowScene);
        if(nowScene==5)
        nowScene=0;
    }
    void Update()
    {
        if(Clickable)
        if(Input.GetMouseButtonDown(0))
        {
            ChangeScene();
            Clickable = false;
        }
    }
}
