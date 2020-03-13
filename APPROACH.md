# APPROACH

## Session 001

**Wed Sep 11 15:40:50 - Wed Sep 11 17:22:07**

**To do**
- Plan project
    - Write spec with description, user stories, UX design

**Done**
- Initialised repo with readme and approach
- Made initial mechanics design diagrams
```
The original game was restricted to playing with fixed buttons made of plastic:
```

![original_gameplay](wip/OriginalGameplay.png)

```
There was no win state, the length of the longest sequence you remembered was your high score.

Taking inspriration from this but with the flexibility of being able to display anything:
```
![new gameplay](wip/NewGameplay.png)
```
Again the win state will just be a highscore, but with this version the higher your score the more vibrant and dynamic the visual effects could get.
```
- Wrote initial user stories
- Added terminology of main gameplay loops
- Added notes about the future evolution and application of this project

## Session 002

**Thu Sep 12 15:14:15 - Thu Sep 12 16:57:02"

**To do**
- Plan the UX
- Initialise Unity project
- Start on the first user story

**Done**
- Drew the intitial draft of the UX, sans some styling

![UX](wip/UX_001.png)

- Made a new project with a black background

- Test driving the development, delineated the UX loop:
    - Press the start button
    - Watch a gesture
    - Draw a gesture
    - See another gesture if succesful or my score if not
    - Go back to the start menu after seeing my score

- Setting up for testing:
    - Create Assets/Scripts folder
    - Open the Test Runner Window
    - Click create edit mode test runner folder in /Scripts
    - Created StartButtonTest file
    - Checked placeholder tests pass

![testrunner](wip/testrunner.png)

- Made a .gitignore
- Excluded temp, log, library, builds folders, and all .meta files
- Set Unity package names in player settings
- Ran a test build in Unity
- Unity hanging so forcing quit
- Renamed Unity project folder to remove space
- Build completed

## Session 003

**Fri Sep 27 13:36:43 - Fri Sep 27 14:13:48**

**To do**
- Delineate the first developer story
- Prioritize tasks in a Trello board

