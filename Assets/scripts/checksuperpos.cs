using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checksuperpos : MonoBehaviour
{
    float timer = 1f;
    bool decrement;
    //bool kill;
    void Awake()
    {
        decrement = false;
        //kill=true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(decrement)
        {
            timer-=Time.deltaTime;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            decrement = true;
            //kill = false;
        }
        if(col.gameObject.CompareTag("Player2"))
            decrement = true;
    }
}
