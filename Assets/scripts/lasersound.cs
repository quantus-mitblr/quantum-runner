using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasersound : MonoBehaviour
{
    bool shouldplay;
    AudioSource audioSource;
    GameObject player;
    void Awake()
    {
        audioSource=gameObject.GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        shouldplay=true;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.transform.position.z-transform.position.z)<=5&&shouldplay)
        {
            audioSource.Play();
            shouldplay = false;
        }
    }
}
