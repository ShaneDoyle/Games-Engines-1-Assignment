# Games-Engines-1-Assignment
## Original Proposal
### Description:
In this game, the player will explore a strange planet plagued with ominous features, creatures and environments.
I'm aiming to give the planet an eerie feeling and a sense of unfamiliarity. Some of the creatures will the dangerous to the player.
Some of the environments will be treacherous, so the player will have to be cautious of that too.
The player will have a gun to defend himself (probably some sort of futuristic laser gun to show off some cool sort of projectile)
Through some maths functions and other calculations, the creatures will behave, move and look oddly, like an unknown alien creature.

I want to add support for multiplayer too. Currently, I'd like to have the players compete against each other in some way.
The players will have to collect crystals that will randomly spawn around the map.
On death, a player will drop a crystal which can then be collected by the other player. First to X amount of crystals wins.
The objective of this game may change in the future but for now, this is what I hope to do.

### References:
I'm not purely basing the planet on anything. Honestly, I'm making it as I go along and seeing what ways I can implement complexity.
However, I may take some inspiration from the game World of Warcraft, as this features a land named "Outland" which looks like an alien planet.
See: https://i.ytimg.com/vi/I3UPfKhx8fE/maxresdefault.jpg

As for code, I am looking up things as I need them. I'm sure I will use some of the material covered in the labs such as the "tentacle" like movement.
I found https://www.youtube.com/user/Brackeys/videos in particular to be quite helpful for a few things.

## New Proposal
### Description:
The game aesthetic and environment is still the exact same but the gameplay is very different.
The environment is a dark and dead path covered and surrounded by green sludge. I created a colourful and eerie planet-like environment.
The player controls a space-tank that will explore the land and up to 2 players can play at the same time. The players work together to reach the end of the level.
The objective is to reach the end of the randomly generated level. Mutated living goo-monsters live on the planet and will attack the player as they try progress to the end of the level.
Each level, the goo-monsters get faster and tougher and spawn more frequently. The levels become bumpier and harder to navigate and also get longer. There is no end to this game as everything is randomly generated. In other words, there is no max level/wave.

## What this Assignment does and how it works:
### What it does:
This assignment aims to create a randomly generated endless co-op game that supports multiplayer (2 players). It uses random generation whenever possible which will be discussed in a moment. Enemies will get stronger and stronger and levels will get longer and longer, and this makes the levels increasingly difficult. The game has a cartoony look and looks visually smooth and pleasing. Things such as animations using rotations, scales & emissions give the game an alien like feel and a cartoony glow.

### How it works:
#### Wave Management:
The game is divided into different levels known as waves. The player must reach the end of the level to progress to the next wave. Every wave, the length of the map gets longer. This map is randomly generated in relation to height and detail. The map has 4 different planes, the lava plane, the starting plane, the normal plane and the ending plane. The game functions by detecting when the player is touching each plane and acts accordingly. For example, when the player touches the ending plane, the game detects this and knows to recreate the next level. Another example is being a certain distance away from the ending plane and the game will stop the generation of the goo-monsters as the player is beside the finish. It does this by deleting all the existing planes, increases wave variables such as enemy speed and map length and then recreates the level. This is an endless cycle and there is no limit to the amount of waves. The variables used for this algorithm can be easily adjusted for people who want to change the way it is generated or want to adjust difficulty etc.
#### Players:
The players have no HP and are eliminated when they make contact with either the lava plane or the goo-monsters. Players can shoot a bullet that is limited to a coroutine timer. These bullets inflict damage to the goo-monsters and each bullet does 1 damage. A goo-monster can take 3 hits by default.
#### Camera:
The camera works by calculating the average X position of all the players and then lerps to this position. Each player has a script that allows them to be tracked by the camera. For example, if Player 1 is at X=100 and Player 2 is at X=50, then the camera will lerp to X=75. Easily put, all X positions of all players are added together and then divided by the amount of players. This means that the camera is not hardcoded and can easily support more than 2 players if they were to be added. This gives the game a lot of scalability.
#### Enemies (Goo-Monsters):
The enemies constanly track the player. The enemies find the player with the shortest distance away from them and then moves towards them. Enemies have 3 health by default and 3 speed by default. Each wave, the speed increases by 1 (can be changed) and will keep increasing every wave until the max speed that is set is reached (10 by default). When the enemies die, the Y scale and the spin speed of the enemies is reduced and they lose their "Enemy" tag. The reason for losing the tag is to ensure that players don't die from touching an enemy that is dead. After a set amount of time, the X and Z scales are then reduced until the enemy then completey disappears. This gives a nice death animation to the enemy. The gameobject is then removed and the generation algorithm knows that another slot is now available to spawn a new enemy.
#### Audio:
Rather than individual gameobjects having an audio source, there is a global audio source that allows any object to play a sound. At the start of the game, the audio manager loads up every sound effect using a custom sound class. This audio manager is public and has a public function that takes in an argument which specifies the name of the sound effect. For example, take a look at the following command: <blockquote>"FindObjectOfType<AudioManager>().Play("Pop");"</blockquote> This will play the pop sound effect that is heard at the start of each wave and this can be called from any gameobject in the game. This makes it extremely easy to add more sound effects simply by expanding the sound array by one element and specifying the sound file and name.
#### Global Variables:
The game has global variables that are used in order to manage the game. These global variables are connected to a public gameobject and can be accessed by the other gameobjects. Some variables in here include generation arguments, enemy settings, wave settings and more. These variables allow the gameobjects in this game to work together and be able to respond to each other's actions more effectively. For example, the ending plane is able to increment settings every wave in order to make 
  
## Development:
The main part I can't take full credit for is the land generation. However, I did heavily modify the code which does make it quite different to the original. I made the land generation able to detect when to create the appropriate planes and adjust positions of these planes. The graphical textures are not completely mine but I did make heavy changes to them in an image editing software in order to create and build the environment. The bullet script is very simple and I didn't need to create my own so I used the one from one of the previous labs. I took some inspiration for the audio class in order to manage the sound effects a bit better. The rest of the code is  completely my own and the way in the game actually functions (wave management, animations, deaths, emissions etc.) is completely my interpretation. I wanted to give the game a nice visual style. I did this through the lava and the other glowing emissions, which make the game look colourful and alive. With my original idea, I wanted to try and implement random generation and add complexity. It was very hard to create random generation for the previous idea as it was a 3D environment that made use of the terrain feature in Unity. Once I created the lava planes seen in the current assignment, the new assignment idea was born. However, the aesthetic I was aiming for didn't change and I feel the current game style was successful at doing so.

## Proud elements of this Assignment:
I'm very happy with how nice the animations and materials look. Making clever use of scales, rotations, materials and emissions made this possible. The camera system I created from scratch to track the players is also very nice and works perfectly. On top of that, I'm happy that the game is actually pretty enjoyable to play!

## Video!
[![YouTube](https://i.ytimg.com/vi/3nb482ndvdY/hqdefault.jpg?sqp=-oaymwEZCPYBEIoBSFXyq4qpAwsIARUAAIhCGAFwAQ==&rs=AOn4CLAhNREP07nNhd3tYj3HHbnMuSnMmQ)](https://www.youtube.com/watch?v=3nb482ndvdY&)
