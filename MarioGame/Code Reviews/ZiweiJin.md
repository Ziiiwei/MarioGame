### Code Readiblity Review
Author: Ziwei Jin
Date: 6/7/19
Sprint: 3
Name: Matthew Harrow
File: CollisionHandler.cs
Minutes: 10

Coupling: not too high
-It interact with objects in waod and also call commands act on world.cs 
-The information that is taken from other classes are just location and 
rectangle size

Cohesion: Ok
-This class handle both collision detection, which could be seprated 
-The comand loading part could also happen in other place

Complexity: High
-It is expected that this class will be farily complex, but currently it
is not possible for people other than creater to understand which part of 
code is doing what
-The Collision comand data representation is too complicated
-Detection method is too long.
-4 different case could be handled in different method 


Additional Notes:
-Refacter gonna happen maily on this and physics to make their fucntion and 
relation more transparent and intuitive 