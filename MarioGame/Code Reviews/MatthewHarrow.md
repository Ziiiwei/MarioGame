
### Code Readiblity Review
Author : Matthew Harrow (harrow.13)
Date   : 7th June 2019
Sprint : 3
Name   : Ziwei Jin
File   : Physics.cs
Minutes: 12

Coupling - medium
- The class depends on a rectangle passed in that represents the collision area. This locks in
the implementation for collision detection. It makes sense that physics is involved with collision
detection, but any changes in collision detection will result in changes in the Physics class.
- The Update method includes code that implements wrap-around, but it is defined with magic numbers,
so any screen size changes breaks this.
- The public IGameObject doesn't appear to need to be open to set.

Cohesion - medium (of concern)
-The wrap-around implementation being in physics and not being implemented in something relation to
collision is not cohesive. 
- The public methods are all relevant to events related to Physics, but it is unclear
how FreeFall() may come into use.

Readability:
- The constants are curiously named and violate convention. A and G should be lowercase. G may get 
a pass because of its relation with gravity, but maybe not because it doesn't equal 9.8. The variable
A certainly needs a new name.

Additional notes: It says I authored the file, but it is Ziwei's creation, except I changed login in update.