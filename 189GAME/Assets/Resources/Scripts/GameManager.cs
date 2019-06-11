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
    public int Wave;
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
    public Text waveDisp;
    public Text diaryEntry;
    public Image gameOverDisp;
    public Image upgradeScreen;
    public Image dialogueScreen;
    public Image wave_Completed;
    public Image winScreen;
    public Image pauseScreen;
    public Image titleScreen;
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
    private AudioClip defaultMusic;
    [SerializeField]
    private AudioClip bossMusic;
    // Upgrade bools
    public bool spread;
    public bool AOE;
    public bool hit;
    public bool followCam;

    // Game states
    public enum gameState {title, bootUp, gameOver, waveCompleted, playing, pause, upgradeScreenState, won, dialogueScreenState}
    public gameState currState;

    // Array to store Diary entry stories
    // The text in each entry is assigned to each array entry
    // at the bottom of this source file.
    private string [] listOfDiaryEntries = new string[8];

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
        currState = gameState.title;
        Health = 10;
        Score = 0;
        Wave = 1;
        Ammo = 50;
        PlayerFireRate = 0.33f;
        SpeedFactor = 1f;
        spread = false;
        AOE = false;
        hit = false;
        followCam = false;
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
        waveDisp.text = "Wave " + Wave;
        waveHealthBar.value = Health;
        upgradeHealthBar.value = Health;
        diaryEntry.text = listOfDiaryEntries[Wave-1];
        if (Health < 10)
        {
            healthRefill.interactable = true;
        }
        else
        {
            healthRefill.interactable = false;
        }

        Physics.IgnoreLayerCollision(10, 11);
        Physics.IgnoreLayerCollision(11, 9);
        Physics.IgnoreLayerCollision(9, 9);
        Physics.IgnoreLayerCollision(0, 10);
        
        if (Wave == 8)
        {
            BGM.clip = bossMusic;
        }

        if ((currState == gameState.playing || currState == gameState.bootUp) && !BGM.isPlaying){
            BGM.Play();
        }
        if (currState != gameState.playing && 
            currState != gameState.bootUp &&
            currState != gameState.title &&
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
            titleScreen.gameObject.SetActive(false);
            BGM.clip = defaultMusic;
        }

        // UI in different game states
        if (currState == gameState.gameOver)
        {
            waveDisp.gameObject.SetActive(false);
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            gameOverDisp.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        }
        if (currState == gameState.waveCompleted)
        {
            waveDisp.gameObject.SetActive(false);
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            wave_Completed.gameObject.SetActive(true);
            dialogueScreen.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(false);
        }
        if (currState == gameState.playing)
        {
            waveDisp.gameObject.SetActive(true);
            scoreDisp.gameObject.SetActive(true);
            ammoDisp.gameObject.SetActive(true);
            healthBar.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(true);
        }
        
        if (currState == gameState.upgradeScreenState)
        {
            waveDisp.gameObject.SetActive(false);
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            wave_Completed.gameObject.SetActive(false);
            upgradeScreen.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        }
        if (currState == gameState.dialogueScreenState)
        {
            waveDisp.gameObject.SetActive(false);
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            wave_Completed.gameObject.SetActive(false);
            dialogueScreen.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);            
        }
        if (currState == gameState.won)
        {
            waveDisp.gameObject.SetActive(false);
            scoreDisp.gameObject.SetActive(false);
            ammoDisp.gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(false);
            winScreen.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
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

    public void dialogueScreenButton()
    {
        clickSound.Play();
        currState = gameState.dialogueScreenState;
    }

    public void backToMenu()
    {
        clickSound.Play();
        currState = gameState.waveCompleted;
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
            pauseScreen.gameObject.SetActive(false);
        }
        else if (currState == gameState.playing)
        {
            currState = gameState.pause;
            pauseScreen.gameObject.SetActive(true);
        }
    }

    public void Quit(){
        clickSound.Play();
        Application.Quit();
    }

    public void Redirect(){
        Application.OpenURL("https://mars.nasa.gov/participate/send-your-name/mars2020/");
    }

    public void ChangeCamera()
    {
        clickSound.Play();
        if (followCam)
        {
            followCam = false;
        }
        else
        {
            followCam = true;
        }
    }

    // Mute the volume
    public void VolumeOn()
    {
        clickSound.Play();
        if (AudioListener.volume != 0)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

    public void startPlay()
    {
        currState = gameState.bootUp;
        
        listOfDiaryEntries[0] = "Junaury 2, 20xx \n\n The invaders have been coming at higher frequencies. We had almost lost hope, but we found that we can intercept their resources from their black supply ships that pass by. We are able to extract energy from their green capsules to recharge my lasers, and the purple capsules have natural resources to repair my precious planet.\n\n\t- Musky";

        listOfDiaryEntries[1] = "February 27, 20xx \n\n We have spotted in the distance much larger ships. We must take caution as they approach. I do not think that They will be easy to take down in one shot...\n\n\t- Musky";

        listOfDiaryEntries[2] = "March 20, 20xx \n\n The large ships are proving to be quite adversarial. They are getting much to close to home before I can take them down with enough laser shots. The explosive shots we are researching should take them down easier, but it may be some time before we have the resources to have those ready. For now, attacking them at close quarters should help to keep them at byay. \n\n\t- Musky";

        listOfDiaryEntries[3] = "April 15, 20xx \n\n It looks like the enemy is looking for a change of strategy. We've spotted smaller and more agile ships in the distance. It won't be long before they reach our home. We should consider upgrading our lasers to help us shoot them down easier... \n\n\t- Musky";
    
        listOfDiaryEntries[4] = "May 10, 20xx \n\n Although I fight to protect Mars, I still have not forgotten my roots. To the original homeland, happy Mother's Day, planet Earth. \n\n\t- Musky";

        listOfDiaryEntries[5] = "June 12, 20xx \n\n The enemy has been rushing more and more forces at us, but it seems that we can use this against them, as every ship we take down is more resources to upgrade our own weaponry against them. \n\n\t- Musky";

        listOfDiaryEntries[6] = "November 1, 20xx \n\n We have finally attracted the Queen Bee. This will be the final battle. The planet cannot survive a single blow from the Queen. Game time is over, it's Destroy or be destroyed.\n\n\t - Musky";
    }

}

