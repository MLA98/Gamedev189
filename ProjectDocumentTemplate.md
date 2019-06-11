# Game Basic Information #

## Summary ##

Set in an immersive space setting, MUSKY DEFENDER builds on the popular shoot 'em up genre with an interesting twist. Our hero, stationed on Mars, fights off waves of enemies, utilizing left/right movement and rocket jumping to get around the planet. Our hero starts out with a simple laser gun. As the waves of enemies grow stronger, so does our hero, with access to upgrades and power-ups at the end of each wave. Throughout the waves the player will face enemies of varying difficulties. The player must manage their resources well and build up their arsenal before ultimately reaching a boss fight that will surely stress test their abilities.

## Gameplay explanation ##

**In this section, explain how the game should be played. Treat this like a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**




# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based off the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your own relevant information. Liberally use the template when necessary and appropriate.

## User Interface

#### Overview of the UI
For each state, one page of UI is implementated to provide different functions for game including updating items, pausing the game and providing information. 
        
#### Buttons
I tried to use buttons from a single asset pack to keep visual consistency. In addition, when the user clicks each button, they will get feedback visually and audibly.

Feedback to player - The button will get darker as play presses.The change of the color would give player a real time feedback that he successfully press the button and computer perceive it. 

![Before pressing](https://github.com/MLA98/Gamedev189/raw/master/imageHost/471A5887-A1AD-4ABF-ADDD-E17DF2E946E6.png?raw=true) 
(Before pressing)                  ![After pressing](https://github.com/MLA98/Gamedev189/raw/master/imageHost/ACEA395D-39AE-4B16-B02D-45E71D03CEF0.png?raw=true)
(After pressing)

In addition, as the user clicks the button, a click sound will be played. The click sound would give the player a sense of real-time control as well. [Click Sound Feedback](https://github.com/MLA98/Gamedev189/blob/76edc1f0100cac07f17d468c9e120e5c1bf83d65/189GAME/Assets/Resources/Scripts/GameManager.cs#L227)

Game feel - When player finish eight waves of enemies, they will reach won page. In the won page, there is a golden button which will open a [NASA's page](https://mars.nasa.gov/participate/send-your-name/mars2020/) for sending the player's name to Mars in 2020. The golden color of the button will make the player feel a sense of achievement since golden is a color of treasure. Furthermore, NASA's page matches our game perfectly. 


![Golden Button](https://github.com/MLA98/Gamedev189/raw/master/imageHost/Screen%20Shot%202019-06-10%20at%2010.19.50%20PM.png)

#### UI for Home page
In the home page, we have a huge play button in the center of the screen and, some game instructions are below the play button. People tend to focus on the center of the screen. Therefore, we put the play button and instructions which are most important there. In addition, there are two small buttons on the left top which are quit and mute. 

#### HUD for battles
Realtime Feedback - The HUD includes pause button, health bar and score. The pause button will change to continue button as the player click. The health is designed to be a health bar which could give the player an intuitive impression of their health. Meanwhile, the Ammo left will decrease as the player shot. 

#### Menu on the upgrade page
In the upgrade page, we offer several upgrading choices including increasing fire rate and ammo refill. Also, health bar, ammo left and score are displayed in order to help players make the decisions.

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your own movement scripts that do not use the phyics system?**

## Animation and Visuals

**List your assets including their sources, and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

Movement can be done using arrow keys or W (jump), A (left), D (right). Space bar is used to shoot. 

Input in the game is handled using the [SimpleInput library](https://github.com/yasirkula/UnitySimpleInput). It simply offers a [uniform way](https://github.com/MLA98/Gamedev189/blob/704260c03faa5f1aa66697238ba8202b40af3640/189GAME/Assets/Resources/Scripts/PlayerController.cs#L38) of getting user inputs such that input can be detected from keyboards, joysticks, and UI buttons, depending on the platform.

- Desktop - SimpleInput offers a conveniently familiar API for getting input.

- Mobile - UI buttons are used for user input, and [HUDController.cs](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/HUDController.cs) toggles the UI buttons depending on the state of the game. 


*Command Pattern* - The game uses the command pattern by implementing [IPlayerCommand](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/IPlayerCommand.cs), a command interface which is extended by [MovePlayerClockwise](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/MovePlayerClockwise.cs), [MovePlayerCounterClockwise](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/MovePlayerCounterClockwise.cs), [PlayerJump](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/PlayerJump.cs), and [PlayerShoot](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/PlayerShoot.cs).

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

#### Audio sources of Musky Defender
- Background music source: [Sci-fi Music pack](https://assetstore.unity.com/packages/audio/music/electronic/sci-fi-music-loops-pack-120186) is licensed under Creative Commons CC-BY 3.0, together with the standard ToS and EULA from the Unity Asset Store. Created by Robson Cozendey - Biare Studio ( www.cozendey.com )



- Button Click/ weapon hit source: [8 bit sounds](https://assetstore.unity.com/packages/audio/sound-fx/8-bit-sounds-free-package-3766) is free in Unity Asset Store without an explicit license. According to Unity Store, free asset could be used commercially and personally.

#### Implementation of audio system

##### Background music implementation
In the game scene, we have several different game states including title, playing, pause, upgrade and waveCompleted. The Background music follows each state in [GameManager.cs](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/GameManager.cs) which follows a singleton pattern. For pause, upgrade and waveCompleted states, there is no Background music. For title(home) state and playing state, we have two different Background music.

serialized field - Each Background music is a serialized field in the [script](https://github.com/MLA98/Gamedev189/blob/40effdbdf8978cd86fc19d549ac893de9beeb900/189GAME/Assets/Resources/Scripts/GameManager.cs#L50):  ```[SerializeField] 
    private AudioSource BGM;```

When the state changes, the BGM's clip will be changed to another clip in the [script](https://github.com/MLA98/Gamedev189/blob/40effdbdf8978cd86fc19d549ac893de9beeb900/189GAME/Assets/Resources/Scripts/GameManager.cs#L151):
```    
    BGM.clip = defaultMusic;
```   

When the state has no background music:
```
	BGM.Pause();
```

##### UI Button click sound implementation
For each button click, we add a onClick() function in unity editor. ![picture](https://github.com/MLA98/Gamedev189/raw/master/imageHost/Screen%20Shot%202019-06-10%20at%209.38.28%20PM.png)

The function will play the click sound as player presses buttons. Example:
[pasueContinue](https://github.com/MLA98/Gamedev189/blob/40effdbdf8978cd86fc19d549ac893de9beeb900/189GAME/Assets/Resources/Scripts/GameManager.cs#L327)

##### Weapon sound implementation
The sound is added through unity editor. ![picture](https://github.com/MLA98/Gamedev189/raw/master/imageHost/Screen%20Shot%202019-06-10%20at%209.53.39%20PM.png)

When the shoot button is clicked, the audio source will be played in [playerController.cs](https://github.com/MLA98/Gamedev189/blob/28572da8d3036f37825a21c2105d643ca10103b0/189GAME/Assets/Resources/Scripts/PlayerController.cs#L50) 

#### Sound Style
##### Background music for Home page
In the home page, the background music is sci-fi music from [Sci-fi Music pack](https://assetstore.unity.com/packages/audio/music/electronic/sci-fi-music-loops-pack-120186) on Unity asset store  The music sounds mysterious and chill. The music would give players a feeling of suspense and danger. Also, the music could make them ready for the challenges afterward.


##### Background music for battles

The battles in the game are really exciting. Players have to handle enemies from all the directions. Therefore, I picked "Space battle" in the [Sci-fi Music pack](https://assetstore.unity.com/packages/audio/music/electronic/sci-fi-music-loops-pack-120186) which sounds exciting. It mixes some drums which are exciting. The BGM can give players an exciting and engaging feeling.

##### No background music for wave_completed, upgrade, pause states
In these states, the player just finished some exciting fights. Therefore, they may need some rest. In addition, in the upgrade screen, silence could give the player some quiet time to think of upgrading.


##### Button Click sound

The buttons in the game provide various functions including pause, mute, restart, quit and start. The sounds of buttons are from [8 bit sounds](https://assetstore.unity.com/packages/audio/sound-fx/8-bit-sounds-free-package-3766). 


Realtime feedback - When the player clicks each button, they will get immediate sound feedback along with the shade of the button. It will give the player an input that he or she successfully click the button and the computer will follow his or her commands.

##### Shoot sound in battle 
Realtime feedback - For weapon shooting sound, we choose a high-pitched sound since the weapon of the player is laser gun. When the laser hit enemies, the sound will give players feedback that the enemies are destroyed.
 


## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**oDocument how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

### [Press Kit](https://mla98.github.io/Gamedev189/press_release.pdf)

- [Web page](https://mla98.github.io/Gamedev189/) source available in './docs', along with license for CSS library.

- Press kit document based off of [this Latex template](https://www.latextemplates.com/template/press-release). 

### [Trailer](https://www.youtube.com/watch?v=DS22M8uvKxo)

I wanted to create a trailer that grabbed the attention of the viewer. Given the top down nature of the game, I felt adding cinematic and playful shot of the main character running would immerse the viewer in the world of the game.

As for the in-game footage, I tried to capture visually appealing gameplay with interesting patterns, while showcasing different kinds of power-ups available to the player.

## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
