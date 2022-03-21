using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    private Rigidbody rb;
    public bool didHit;
    public float atk;
    public GameObject effect;
    void Start()
    {
        if(this.GetComponentInParent<Rigidbody>()!=null)
        Destroy(this.transform.parent.gameObject,3f);
        
    }
    void OnTriggerEnter(Collider collider)
    {
        
        if(collider.tag == "Enemy")
        didHit = true;
        if(collider.name == "Target")
        {
            Debug.Log("yes");
            this.GetComponentInParent<Rigidbody>().Sleep();
              
        }
  

        if(didHit)
        {
        
            collider.transform.root.GetComponent<EnemyStateInfo>().Damage(atk);
            Destroy(this.transform.parent.gameObject);
        }
        // if(collider.name!="Player")
        // Destroy(this.transform.parent.gameObject);
    }
    void GenerateEffect(Collider collider)
    {
        
        Instantiate(effect,collider.transform.position,Quaternion.identity);
        effect.GetComponent<ParticleSystem>().Play();
        if(effect.GetComponent<ParticleSystem>().isStopped)
        GameObject.Destroy(effect,0.5f);
    }
    
}
