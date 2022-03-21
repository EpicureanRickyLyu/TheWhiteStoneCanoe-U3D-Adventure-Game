using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Material mat;
    public float thickness = 1.15f;
    public Color ColorOutline = Color.red;
    public float _LightSpeed = 0.1f;
    private Renderer rend;
    void Start()
    {

        
    }
    public void init()
    {
        GameObject outlineObject = Instantiate(this.gameObject,this.transform.position,this.transform.rotation);
        outlineObject.transform.localScale = new Vector3(1,1,1);
        rend = outlineObject.GetComponent<Renderer>();
        rend.material = mat;
        rend.material.SetFloat("_Thickness",thickness);
        // rend.material.SetColor("_OutlineColor",ColorOutline);
        rend.material.SetFloat("_LightSpeed",_LightSpeed);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        rend.enabled = false; 
        outlineObject.GetComponent<Collider>().enabled = false;
        rend.transform.SetParent(this.transform);
    }
    private void OnMouseEnter()
    {
        if(rend == null)
        init();
        rend.enabled = true;

    }
    private void OnMouseDrag()
    {
        
    }
     private void OnMouseExit()
    {
        rend.enabled = false;
        Destroy(rend.gameObject);
    }
    void Update()
    {
        
    }
}
