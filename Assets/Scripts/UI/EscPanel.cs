using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscPanel : MonoBehaviour
{
    public GameObject HelpPanel,SettingPanel;
    private bool PanelActive;
    public void Resume()
    {
        PanelActive = false;
        this.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale =1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerInfo.PlayerInstance.GetComponent<CharacterChontrol>().Resume();

    }
    private bool HelpActive,SettingActive = false;
    public void Help()
    {
        if(HelpActive == true)
        {
            HelpActive = false;
            HelpPanel.SetActive(false);     
        }
        HelpActive = true;
        HelpPanel.SetActive(true);
    }
    public void SETTING()
    {
         if(SettingActive == true)
        {
            SettingActive = false;
            SettingPanel.SetActive(false);         
        }
        SettingActive = true;
        SettingPanel.SetActive(true);

    }
    public void Exit()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!PanelActive)
            {
            PanelActive = true;
            this.transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerInfo.PlayerInstance.GetComponent<CharacterChontrol>().Pause();
            }
            else if(HelpActive)
            {
                HelpActive = false;
                HelpPanel.SetActive(false);
            }
            else if(SettingActive)
            {
                SettingActive = false;
                SettingPanel.SetActive(false);
            }
            else if(PanelActive&&!HelpActive&&!SettingActive)
            {
                Resume();
            }
        }
    }
}
