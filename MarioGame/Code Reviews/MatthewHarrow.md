
### Code Readiblity Review
Author : Matthew Harrow (harrow.13)
Date   : 10th July 2019
Sprint : 5
Name   : Keith Chin
File   : SoundFactory.cs
Minutes: 

Coupling: Some coupling
-The operation of the class is coupled to two magic strings: The file path and a magic string for back ground music.
-There is also coupling to the MarioGame instance, for the Load sound method. 


Cohesion: 
- The class is cohesive. As far as the interface on the outside, strings are passed in that match a data file and it plays 
sounds. The implementation has some variation.
- Methods like GetMainBGM could possibly be handed like any other sound.
- Integration for JSON parsing could be moved to the JSON parser class which handles the data in other classes.


Complexity: Low
- The user interfaces with the class which does not involve conditionals and looping. 



Hypothetical change: 
-Adding additional background music involves changing the GetMainBGM function in the methods that call it. This could be
better handled by fetching the background music with a key rather than having a sepearate method.

