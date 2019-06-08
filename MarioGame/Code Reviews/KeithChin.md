### Code Readiblity Review
Author: Keith Chin
Date: 6/7/19
Sprint: 3
Name: Matthew Harrow 
File: CollisionHandler.cs
Minutes: 12

Coupling: Moderate
- CollisionHandler is coupled with IGameObject as the handling and receiving collision methods
receive mover and target game objects for their respective parameter fields.

Cohesion: Moderate
- This class is not entirely cohesive because even though it deals with collision, it is not singling
out its responsibility to multiple classes.
- For example, DetectCollision and HandleCollision inside this class can be made into its own subclasses.
- In this case, collision handler can be renamed collision manager, where it deals with DetectCollision and
HandleCollision.

Complexity: Moderately High
- Complexity is an issue for the CollisionHandler class since the constructor is constantly adding collisionActions
to the dictionary.


Additional Notes:
