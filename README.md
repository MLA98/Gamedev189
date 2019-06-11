# Game Basic Information #

## Summary ##

Set in an immersive space setting, MUSKY DEFENDER builds on the popular shoot 'em up genre with an interesting twist. Our hero, stationed on Mars, fights off waves of enemies, utilizing left/right movement and rocket jumping to get around the planet. Our hero starts out with a simple laser gun. As the waves of enemies grow stronger, so does our hero, with access to upgrades and power-ups at the end of each wave. Throughout the waves the player will face enemies of varying difficulties. The player must manage their resources well and build up their arsenal before ultimately reaching a boss fight that will surely stress test their abilities.

## Gameplay explanation ##

### Controls
- Use left and right keys (<-/-> or A/D) to move around the planet.
- Use the up key (W or ↑) to jump.
- Use spacebar to shoot your laser.
- Use esc key as an alternative way to pause

### Tutorial
Move around the planet and shoot your laser to destroy incoming enemy spaceships. Also note that jumping into enemies will also destroy them just don't do so at low health or you might die.  Be sure to keep track of your HUD to conserve your ammo and be wary of your health.  You start off with 50 ammo and a maximum of 10 health.  These can be replenished via spending points in the upgrade screen or shooting down supply ships providing either max health or 50 ammo.  Also be sure to check which camera option best suits you in the pause menu by clicking the camera icon.  There are two options: a static camera or a camera following your movement.

### Strategy
Your main goal is to survive the oncoming waves of enemies.  Each of the three enemies have different stats and behaviors for you to find out so react accordingly.  Be careful of the boss that arrives at wave 8.  In order to prepare, spend your points wisely on upgrades between waves.  If you aren't careful with your health or ammo, most of your points would be spent refilling them.  You can upgrade your fire rate and laser speed but be sure to save up for more the powerful upgrades: spreadshot and explosive lasers.


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

### Player Movement

