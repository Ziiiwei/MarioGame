### Code Readibility Review
Author: Rayan Hamza
Date: 7/10/19
Sprint: 5
Name: Matt Harrow/Ziwei Jin
File: World.cs
Minutes: 6

Coupling: Same as initial implementation
-The collision handler was one of the only recently updated classes
in this refactor. It still needs the same information to function,
a mover and a target.

Cohesion: Similar and not figured out
- this was one of the concerns that needed to be addressed, however
there was not a very good understanding on how to go about. There 
was a lack of abstraction in our code, that much has been stated.
But as of right now, it has not been found within the code.

Complexity: Noticable
-This is also part of the problem we cannot solve right now,
extra branching exists in our code, and getting rid of it would
mess with some cases for the state of our game. Since the collision
handler checks constantly and requires a lot of specifics, it holds
a really high cyclomatic complexity compared to other  classes.

Hypothetical change: Sides are delegates for their collision function
- If this idea could work out, it may help solve the abstraction 
scarcity going on in our code.