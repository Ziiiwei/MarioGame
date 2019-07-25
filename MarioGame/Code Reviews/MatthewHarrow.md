
### Code Readiblity Review
Author : Matthew Harrow (harrow.13)
Date   : 24th July 2019
Sprint : 6
Name   : Ziwei Jin
File   : ProjectileLauncher.cs
Minutes: 16

Coupling: Medium
- OwnedBy is couple to an abstract class instead of the interface it implements being extended to include a new property.
- The ILauncher interface is good and promotes an entity design patterns, which seems appropriate for something each character has.
- The class is couple to Physics, but since a projecile needs initial velocity, this relly seems unavoidable.


Cohesion: High
- Very cohesive, and well contained. 
- The SetOwner function is not very cohesive because is not clear to an calling class that this is needed for projectile collision
registration. The alternative approach is unclear to me, so I don't know how to avoid it.



Complexity: Medium
- The use of dictionaries cuts down on cyclomatic complexity. 
- There is also the use of an object pool which cuts down on object instatiation overhead, but the first readthrough for me, 
I didn't observe that there was an object pool. Different names could help clear it up.

Hypothetical change: Goombas can shoot projectiles. 
- Goombas are IGameObjects that implement AbstractGameObject, with a simple extension of IEnemy, they could implement Fire(). Then
some AI could controll calls to Fire(). The code requires changes only to the Goomba class for such a change. 


Additional Notes: None
