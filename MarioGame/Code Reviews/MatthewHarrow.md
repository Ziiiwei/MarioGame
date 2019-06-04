
### Code Readiblity Review
**Author** : Matthew Harrow (harrow.13)
**Date**   : 29th May 2019
**Sprint** : 2


**Class Name**: Pipe
**Author of class**: Keith Lou Jian Chin
**Number of mins** : 5
**Comments** : The Pipe class is very simlar to most other IGameObject implenting classes.
			   By examining the class instance variables, it is clear that a game object
			   is the a section of a texture and a location on screen. The constructor is
			   simple and doesn't require parameters that aren't essential. One issue is 
			   The Draw() method. The parameters in the Draw call are very difficult to read
			   and the use of tuple leads to ambiguity due to having to reference Item1
			   and Item2.


**Class Name**:  Keyboard2
**Author of class**: Ziwei Jin
**Number of mins** : 5
**Comments** : This class almost identical to Keyboard1 and Keyboard3.
			   While the code in the class is very readable, the class is mostly duplicated code with
			   the difference being magic numbers that determine state. This is a good indication that 
			   the class could be generalized and data driven.


**Class Name**:  IBlock
**Author of class**: Rayan Hamza
**Number of mins** : 5
**Comments** : IBlock doesn't implement IGameObject, which contains Draw and Update, and would allow for instantiation in
			   the LevelLoader class. Otherwise the methods are essential and the focus of the interface
			   is concise. 