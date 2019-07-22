### Code Readiblity Review
Author: Ziwei Jin
Date: 6/7/19
Sprint: 3
Name: Matthew Harrow
File: World.cs
Minutes: 10

World as a singleton is way too overpowered now. It handles collsion, it plays animation
and it's being constantly called everywhere. We want to change this in the future thus we 
are starting devide the functions into partial class. But for now, it is a major bug origin
and mess to sort through

As Matthew trying to make collision efficient, the new block space arraging system narrow 
world space collison detection down to 3 row of block space on screen, this eliminated the 
fucntion overcalling issue in the begining of this sprint. If the future this system can be 
also applied to update and draw to furthur improve out game efficiency

Complexity: Too High
Cohesion: As a singlton supposed to be the game objectManager, it is kind low
Couplin: with collision and animation
