using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    // Start is called before the first frame update
    GroundSpawner groundSpawner;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }
     IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        // Code to execute after delay
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
        groundSpawner.SpawnTile();
        StartCoroutine(ExecuteAfterDelay(20f));
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
