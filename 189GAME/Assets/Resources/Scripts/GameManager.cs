using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float Score;
    public float Health;
    public float Ammo;

    public Text scoreDisp;
    public Text gameOverScoreDisp;
    public Text ammoDisp;
    public Image gameOverDisp;
    public Slider healthBar;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Health = 3;
        Score = 0;
        Ammo = 10000;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisp.text = "Score: " + Score;
        gameOverScoreDisp.text = "Score: " + Score;
        healthBar.value = Health;
        ammoDisp.text = "Ammo: " + Ammo;
        if (gameOver)
        {
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            gameOverDisp.gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
