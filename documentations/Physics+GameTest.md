# Main Role: Physics in Musky Defender

## Player Movement

### Gravity System
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
### Player Rotation
Player is enabled to rotate around the planet by [MovePlayerClockWise.cs](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/MovePlayerClockwise.cs) and calls MovePosition to move:
```C#
        rigidBody.MovePosition(updatedPosition);
```
where updatedPosition is:
```C#
        var updatedPosition = rigidBody.position + rigidBody.transform.TransformDirection(moveDir) * moveSpeed * Time.fixedDeltaTime;
```

###Player Jump
Player can jump by [PlayerJump.cs](https://github.com/MLA98/Gamedev189/blob/master/189GAME/Assets/Resources/Scripts/PlayerJump.cs). It seems useless now, but, in future builds(UPDATED), jump will be melee attack for player in case of insufficient ammo.

[JUMP HAS ALREADY HAS THE FUNCTION AS A MELEE ATTACK NOW.](https://github.com/MLA98/Gamedev189/blob/91922453c3b27931559b001f8e6f44b2d772bda5/189GAME/Assets/Resources/Scripts/PlayerController.cs#L71)

## Enemy and Supply Ship Movement

### Enemy Movement

Enemies spawn outside the screen and move towards the planet. Because Enemy deal damage to the player by hitting the planet or the player. A straightforward path will be efficient to handle this game logic:
```C#
        transform.LookAt(planet);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
```
There is a Zig-Zag movement provided:
```C#
        transform.position = new Vector3(Mathf.PingPong(Time.time, 1), transform.position.y, transform.position.z);
```

### Supply Ship Movement

Supply ships move from one side of the screen to another side and require player to shoot at them to drop Health or Ammo Buffs.
Buffs has similar moving path as the enemy, in future, I will add ADSR envelop to buff movement to make them feel like being attracted towards the planet. 

## Movement Summary
At beginning, I planned to make our own physic system which typically contains gravity interaction with game objects. Which means that all entity game objects (Include Players, Enemies, Supply Ships and their buffs) attracted by the gravity and do orbital movement just like the real physics. However, I found that intervenes with the game play and game feel. The current Version contains the gravity system only on player it works well for the player. 
In this section, Movement and Physics, the part that most related to what we talked on class is the command pattern. Many commands are written under the IPlayer interface and it helps with the clarity of code structure.
One thing I feel can be potentially related is ADSR envelop. Although I didn't add it to our game due to my busy final schedule, it will be involved in future build in this game.

# Sub-Role: Game test

## Methods

As a game tester in my team, I used Google form to ask for opinions. Due to the form provided is too long and I don't expect other people would like to spend more than half an hour to give me feedback. I extracted few representative questions to our specific game, and these questions are what I expected to hear from users during the period of code development. 

In the Google Form and asked 6 questions to 10 participants. 
[Link to the Results](https://docs.google.com/forms/d/16UKjFR_uxIj1NUQ3Aiartenbah8IORJ5pXacHDoReO4/edit?usp=sharing)

One thing I noticed when I asked participants about our future improvements. Many of them mentioned about the player jump. At the day of Arcade presentation, the jump had no function instead of just jump. So for an unfinished movement, participants said that the jump function can be improved as a melee attack. Also, people said that, in this game, we could develop more weapons and attack for players instead of simply shooting laser beam. 

As for the difficulty, most people said our game was too easy. I think the game seems easy because the bigger enemy which takes three shots to eliminate is not introduced in the first and the second level. After the bigger enemy has been introduced, people reported at the arcade that the various type of enemies makes this game harder and kind of too hard to survive the wave. To fix this, we need do more balance on enemy spawn rate and numbers of enemies in the screen. 

Most of participants did not feel our game was innovative because they said that "I may have seen the concept done before in other places." But some other participants pointed out that the gravity system was new and interesting. 

When I asked our participants what should be our next step to fix, we got basically the same answer as the improvement part. 

In general, our game has good performance for it contains few major bugs. But people complained about our game due to single mode of attack and single mode of enemy behavior.
