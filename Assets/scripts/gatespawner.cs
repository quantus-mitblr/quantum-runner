using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gatespawner : MonoBehaviour
{    [SerializeField]
    GameObject wallprefab;
     [SerializeField]
    GameObject [] gates = new GameObject[2];
    [SerializeField]
    GameObject laser;
    [SerializeField]
    GameObject movinglaser;
    GameObject obj2;
    int numgate;
    float zposgate;
    float zposlaser;
    float yposlaser;
    float xposlaser;
    float min;
    float max;
    bool ismoving;
    RaycastHit hit;
    void Awake()
    {
        min = transform.position.z;
        max = transform.position.z+40f;
        Gatespawn();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Gatespawn()
    {
        GameObject obj = Instantiate(gates[0],transform.position,Quaternion.Euler(0,180,0));
        GameObject obj1 =   Instantiate(gates[1],transform.position,Quaternion.Euler(0,180,0));
        for(int i = 0;i<2;i++)
        {
        GameObject wall = Instantiate(wallprefab,transform.position,Quaternion.identity);
        wall.transform.SetParent(gameObject.transform);
        wall.transform.localPosition = new Vector3(Random.Range(-4.335f,4.335f),-2.02f,Random.Range(20f,30f));
        }
        obj.transform.SetParent(gameObject.transform);
        obj1.transform.SetParent(gameObject.transform);
        obj.transform.localPosition = new Vector3(0f,-2.02f,13f);
        obj1.transform.localPosition = new Vector3(0f,-2.02f,40f);
        /*int num = Random.Range(0,81);
        bool isswitch = (num < 11 || (num >= 30 && num <= 34) || num == 69 || (num >= 77 && num <= 80));
        if(isswitch)
        {
            //numgate=3
            numgate = 2;
        }
        else {
            numgate = 2;
        }
        for(int i = 0;i<numgate;i++)
        {
            zposgate = Random.Range(min,max);
        
        GameObject obj = Instantiate(gates[gateswitcher.currentgate-1],new Vector3(-0.06f,3.03f,zposgate),Quaternion.Euler(new Vector3(0,180,0)));
        if(Physics.Raycast(obj.transform.position,obj.transform.forward*-26.3f,out hit))
        {
            if(hit.collider.gameObject.CompareTag("gate"))
            {
                obj.transform.position+= new Vector3(obj.transform.position.x,obj.transform.position.y,obj.transform.position.z+(26.3f));
                if(obj.transform.position.z>max)
                {
                    Destroy(obj);
                    continue;
                }
            }
            
        }
        if(Physics.Raycast(obj.transform.position,obj.transform.forward*26.3f,out hit))
        {
             if(hit.collider.gameObject.CompareTag("gate"))
            {
                    Destroy(obj);
                    continue;   
            }
        }
        if(obj!=null)
        obj.transform.SetParent(gameObject.transform);
         
        
        if(gateswitcher.currentgate==1)
        {
            gateswitcher.currentgate=2;
        }
        else{
            gateswitcher.currentgate=1;
        }
        min = obj.transform.position.z+20f;
    }*/
  

}
}
  