**Done**
- Made a [Trello board](https://trello.com/b/6atZPpqj/n3ttl3tsays) with user story 4 intial tasks
- Decided to make it work first in the editor, then in play mode
- Changed my mind about that. Recording in play mode, tools in edit mode.

## Session 004

**Fri Sep 27 15:59:38 - Fri Sep 27 17:08:15**

**To do**
- See if I can console log while running play on my phone
- Test writing the mouse position to file

**Done**
- Ran game on phone
- Ran on phone with visible cube
- Running game just a black screen
- Was in the wrong scene, not in build
- Input Manager in scene that logs mouse position when touching:

![UnityLog](./wip/UnityLog.png)
- Logging input work on the laptop, doesn't show from the phone
- Tried an adb command:
```
adb logcat -s Unity ActivityManager PackageManager dalvikvm DEBUG

```
- Tried installing modules through unity hub and running the monitor
- Monitor not showing log when touching screen
- Monitor does show now, made a Unity tag filter, added monitor to start menu

![AndroidLog](./wip/AndroidLog.png)

- Touch is loggable. Will have to convert mousepos to account for different screen sizes

## Session 005

**Fri Sep 27 17:20:53 - Fri Sep 27 17:57:28**

**To Do**
- Test logging mouse hold position to console
- Move a ball with touch

**Done**
- Logging isn't really a thing to test.
- Touching the screen moves the object but not as expected
- Translating screen to world space

![wip001](./wip/wip001.gif)

- Noticeable lag on device
    - Changing to FixedUpdate didn't help
    - Need to change to Touches instead of MouseButton

## Session 006

**Mon Oct  7 17:05:40 - Mon Oct  7 18:38:50**

**To do**
- Change out testing story for Houdini instead
- Change mouse pos for touch events

**Done**
- Changed the user story. Trying to test it is just getting in the way. I think it would be more relevent if this was a team project.
- Logged the Input.touchCount to check the device registers touches properly
- Movement changed to touch input but still lagging
    - Reading online, apparently this is a common issue due to engine framerate. Installing a preview package to see if this fixes it since low latency is mission critical.

    ![inputpackage](wip/inputpackage.png)
    - Changed the player settings to only use the new input system
    - Added the UnityEngine.InputSystem namespace
    - After reading around, I may have to do this through a new component instead of in a script.


## Session 007

**Sun Oct 13 17:29:44 - Sun Oct 13 18:40:30**

**To do**
- Use the new input system to trigger a script method

**Done**
- Created a controls actions asset
- In the inspector for the asset, click create c# file
- Create a playergesturingscript that has a private Controls assigned in awake
- Add the assembly reference:
    ```
    using UnityEngine.InputSystem;
    ```
- Add on enable and disable events that add/remove callbacks to the action and enable them
- Tested the input on the device logs the message, it does

## Session 008

**Sun Oct 13 19:40:51 - Sun Oct 13 21:22:00**

**To do**
- Get the position of the touch
- Move the cube with the touch

**Done**
- Added a new action to the input controller
- Set it to be a value, the touch position
- Read the value
- Use the value to change position of cube
- Still lags
- Found a paid plugin on the asset store that can decrease the latency slightly
- Using android debug tools, found that there is a lag natively on android, not just from unity.
- Could be a mission critical limitation, no way to know without testing the mvp
- Found another thread that used normalised values to cut latency
- Not really sure what normalize does but didn't help

## Session 009

**Mon Oct 21 18:42:25 - Mon Oct 21 19:17:45**

**To do**
- Roll back to simple touch input
- Implement simple click input
- Make touches and clicks trigger separate behaviour script (single responsibility principle)
- Plan the implementation of turns and rounds

**Done**
- Went back to simple touch input
- Simple mouse input
- touches and clicks trigger GestureControl component

## Session 010

**Mon Oct 21 19:50:44 - Mon Oct 21 20:36:02**

**To do**
- Plan the implementation of turns and rounds
- Make some gestures in the animator. Get the game loop working before planning the recorder implementation


**Done**
- Removed the old input package
- Started the CRC diagram:

    ![CRC](wip/CRC.png)

- Started the control flow diagram but got a bit stuck:

    ![controlflow01](wip/controlflow01.png)

- Roughed out the game loop algorithm
    - 1. Player presses play
            - Tap the play button
            - Enter game mode scene
    - 2. Watch a gesture
            - Start the visual metronome border
            - Make a list of gestures
            - Choose one from library and add it
            - Play the next gesture on the list
    - 3. Try and copy the gesture
            - Restart the visual metronome border
            - Play the gesture invisibly
            - If the touch collides with the gesture, increase the turn score
    - 4. If close, emit sparkles
            - When turn score increases, emit particles
    - 5. If enough sparkles, next round (repeat from 2 with a new gesture added)
            - Wait for the metronome to finish
            - If turn score > difficulty out of a hundred, back to 2
    - 6. If not enough sparkles, game ends
            - If turn score < difficulty out of a hundred, go to 7
    - 7. Display the score
            - Keep score across to game ended screen

## Session 011

**Mon Oct 21 20:43:55 - Mon Oct 21 21:13:43**

**To do**
- Make menu, main and end scenes
- Make buttons to move between them
- Make a visual metronome that just plays twice for now

**Done**
- Made a menu scene and removed input and gesture control scripts
- Added a canvas and button to the input manager
- made a menu script with a playnewgame method
- Created a new canvas gameobject instead, added the menu script to that
- Changed the method to accept a string for the level to make it reuseable
- Copied the scene and changed button text and level to load string, to make it the end menu
- Made a GameManager script on a new empty object
- Made a new canvas object called metronome and started adding borders

## Session 012

**Mon Oct 21 21:18:59 - Mon Oct 21 22:05:11**

**To Do**
- Make the border
- Animate the border
- Add game over logic

**Done**
- Added border panels and anchored them to each side
- Made the canvas size renderer a constant pixel size
- Made an animation folder with a controller for the new metronome animator component
- Added a new animation in the controller with the borders colours as parameters
- Faded the colour from white to black

    ![wip002](wip/wip002.gif)

-  Made a metronome script with a finishTurn method
- Added a switch so the metronome flips the current turn on the gamemanager between game and player
- Added an event to the animator the trigger the switch
- Added a method to check the turn score if it is the player turn
    - difficulty value is a range slider from 0 to 100
    - Loads end menu if < difficulty
    - Happens late...
- Changed the canvas's to have constant physical size instead of by pixels (looked to small on device)
- Adjusted dimensions of buttons and borders

## Session 013

**Fri Oct 25 13:46:40 - Fri Oct 25 14:57:12**

**To do**
- Remove latency on metronome check(only trigger fade animation if passed?)
- Make sample animations as example gestures

**Done**
- Added a trigger condition to the metronome's animator loop
- Found the animator with getcomponent
- Set play trigger unless player fail
- Made a gesture library folder
- Made a GestureLibraryInput script that will read from the library and send a vector to the gesture control
- Gave the input manager an animator
- Made an empty to animate
- Made a sample animation to trigger
- Trigger the anim on game's turn
- Coroutine starts and stops sending the animtarget vector to gesture control
- Moved the worldpoint logic to only the relevant inputs
- Disable touch and mouse inputs from game manager during game's turn
- Made gamemanager trigger game's turn first

## Session 014

**Fri Oct 25 16:26:50 - Fri Oct 25 17:36:44**

**To do**
- Increase length of metronome and gestures
- Play animations in the background of player's turn for comparison
- Use collisions to detect tracing
- Collisions add up to reach win condition

**Done**
- Increased turn length (manually, needs to be centralised)
- Triggered the gesture to play but not send a vector
- Gave the animatarget a collider
- Renamed the animtarget to gesturetarget and gave it a script
- Increase int(score) on gesturetarget during collisions
- Add an event at the start of the metronome
- Split logic between the events
- Difficulty needs to be dynamic, based on frame count
    - Measure it at the start of a player turn
    - Measure it at the finish of a player turn
    - Minus the start from the finish
    - Difficulty = that minus 10% of it
    - Made it 20% offset instead
    - After playing on device, made it 40%
- Losing:

![wip003](wip/wip003.gif)

- Winning:

![wip004](wip/wip004.gif)

## Session 015

**Fri Oct 25 18:03:20 - Fri Oct 25 18:39:56**

**To do**
- Change the cube to a sphere
- deactivate target sphere mesh during game's turn
- make more gesture sample animations

**Done**
- Cube to sphere
- Set mesh renderer as a public variable, enabled and disabled it
- Made three more sample gestures

## Session 016

**Wed Oct 30 15:46:20 - Wed Oct 30 17:02:55**

**To do**
- choose from gestures randomly
    - make a list of gestures from folder
    - directly assign it
- add gestures to an list to iterate through each round


**Done**
- Tried getting all the gestures with AssetDatabase.LoadAllAssetsAtPath,didn't work
- Resources folder is standard practice, switching to Resources.LoadAll("Gestures", typeof(Animation)), still doesn't work
- Found can't add them manually either
- Was declaring them as Animations, should have been AnimationClips
- Trying to use animator overrides but not changing anything
    - The actual clip name, not the state node, needs to be provided for override

## Session 017

**Wed Oct 30 17:11:39 - Wed Oct 30 18:20:03**

**To do**
- Make it easier without trivialising it

**Done**
- Increased the collider size (difficulty adjustment)
- Decreased the mesh size (aesthetic adjustment)
- Decreased the difficulty of the game manager
- Still too difficult, increase collider size again
- The touch collider needs to only exist when the player is touching, or the difficulty is skewed by initial overlap
- Deactivated pointer(mesh renderer and collider) unless there is a change in input position
- Didn't work on device, only at first frame tap
- Renamed difficulty to miss allowance
- Set the pointer to off to start
- Not sure why it isn't working on device, should be updating same as touch or library input

## Session 018

**Thu Oct 31 14:45:42 - Thu Oct 31 15:14:32**

**To do**
- Debug device input affecting pointer visibility

**Done**
- Trying to get visibility on when the renderer is disabled
    - Maybe getting two calls to the update gesture method per frame from touch
    - Logged the frame count and the mesh state to see that it is being triggered twice

    ![wip005](wip/wip005.png)

## Session 019

**Thu Oct 31 15:31:59 - Thu Oct 31 16:02:07**

**To do**
- Stop the method being triggered twice per frame

**Done**
- Add an automatic switch for input (editor/device)
    - For activating input on player's turn

    ```
    #if UNITY_EDITOR
            mouseInput.enabled = !mouseInput.enabled;
    #elif UNITY_ANDROID
            touchInput.enabled = !touchInput.enabled;
            Debug.Log("touch input enabled");
    #endif
    ```
    - This made sure only the relevant input is available

## Session 020

**Thu Oct 31 16:11:42 - Thu Oct 31 17:11:11**

**To do**
- Stop pointer flickering

**Done**
- Added animation events manually to gestures, to turn on and off the position updates at relevant times
    
    ![wip006](wip/wip006.png)

    The second event has to be two frames after the motion rests!
- Made pointer turn off at the end of played gestures
- Turned the pointer off when the touch ends

## Session 021

**Thu Nov 14 14:42:02 - Thu Nov 14 15:10:21**

**To do**
- Change frame count to only include moving frames 
    - Move the frame count logic to the gesture controller

**Done**
- Refamiliarised myself with the scripts
- Moved the logic to the gesture taget, not pointer

## Session 022

**Thu Nov 14 15:20:58 - Thu Nov 14 15:52:55**

**To do**
- Retrieve the gesture frame count
- Update the difficulty handicap accordingly

**Done**
- Retrieve the gesture frame count
- Turn off the target rendered when it isn't moving
- Cleaned up some dead variables and logic
- Tested the updated difficulty myself, and on someone else

![wip007](wip/wip007.gif)

## Session 023

**Thu Nov 14 16:12:00 - Thu Nov 14 17:32:00**

**To do**
- Incremental chain of gestures, grows as player succeeds
    - List of gestures in sequence
        - On game manager
    - Add to them when a new one is picked each round
        - Chosen from library
    - Iterate through them each turn
        - update a turn count incrementer

**Done**
- Game manager has an empty list at the start of a game
- It chooses a gesture from the library and tells it to play it
- Need to start and end rounds, not just turns
    - Increasing and then resetting the beat counter addresses this
- The sequences work, but there might be a bug with viewing the player input pointer
    - Moved the appropriate finish player turn out of the conditional
    - Renamed methods to avoid confusion with updated terminology

![wip008](wip/wip008.gif)

## Session 024

**Fri Nov 15 15:20:31 - Fri Nov 15 15:49:03**

**To do**
- Add score to lose screen
- Add highscore to main screen

**Done**
- Made a ScoreManager object to carry the score across scenes
- Made a ScoreManager script on the empty
    - Set it to not destroy on load
    - Game Manager knows it and sets its score
    - Menu script deletes it at button press
    - End menu UI text is set to be score

![wip009](wip/wip009.png)

## Session 025

**Fri Nov 15 17:13:48 - Fri Nov 15 17:57:07**

**To do**
- Add highscore to main screen

**Done**
- Store the score in playerprefs if it is higher than the current stored score
- Display the score on the start menu
- Increased the metronome width for visibility
- Changed the start button hover colour
- Rearranged the score texts
- Tested on device
- Rearranged the score texts again

![wip010](wip/wip010.png)
![wip011](wip/wip011.png)
![wip012](wip/wip012.png)

## Session 026

**Fri Nov 15 18:30:51 - Fri Nov 15 19:04:18**

**To do**
- Make it visibly obvious whose turn it is
    - Add lines in the corner that point in on the game's turn, and out on the player's turn

**Done**
- Added UI images in the corners
- Refactored the game manager logic checking whose turn it is
- Game manager triggers metronome points on turn change
    - Works, but should happen at start of turn not the end
    - Game manager flips a bool, which is checked by metronome at beat's start
- Renamed metronome methods to new terminology

![wip013](wip/wip013.gif)
---

## Session 027

**Mon Feb 10 13:48:26 - Mon Feb 10 14:15:40**

**To do**
- Refamiliarise myself with the project
    - Control flow diagram

**Done**
- Made a particle manager object with script
- Referenced the particle manager script in GameManager and GestureTarget
- Placed comments in the other scripts where they need to call the particle maker
- Made updatelevel, updatebeat and emit methods

## Session 028

**Mon Feb 10 14:21:07 - Mon Feb 10 14:53:21**

**To do**
- Call methods from managers
- Emit basic particles that die
- Encapsulate control in the game manager

**Done**
- Removed dupication of data across game and particle managers
- collider triggers emit on gamemanager, who checks whose turn it is before passing on the method call
- Made a particle with a script, added it in particle manager as a prefab
- collider passes it's position for emission
- game manager sends position for emission
- particles emit and crash editor

## Session 029

**Mon Feb 10 15:03:51 - Mon Feb 10 15:44:19**

**To do**
- Find out why it crashes and fix it
- Test on device

**Done**
- The colliders on the particles were triggering emission of each other, exponentially
- Particles die after one second
- Works on phone

## Session 030

**Mon Feb 10 15:59:02 - Mon Feb 10 17:05:52**

**To do**
- Particle sequence design

**Done**
- Particle phases design
    - Each phase has a cycle of three beats
    - colours cycle through blue, red, yellow
    - new particle type each phase
    - type 1: circles that shrink and fade. they start bigger on each beat
    - type 2: circles that move away randomly, some shrink some grow, and fade. they move quicker, start bigger on each beat
    - type 3: circles that move away in lines, leaving a trail, grow and fade. they move quicker, start bigger on each beat
    - type 4: circles that move away spawning crystals, fade. they spread further by moving quicker on each beat
- Particles now fade

## Session 031

**Tue Feb 11 12:13:40 - Tue Feb 11 13:12:28**

**To do**
- Scale change control of particles
- Change colour or particles in sequence

**Done**
- Particles start bigger and shrink
- Particles change colour in sequence, but only for first three. Need to reset the array counter

## Session 032

**Tue Feb 11 13:23:43 - Tue Feb 11 13:52:23**

**To do**
- Make sequence loop through materials

**Done**
- Sequences loop through the three materials

## Session 033

**Tue Feb 11 14:02:02 - Tue Feb 11 14:31:14**

**To do**
- Remove corner details
- Change background colour on game and player turns
- turn off pointer renderer for player turn

**Done**
- Background is black for game turn, white for player
- pointer is only on for game's turn

## Session 034

**Tue Feb 11 17:20:10 - Tue Feb 11 17:50:10**

**To do**
- Increase size of particles over cycle
- Gifs of progress
- Next particle type

**Done**
- Size increases through cycle, then resets
- gif, see below
- set up particles ready to have different behaviour based on type

![wip014](wip/wip014.gif)

## Session 035

**Wed Feb 12 14:31:46 - Wed Feb 12 15:47:01**

**To do**
- Particles type 2

**Done**
- Particles type 2 move away in random directions
- Particles type 2 scale randomly either up or down

![wip015](wip/wip015.gif)

## Session 036

**Wed Feb 12 16:04:28 - Wed Feb 12 16:27:32**

**To do**
- Make colours fade to white instead of transparent

**Done**
- Colours fade to white
- Borders are thinner
- Colours start less saturated


## Session 037

**Fri Feb 14 14:43:54 - Fri Feb 14 15:13:30**

**To do**
- lock device rotation
- particle type 3

**Done**
- Rotation locked to portrait
- Tried particles calling emitter method on manager but slows down framerate too much


## Session 038

**Fri Feb 14 15:18:59 - Fri Feb 14 16:23:13**

**To do**
- Stagger type 3 emitter to skip frames
- type 3 don't shrink or grow
- fix emit colours

**Done**
- Stagger type 3 emitter to skip frames
- type 3 shrink
- tried tweaking values to get nice visuals
- extended emit method to discern between generations of particle, fixes emit colours

## Session 039

**Fri Feb 28 14:00:14 - Fri Feb 28 14:29:06**

**To do**
- type 4 particles
    - Too many particles is lowering framerate, design needs to rely on something else.
    - possiblities: draw lines between particles, transform particles, make particles lines that stretch, make layers of particles alias, use the particle system instead


**Done**
- Make editor view closer to device scaling
- change particle to sprite instead of mesh
- display framerate
- test performance
- fixed particle rotation
- particle size has strange behaviour

## Session 040

**Fri Feb 28 15:23:35 - Fri Feb 28 15:56:38**

**To do**
- Fix particle translate (axis?)
- Fix particle scale speed

**Done**
- Changed vector for particle translate
- Started experimenting with particle type 4

## Session 041

**Fri Feb 28 15:59:38 - Fri Feb 28 17:37:53**

**To do**
- Design all four particle types as a set

**Done**
- Four types of particle implemented

    - Type 1

    - ![wip018](wip/wip018.gif)

    - Type 2

    - ![wip019](wip/wip019.gif)

    - Type 3

    - ![wip020](wip/wip020.gif)

    - Type 4
    (The scaling of type 4 looks better on an android device)

    - ![wip021](wip/wip021.gif)
    
## Session 042

**Mon Mar  2 14:40:30 - Mon Mar  2 15:19:59**

**To do**
- Loop particle type selection with higher scores
- sound generator, vertical finger position affecting pitch and horizontal something else

**Done**
- Tested particle type looping
- Found a sound generator sccript online
- Made a sound Manager object and added the sound generator script to it
- Played with values and effects to plan parameters affected by player
- Added chorus filter component
- Referenced the sound generator in the gameManager

## Session 043

**Mon Mar  2 15:28:06 - Mon Mar  2 16:27:45**

**To do**
- Turn on sound when emitting

**Done**
- Added an Emit method to soundgenerator and called it together with particle emit method
- set the gain to decrease over time, clamped to minimum zero
- set gain to increase with beats and cycle like colours
- tested on device
- works but doesn't sound nice, might need to access audio source and change volume instead of gain

## Session 043

**Mon Mar  2 16:36:09 - Mon Mar  2 17:32:09**

**To do**
- Change gain level to volume levels

**Done**
- Find audio source component
- Changing audio source volume didn't affect the generator, but the chorus effect wet/dry does
- Changing level of chorus dry signal and three wet channels
- test on device, different frequencies
    - 100 is too low, can't hear it at all on phone
    - 2000 is too shrill, unpleasant
- Tried changing sin function to sqrt, not sure which sounds better
- Adjusted volume levels for device

## Session 044

**Tue Mar 3 14:27:55 - Tue Mar  3 14:59:01**

**To do**
- Map pitch to vertical mouse position and the chorus filter to horizontal mouse position
    - get the screen height and width


**Done**
- Made sound emitter call methods for volume, pitch and filter
- Moved volume logic to new method
- Found out I need to get the mouse position in pixels rather than use the given Vector3

## Session 045

**Tue Mar 3 15:06:44 - Tue Mar  3 15:57:06**

**To do**
- set the min and max for pitch and filter
- match the position as screen percentage to pitch and filter percentage
    - find the percentage of screen position:
    - divide the position by (max minus min)
    - multiply the result by 100
    - find one percent of value to change:
    - divide (max minus min) by 100
    - (multiply result by percentage) plus min

**Done**
- Finger vertical affects pitch
- Finger horizontal affects filter depth

## Session 046

**Wed Mar  4 15:37:36 - Wed Mar  4 16:51:15**

**To do**
- Make a tool for me to record my finger movements and add them to the gesture library

**Done**
- Add a button to go to a recording screen on the menu
- Duplicated the main scene and the game manager script
- Renamed the duplicates as recorders
- started removing unneeded behaviour
- recorder scene has a looping metronome
- pointer appears and emits when receiving input
- recorder scene exits to menu after 12 beats


## Session 047

**Wed Mar 4 17:02:09 - Wed Mar  4 18:25:25**

**To do**
- Record pointer movement into new clip each beat
- Store clips in resources/gestures

**Done**
- A new animation clip is created each beat, with the time as it's name
- Clips are saved to the resources folder
- Clips are saved with pointer location
- Clips playback strangely, and need to add events manually

## Session 048

**Wed Mar 4 19:35:36 - Wed Mar  4 22:12:28**

**To do**
- Add animation clip events automatically
- Test scaling
- Test on device

**Done**
- I think it is working but I haven't taken a break for ages and I've fried my brain
- Just tested it and found out that the static methods I used are editor only, and can't be compiled for use in an app. Bugger.

## Session 049

**Sun Mar  8 16:13:07 - 

**To do**
- See if I can easily record gestures with the mouse in the editor
- Remove the runtime recorder if i can

**Done**
- Made some new animation clips
    - This is best done in the animator window attached to the gesture target, so it can be recorded into
    - Added events at 0 and 1 second
    - Added events at start and end of motion
    - This works but I've set the metronome to two seconds, not one
    - Made a new set of gestures
- Need the pointer to be off until triggered
- Pointer is turned off, but the code is a mess and needs refactoring
- Removed Recorder script and references to it in scene
---

## Session 050

**Thu Mar 12 15:02:29 - Thu Mar 12 15:56:50**

**To do**
- Redesign (colour, sizes, font)


**Done**
- Slight difficulty adjustment based on feedback
- Slight volume levels adjustment based on playing outside
- Changed menu UI overlay method
- Simplified both menu UIs, replacing buttons with circles and removing all text except score

## Session 051

**Fri Mar 13 12:44:37 - Fri Mar 13 13:20:36**

**To do**
- Fade transitions between screens


**Done**
- Added a UI image over the whole screen, set to stretch
- Gave the transition screen an animator
- Added fade in and fade out animations to the animator, with in playing on load and out playing on trigger
- Added a coroutine to trigger the animation and load level after it plays
- Turned off raycasting on the transition image so it doesn't interfere with menu buttons
- Tested on device

## Session 052

**Fri Mar 13 13:29:36 - Fri Mar 13 14:18:25**

**To do**
- Title card
- Change font
- Make smooth circles for buttons

**Done**
- Downloaded a few fonts to try
- Keeping my handwriting font for now
- Made png images of circles to use in menus, different sizes to prevent aliasing

## Tasks

- Add an instructions scene
- Continue with particle type implementing
    - Next 4 with same behaviour but triangle sprite?
    - 4 after that same behaviour but with cross sprite?
    - 12 types after that same behaviours and sprites but different colours?

