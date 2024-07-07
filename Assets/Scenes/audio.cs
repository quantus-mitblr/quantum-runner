using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    float initialPitch;
    AudioSource audioSource;
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        initialPitch = audioSource.pitch;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (audioSource.isPlaying)
        {
            audioSource.pitch = initialPitch;
        }
    }
}
