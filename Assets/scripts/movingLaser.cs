using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movingLaser : MonoBehaviour
{
    GameObject laser;
    float ymove = 5f;
    Vector3 movement;
    // Start is called before the first frame update
    void Awake()
    {
        
        laser = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(laser.transform.localPosition.y <= -4.46)
        {
            ymove = 5f;
        }
        if (laser.transform.localPosition.y >= 3.92)
        {
            ymove = -5f;
        }
        laser.transform.Translate(transform.right*ymove*Time.deltaTime);
    }
}
