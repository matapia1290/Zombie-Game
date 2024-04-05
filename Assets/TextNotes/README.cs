/*
 To the reader: I created this as a journal of progress of this game.
on the first day of development i deciced to keep track of things such as goals, bugs, struggles, and write progress of what i did on a certain day.

During development, I will be using '[]' as required goals and '{}' as optional goals. On the next day I will have each completed goal with a [X]/{X} 
to symbolize completed goals.

Day 1, 11/10/2023
I wanted to create a control script that allows the player to move around using transform to have a smoother movement.
I also then took forever to create a script that takes the movement of the mouse.
the way it worked was like this:
    Take the input of the X or Y axis
    set a rotate var added and equal to the the movement of the mouse script
        for the vertical script set a clamp to min 90 and max 70 
    have a Quaternion rotate to look in that direction so when moving the WASD stays consistent.


Goals:
    [] Create a larger map and begin nav mesh 
    [] Create an agent that will go to player
    [] Create a shooting system that shoots basic bullets
    [] Add a jump feature in the MovementScript
    {} Create a small pistol and adjust bullets spawning from weapon

Day 2, 11/11/2023
    [] Create a larger map and begin nav mesh 
    [X] Create an agent that will go to player
    [] Create a shooting system that shoots basic bullets
    [X] Add a jump feature in the MovementScript
    {} Create a small pistol and adjust bullets spawning from weapon

I focused on working on the Movement script to make the jumping smoother.
   When input is detected to make the speed at 5 but when Left-Shift is held
   up the speed to 8.5 until Left-Shift it let go
I used AddForce() to create a realistic jump since Transform just teleports you in the air
    Added two on collisions and added a tag to the floor. When player is colliding with floor, allow player to jump
    Added a bool that is set to false when in air to prevent double jump
I removed the Capsule and replaced it with a tall and skinny cube for the player that i turned into a prefab
    Had issues with player sliding when running into objects.
    Because of the rounded bottoms, the player slides around when colliding with non-floor objects
Followed by 2 more prefabs, enemy and ally. These will be used as Mesh Agents for the next developent
    They are the same dimensions as the player.

Goals:
    [] Begin nav-mesh bake
    [] Create a script for agent that goes to player
    [] Create a shooting system that shoots basic bullets
    [] Create basic cover for the agent to navigate
    {} Turn cover to a maze for the agent to follow.
    {} Create a small pistol and adjust bullets spawning from weapon
 */