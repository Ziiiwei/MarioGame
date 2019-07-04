### Code Maintainability Review
Author: Rayan Hamza
Date: 6/28/19
Sprint: 4
Name: Matt Harrow
File: KeyboardController.cs
Minutes: 6

Coupling: None directly
-Just looking at the file, there is nothing that the Keyboard Class couples
with, it does not have other class instance variables nor does it utilize
methods of other classes, however there is something that relates Keyboard
to another file, the "alive" and "dead" strings. These strings implicitly
couple the keyboard with mario, because the keyboard's functionality and 
accessible keys depends on Mario's health state. This was good for
functionality, but removes flexibility from the code.

Cohesion: Handles a little more 
- The job of the keyboard controller is to assign keys to commands, and 
to handle the holding and releasing of keys to start and stop certain
commands. This one goes a step further by not only doing those things,
but having a way to lock and unlock keys disguised as a way to switch
mapping.

Complexity: Minimal for this case
-The class is short and easy to read, most of the code is either adding
something or assigning something to something else, so it is not too
hard to see what is going on. As for cyclomatic complexity, there is the
obligatory for loop that checks for pressed keys.

Hypothetical change: Mario does not die
- this class would not be able to deal with that because stuff in it depends
on mario dying.
-  there probably will be some change here, what may happen as a result of 
getting rid of the implicit coupling here could be new coupling between
keyboard and physics.

Additional Notes:
- Strings exist, and will likely be exterminated by sprint 5.
- Overall, this class has a lot of dictionaries and is very data driven.