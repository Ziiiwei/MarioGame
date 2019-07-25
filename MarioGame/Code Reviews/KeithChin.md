### Code Maintainability Review
Author: Keith Chin
Date: 7/24/19
Sprint: 6
Name: Matt Harrow
File: GameMenu.cs
Minutes: 15

Coupling: Minimal, only with other classes in Menu folder

This class was created to isolate each menu class as well as each view.
It is only coupled to the Menu classes and thus coupling is really low.



Cohesion: Highly functional and cohesive

With this class, the cohesion between each menu view, the MenuInputController class
and TitleScreenInput class is tied together tightly. Cohesion is really good because
of Matt's GameMenu, and it allowed me to add new views into it smoothly. Functionality
is not a problem because of this, and I can easily add new views into the game, such as
loading screens, cutscenes at ease.


Complexity: Low complexity

The Game Menu class is riddled with many different methods for transitions between views,
button clicks, as well as storing dictionaries for the state of the menu. 
Even though there's a lot of code in this class, it serves as a middle man between each view
to call and transition between different views.  Complexity as a result, is low, making it easy
to maintain the Game Menu in the game.

Hypothetical change: 

One hypothetical change is to add a GameMenu manager and move most of the code into it.
