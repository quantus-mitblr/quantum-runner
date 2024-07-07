using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Break : MonoBehaviour
{
    int score;
    [SerializeField]
    GameObject centre;
    [SerializeField]
    GameObject text;
    [SerializeField]
    GameObject scoretext;
    [SerializeField]
    GameObject button;

    Material mat;   
    float intensity = 0f;
    Color current;
    float red,blue,green;
    void Awake()
    {
        score = (int)GameSettings.num;
        Time.timeScale=1f;
        mat = gameObject.GetComponent<MeshRenderer>().materials[0];
       StartCoroutine(shatter());
        current = mat.GetColor("_EmissionColor");
        red = current.r;
        blue = current.b;
        green = current.g;
    
    }
    IEnumerator shatter()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(1);

        // After 2 seconds have passed, this code will execute
         gameObject.GetComponent<MeshRenderer>().enabled=false;
        gameObject.transform.parent.gameObject.GetComponent<MeshRenderer>().enabled=false;
        for (int i = 0; i <= 2; i++)
        {
            
            transform.GetChild(i).gameObject.SetActive(true);
            Vector3 dir = (transform.GetChild(i).position - centre.transform.position).normalized;
            Rigidbody rb = transform.GetChild(i).GetComponent<Rigidbody>();
            rb.AddForceAtPosition(dir * 5, transform.position, ForceMode.Impulse);
            text.SetActive(true);
            scoretext.SetActive(true);
            scoretext.GetComponent<TextMeshProUGUI>().text ="Score: " + score.ToString();
            button.SetActive(true);
            button.GetComponent<Button>().onClick.AddListener(Retry);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
       intensity+=2*Time.deltaTime;
       float factor = Mathf.Pow(3,intensity);
        Color color = new Color(red*factor,green*factor,blue*factor);
        mat.SetColor("_EmissionColor",color);
    }
}
