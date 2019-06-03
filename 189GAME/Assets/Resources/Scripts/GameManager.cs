using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Universal values
    public float Score;
    public float Health;
    public float Wave;
    public float Ammo;
    public float PlayerFireRate;
    public float SpeedFactor;

    // Used for initial game state
    private float bootUpTimer;

    // UI
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
    public Button pauseButton;

    // Upgrade bools
    public bool spread;
    public bool AOE;
    public bool hit;

    // Game states
    public enum gameState { bootUp, gameOver, waveCompleted, playing, pause}
    public gameState currState;

    // Singleton
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currState = gameState.bootUp;
        Health = 10;
        Score = 0;
        Wave = 1;
        Ammo = 50;
        PlayerFireRate = 0.33f;
        SpeedFactor = 1f;
        spread = false;
        AOE = false;
        hit = false;
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

        Physics.IgnoreLayerCollision(9, 9);
        Physics.IgnoreLayerCollision(0, 10);

        // Boot up game state
        if (currState == gameState.bootUp)
        {
            bootUpTimer += Time.deltaTime;
            if (bootUpTimer >= 3.2f)
            {
                currState = gameState.playing;
            }
        }

        // UI in different game states
        if (currState == gameState.gameOver)
        {
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            gameOverDisp.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        }
        if (currState == gameState.waveCompleted)
        {
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            upgradeScreen.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        }
        if (currState == gameState.playing)
        {
            scoreDisp.gameObject.SetActive(true);
            ammoDisp.gameObject.SetActive(true);
            healthBar.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            PauseContinue();
        }
    }

    // Button functions
    public void startNextWave()
    {
        upgradeScreen.gameObject.SetActive(false);
        Wave += 1;
        currState = gameState.playing;
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

    public void upgradeLaserSpeed()
    {
        if (Score >= 250)
        {
            Score -= 250;
            SpeedFactor *= 1.1f;
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

    public void Menu()
    {
        SceneManager.LoadScene("welcome");
    }

    public void PauseContinue()
    {
        if (currState == gameState.pause)
        {
            currState = gameState.playing;
        }
        else if (currState == gameState.playing)
        {
            currState = gameState.pause;
        }
    }
}
