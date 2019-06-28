### Code Readiblity Review
Author: Ziwei Jin
Date: 6/7/19
Sprint: 3
Name: Matthew Harrow
File: World.cs
Minutes: 10

Coupling: Kinda High
-world now decide the sequence of colisison handling, this happens only 
because handling outside world without knoklege of other pending conlision
is potentially buggy
-But the solution is elegent by ranking out the priority of each collision
case by its area and type, and only world is has approriate access to get these
information.
-And in future We would change name of the class to GameobjectManager

Cohesion: 
-Still tight
-Since the world is basically the gameobject manager, its natural for it 
to do anything related to it


Complexity: High
-Collision Ranking and Masking would be preffered to be seprated out somewhere 
else

Additional Notes:
-potential waste of memory by keep the rank information in mutilple dictionary
when it could be condenced in one.