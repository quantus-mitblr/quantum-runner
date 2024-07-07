using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincontinue : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    
    [SerializeField]
    GameObject text2;
    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            text2.SetActive(false);
            Time.timeScale = obj.GetComponent<start>().gamespeed;
            obj.GetComponent<start>().paused = false;
            gameObject.SetActive(false);
        }
    }
}
