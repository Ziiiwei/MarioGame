### Code Readiblity Review
Author: Ziwei Jin
Date: 6/7/19
Sprint: 3
Name: Matthew Harrow
File: Menu
Minutes: 10

Menu is where a complex delegate class mesh for player to select map, charactor, and number of players
It is cohesive, does the job nicely, and comabine all members' work from Art to Sound to acheive a consist
ent feel for the game.
Coupling wise, it is a indvidul part has clear sepration from rest of the code base.
We chose use system provided function to draw the elemental part to seprate the view, which was a efficient
chocice other than make the art work in out side souce's then input into content
But in seems espectially complex for a menu system

Menu use entity comand pattern which is right too for the right tast. Overall it give our game deepth and
functionality we deserve.