#### Gravity System
Gravity Systems are retrieved from [Unity Asset Store](https://assetstore.unity.com/packages/tools/physics/orbital-gravity-movement-65682) by Author [Tiago Silva Duarte](https://assetstore.unity.com/publishers/22155). It provides oribital gravity by add force on rigid body:
```C#
        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
```
and Keep The Rotation Quaternion of the player always look like standing on the planet:

```C#
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
```
and calling the attract function from the gravity attarctor:

```C#
        attractor.Attract(transform);
```
#### Player Rotation
Player is enabled to rotate around the planet by [MovePlayerClockWise.cs](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/MovePlayerClockwise.cs) and calls MovePosition to move:
```C#
        rigidBody.MovePosition(updatedPosition);
```
where updatedPosition is:
```C#
        var updatedPosition = rigidBody.position + rigidBody.transform.TransformDirection(moveDir) * moveSpeed * Time.fixedDeltaTime;
```

#### Player Jump
Player can jump by [PlayerJump.cs](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/PlayerJump.cs). It seems useless now, but, in future builds(UPDATED), jump will be melee attack for player in case of insufficient ammo.

[JUMP HAS ALREADY HAS THE FUNCTION AS A MELEE ATTACK NOW.](https://github.com/MLA98/Gamedev189/blob/91922453c3b27931559b001f8e6f44b2d772bda5/189GAME/Assets/Resources/Scripts/PlayerController.cs#L71)

### Enemy and Supply Ship Movement

#### Enemy Movement

Enemies spawn outside the screen and move towards the planet. Because Enemy deal damage to the player by hitting the planet or the player. A straightforward path will be efficient to handle this game logic:
```C#
        transform.LookAt(planet);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
```
There is a Zig-Zag movement provided:
```C#
        transform.position = new Vector3(Mathf.PingPong(Time.time, 1), transform.position.y, transform.position.z);
```

#### Supply Ship Movement

Supply ships move from one side of the screen to another side and require player to shoot at them to drop Health or Ammo Buffs.
Buffs has similar moving path as the enemy, in future, I will add ADSR envelop to buff movement to make them feel like being attracted towards the planet. 

### Movement Summary
At beginning, I planned to make our own physic system which typically contains gravity interaction with game objects. Which means that all entity game objects (Include Players, Enemies, Supply Ships and their buffs) attracted by the gravity and do orbital movement just like the real physics. However, I found that intervenes with the game play and game feel. The current Version contains the gravity system only on player it works well for the player. 
In this section, Movement and Physics, the part that most related to what we talked on class is the command pattern. Many commands are written under the IPlayer interface and it helps with the clarity of code structure.
One thing I feel can be potentially related is ADSR envelop. Although I didn't add it to our game due to my busy final schedule, it will be involved in future build in this game.

## Animation and Visuals

**List your assets including their sources, and licenses.**

All 3D model assets were downloaded from the Unity asset store and follow the standard Unity EULA, and the publishers specified no restrictions and therefore are free to use for commercial and private use.

[Stylized Astronaut](https://assetstore.unity.com/packages/3d/characters/humanoids/stylized-astronaut-114298) by NIGHTSOUNDGAMES - Used for the player model.

[Starfield Skybox](https://assetstore.unity.com/packages/2d/textures-materials/sky/starfield-skybox-92717) by NIGHTSOUNDGAMES - Used for the game background.

[Alien Ships Pack](https://assetstore.unity.com/packages/3d/vehicles/space/alien-ships-pack-131137) by AUTARCA - for the enemies.

[Free Space Ships](https://assetstore.unity.com/packages/3d/vehicles/space/alien-ships-pack-131137) by 1MAFX - for the enemy supply ships.


**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

Our game has a simple, lighthearted, arcade type of feel. Therefore, our choice of assets should fit with the design and feel of the game. The models and graphics are detailed but have a cartoonish type of feel to fit the game. 

The player astronaut is a low-poly design and not meant to look realistic. However, it has enough detail to appreciate the animations when the character runs, jumps, and shoots. the quick and simple animations from the astronaut give the player feedback as they control the character. The jump animation as a summersault serves a purpose to make the jump seem more noticable since the astronaut is small in comparison to the rest of the screen, and also add to the feel that the jump is also an attack.

The enemy spaceships fit the cartoonish sci-fi environment that we intended for the setting of the game. The more difficult enemies, such as the green spaceship that takes more shots to destroy, and the fast purple spaceship both have a more menacing look than the standard enemy to show that they are different.

We combine these aesthetically pleasing assets with simple objects, such as a simple glowing rectangular prism for the lasers and simple spheres drawn in the unity engine for the power ups. Although simple, these elements still are fitting for the rest of the visual 3D cartoon style and also serves to be less distracting so that the player can focus on the gameplay while still enjoying the visuals.

## Input

Movement can be done using arrow keys or W (jump), A (left), D (right). Space bar is used to shoot. 

Input in the game is handled using the [SimpleInput library](https://github.com/yasirkula/UnitySimpleInput). It simply offers a [uniform way](https://github.com/MLA98/Gamedev189/blob/704260c03faa5f1aa66697238ba8202b40af3640/189GAME/Assets/Resources/Scripts/PlayerController.cs#L38) of getting user inputs such that input can be detected from keyboards, joysticks, and UI buttons, depending on the platform.

- Desktop - SimpleInput offers a conveniently familiar API for getting input.

- Mobile - UI buttons are used for user input, and [HUDController.cs](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/HUDController.cs) toggles the UI buttons depending on the state of the game. 


*Command Pattern* - The game uses the command pattern by implementing [IPlayerCommand](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/IPlayerCommand.cs), a command interface which is extended by [MovePlayerClockwise](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/MovePlayerClockwise.cs), [MovePlayerCounterClockwise](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/MovePlayerCounterClockwise.cs), [PlayerJump](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/PlayerJump.cs), and [PlayerShoot](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/PlayerShoot.cs).

## Game Logic

### Singleton
A [singleton](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/GameManager.cs#L72) method was used on our GameManager in order to manage variables used among all other scripts.  This is done by instantiating a private static instance inside the Awake function of the GameManagers MonoBehaviour.  It checks if there's another instance and destroys itself if there is or instantiates itself if there isn't.  Other scripts are then able to access this instance through a public getter function.  The structure of using a singleton was based off [this forum post](https://gamedev.stackexchange.com/a/116010).

Inside the GameManager we stored various variables and states, as well as managing UI and button scripts.  The key gameplay variables include Score, Health, Ammo, and Wave.  

### Score
Score is the amount of points obtained [from destroying enemies](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/EnemyController.cs#L109).  These points can then be used to refill 100 ammo for 10 points or refill all health for 50 points as well as be used for various upgrades [starting here](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/GameManager.cs#L276) to your laser gun at the end of each wave.  These upgrades include increasing fire rate and laser speed by a factor of 1.1 times for 250 points.  There are also one time upgrades for spreadshot for 500 points and explosive shots for 1000 points.  The spreadshot shoots 3 lasers in a spread out pattern.  The explosive shot creates an explosion on impact with an enemy which can then destroy other enemies that run into it.  The default enemy gives you 5 points, big enemy gives you 10 points, tiny enemy gives you 15 points, supply ships give you 20 points, and the boss gives you 100 points.  

### Health
The health is initialized as 10 health points.  The default enemy and tiny enemy takes away 1 health point, the big enemy takes away 2 health points, and the boss takes away 10 health points (an instant kill).  To refill health to max, you can gather the [pink orbs](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/HealthBuff.cs#L28) from supply ships or spend [50 points](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/GameManager.cs#L266) in the upgrade screen.

### Ammo
The ammo is amount of lasers left that you can shoot.  You start off with 50 ammo and each shot takes away one ammo.  Later on, when you upgrade to spreadshot, 3 lasers are shot at a time and thus [3 ammo](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/PlayerShoot.cs#L50) is taken away.  To refill ammo, you can gather [50 ammo](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/AmmoBuff.cs#L29) from green orbs dropped by supply ships and [100 ammo](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/GameManager.cs#L256) from spending 10 points in the upgrade screen.

### Wave
Finally, the last variable is Wave which keeps track of which wave the player is currently on.  The number is also used to adjust the difficulty of the wave.  The spawn rate of enemies are increased by decreasing the time between each spawn using the [linear equation](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/EnemySpawner.cs#L30) 2 - 0.1 * (Wave - 1).  It is also used for the amount of enemies spawned using the [linear equation](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/EnemySpawner.cs#L29) 12 * Wave.  The Wave number also indicates which enemies are spawned and their probability of being spawned through the use of if statements starting [here](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/EnemySpawner.cs#L53).  Waves 1 and 2 only have the default enemies.  Waves 3 and 4 have the default enemies spawn 70% of the time and big enemies spawn 30% of the time.  Waves 5 - 7 have default enemies spawn 40% of the time, big enemies spawn 35% of the time, and small enemies spawn 25% of the time.  This is done by using a random number generator and if statements.  At [wave 8](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/EnemySpawner.cs#L96), only the boss is spawned once by using a boolean to tell if it was spawned already in the update function.  Similar spawning logic from the Wave variable is used for spawning supply ships as well.  Their limit is increased by the [linear equation](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/SShipSpawner.cs#L25) 4 * Wave and the spawn rate is decreased by increasing the rate between each spawn by the [linear equation](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/SShipSpawner.cs#L26) 5 * Wave.

### Game States and Transitions
The [states](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/GameManager.cs#L63) stored in GameManager include title, bootUp, gameOver, waveCompleted, playing, pause, upgradeScreenState, won, and dialogueScreenState.  The game starts off in the title state which is [initialized](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/GameManager.cs#L91) in the start function of GameManager.  This state contains the title screen with the planet in the middle, our logo, as well as a play button, mute button, and exit button.  When clicking the play button on the title screen, the game state then [transitions](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/GameManager.cs#L383) to the boot up state which uses game feel to transition to the play state.  During the playing state, you can [move your character](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/PlayerController.cs#L35) around the planet to shoot enemies which are also spawning.  You can [pause](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/GameManager.cs#L330) the game using the pause button or esc key which then transitions the game to the pause state in which [enemy](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/EnemyController.cs#L34), player, and [laser movement](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/Projectile.cs#L30) are all stopped.  Since movement is stopped there is no way to transition from pause to waveCompleted or gameOver.  Movement continues when the game is unpaused and taken back to the playing state.  When the set amount of enemies are all destroyed, the game [transitions](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/EnemySpawner.cs#L90) from playing state to waveCompleted state.  We look after the amount of enemies spawned matches the wave limit then check if there's any gameobjects with the enemy tag.  This state stops movement and brings up the Wave Completed Screen.  From this state, there are buttons to transition to other states.  The upgrade button goes to the upgradeScreenState which pulls of the upgrade UI where points are used to buy upgrades.  The wave complete state also has a journal entry button which transitions to the dialogueScreenState which pulls up unique journal entries from Elon Musk at the end of each wave.  A button in this screen takes you back to the waveCompleted state.  From the waveCompleted and upgradeScreen states there's a button to continue to the next wave which increments the wave by 1 and transitions to the playing state.  If the health is decreased to 0 or below the playing state transitions to the gameOver state where the planet is destroyed, enemy movement stops, and the game over screen is pulled up.  If the player manages to beat the boss in wave 8, the game [transitions](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/EnemySpawner.cs#L104) to the won state where movement stops and the win screen with a special link is pulled up.  There's also a button to go to the title screen by reloading the scene bringing us back to the initial title state.  This same button is also located in the pause screen.

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

### Methods

As a game tester in my team, I used Google form to ask for opinions. Due to the form provided is too long and I don't expect other people would like to spend more than half an hour to give me feedback. I extracted few representative questions to our specific game, and these questions are what I expected to hear from users during the period of code development. 

In the Google Form and asked 6 questions to 10 participants. 
[Link to the Results](https://docs.google.com/forms/d/16UKjFR_uxIj1NUQ3Aiartenbah8IORJ5pXacHDoReO4/edit?usp=sharing)

One thing I noticed when I asked participants about our future improvements. Many of them mentioned about the player jump. At the day of Arcade presentation, the jump had no function instead of just jump. So for an unfinished movement, participants said that the jump function can be improved as a melee attack. Also, people said that, in this game, we could develop more weapons and attack for players instead of simply shooting laser beam. 

As for the difficulty, most people said our game was too easy. I think the game seems easy because the bigger enemy which takes three shots to eliminate is not introduced in the first and the second level. After the bigger enemy has been introduced, people reported at the arcade that the various type of enemies makes this game harder and kind of too hard to survive the wave. To fix this, we need do more balance on enemy spawn rate and numbers of enemies in the screen. 

Most of participants did not feel our game was innovative because they said that "I may have seen the concept done before in other places." But some other participants pointed out that the gravity system was new and interesting. 

When I asked our participants what should be our next step to fix, we got basically the same answer as the improvement part. 

In general, our game has good performance for it contains few major bugs. But people complained about our game due to single mode of attack and single mode of enemy behavior.

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

To guide us on starting with a narrative, we first viewed [this quick youtube video by Extra Credits](https://www.youtube.com/watch?v=22HoViH4vOU) explaining narrative design. One thing that they mentioned about coming up with a good narrative was that it was best not to start with a story. So in very beginning of our game creating process, we were first brainstorming the type of game we wanted, the game mechanics, and the game setting before coming up with any story around it.

Once we decided that our game would be a defend your base type game in space, We came up with the basic plot of Elon Musk defending Mars. You can see that the planet is Mars because we chose a texture for the planet that is red, and the spaceships are alien-like to show that they are invaders. 

One important device linking our narrative to our gameplay is the "Diary Entries" that can be viewed between waves. The Diary gives insight to Elon Musk's thoughts before the next wave, but these entries are more than just something that is shoehorned into our game to give a sense of a story. The Diary entries also give clues as to what the player should expect in the next wave. For example, Wave 3 is when the big green spaceships will start to appear, and the Diary will mention that he sees big spaceships coming in the distance. After that wave, the Diary entry mentions that the big spaceships are difficult to take down but would be easier with more powerful lasers or by using melee attacks, so the player can use that information to guide them to play the game. 



## Press Kit and Trailer

### [Press Kit](https://mla98.github.io/Gamedev189/press_release.pdf)

- [Web page](https://mla98.github.io/Gamedev189/) source available in './docs', along with license for CSS library.

- Press kit document based off of [this Latex template](https://www.latextemplates.com/template/press-release). 

### [Trailer](https://www.youtube.com/watch?v=DS22M8uvKxo)

I wanted to create a trailer that grabbed the attention of the viewer. Given the top down nature of the game, I felt adding cinematic and playful shot of the main character running would immerse the viewer in the world of the game.

As for the in-game footage, I tried to capture visually appealing gameplay with interesting patterns, while showcasing different kinds of power-ups available to the player.

## Game Feel

### Boot Up Immersion
The sequence of the title screen to boot up to playing state was added to give off an immersive experience from the moment you press the play button.  The camera is rotated around the planet as well as backing up through the use of lerp.  The [rotation](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/CameraController.cs#L51) was achieved by putting the camera in an empty game object located in the center of the planet.  The parent then used Quaternion.Euler to rotate with a value that was changed via Mathf.Lerp.  This empty game object is rotated to achieve the effect of rotating around the planet.  The [backing up](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/CameraController.cs#L49) is a simple lerp of the y position of the camera itself.  The player is also placed above the planet out of the camera view set inactive until the boot up camera lerp is finished and [sets it active](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/CameraController.cs#L55).  This is to give the player the feeling of having an "Iron-Man"-like landing onto the planet as gravity drags the player back to the planet as it is set active.  

### Screen Shake
Screen shake is also implemented to the camera and is activated when the player is hit.  The [implementation](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/CameraController.cs#L69) is taken from [this code from Github Gist](https://gist.github.com/ftvs/5822103).  A boolean called hit in the singleton GameManager is [set true](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/EnemyController.cs#L84) in the EnemyController when it collides with the player or planet and is then set false after the screen shake is over in the CameraController.  The camera shake effect [is increased](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/CameraController.cs#L59) when the players health reaches 0.  I went through a roundabout way to change the factor once without it resetting constantly leading to a never ending screen shake.  I checked if the health ranged from -9 to 0 which is the furthest back the health can get due to the boss being able to take away 10 health points from a health bar with 1 point.  From there I increased the factors of the screen shake then subtracted the health by 10 to get out of the if statement in the update function.  When adding jump as a method to destroy enemies, we decided to keep screen shake for that part as well.  We differentiate actually being hit and destroying enemies by using a [flash of a translucent red image](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/CameraController.cs#L73).  We are able to differentiate the collisions through the use of another [boolean](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/EnemyController.cs#L57) called melee.

### Optional Camera Rotation
The last effect I added to the camera controller for game feel is an option to change the camera from being static to lerping and following the player's rotation.  This option is added in the pause menu and the effect can be seen while in the pause menu as the camera lerps to match the players rotation or lerps back to the static position.  These camera options [are found](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/CameraController.cs#L92) in the LateUpdate function of the CameraController.  For the [lerping rotating camera](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/CameraController.cs#L98), we took the current rotation of the camera and lerped it to the rotation of the player - 90 due to the way we placed the planet and player with respect to the camera.  We used Time.deltaTime as the third parameter of the Quaternion.Lerp in order to constantly lerp.  Switching back to the static rotation, we [lerp](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/CameraController.cs#L109) the camera's rotation from the current rotation to the starting rotation (90, 90, 0).  We do this once by taking the [Time.time](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/CameraController.cs#L99) from the rotating camera controller and using the [percent](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/CameraController.cs#L104) of the current time minus this along with a set lerp duration as the third parameter and stop when the percent is at 100%.  I originally tried to lerp the EulerAngles but it didn't work correctly.  I ended up using [this forum post](https://forum.unity.com/threads/euler-rotation-lerp.129006/) to convert the EulerAngles to Quaternion to use Quaternion.Lerp.

### Explosions
I also added explosion particles to make the explosions feel more real.  The explosive lasers used to just produce expanding red spheres.  Instead, I made the sphere invisible and added a single burst of particles erupting in a sphere when the explosion is instantiated.  I added a more dramatic explosion when your health reaches 0 or less.  [This](https://github.com/MLA98/Gamedev189/blob/1087d1c0f02277739aca91a197f4adf6050bee4b/189GAME/Assets/Resources/Scripts/EnemyController.cs#L88) is activated by enabling the planets emission then playing it.  I used [this Unity tutorial](https://docs.unity3d.com/Manual/PartSysExplosion.html) to create these explosive effects in the particle system along with the particles from [this asset](https://assetstore.unity.com/packages/vfx/particles/fire-explosions/particle-dissolve-shader-package-33631).
