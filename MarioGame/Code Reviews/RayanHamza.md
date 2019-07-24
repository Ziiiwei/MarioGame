### Code Readibility Review
Author: Rayan Hamza
Date: 7/24/19
Sprint: 6
Name: Ziwei Jin/Matt Harrow
File: WorldCollision.cs
Minutes: 6

Coupling: it is a part of the world, but not the whole world
-This file is still part of the world class, but it only couples 
with things that are collidable, so taking it out and segregating
it was able to prevent any potential tangling from other items 
coupled in the World's design.

Cohesion: Yes and no
- This file demonstrates both for and against cohesion, looking at 
the file itself, it just checks for collisions, it  does one (really
big) job, and is about 120 lines long, a little over a full page. The
class as a whole goes beyond this file and goes into 3 files, so
speaking in terms of the whole world, it is not cohesive, it does 3
things, and we show that it does 3 things. I beleive the file perspective
is what needs to be focused on in this case, and from that, not only is 
this class cohesive, it is more focused than our previous handler system.

Complexity: Greatly reduced
-In terms of number of calls on our collision system, we went from around
50,000 operations to nearly 60. That is a decrease in complexity by a 
factor of about 900, which is insane. This class holds a little less 
complexity than our collision handler, as it has the branching and 
loops to iterate over collidables and process their information,
i.e. what group to add them in.

Hypothetical change: Say we make interfaces IStatic and IMoveable,
and make ClassifyObject  a delegate containing two functions, one
taking IStatic, and one Taking IMoveable
- This reduces the method(s) to one line without any branching
whatsoever.