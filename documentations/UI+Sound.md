## User Interface in Musky Defender

### Implementation of UI pages
Each UI page in Musky Defender stages follows each stage of the game. we have several different game states including title, playing, pause, upgrade and waveCompleted. In the different stage, we manipulate the UI gameobject with SetActive() to disable some pages and then enable one page:
    
        if (currState == gameState.gameOver)  
        {  
            waveDisp.gameObject.SetActive(false);  
            scoreDisp.gameObject.SetActive(false);  
            ammoDisp.gameObject.SetActive(false);  
            healthBar.gameObject.SetActive(false);
            gameOverDisp.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        }
        
### Buttons
I tried to use buttons from a single asset pack to keep visual consistency. In addition, when the user clicks each button, they will get feedback visually and audibly.

##### Visual feedback 

The button will get darker as play presses.

![Before pressing](https://github.com/MLA98/Gamedev189/raw/master/imageHost/471A5887-A1AD-4ABF-ADDD-E17DF2E946E6.png?raw=true) 
(Before pressing)                  ![After pressing](https://github.com/MLA98/Gamedev189/raw/master/imageHost/ACEA395D-39AE-4B16-B02D-45E71D03CEF0.png?raw=true)
(After pressing)

#####  Sound feedback: 
As the user clicks the button, a click sound would give the player a sense of real-time control.

##### A special button:
When player finish eight waves of enemies, they will reach won page. In the won page, there is a golden button which will open a [NASA's page](https://mars.nasa.gov/participate/send-your-name/mars2020/) for sending the player's name to Mars in 2020. The golden color of the button will make the player feel a sense of achievement since golden is a color of treasure. Furthermore, NASA's page matches our game perfectly.

### UI for Home page
In the home page, we have a huge play button in the center of the screen and, some game instructions are below the play button. People tend to focus on the center of the screen. Therefore, we put the play button and instructions which are most important there. In addition, there are two small buttons on the left top which are quit and mute. 

### HUD for battles
The HUD includes pause button, health bar and score. These elements are on the top left and top right in order to not conflict with the main game scene. The health is designed to be a health bar which could give the player an intuitive impression of their health.

### Menu on the upgrade page
In the upgrade page, we offer several upgrading choices including increasing fire rate and ammo refill. Also, health bar, ammo left and score are displayed in order to help players make the decisions.
## Sound in Musky Defender

### Implementation of sounds
The BGM sounds follow the states of the game. 

In the game scene, we have several different game states including title, playing, pause, upgrade and waveCompleted. The BGM follows each state in GameManager.cs which follows a singleton pattern.

The BGM is a serialized field in the script:  ```[SerializeField] 
    private AudioSource BGM;```

when the state changes, the music will switch:
```    
    if (currState == gameState.playing && !BGM.isPlaying) BGM.Play();
```   


### BGM for Home page
In the home page, the background music is sci-fi music from [Sci-fi Music pack](https://assetstore.unity.com/packages/audio/music/electronic/sci-fi-music-loops-pack-120186) on Unity asset store  The music sounds mysterious and chill. The music would give players a feeling of suspense and danger. Also, the music could make them ready for the challenges afterward.


### BGM for battles

The battles in the game are really exciting. Players have to handle enemies from all the directions. Therefore, I picked "Space battle" in the [Sci-fi Music pack](https://assetstore.unity.com/packages/audio/music/electronic/sci-fi-music-loops-pack-120186) which sounds exciting. It mixes some drums which are exciting. The BGM can give players an exciting and engaging feeling.

### No BGM for wave_completed, upgrade, pause states
In these states, the player just finished some exciting fights. Therefore, they may need some rest. In addition, in the upgrade screen, silence could give the player some quiet time to think of upgrading.


### Button Click sound

The buttons in the game provide various functions including pause, mute, restart, quit and start. The sounds of buttons are from [8 bit sounds](https://assetstore.unity.com/packages/audio/sound-fx/8-bit-sounds-free-package-3766). When the player clicks each button, they will get immediate sound feedback along with the shade of the button. It will give the player an input that he or she successfully click the button and the computer will follow his or her commands.

### Shoot sound in battle 
For weapon shooting sound, we choose a high-pitched sound since the weapon of the player is laser gun. When the laser hit enemies, the sound will give players feedback that the enemies are destroyed.
 
