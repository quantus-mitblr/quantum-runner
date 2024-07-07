using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public static float num;
     int score;
    GameObject Sphere;
    public static GameSettings inst;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        num = 0;
        score = 0;
        inst = this;
    }
    void Start()
    {
        Sphere = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        num+=Time.deltaTime;
        score = (int)num;
        scoreText.text = Mathf.RoundToInt(score).ToString();
    }
}
