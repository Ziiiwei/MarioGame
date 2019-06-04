### Code Readiblity Review
**Author** : Keith Chin (chin.204)
**Date**   : 31th May 2019
**Sprint** : 2 (Refactored)

**File Name**:  AbstractGameObject
**Author of File**: Matthew Harrow
**Number of mins** : 2
**Comments** : Matt's idea of the AbstractGameObject was a refactoring decision as a layer between 
			   the Sprite Factory and the sprite classes themselves. This allowed us to get rid of 
			   duplicate code for now.


**File Name**:  States
**Author of File**: Rayan Hamza
**Number of mins** : 2
**Comments** : Rayan worked on renaming the states to a shorter name, which made the classes appear
			   more clear. This allowed us to be able to work with easier names, and is a code smell
			   we wanted to get rid of as soon as possible.

**File Name**:  QuestionBlock.cs
**Author of File**: Ziwei Jin
**Number of mins** : 5
**Comments** : Ziwei was able to adapt to our sudden changes, and introduced state pattern
			   onto the blocks. The class is concise and easy to understand, the statess
			   also had to be implemented, but overall, the block transitions held
			   minimal coupling. In general, this concept was programmed in a way that is
			   easy to understand.