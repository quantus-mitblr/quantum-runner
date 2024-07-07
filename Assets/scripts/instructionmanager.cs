using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class instructionmanager : MonoBehaviour
{
    [SerializeField]
    GameObject text1;
    [SerializeField]
    GameObject text2;
    string[] arr = new string[4];
    void Awake()
    {
        arr[0]="Welcome to the game! try to avoid the lasers!";
        arr[1]="Great job!, as u may have noticed, you are a quantum particle, see that gate in front of you?,that is a double slit!The blue cone represents an observer. When the nature of an electron passing through double slit is observed, it exhibits particle nature!, which means u can pass through it as is";
        arr[2]="Now this gate has no observer, when youngs double slit experiment was first performed, an interference pattern was observed, indicating wave nature. When a wave is passed through the double slit, one wave passes through each slit, hence the wave is in superposition(2 states at once), try pressing K to enter into superposition state";
        arr[3]="Quantum particles have a probability to tunnel through walls, this probability depends on the thickness of the wall, in this game, the thicker the wall, the less transparent it is. Usually values above 0.4 will not let you pass through, try moving through at ur own risk!";
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
            text1.SetActive(true);
            text2.SetActive(true);
            text1.GetComponent<TextMeshProUGUI>().text=arr[++instructionindex.index];
            Time.timeScale = 0f;
        }
    }


}
