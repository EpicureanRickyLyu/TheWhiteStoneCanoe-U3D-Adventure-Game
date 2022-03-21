using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavigationSystem : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public GameObject player;
    public GameObject waylineParent;
    public float Alertdistance;
    private WayLine line;
    public float DetectAngle;
    private int index;
    public float rotatespeed=1f;
    [HideInInspector]
    public bool isAlert=false;

    public float Attackdistance = 5f;
    [HideInInspector]
    public bool isattack = false;
    public float AlertSpeed = 5f,PatrolingSpeed = 5f;

    private GameObject attackArea;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        print(player);
        enemyAgent = GetComponent<NavMeshAgent>();
        CulculateWayLine();
        DrawAttackArea(enemyAgent.transform,DetectAngle,Alertdistance);
        
    }
    public void LookRotation(Vector3 targetPos)
    {
        // targetpos should be a Vector   
        Quaternion look =  Quaternion.LookRotation(targetPos);
        Quaternion lookLerp = Quaternion.Slerp(this.transform.rotation, look,rotatespeed);
        this.transform.rotation = lookLerp;
    
        // this.transform.LookAt(targetPos);

    }   
    public void Patrol()
    {
        enemyAgent.speed = PatrolingSpeed;
        print("is patroling");
        DrawAttackArea(enemyAgent.transform,DetectAngle,Alertdistance);
        isAlert = false;
        if(!enemyAgent.pathPending&&enemyAgent.remainingDistance < 0.5f)
        {
        if(line.WayPoint.Length<=0||line==null)
        return;
        enemyAgent.destination = line.WayPoint[index];
        index=(index+1)%line.WayPoint.Length;
        }
     
    }
    private void CulculateWayLine()
    {
            Transform roottf = waylineParent.transform;
            int pointcount = roottf.childCount;
            line = new WayLine(pointcount);
            for (int pointindex = 0; pointindex < pointcount; pointindex++)
            {
                line.WayPoint[pointindex] = roottf.GetChild(pointindex).transform.position;
            }
    }
    public void Detectmodel()
    {
        float dis = Vector3.Distance(player.transform.position,enemyAgent.transform.position);
        float dot = Vector3.Dot(enemyAgent.transform.forward,player.transform.position-enemyAgent.transform.position);
        float angel = Vector3.Angle(enemyAgent.transform.forward,player.transform.position-enemyAgent.transform.position);
        // Detect area
        if(dis<Alertdistance&&dot>0 && angel<DetectAngle/2)
        {
            if(dis<=Attackdistance)
            {
                isattack = true;
                enemyAgent.destination = this.transform.position;
            }
            else
            {
                isattack = false;
                enemyAgent.destination =player.transform.position;
            }
            
            isAlert = true;
            Destroy(attackArea);   
        }
        else
        {
            Patrol();
            
        }
        
    }
    private int Alettime = 0;
    public void Alertedmodel()
    {
        
        float dis = Vector3.Distance(player.transform.position,enemyAgent.transform.position);
        float dot = Vector3.Dot(enemyAgent.transform.forward,player.transform.position-enemyAgent.transform.position);
        float angel = Vector3.Angle(enemyAgent.transform.forward,player.transform.position-enemyAgent.transform.position);
        enemyAgent.speed = AlertSpeed;
        if(Alettime>=1&&dis>Alertdistance&&angel>=DetectAngle/2)
        {
            Alettime = 0;
            
            isAlert = false;
            Patrol();
            return;
        }
        if(dis<=Attackdistance)
        {
            isattack = true;
            Alettime++;
            enemyAgent.destination = this.transform.position;
        
        }
        else
        {
            isattack = false;
            enemyAgent.destination =player.transform.position;
        }
        isAlert = true;
        Destroy(attackArea);   


    }
    public void DrawAttackArea(Transform t, float angle, float radius)
    {
        if(attackArea!=null)
        return;
        int segments = 100;
        float deltaAngle = angle / segments;
        Vector3 forward = t.forward;
 
        Vector3[] vertices = new Vector3[segments + 2];
        vertices[0] = t.position;
        for (int i = 1; i < vertices.Length; i++)
        {
            Vector3 pos = Quaternion.Euler(0f, -angle / 2 + deltaAngle * (i - 1), 0f) * forward * radius + t.position;
            vertices[i] = pos;
        }
        int trianglesAmount = segments;
        int[] triangles = new int[segments * 3];
        for (int i = 0; i < trianglesAmount; i++)
        {
            triangles[3 * i] = 0;
            triangles[3 * i + 1] = i + 1;
            triangles[3 * i + 2] = i + 2;
        }
 
        GameObject go = new GameObject("AttackArea");
        go.transform.position = new Vector3(0, 0.1f, 0);
        go.transform.SetParent(transform);
        MeshFilter mf = go.AddComponent<MeshFilter>();
        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        Mesh mesh = new Mesh();
        mr.material.shader = Shader.Find("Universal Render Pipeline/Unlit");
        mr.material.color = Color.red;
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mf.mesh = mesh;
        attackArea = go.gameObject;
    }
    void Update()
    {
        if(isAlert==false)
        Detectmodel();   
        else
        {
            Alertedmodel();
        }
    }
}
