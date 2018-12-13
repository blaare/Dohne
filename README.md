# Dohne

## Specification
### Concept
Dohne is simple. It's essentially a wolfenstein/doom clone where players will move about the map and attempt to reach the finish.
### Game Structure
There will be several maps, each with a different layout and the player will have to collect keys to advance through the areas.
### Players
The Player will have to move through the environment, there is neither co-op nor multiplayer, only solo.
### Actions
Players can do the following:
* Equip guns
* Fire guns
* Move around the map
* The ability to run to increase movement and lookspeed
* Use a melee weapon to conserve ammunition
All actors are infinitely tall, so if their direction is hit, the player will take damage. The same is true for enemies.
Objectives
The objective is simple, get to the end of the level. You may need to find keys to do so. Running past enemies is entirely an option, and may be recommended due to limited ammunition.

## Graphics
### Landscape
The landscape will be viewed head on in a first person perspective. The landscape will be built through applying textures to objects. Every level will take the shape of a cave, various rooms and chambers will be used. There will be different elevations but the player won’t be able to access all of them, they will only act as different enemy placements for variety. Infinitely tall actors, as mentioned in the actions section, will allow the player to hit them. Each area will have adequate area to hide behind for the given situation, for both you and the enemy. This is required given most weapons will be hitscan.
### Level of Detail
Low poly squares, ramps, steps, etc. will be used to construct the levels and objects. Along with these pieces, Unity's game engine will handle the LOD (Level of Detail) regarding texturing. Sprites will be used for just about everything else, including enemies and pickups. Objects in each of these maps include enemies, collectibles, false walls, and keys. Decorative objects will be added. These may also be able to be interacted with or destroyed in some way. For example, barrels or explosive crates may be lying around which explode and cause high amounts of damage within a small radius.
### HUD
The player will have a HUD that displays the following:
* Health
* Ammo count
* Current and available weapons
* Found keys

## Gameplay
### World
As mentioned before, every scene takes place inside of a spaceship. No outer walls/faces will be rendered for performance's sake.
Each level will be rather large taking several minutes to traverse.
###Landscape
The landscape will consist of the following:
* Solid flooring
* Computer Terminal like objects
* Typical science fiction objects - go crazy 
### Ground Type
The ground type of our levels will be simple textures that correspond to different rooms. The main textures are the following:
* Rough cavernous floors, ceilings
* Slightly developed walls
### Control
The user will use a standard FPS controller where WASD controls longitudinal and lateral movement. The mouse will control the user's aming by rotating along the y axis. Left mouse click will allow firing. Shift will make the player run.
### Pickups
* Ammo crates of varying capacity and type.
* Health restoration items of varying effectiveness.
* Enemies
* Probably robotic, alien, or both.
* Each will have a different overall strategy for attacking the player.
* Each will have specific number of hits, speed, range, etc.

