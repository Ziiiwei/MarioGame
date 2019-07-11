### Code Readiblity Review
Author: Keith Chin
Date: 7/10/19
Sprint: 5
Name: Matt Harrow
File: BumpableBlockPhysics.cs
Minutes: 12

Coupling: Moderate

Coupling in this class exists with all the game objects in the world as well as its physics.
Matt modified the Physics classes heavily and in our latest solution, we decided to separate
the physics constants into its own class. This allows us to avoid coupling with the game itself
as before this, all of the physics was derived from a single class. 

Cohesion: High

The purpose of this class is to "bump" the block up, and return it to its original position.
This separation of functionality from the main Physics class was seen as necessary, as the 
block itself is not only bumped, but also any game object above it.

Complexity: Moderate

Without understanding how the physics works in our solution, this class can be a little tedious
to read. Most of the complexity occurs in the Update() method, where calculations for the
velocity and the possible position for the game object is obtained. Comments for this class
will need to be added in the future to ensure that it is easier to maintain.

Hypothetical change: 

In future sprints, when more physics is added for the game, those classes will have to be moved 
into a new folder. Perhaps a class called BlockPhysics can be created to envelope all of the
different physics that can occur to the blocks and game objects.

Additional notes:

This class is important for making the blocks bump up and down. However, complexity may be an issue
when maintaining in the future because of the lack of clarity in the code. Hypothetically, 
a BlockPhysics class could be created to include this class and any other physics that involve blocks
in the near future.