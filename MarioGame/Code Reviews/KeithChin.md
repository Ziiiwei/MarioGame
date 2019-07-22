### Code Maintainability Review
Author: Keith Chin
Date: 7/10/19
Sprint: 5
Name: Matt Harrow
File: PhysicsConstants.cs
Minutes: 15

Coupling: Minimal, only with Physics

This class was created to isolate all of the physics constants
for game objects that required physics. This class is only coupled to the Physics classes
and thus coupling is really low.



Cohesion: Highly functional and cohesive

With this class, the cohesion along with the other Physics classes were
high because of the way the classes interacted with one another. There was
no need to declare constants in the respective physics classes, but with the
PhysicsConstants class, we are now able to data drive all the constants that
belong in Physics.



Complexity: Could do with more organization but not complicated.

Without understanding how the physics works in our solution, this class can be a little tedious
to read. Most of the complexity is bounded by the way the code is organized but
in general, it is relatively easy to understand. However, the code may be riddled with high complexity
in the future when there are more constants to be added.

Hypothetical change: 

One recommended change is to fully data drive all of the Physics constants assignments
into a json file. This will significantly reduce the amount of times we have to add
constant assignments in the constructor of the PhysicsConstants class.
