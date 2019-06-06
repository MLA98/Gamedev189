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
    public Text winScoreDisp;
    public Text upgradeScoreDisp;
    public Text upgradeAmmoDisp;
    public Text upgradeWaveDisp;
    public Text waveScreenScoreDisp;
    public Text waveScreenAmmoDisp;
    public Text ammoDisp;
    public Image gameOverDisp;
    public Image upgradeScreen;
    public Image wave_Completed;
    public Image winScreen;
    public Slider healthBar;
    public Slider waveHealthBar;
    public Slider upgradeHealthBar;
    public Button spreadUp;
    public Button AOEUp;
    public Button healthRefill;
    public Button pauseButton;

    [SerializeField] 
    private AudioSource clickSound;
    [SerializeField]
    private AudioSource BGM;
    [SerializeField]
    private AudioClip bossMusic;
    // Upgrade bools
    public bool spread;
    public bool AOE;
    public bool hit;

    // Game states
    public enum gameState { bootUp, gameOver, waveCompleted, playing, pause, upgradeScreenState, won}
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
        BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisp.text = "Score: " + Score;
        gameOverScoreDisp.text = "Score: " + Score;
        healthBar.value = Health;
        ammoDisp.text = "Ammo: " + Ammo;
        winScoreDisp.text = "Score: " + Score;
        waveScreenScoreDisp.text = "Score: " + Score;
        waveScreenAmmoDisp.text = "Ammo: " + Ammo;
        upgradeAmmoDisp.text = "Ammo: " + Ammo;
        upgradeScoreDisp.text = "Score: " + Score;
        upgradeWaveDisp.text = "Wave " + Wave + " Completed";
        waveHealthBar.value = Health;
        upgradeHealthBar.value = Health;
        if (Health < 10)
        {
            healthRefill.interactable = true;
        }
        else
        {
            healthRefill.interactable = false;
        }

        Physics.IgnoreLayerCollision(11, 9);
        Physics.IgnoreLayerCollision(9, 9);
        Physics.IgnoreLayerCollision(0, 10);
        
        if (Wave == 8)
        {
            BGM.clip = bossMusic;
        }

        if (currState == gameState.playing && !BGM.isPlaying){
            BGM.Play();
        }
        if (currState != gameState.playing && 
            currState != gameState.bootUp && 
            BGM.isPlaying) {
            BGM.Pause();
        }
         

        // Boot up game state
        if (currState == gameState.bootUp)
        {
            bootUpTimer += Time.deltaTime;
            if (bootUpTimer >= 2.7f)
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
            wave_Completed.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        }
        if (currState == gameState.playing)
        {
            scoreDisp.gameObject.SetActive(true);
            ammoDisp.gameObject.SetActive(true);
            healthBar.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(true);
        }
        
        if (currState == gameState.upgradeScreenState)
        {
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            wave_Completed.gameObject.SetActive(false);
            upgradeScreen.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        }
        if (currState == gameState.won)
        {
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(false);
            winScreen.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseContinue();
        }
    }

    // Button functions
    public void startNextWave()
    {
        clickSound.Play();
        wave_Completed.gameObject.SetActive(false);
        upgradeScreen.gameObject.SetActive(false);
        Wave += 1;
        currState = gameState.playing;
    }

    public void upgradeScreenButton()
    {
        clickSound.Play();
        currState = gameState.upgradeScreenState;
    }

    public void RefillAmmo()
    {
        clickSound.Play();
        if (Score >= 10)
        {
            Score -= 10;
            Ammo += 100;
        }
    }

    public void RefillHealth()
    {
        clickSound.Play();
        if (Score >= 50 && Health < 10)
        {
            Score -= 50;
            Health = 10;
        }
    }

    public void upgradeFireRate()
    {
        clickSound.Play();
        if (Score >= 250)
        {
            Score -= 250;
            PlayerFireRate /= 1.1f;
        }
    }

    public void upgradeLaserSpeed()
    {
        clickSound.Play();
        if (Score >= 250)
        {
            Score -= 250;
            SpeedFactor *= 1.1f;
        }
    }

    public void upgradeSpread()
    {
        clickSound.Play();
        if (Score >= 500)
        {
            Score -= 500;
            spread = true;
            spreadUp.interactable = false;
        }
    }

    public void upgradeAOE()
    {
        clickSound.Play();
        if (Score >= 1000)
        {
            Score -= 1000;
            AOE = true;
            AOEUp.interactable = false;
        }
    }

    public void Restart()
    {
        clickSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        clickSound.Play();
        SceneManager.LoadScene("welcome");
    }

    public void PauseContinue()
    {
        clickSound.Play();
        if (currState == gameState.pause)
        {
            currState = gameState.playing;
        }
        else if (currState == gameState.playing)
        {
            currState = gameState.pause;
        }
    }

    public void Quit(){
        clickSound.Play();
        Application.Quit();
    }

    public void Redirect(){
        Application.OpenURL("https://mars.nasa.gov/participate/send-your-name/mars2020/");
    }
}
