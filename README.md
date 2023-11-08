# Input System in Unity 
<p align="center">
<img src= https://github.com/KorobD/InputSystem/blob/main/Assets/Project/Resourses/Git/TitleGit.png width="700">
</p>


__Unity Input System__ - more flexible and advanced system for setting up controls in applications created using the Unity engine


### Action assets in project
__GameInputActions__:

<img src= https://github.com/KorobD/InputSystem/blob/main/Assets/Project/Resourses/Git/GameInputActions.png width="600">

__DefaultInputActions__ (default input asset for controll in UI):

<img src= https://github.com/KorobD/InputSystem/blob/main/Assets/Project/Resourses/Git/DefaultInputActions.png width="600">

## What is connected to what and what is it needed for

GameInputActions - automatically created script С# __“Input System”__, all changes applied to the __input asset__ are automatically applied in this script (not directly change)

GameInput - connects __GameInputActions__ with other scripts responsible for control.

PlayerController - receives information from __GameInput__ (events, vector) and passes it to the player object

SettingUI - responsible for displaying key bindings as well as changing the binding

<img src= https://github.com/KorobD/InputSystem/blob/main/Assets/Project/Resourses/Git/123.png width="600">

## List of sources used

- https://docs.unity3d.com/Packages/com.unity.inputsystem@1.6/manual/index.html
- www.youtube.com/@CodeMonkeyUnity
