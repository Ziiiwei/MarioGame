
### Code Readiblity Review
Author : Matthew Harrow (harrow.13)
Date   : 13th June 2019
Sprint : 3
Name   : Ziwei Jin
File   : Physics.cs
Minutes: 

Coupling - Low to medium
- Since physics can be passed a IGameObject and position vector, a new class specifying constants could provide different physics for different classes.
- Physics class is coupled with collision, but this may be necessary. It is unlikely that the use of a collision rectangle will change though, so this coupling seems fine.
- Use of GAME_WINDOW constants nicely decouples the screen and physics.
- The physics class is coupled to any implementing class in that thy must have a position Vector2, but this is pretty universal in our codebase, a lot depends on this assumption
in our code, and it seems fair to assume it here as well. 


Cohesion - High
- Includsion of the MarioWorldConstant class separates the defintion of the Physics of the world and the aim of the Physics class, which is the interpretation.

Readability:
- Without examination the names for Loop and Stop do not describe much. Stop could be more specific, as it does indicate a Stop, but it looks like a very conditional and specific
stop. 
- Use of Math.Sign makes for a nice elimination of conditionals that would otherwise be needed.
- Its not exactly clear what unit of measurement is used. 
- Names like G and A are not specific enough. 
- The naming for functions may become strange in the future. Consider an object that bounces around like a fireball, it may implement a physics class with its own constants 
and then need to Jump() or something like that, which may look weird in the fireball code that has to say this.Jump(). This assumes Physics doesnt become MarioPhysics and fireballs get 
their own Physics. 

Notes: Position is a 2-tuple of floats because it is a Vector2, and in one place these floats have the ceiling taken. Why in this spot but not others? Is it possible that these
roundoff errors may affect gameplay (albeit by at most a pixel)?
