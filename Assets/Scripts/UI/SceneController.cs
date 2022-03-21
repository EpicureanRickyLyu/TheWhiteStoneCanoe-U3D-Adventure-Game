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
        nowScene += 1;
        SceneManager.LoadScene(nowScene);
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
