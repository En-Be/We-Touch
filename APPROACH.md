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

## Session 04

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
<!-- - Test logging mouse hold position to console -->