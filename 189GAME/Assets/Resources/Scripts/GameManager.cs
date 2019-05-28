using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float Score;
    public float Health;

    public Text scoreDisp;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Health = 3;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisp.text = "Score: " + Score;
        healthBar.value = Health;
    }
}
