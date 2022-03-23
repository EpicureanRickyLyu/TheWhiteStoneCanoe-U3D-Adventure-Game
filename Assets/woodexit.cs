using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodexit : MonoBehaviour
{
    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player")
        {
            AudioSource go = PlayerInfo.PlayerInstance.GetComponent<CharacterChontrol>().SoundControl;
            go.clip = MusicController._instance.GetAudioClip(MusicController._instance.Groundwalk);
            PlayerInfo.PlayerInstance.GetComponent<CharacterChontrol>().outroom = true;

        }

    }
}
