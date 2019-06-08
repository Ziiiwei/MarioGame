### Code Readiblity Review
Author: Rayan Hamza
Date: 6/7/19
Sprint: 3
Name: Ziwei Jin
File: Physics.cs
Minutes: 7

Coupling: not too high
-Physics interacts with game objects, mainly Mario and the enemies
-The information that is taken from other classes involve the motion of the
game objects, i.e. their position, and updates it based on factors of 
acceleration and velocity.

Cohesion: Pretty high
- This class focuses entirely on the movement of sprites, but it handles 
multiple kinds of movement, though I guess movement itself is a purpose.
-The Update does way too much here, but it was done in a compressed time
interval, and is something that is on the list to refactor.

Complexity: Getting there
-As I said, long update
-The update contains many conditionals, which increase the class' cyclomatic
complexity.
-We deal with the position and the previous position, which I believe is 
for the future, in case we want to track sliding facing the other way.

Additional Notes:
- Most other methods are one line long, which is really good and easy to 
understand
- some methods are empty, so that might be something to address with the 
virtual keyword or something along those lines.
-There are some magic numbers used for the acceleration, gravity, and 
velocity, I'm sure those are planned to be data drived in the future.
-He knows the Conditional one line operator "statement? (if true):(if false)"
which is pretty neat.