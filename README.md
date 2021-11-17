# Simple 2D Animated Sprite Mask #
 
 Preview
=============  
 <img src="https://i.hizliresim.com/bt5ma31.gif"/>
 <img src="https://i.hizliresim.com/1vq18ta.gif"/>
 
 Watch the Youtube Video: https://youtu.be/2XqQ4zxdjk8

Usage
=============  
+ Create an Empty GameObject.
    + Add **AnimatedSpriteMask** Component.
    + Click on Add Mask.
+ Set Sprite To Visible Inside Mask or Visible Outside Mask.
+ In **AnimatedSpriteMask** Component set Sprites to how many frames do you have in your animation.
    + Add all frames to Sprites Array.
+ If PlayOnStart is marked AniamtedSpriteMask will animate the Sprite Mask OnStart() game.
+ You can accsess to AnimateSpriteMask() function enywhere you want.


 Functions and Enums
=============
| Public Functions  | Enums |
| ----------------- | ----------------- |
| AnimateSpriteMask()  | State  |
| ResetComponent()  | MultipleState  |

| Public Function | Description                    |
| ------------- | ------------------------------ |
| `AnimateSpriteMask()`   | Trigger your Animated Sprite Mask |
| `AnimateSpriteMask()`   | Reset all your settings in AnimatedSpriteMask |
| `GetState`      | Accsess to current **One Time Usage** state of Animated Sprite Mask|
| `GetMultipleState`   | Accsess to current **Multiple Time Usage** state of Animated Sprite Mask|

| Enums | Description                    |
| ------------- | ------------------------------ |
| `State`      | Current state of **One Time Usage Animation** Sprite Mask|
| `MultipleState`   | Current state of **Multiple Time Usage Animation** Sprite Mask|

| States | Description                    |
| ------------- | ------------------------------ |
| `OnHold`      | Animation Sprite Mask is on hold state. |
| `Running`   | Animation Sprite Mask is in animation state. |
| `Finish`   | Animation Sprite Mask is finish state. |
