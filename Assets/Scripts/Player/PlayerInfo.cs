using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo PlayerInstance {get;private set;}
    public float HP=200;
    public float MaxHP=200;
    public PlayerUI infoUI;
    public GameObject DeathPanel;
    void Awake()
    {
        PlayerInstance = this;
        
     
    }
    public void Damage(float x)
    {
        this.HP-=x;
        if(HP<=0)
        {
            Death();
        }
        // animation in UI : like red effect
        infoUI.AttackedEffect();
    }
    public bool DeathActive = false;
    public void Death()
    {
        Time.timeScale = 0;
        DeathPanel.SetActive(true);
        DeathActive = true;

        this.GetComponent<CharacterChontrol>().Pause();

    }
    public void Restart()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
        print("restart");

    }
    void Update()
    {
        if(DeathActive&&Input.GetMouseButtonDown(0))
        {
            Restart();
        }
    }
}
