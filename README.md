**Web Page: https://mla98.github.io/Gamedev189/**

# Game Design Document

https://docs.google.com/document/d/1OoG64V6UgWOQgnyDLk36IJglLyYrlUKNWHvKCWiIzDg/edit?ts=5ce98005

Idea: Defend Your Base/Survival

Theme: Human astronaut in Space (Mars) with aliens shooting objects from random directions

## REQUIREMENTS FOR BASE GAME:

**Objective of the Game**: Defend your base from incoming enemies every level.
- Survival Mode: Limited Ammo, collect money to upgrade weapons or refill ammo between rounds.  For now, if ammo runs out game over.  Possibly in future implement ways to gather ammo when you run out

**Mechanics**:
- 2.5D? 2D in 3D
- Shooting pew pew laser
- Random Enemy spawn
- Increasing difficulty every level
- Human orbiting/running around planet

### PROSPECTIVE FEATURES?:	

- Hemisphere or full circle
	- lerp camera when switching sides of hemisphere
	- camera follows player around full circle accounting for rotation
- Planet gets bigger with each hit
- Different areas with different debuffs
- Object like supply ship flying fast by
	- If taken down, ultimate powerup
- Ultimate powerup bar filling up with killed enemies
	- Activate when full
- Ultimate + straight lazer
- Circle to move around

### GameObjects
- Hostile:
    - Supply ship
    - Normal Enemy Ships
    - Bombs that you don’t want to shoot
- Friendly:
    - Player
    - Base 
---
## Roles

### User Interface
- Heads-up Display:
    - Health Bar
    - Timer
    - Ammo bar for special weapons
    - Type of gun used
    
- Upgrade screen
    - Upgrade single weapon
	- Increase damage/ size of bullet?
	- Refill ammo
- Amount of Coins?
- Ultimate bar?

- Main menu
	- Start
	- Options
		- Change modes?
		- Change controls?
		- Sound options

- Pause menu
	- Time.timeScale = 0
	- Enable UI
- Game over screen

### Movement/Physics
- Gravity centered on planet
- Running/Orbiting with jump
- Projectile straight upward
- Enemies spawn from random places and move towards the planet (random path)
- Enemy projectiles aimed towards planet

 
### Animation and Visuals
Space Theme
- [Astronaut sprite](https://assetstore.unity.com/packages/3d/characters/humanoids/stylized-astronaut-114298)
- Space Background: [1](https://assetstore.unity.com/packages/3d/environments/sci-fi/vast-outer-space-38913), [2](https://assetstore.unity.com/packages/2d/textures-materials/sky/starfield-skybox-92717)


- Orangish material for Mars planet
- Long thin capsules for laser beams
- Space Junk/Debris: [1](https://assetstore.unity.com/packages/3d/environments/sci-fi/space-shooter-asteroids-96444), [2](https://assetstore.unity.com/packages/3d/props/space-debris-and-crates-99699)

- Gun?
- Space Rocks thrown?

### Input
- Menu
(Pause probably)
- Horizontal Axis to move left and right
- w to jump
- Either autoshoot or space bar to shoot
- Joystick in the future
### Game Logic
- Camera control
- Amount of money/ ammo
- Damage output calculation
- Health bar
- Collision detection
- Timer for each round

- Difficulty increasing over time and rounds
	- More complex paths over time
- Keep track of buffs from supply ship
- When to send supply ship


## Sub-roles
--- 

### Audio
- Background Music: 
    - https://drive.google.com/file/d/1GtKvWwhkVA9xwLqdmDfx1Vc36dvuGSA5/view?usp=sharing 
    - https://drive.google.com/file/d/1cp-JW4bcFAwTSCcjels-jfwYCtYiOmrt/view?usp=sharing Seamless loop?

- Laser Sound Effects
### Gameplay Testing  
- Just do it
### Narrative Design
- Possible secret ending? Don’t shoot
- The year is 1097 DE (During Elon); Elon Musk finally makes it Mars (Game Name: Musky Defenders) Aliens want to steal Elon’s precious Cryogenic technology to live longer.  Elon Musk holds off the invasion while the citizens of Mars evacuated to Andromeda.
### Press Kit and Trailer
- 360 noscope montage trailer
- Abstract of game features and our roles
- Web page
### Game Feel
- Explosions from crash
- Screen shakes every explosion
- Apply adsr envelope somewhere
- Face on Mars? Frowns each time it gets hit? (Probably not)
