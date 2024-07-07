using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    AudioClip audio;
    float animtimer;
    GameObject player;
    GameObject player2;
    Rigidbody rb;
    GameObject pointer;
    Rigidbody rb2;
    [SerializeField]
    Mesh plane;
    [SerializeField]
    Mesh sphere;
    [SerializeField]
    SkinnedMeshRenderer skinnedMeshRenderer;
    //bool merge = false;
    public bool split = true;
    public bool startanim = false;
    bool started = false;
    int delay = 0;
    void Awake()
    {
        pointer = gameObject.transform.GetChild(1).gameObject;
        animtimer = 0.2f;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = gameObject.transform.GetChild(0).gameObject;
        skinnedMeshRenderer.sharedMesh = plane;
        rb = player.GetComponent<Rigidbody>();
        rb2 = player2.GetComponent<Rigidbody>();
        split = true;
        started = false;

    }
    void FixedUpdate()
    {if(false){

    
        //if(( player2.transform.position.x-player.transform.position.x)>0.2)
                {
                /*player2.transform.SetParent(null);
                player2.SetActive(true);
                rb.AddForce(new Vector3(5f, 0, 0), ForceMode.Impulse);
                rb2.AddForce(new Vector3(-5f, 0, 0), ForceMode.Impulse);
                animtimer = 0.2f;
                merge = false;
                split = false;
                startanim = true;*/
                //layer2.transform.Translate(new Vector3(-5f,0f,5f)*Time.fixedDeltaTime);
                }
                //else{

                //split = true;
            //}
    }
    }

    // Update is called once per frame
    void Update()
    {
        if (delay < 5)
        {
            delay += 1;
            return;
        }
        if(!started && split)
        {
            started = true;
            split = false;
            skinnedMeshRenderer.sharedMesh = sphere;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {

            split = !split;
            startanim = true;
        }
        if (startanim)

        {
            animtimer -= Time.deltaTime;
        }
        if (animtimer <= 0)
        {
            rb.velocity = new Vector3(0, 0, rb.velocity.z);
            rb2.velocity = new Vector3(0, 0, rb2.velocity.z);
            animtimer = 0.2f;
            player.GetComponent<SphereCollider>().enabled = true;
            startanim = false;
            if (!split)
            {
                //Vector3 newpos = rb.position;
                //rb2.MovePosition(newpos);
                
                player.GetComponent<MeshFilter>().mesh = sphere;
                skinnedMeshRenderer.sharedMesh = sphere;
                player.GetComponent<Cloth>().enabled=false;
                pointer.SetActive(false);
            }
            if (split)
            {
                
                 player.GetComponent<MeshFilter>().mesh = plane;
                 skinnedMeshRenderer.sharedMesh = plane;
                 player.GetComponent<Cloth>().enabled=true;
                 pointer.SetActive(true);
                
                
            }
        }
        
        
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("trash"))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(audio);
            Destroy(col.gameObject);
        }
    }

    

   
   
}
