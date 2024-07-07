using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobspawn : MonoBehaviour
{
  //wallspawnvariables
    [SerializeField]
    public GameObject wallPrefab;
    public Transform[] gates; // Array of gate transforms
    public float minX = -3.2f;
    public float maxX = 3.2f;
    public float minDistance = 70f; // Minimum distance to other objects
    RaycastHit hit2;
    public float spawnRange = 80f; // Range within which walls can spawn in front of the spawner
    public int numWallsToSpawn = 2; // Number of walls to spawn each time
    [SerializeField]
    GameObject bag;
//laserspawnvariables
    float min;
    float max;
    float zposlaser;
    float yposlaser;
    float xposlaser;
    [SerializeField]
    GameObject spawner;
    
    GameObject obj;
    [SerializeField]
    GameObject laser;
    [SerializeField]
    GameObject movinglaser;
    GameObject player;
    bool spawn;
    bool ismoving;
    RaycastHit hit;
    
    void Awake()
    {
       
        spawn = true;
        player = GameObject.FindWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z-player.transform.position.z<=-150f)
        {
            
            Destroy(gameObject);
        }
        if(transform.position.z-player.transform.position.z<=60f&&spawn)
        {
        Instantiate(spawner, transform.position + new Vector3(0, 0, 50), transform.rotation);

        Laserspawn();
        //Wallspawn();
        bagspawn();
        spawn = false;
       
        }
    }
    
    void Laserspawn()
    {
        
        min = transform.position.z+20;
        max = transform.position.z+120;
        for(int i = 0;i<6;i++)
        {
            ismoving=(Random.Range(0,50)<11);
        zposlaser=Random.Range(min,max);
        yposlaser=Random.Range(0.22f,10.06f);
        if(ismoving)
        {
            float rotation;
            bool isopposite = Random.Range(0,180)<=90;
            if (isopposite)
            rotation = 180f;
            else 
            rotation=0f;
            bool isdouble = Random.Range(0,180)<=40;
            if(isdouble)
            {
                GameObject obj2 = Instantiate(movinglaser,new Vector3(4.22f,5f,zposlaser),Quaternion.Euler(new Vector3(0f,-90f,rotation-180f)));
                obj2.transform.SetParent(gameObject.transform);
            }
            obj = Instantiate(movinglaser,new Vector3(-4.22f,5,zposlaser),Quaternion.Euler(new Vector3(0f,90f,rotation)));
        }
        else
         obj = Instantiate(laser,new Vector3(-4.22f,yposlaser,zposlaser),Quaternion.Euler(new Vector3(0f,0f,-90f)));
        
        if(Physics.Raycast(obj.transform.position,Vector3.forward*-5,out hit))
        {
            if(hit.collider.CompareTag("gate"))
            {
                obj.transform.position+=new Vector3(0,0,10);
            }
        }
        StartCoroutine(DestroyAfterDelay(100f,obj));

    }
    }
     private IEnumerator DestroyAfterDelay(float delay,GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
   void Wallspawn()
   {
     float currentMinZ = transform.position.z;
        float currentMaxZ = currentMinZ + spawnRange;

        // Loop to spawn walls
        for (int i = 0; i < numWallsToSpawn; i++)
        {
            // Generate random position within spawn range ahead of spawner
            Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 5f, Random.Range(currentMinZ, currentMaxZ));
            GameObject wallpref = Instantiate(wallPrefab, randomPosition, Quaternion.identity);
            if(Physics.Raycast(wallpref.transform.position,wallPrefab.transform.forward*-13, out hit))
            {
                if(hit.collider.gameObject.CompareTag("gate")||hit.collider.gameObject.CompareTag("gatesides")){
            
                    Destroy(wallpref);
                }
                if(Physics.Raycast(wallpref.transform.position,wallPrefab.transform.forward*-13, out hit))
                {
                   if( hit.collider.gameObject.CompareTag("gate")||hit.collider.gameObject.CompareTag("gatesides"))
                   Destroy(wallpref);
                }
            }
            if(wallpref!=null)
            {
                wallpref.transform.SetParent(gameObject.transform);
            }

        }
    }

    void bagspawn()
    {
        Instantiate(bag,new Vector3(Random.Range(minX,maxX),2f,Random.Range(min,max)),Quaternion.identity);
    }
   
    }


