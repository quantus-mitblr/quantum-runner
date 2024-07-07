using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject death;
    public GameObject Player;
    public GameObject Player2;
    public bool isdead;
    public float speed = 1;
    public Rigidbody rb;
    float horizontalInput;
    float verticalInput;
    bool keyInput;
    public float multiplier = 2;
    public bool wave = true;
    float sidetimer = 1f;
    bool sidetimerstarted;
    void Awake()
    {
        sidetimerstarted=false;
        isdead=false;
    }
    private void FixedUpdate()
    {
        Vector3 forwardMove = Player.transform.forward * speed * Time.fixedDeltaTime;
        Vector3 movementH = new Vector3(horizontalInput, verticalInput,0f) * speed * Time.deltaTime *multiplier;
        //Vector3 movementV = new Vector3(0f, verticalInput, 0f) * speed * Time.deltaTime * multiplier;
        if (gameObject.transform.position.y+0.3f > 7 && verticalInput>0)
            movementH.y = 0;
        if (gameObject.transform.position.y-0.2f < 2 && verticalInput < 0)
            movementH.y = 0;
        if (gameObject.transform.position.x+0.2f > 4.5 && horizontalInput>0)
            movementH.x = 0;
        if (gameObject.transform.position.x-0.2f < -4.5 && horizontalInput < 0)
            movementH.x = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        Vector3 newpos = rb.position + movementH;
        newpos.z = Player.transform.position.z + forwardMove.z;
        newpos.z = Player2.transform.position.z + forwardMove.z;
        newpos.z += forwardMove.z;
        rb.position = newpos;
    }

    void Update()
    {
       
        if(sidetimerstarted)
        {
            sidetimer-=Time.unscaledDeltaTime;
            if(sidetimer<=0f)
            {
                sidetimer = 1f;
                sidetimerstarted=false;
                isdead=true;
            }
        }
       if(isdead==true)
       {
       
        death.GetComponent<sceneswitcher>().Switch();
       }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        keyInput = Input.GetKeyDown(KeyCode.L);
        if (keyInput)
        {
            wave = !wave;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("tunnellingWall"))
          sidetimerstarted=true;
        if(col.gameObject.CompareTag("laser"))
        {
          
            isdead=true;
        }
      
    }
    void OnCollisionEnter(Collision col)
    {
        
       
          if(col.gameObject.CompareTag("gatesides"))
          {
            
            sidetimerstarted = true;
          }
    }
    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.CompareTag("gatesides"))
        {
            sidetimer = 1f;
            sidetimerstarted = false;
            
        }
    }
    void OnTriggerExit(Collider col)
    {
        sidetimer = 1f;
        sidetimerstarted = false;
    }
}
