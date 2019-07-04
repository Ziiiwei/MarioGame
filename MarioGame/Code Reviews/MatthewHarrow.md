
### Code Readiblity Review
Author : Matthew Harrow (harrow.13)
Date   : 28th June 2019
Sprint : 4
Name   : Rayan Hamza
File   : Camera.cs
Minutes: 12

Coupling: Moderate
- The camera implementation is tightly coupled to Mario. This makes sense, but inside of the 
MarioWorld class, on update the camera is updated according to Mario's center. Currently the class design can only handle one Mario. 
- The coupling could however be solved with a controller that communicates with camera instead of the single instance of Mario.


Cohesion: Very cohesive.
- The class is very cohesive, but is also very sparce. Right now the class only has methods that correspond to 
a Mario clone gameplay. During our sprint 5 and 6 changes, the camera system is going to need a lot of rework most likely. 


Complexity: Very little
- The class does not contain much branching. There is not very much logic and most actions are performed by the Monogame api. 
It's good to use what is available. 


Hypothetical change: Multiplayer mario.
- The class is curently coupled to the absolute dimensions of the Game window, our current implementation would thus be lacking. 
The class otherwise is suitable, as instead of feeding the camera Mario's center, we could create a controller that manages the coordinates
that get fed to the multiple cameras and are couple with Mario. This approach would decouple Mario and the camera allowing for other
camera styles like floating instead of scrolling.


Additional Notes:
- It is a spartan class, but with that comes the advantage that dramatic rewrites (anticipated as we plan on multiplayer) would be as painful.

