
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    
    public GameObject Groundtile;
    Vector3 nextSpawnPoint = new Vector3(0f,5f,40f);
    // Start is called before the first frame update
    void Start()
    {
        SpawnTile();
        SpawnTile();

    }

    // Update is called once per frame
    public void SpawnTile()
    {
        GameObject newtile  = Instantiate(Groundtile,nextSpawnPoint,Quaternion.identity);
        nextSpawnPoint = newtile.transform.GetChild(4).transform.position;
        nextSpawnPoint.z += 50;
        nextSpawnPoint.y += 5;
    }
}
