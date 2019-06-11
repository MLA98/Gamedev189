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

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

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

**List your assets including their sources, and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

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
