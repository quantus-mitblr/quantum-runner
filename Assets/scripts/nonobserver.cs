using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonobserver : MonoBehaviour
{
    float timer = 1f;
    bool decrement;
    bool kill1;
    bool kill2;
    void Awake()
    {
        kill1=true;
        decrement = false;
        kill2=true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*void OnTriggerExit(Collider col)
    {
        print("called");
        if(col.gameObject.CompareTag("Player")||col.gameObject.CompareTag("Player2"))
        {
            decrement = true;
        if(col.gameObject.CompareTag("Player"))
        {
            kill1=false;
        }
        if(col.gameObject.CompareTag("Player2"))
        {
            kill2=false;
        }
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!other.GetComponent<NewBehaviourScript>().split)
            {
                other.GetComponent<PlayerMovement>().isdead=true;
            }
        
        /*if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().wave)
        {
            gameObject.layer = 1;
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
        else
        {
           
            gameObject.layer = 0;
        }*/
    }
    
    }
}
