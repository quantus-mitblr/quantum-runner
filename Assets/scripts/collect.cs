using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class collect : MonoBehaviour
{
    GameObject scorecard;
    void Awake()
    {
        scorecard = GameObject.FindWithTag("score");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        
        if(col.gameObject.CompareTag("Player"))
        {
            print("called");
           float num = float.Parse(scorecard.GetComponent<TextMeshProUGUI>().text);
           num+=500;
           GameSettings.num=num;
        }
    }
}
