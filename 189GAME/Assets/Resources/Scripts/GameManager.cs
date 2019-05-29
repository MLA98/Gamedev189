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
    public float Wave;
    public float Ammo;
    public float PlayerFireRate;
    
    public Text scoreDisp;
    public Text gameOverScoreDisp;
    public Text upgradeScoreDisp;
    public Text upgradeAmmoDisp;
    public Text upgradeWaveDisp;
    public Text ammoDisp;
    public Image gameOverDisp;
    public Image upgradeScreen;
    public Slider healthBar;
    public Slider upgradeHealthBar;

    public Button spreadUp;
    public Button AOEUp;

    public bool gameOver;
    public bool nextWave;

    public bool spread;
    public bool AOE;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        Health = 10;
        Score = 0;
        Wave = 1;
        Ammo = 50;
        gameOver = false;
        PlayerFireRate = 0.33f;
        nextWave = false;
        spread = false;
        AOE = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisp.text = "Score: " + Score;
        gameOverScoreDisp.text = "Score: " + Score;
        healthBar.value = Health;
        ammoDisp.text = "Ammo: " + Ammo;

        upgradeAmmoDisp.text = "Ammo: " + Ammo;
        upgradeScoreDisp.text = "Score: " + Score;
        upgradeWaveDisp.text = "Wave " + Wave + " Completed";
        upgradeHealthBar.value = Health;

        if (gameOver)
        {
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            gameOverDisp.gameObject.SetActive(true);
        }
        if (nextWave)
        {
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            upgradeScreen.gameObject.SetActive(true);
        }
    }

    public void startNextWave()
    {
        scoreDisp.gameObject.SetActive(true);
        ammoDisp.gameObject.SetActive(true);
        healthBar.gameObject.SetActive(true);
        upgradeScreen.gameObject.SetActive(false);
        Wave += 1;
        nextWave = false;
    }

    public void RefillAmmo()
    {
        if (Score >= 10)
        {
            Score -= 10;
            Ammo += 100;
        }
    }

    public void RefillHealth()
    {
        if (Score >= 50 && Health < 10)
        {
            Score -= 50;
            Health = 10;
        }
    }

    public void upgradeFireRate()
    {
        if (Score >= 250)
        {
            Score -= 250;
            PlayerFireRate /= 1.1f;
        }
    }

    public void upgradeSpread()
    {
        if (Score >= 500)
        {
            Score -= 500;
            spread = true;
            spreadUp.interactable = false;
        }
    }

    public void upgradeAOE()
    {
        if (Score >= 1000)
        {
            Score -= 1000;
            AOE = true;
            AOEUp.interactable = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
