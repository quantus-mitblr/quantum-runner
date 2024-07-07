using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextinstruct : MonoBehaviour
{
    [SerializeField]
    GameObject text2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale=1f;
            text2.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
