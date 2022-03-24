using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowarrow : MonoBehaviour
{
    public int Arrownum = 20;
    private Rigidbody rg;
    public float AimmingSpeed =0.1f;
    private float shootstrength;
    public float MaxStrength=1f;
    public Transform FirePoint; 
    public float ArrowSpeed=15f;
    public GameObject Arrows,Arrows1;
    public AudioSource SoundControl;
    private Transform ArrowPosOnBow;
    private GameObject lyu;

    void Start()
    {
        rg = this.GetComponent<Rigidbody>();
        ArrowPosOnBow = this.transform.GetChild(1);
    }
    void Draw()
    {
        
        shootstrength = 0;
        if(Input.GetMouseButtonDown(0))
        {
            lyu = Instantiate(Arrows1,ArrowPosOnBow.transform.position,Quaternion.identity,ArrowPosOnBow) as GameObject;
            ResetTransform(lyu);
            //draw
            SoundControl.clip = MusicController._instance.GetAudioClip(MusicController._instance.DrawBow);
            SoundControl.Play();
            
        }
        if(Input.GetMouseButton(0))
        {
            
           
            shootstrength+=Time.deltaTime;
            if(shootstrength>=MaxStrength)
            shootstrength = MaxStrength;
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            Destroy(lyu);
            Transform ArrowPos =  FirePoint.transform.GetChild(0);
            GameObject go = Instantiate(Arrows,ArrowPos.transform.position,Quaternion.identity) as GameObject;
            go.transform.SetParent(ArrowPos);
            ResetTransform(go);
            ArrowPos.DetachChildren();
            Fire(go);
        }
    }
    void Fire(GameObject go)
    {
        // release
        SoundControl.clip = MusicController._instance.GetAudioClip(MusicController._instance.Draw);
        SoundControl.Play();


        go.GetComponent<Rigidbody>().velocity = FirePoint.transform.forward*ArrowSpeed;
    }
    void ResetTransform(GameObject go)
    {
        go.transform.localPosition = Vector3.zero;
        go.transform.localEulerAngles = Vector3.zero;
        go.transform.localScale = new Vector3(1,1,1);
    }
    void Aimming()
    {
        Camera MyCamera = Camera.main;
        if(Input.GetMouseButton(0))
        {
            
            this.GetComponent<Animator>().SetBool("aim",true);
            MyCamera.fieldOfView = Mathf.Lerp(MyCamera.fieldOfView,40,AimmingSpeed);
            if(Mathf.Abs(MyCamera.fieldOfView - 40)<=0.1f)
            MyCamera.fieldOfView = 40;   
           
        }
        else
        {
            
            this.GetComponent<Animator>().SetBool("aim",false);
            MyCamera.fieldOfView = Mathf.Lerp(MyCamera.fieldOfView,60,AimmingSpeed);
            if(Mathf.Abs(MyCamera.fieldOfView - 60)<=0.1f)
            MyCamera.fieldOfView = 60;  
           
        }
        
    }
    void Update()
    {
        Aimming();
        Draw();

    }

}
