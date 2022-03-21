using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAction : MonoBehaviour
{
    private Animator Anim;
    private AudioSource AudioControl;
    private MusicController Clips;

    void Start()
    {
        AudioControl =GetComponent<AudioSource>();
        Clips = GetComponentInChildren<MusicController>();
        Anim = GetComponentInChildren<Animator>();
       
    }
    public void SetAnimator(Animator anim)
    {
        this.Anim = anim;
        print(Anim);
    }
    public void SetDraw()
    {
         
        AudioControl.clip = Clips.GetAudioClip(Clips.Draw);
        if(!AudioControl.isPlaying)
         AudioControl.Play();
        StopCoroutine("PlaySound");
        StartCoroutine("PlaySound");
     
        Anim.SetBool("aim",false);
    }
     public void SetShoot()
    {
         
        AudioControl.clip = Clips.GetAudioClip(Clips.Draw);
        if(!AudioControl.isPlaying)
         AudioControl.Play();
        StopCoroutine("PlaySound");
        StartCoroutine("PlaySound");
     
        Anim.SetBool("Alerted",false);
    }
    public void SetRun()
    {
        
        // AudioControl.clip = Clips.GetAudioClip(Clips.snowwalk);
        // if(!AudioControl.isPlaying)
        //  AudioControl.Play();
        // StopCoroutine("PlaySound");
        // StartCoroutine("PlaySound");
        if(Anim!=null)
        Anim.SetBool("run",true);
    }
    public void SetRunfalse()
    {
        
        // AudioControl.clip = Clips.GetAudioClip(Clips.snowwalk);
        // if(!AudioControl.isPlaying)
        //  AudioControl.Play();
        // StopCoroutine("PlaySound");
        // StartCoroutine("PlaySound");
        if(Anim!=null)
        Anim.SetBool("run",false);
    }
    public void Setwalktrue()
    {
        
        // AudioControl.clip = Clips.GetAudioClip(Clips.snowwalk);
        // if(!AudioControl.isPlaying)
        //  AudioControl.Play();
        // StopCoroutine("PlaySound");
        // StartCoroutine("PlaySound");
        if(Anim!=null)
        Anim.SetBool("walk",true);
    }
    public void Setwalkfalse()
    {
        
        // AudioControl.clip = Clips.GetAudioClip(Clips.snowwalk);
        // if(!AudioControl.isPlaying)
        //  AudioControl.Play();
        // StopCoroutine("PlaySound");
        // StartCoroutine("PlaySound");
        if(Anim!=null)
        Anim.SetBool("walk",false);
    }
    

    IEnumerable PlaySound()
    {   
        yield return null;
        AudioControl.Play();
    }
}
