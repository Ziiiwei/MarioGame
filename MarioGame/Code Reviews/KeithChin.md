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
- For instance, the constant addition will cause additive complexity.
- However, we have acknowledge this problem by creating a separate class that adds each collision action. This will be 
implemented in a future sprint.

Additional Notes:
Overall, the collision handler class works as intended, however, it still suffers from high complexity and smaller issues of 
cohesion and coupling. We have addressed this problem and our goal was to have this working for the initial implementation.
