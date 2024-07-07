using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    float reload =  0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reload-=Time.deltaTime;
        if(reload<=0f)
        {
            reload =0.5f;
            sh();

        }
    }
    void sh()
    {
        GameObject obj = Instantiate(gameObject.transform.GetChild(1).gameObject,gameObject.transform.GetChild(1).gameObject.transform.position,transform.rotation);
        obj.SetActive(true);
        obj.AddComponent<Rigidbody>();
        obj.GetComponent<Rigidbody>().useGravity=false;
        obj.GetComponent<Rigidbody>().AddForce(transform.up*30,ForceMode.Impulse);
    }
}
