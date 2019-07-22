
### Code Readiblity Review
Author : Matthew Harrow (harrow.13)
Date   : 12th July 2019
Sprint : 5
Name   : Ziwei Jin
File   : Animation.cs
Minutes: 10

Coupling: Low
- Class is coupled to implementation in world. Animations are added to the object manager which is responsibly for playing then,
so this is necessary. 
- The rest of the class is coupled to KeyFrames, which are expected to be tightly coupled to an animation because they make up
one. 


Cohesion: High
-Cohesion could be possibly increased by having an animation builder. This way an animation is responsible for playback,
but construction details are left out. 


Complexity: 
- Special cases like having frameCounter set to -1 could possibly be better served with a boolean, for clarity
- The if-else check for an animation finished could possibly be constructed into a observer pattern setup, eliminating some complexity.


Hypothetical change: 
- Adding an animation that runs as long as the level is running. This involves setting the FinishedAction to play 
the start of the animation. This involves no changes to the class, just to the use of it. This is ideal.

Additional Notes:
- The exception is good for debugging, but perhaps it would be better to have the error handled more gracefully in a release.