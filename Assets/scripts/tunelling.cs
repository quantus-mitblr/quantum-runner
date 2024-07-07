
using System;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class tunelling : MonoBehaviour
{
    Vector3 size;
    Color s;
    float r;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject Player2;
    [SerializeField]
    public Material mTun;
    public GameObject tunnelling;
    public TextMeshPro prob;
    //public Material tunnellingMaterial;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        r = UnityEngine.Random.Range(0f, 1f);
        //GameObject clone = Instantiate(tunnelling, new Vector3(0f, 0f, 30f), gameObject.transform.rotation);
        s = tunnelling.GetComponent<MeshRenderer>().materials[0].GetColor("_Color");
        size = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        size.z = r;
        s.a = Mathf.Clamp(r,0.75f,1f);
        gameObject.layer = 0;
        tunnelling.GetComponent<MeshRenderer>().material.SetColor("_Color", s);
         prob.text = "t="+(Mathf.Round(r*100)/100).ToString();
        gameObject.transform.localScale = size;
        float m = UnityEngine.Random.Range(0f, 1f);
        if (r<m)
        gameObject.layer = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2")) && r > 0.1)
        {
            Vector3 pos = other.transform.position;
            pos.z -= 1;
            other.transform.SetPositionAndRotation(pos, other.transform.rotation);
            //Player2.transform.SetPositionAndRotation(pos, other.transform.rotation);
            
        }
    }
}
