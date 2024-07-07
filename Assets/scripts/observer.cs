using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class observer : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMovement player;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        /*if(col.gameObject.CompareTag("Player2") && player.wave)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().isdead=true;
        }*/
        if(col.gameObject.CompareTag("Player"))
        {
            if(col.gameObject.GetComponent<NewBehaviourScript>().split==true)
            {
                col.gameObject.GetComponent<PlayerMovement>().isdead=true;
            }
        }


    }
}
