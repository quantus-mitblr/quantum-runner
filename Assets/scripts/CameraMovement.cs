using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public GameObject Player2;
    Vector3 offset;


    private void FixedUpdate()
    {
        //offset = transform.position - target.position;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = target.position;
        newPos.x = (target.position.x+Player2.transform.position.x)/2;
        newPos.z = target.position.z-5;
        newPos.y = target.position.y+1.5f;
        transform.position = newPos;
        
    }
}
