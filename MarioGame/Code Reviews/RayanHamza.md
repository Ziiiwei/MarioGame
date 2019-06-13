### Code Maintainability Review
Author: Rayan Hamza
Date: 6/13/19
Sprint: 3
Name: Matt Harrow
File: CollisionHandler.cs
Minutes: 7

Coupling: nothing dangerous
-Does not depend on much, the only thing it interacts with is data,
which should correspond to files, but is not specific enough to be
considered high coupling.

Cohesion: It does one thing, but that thing is kind of big
- The class, as the name suggests, is designed to handle collision. It
used to also respond to collision, but that has been fixed with the 
collision responder object. There are some conditions for collisions,
like whether they are horizontal, from the top, or from the bottom,
that could be broken down, but only if there is a major reason to do
so.

Complexity: Cyclomatic complexity apparent
-There are four conditional blocks in the code, the last one being nested,
for a total of 5.
-Save for the second condition, the other conditions do not have many lines
in them, so this cyclomatic complexity may not be so threatening in the 
long run.
-The type type side system was made to keep collisions as abstractions,
not relying on hard types, but instead leaving that to the data files,
so this class should not have trouble handling mario vs anything, 
enemies vs anything, and items vs anything.

Additional Notes:
- The collision handler's job is split into 2 parts, handling the 
collision, and detecting the collision to handle, this may harm
elements of cohesion, but I figured something like this is implied.
- I do not like the parameters on the command objects, as that means
all command objects cannot be treated the same way; some pass in the 
game, some pass in mario, and now some pass in an object and a 
rectangle.
- i don't know if the SOftware department at OSU is just pedantic,
but are multiple returns really a bad thing? It seems like an 
effective way for quick termination, and gives us a lower average
case  code runtime.