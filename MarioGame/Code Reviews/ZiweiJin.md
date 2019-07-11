### Code Readiblity Review
Author: Ziwei Jin
Date: 6/7/19
Sprint: 3
Name: Matthew Harrow
File: World.cs
Minutes: 10

Coupling: Kinda High
-World has improved to new orgnized sequence 

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