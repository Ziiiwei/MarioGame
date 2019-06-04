### Code Readiblity Review
**Author** : Rayan Hamza
**Date**   : 31th May 2019
**Sprint** : 2 (Refactored)

**File Name**:  AbstractGameObject.cs
**Author of File**: Matthew Harrow
**Number of mins** : 10 
**Comments** : The AbstractGameObject class was created by Matt in an attempt to generalize 
			   objects in the world. This code made constructors shorter, but since we had
			   to change each individual file, there was some heavy shotgun surgery caused
			   by this new file. Otherwise, it is a concise file, and was a quick way to 
			   finish the sprint.


**File Name**:  Flower.cs
**Author of File**: Keith Chin
**Number of mins** : 2
**Comments** : The flower class was made into an extremely short class thanks to the abstract
			   game object, so Keith did not have to write many lines of code, the fact that 
			   he had to write anything at all in this file, as well as the other items, is 
			   yet again, a clear indicator of heavy shotgun surgery.

**File Name**:  QuestionBlock.cs
**Author of File**: Ziwei Jin
**Number of mins** : 5
**Comments** : Ziwei was able to adapt to our sudden changes, and introduce state pattern
			   onto the blocks. The class is concise and easy to understand, the statess
			   also had to be implemented, but overall, the block transitions held
			   minimal coupling. In general, this concept was programmed in a way that is
			   easy to understand.