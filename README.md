# Simple 2D Animated Sprite Mask #
 
 Preview
=============  
 <img src="https://i.hizliresim.com/bt5ma31.gif"/>
 <img src="https://i.hizliresim.com/1vq18ta.gif"/>
 
 Watch the Youtube Video: https://www.youtube.com/

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


 Functions
=============
| Public Functions  | Private Functions |
| ----------------- | ----------------- |
| GetState(State)  | Awake()  |
| GetMultipleState(MultipleState)  | Start()  |
| AnimateSpriteMask()  | UpdateMask(timeBetweenFrames) |
| ResetComponent()  | 

| Public Function | Description                    |
| ------------- | ------------------------------ |
| `GetState(State)`      | Accsess to current **One Time Usage** state of Animated Sprite Mask (OnHold , Running, Finish) |
| `GetMultipleState(MultipleState)`   | Accsess to current **Multiple Time Usage** state of Animated Sprite Mask (OnHold, Running, Finish) |
| `AnimateSpriteMask()`   | Trigger your Animated Sprite Mask |
| `AnimateSpriteMask()`   | Reset all your settings in AnimatedSpriteMask |
