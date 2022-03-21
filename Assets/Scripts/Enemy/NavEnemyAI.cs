using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavEnemyAI : MonoBehaviour
{
       public enum State
    {
        beated,
        Alerted,
        Attack,
        PathFind,
        Dead,
        idle

    }

    private State currentState =State.PathFind;
    private Animator anim;// animname innit
    private NavigationSystem Nav;
    private EnemyStateInfo enemyStateInfo;
    public float atkTimer=0,atkinterval=3;
    public float SoundTimer = 0,Soundinterval = 5;
    private AudioSource AudioControl;
    private MusicController Clips;

    public float atk=10f;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();       
        Nav = GetComponent<NavigationSystem>();
        enemyStateInfo = GetComponent<EnemyStateInfo>();
        AudioControl =GetComponent<AudioSource>();
        Clips = MusicController._instance;
        
      

    }

    void pathfind()
    {
        // anim.Setidle();
        if(Nav.isAlert == true)
        {
            
            currentState = State.Alerted;

        }

    }
    void Alerted()
    {
        AudioControl.clip = Clips.GetAudioClip(Clips.BoarAlert);
         if(!AudioControl.isPlaying)
        {
        if(SoundTimer <=Time.time)
        {
            SoundTimer = Time.time + Soundinterval;
           
            AudioControl.Play();     
           
        }
        }
        if(Nav.isAlert == false)
        currentState = State.PathFind;
        // anim.SetAlert();
        if(Nav.isattack == true)
        {
            currentState = State.Attack ;
        }
    }
    public void BeatedState()
    {
        Nav.isAlert = true;
        this.currentState = State.beated;
    }
    void Attack()
    {
        if(Nav.isattack == false)
        currentState = State.Alerted;
        Nav.LookRotation(PlayerInfo.PlayerInstance.transform.position-this.transform.position);
        if(atkTimer <=Time.time)
        {
            
            atkTimer = Time.time + atkinterval;
            // anim.SetAttack();  
            Invoke("Attackdelay",0.2f);
        }
    }
    void Attackdelay()
    {
        AudioControl.clip = Clips.GetAudioClip(Clips.BoarAttack);
        if(!AudioControl.isPlaying)
        AudioControl.Play();
            
        PlayerInfo.PlayerInstance.Damage(atk);
        print("attack");
    }
    void Dead()
    {
        if(enemyStateInfo.HP<=0)
        {
            anim.SetTrigger("Die");
            Nav.enemyAgent.speed = 0;
            AudioControl.clip = Clips.GetAudioClip(Clips.BoarDead);
            if(!AudioControl.isPlaying)
            AudioControl.Play();

            print("death");
            currentState = State.Dead;
            enemyStateInfo.Death();
            // anim.SetDeath();
            Destroy(this.gameObject,1.5f);
            Nav.enabled = false;
            this.enabled = false;
            int a = Random.Range(0, 5);
            if(a<=2)
            ItemWorld.SpawnItemWorld(this.transform.position,new Item{itemType = Item.ItemType.Food,amount= 1});
            else
            ItemWorld.SpawnItemWorld(this.transform.position,new Item{itemType = Item.ItemType.Fur,amount= 1});
           
           
        }
      

    }
    private void Update()
    {
        
        if(currentState!=State.Dead)
        Dead();
        switch(currentState)
        {
            case State.PathFind:
            pathfind();
                break;
            case State.Attack:
            Attack();
                break;
            case State.Alerted:
            Alerted();
            break;
            case State.idle:
            // anim.Setidle();
                break;
            case State.Dead:
                break;
            case State.beated:
            // anim.SetDamaged();
            currentState = State.Alerted;
                break;

        }
    }
}
