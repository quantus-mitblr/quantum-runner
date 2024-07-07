using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class start : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField]
    Button startButton;
    [SerializeField]
    Button pauseButton;
    [SerializeField]
    Button exitButton;
    [SerializeField]
    GameObject strt;
    [SerializeField]
    GameObject pause;
    [SerializeField]
    GameObject player;
    [SerializeField]
    SkinnedMeshRenderer sk;
    [SerializeField]
    GameObject tutorial;
    [SerializeField]
    Button tutorialbtn;
    Mesh sphere;
    public float gamespeed;
    public bool paused = true;
    bool started = false;
    bool laserfirst;
    bool gatefirst;
    [SerializeField]
   GameObject continuetext;
   [SerializeField]
   GameObject instruction;
    
    float delay;
    public TextMeshProUGUI pauseText;
    // Start is called before the first frame update
    void Awake()
    {
        laserfirst = gatefirst = false;
        gamespeed = 0;
       pause.SetActive(false);
        Time.timeScale = 0;
        startButton.onClick.AddListener(OnButtonPressed);
        pauseButton.onClick.AddListener(pauseButtonPressed);
        exitButton.onClick.AddListener(exitButtonPressed);
        tutorialbtn.onClick.AddListener(tutorialButtonPresssed);
        //pauseButton.enabled=false;
       
    }
    void exitButtonPressed()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif  
    }
    void pauseButtonPressed()
    {
        paused = !paused;
        exitButton.gameObject.SetActive(!exitButton.IsActive());
        if (pauseText.text == "Play")
        pauseText.text = "Pause";
        else
            pauseText.text = "Play";

    }
    
    void OnButtonPressed()
    {
        started = true;
        Time.timeScale=1f;
        gamespeed=1;
        paused= false;
        strt.SetActive(false);
        tutorial.SetActive(false);
        pause.SetActive(true);
        //player.GetComponent<MeshFilter>().mesh = sphere;
        //sk.sharedMesh = sphere;

}
 void tutorialButtonPresssed()
    {
        gamespeed = 1f;
        paused = false;
        Time.timeScale=1f;
        SceneManager.LoadScene("tutorial");
    }
    private void Update()
    {
        if(!gatefirst)
        {
            if(Physics.Raycast(player.transform.position,player.transform.forward,out hit,5f))
            {
                if(hit.collider.gameObject.CompareTag("gate")&&!gatefirst||hit.collider.gameObject.CompareTag("laser")||hit.collider.gameObject.CompareTag("tunnellingWall")||hit.collider.CompareTag("gateside")&&!gatefirst)
                {
                    instruction.SetActive(true);
                    continuetext.SetActive(true);
                    instruction.GetComponent<TextMeshProUGUI>().text = "Watch Out!";
                    gatefirst = true;
                    paused = true;
                    Time.timeScale=0f;
                }
            }
        }
        if (started && !paused)
        delay += 1;
        if (delay > 30)
        {
            gamespeed += 0.01f;
            delay = 0;
            if(gamespeed>2)
            {
                gamespeed = 2;
            }
        }
        if(paused)
            Time.timeScale=0;
        else
        Time.timeScale = gamespeed;
    }
}
