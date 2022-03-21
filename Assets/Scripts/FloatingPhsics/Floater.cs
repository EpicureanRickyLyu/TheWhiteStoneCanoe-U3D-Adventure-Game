using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float DepthBeforeSubmerged = 0.5f;
    public float Displacementamount = 3f;
    

    void FixedUpdate()
    {
        Debug.Log("FLOAT");
        float waveheight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if(this.transform.position.y < 5f)
        {
            // rigidBody.AddForce(new Vector3(0f,Mathf.Abs(Physics.gravity.y), 0f),ForceMode.Acceleration);
            float DisplacementMultiplier = Mathf.Clamp01(transform.position.y/DepthBeforeSubmerged) * Displacementamount;
            rigidBody.AddForce(new Vector3(0f,Mathf.Abs(Physics.gravity.y)*DisplacementMultiplier, 0f),ForceMode.Acceleration);

        }
    }

}
