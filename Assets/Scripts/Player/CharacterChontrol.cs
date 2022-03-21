using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChontrol : MonoBehaviour
{
    CharacterController playerController;

    Vector3 direction;

    private float speed = 4;
    public float runspeed = 7,walkspeed=4;
    public float jumpPower = 5;
    public float gravity = 9.8f;

    public float mousespeed = 5f;


    public float minmouseY = -45f;
    public float maxmouseY = 45f;

    float RotationY = 0f;
    float RotationX = 0f;

    public Transform agretctCamera;
    private GameObject UIControl;
    public bool Movable = true;
    private WeaponSystem WeaponControl;
    public ItemAction itemControl;
    private GameObject Mapcamera;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerController = this.GetComponent<CharacterController>();
        UIControl = GameObject.FindGameObjectWithTag("PlayerInfo");
        WeaponControl = this.GetComponentInChildren<WeaponSystem>();
        itemControl = this.transform.GetChild(0).GetComponentInChildren<ItemAction>();
        Mapcamera = GameObject.FindGameObjectWithTag("Map");
        if(Mapcamera!=null)
        Mapcamera.SetActive(false);
        Movable = true;
        
    }
    public void GetWorm(float value)
    {
        UIControl.GetComponent<PlayerUI>().GetWorm(value);
    }
    public void Pause()
    {
        this.enabled = false;
        if(WeaponControl!=null)
        if(WeaponControl.NowWeapon!=null)
        WeaponControl.NowWeapon.GetComponent<Bowarrow>().enabled = false;
    }
    public void Resume()
    {
        this.enabled = true;
        if(WeaponControl!=null)
        if(WeaponControl.NowWeapon!=null)
        WeaponControl.NowWeapon.GetComponent<Bowarrow>().enabled = true;
    }
    private void CamMoveControl()
    {
        
        playerController.Move(playerController.transform.TransformDirection(direction * Time.deltaTime * speed));

        RotationX += agretctCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mousespeed;
      
        

        RotationY -= Input.GetAxis("Mouse Y") * mousespeed;
        RotationY = Mathf.Clamp(RotationY, minmouseY, maxmouseY);
    
        this.transform.eulerAngles = new Vector3(0, RotationX, 0);

        agretctCamera.transform.eulerAngles = new Vector3(RotationY, RotationX, 0);
    }

    private void MapControl()
    {
        float value = Input.GetAxis("Mouse ScrollWheel");//0.1-0.2
        float OriginalScale = Mapcamera.GetComponent<Camera>().orthographicSize;
        if(OriginalScale<=100)
        {
            Mapcamera.GetComponent<Camera>().orthographicSize= 100;
        }
        if(OriginalScale>=350)
        {
            Mapcamera.GetComponent<Camera>().orthographicSize= 350;
        }
        if(value<0)
        {
            Mapcamera.GetComponent<Camera>().orthographicSize = Mathf.Lerp(OriginalScale,OriginalScale+=value*1000,0.1f);
        }   
        if(value>0)
        {
            Mapcamera.GetComponent<Camera>().orthographicSize = Mathf.Lerp(OriginalScale,OriginalScale+=value*1000,0.1f);
        }   
        
    }
    private void PlayerMoverControl()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

 
        if (playerController.isGrounded)
        {
            direction = new Vector3(_horizontal, 0, _vertical);
            if (Input.GetKeyDown(KeyCode.Space))
                direction.y = jumpPower;
        }
        direction.y -= gravity * Time.deltaTime;

        if(_horizontal!=0||_vertical!=0)
        {
            this.GetComponent<AnimatorAction>().Setwalktrue();
            if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(UIControl.GetComponent<PlayerUI>().EnduranceBar.transform.GetChild(0).GetComponent<Image>().fillAmount != 0)
        {
            speed=runspeed;
            this.GetComponent<AnimatorAction>().SetRun();
        }
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
      
        this.GetComponent<AnimatorAction>().SetRunfalse();
        this.GetComponent<AnimatorAction>().Setwalktrue();
        speed = walkspeed;
    
        }

        }
        else
        {
             speed=walkspeed;
            this.GetComponent<AnimatorAction>().SetRunfalse();
            this.GetComponent<AnimatorAction>().Setwalkfalse();

        }       

    }
    private bool mapactive = false;
    void Update()
    {
        if(mapactive)
        {
            MapControl();
        }
        else
        {
            if(Mapcamera!=null)
            Mapcamera.GetComponent<Camera>().orthographicSize = 250;
        }
        

        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(itemControl.HaveBow())
            WeaponControl.ChangeWeapon();   
        }
        if(Input.GetKeyDown(KeyCode.M)||Input.GetMouseButtonDown(2))
        {
            if(itemControl.HaveMap())
            {
                if(!mapactive)
                {
                mapactive =true;
                Mapcamera.SetActive(true); 
                }
                else
                {           
                Mapcamera.SetActive(false);
                mapactive =false;
                } 
            }          
        }
        if(Input.GetMouseButtonUp(2))
        {
            Mapcamera.SetActive(false);
            mapactive =false;   
        }


        if(Movable)
        {
            PlayerMoverControl();
            CamMoveControl();
        }


    }
}
