
### Code Readiblity Review
**Author** : Matthew Harrow (harrow.13)
**Date**   : 29th May 2019
**Sprint** : 2


**Class Name**: AbstractGameClass
**Author of class**: Keith Lou Jian Chin
**Number of mins** : 5
**Comments** : For the first time our group tried pair programming. It was very successful, some of the greatest
			   success what Keith and I pair progrogramming the concrete classes for items and enemies. We noticed
			   that the code was mostly identical and could be easily wrapped into an abstract class. Before the code
			   has issues relating to shotgun surgery, now those are mostly eliminated with object. This is even 
			   further improved by SpriteFactory, which is now data driven.

**Class Name**:  BrickBlock
**Author of class**: Ziwei Jin
**Number of mins** : 3
**Comments** : Blocks extend the Abstract game class. In noticing that a Block is just an AbstractGameObject with state
			   the code appear very clean. Before the refactor, the code was duplicated and was tightly coupled and
			   was subject to shotgun surgery.

**Class Name**:  AbstractGameStatefulObject
**Author of class**: Ziwei Jin
**Number of mins** : 5
**Comments** : This came about similarly to the BrickBlock. Today the entire team met and was able to spend the day
			   refactoring, so most files do not have a single author and were developed collaboratively. Ziwei 
			   definitely found the flaws with our reasoning on insisting that our implementation of blocks use
			   the AbstractGameObject class. I find the class to be very readable because it clearly is indetneded
			   to behave similarly to AbstractGameObject, but for object like Blocks with state.

**Class Name**:  MarioGame
**Author of class**: Rayan Hamza
**Number of mins** : 5
**Comments** : Rayan didn't make too significant of change to the file in terms of lines, but his contribution
			   was very valuable because he elimited major code smells. Before, the idea for reset involved 
			   generating new World object or many other methods which included expensive set up. His implementation
			   is very simple to read and understand. It also eliminates problems previous solutions had regarding 
			   coupling.
