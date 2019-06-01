### Code Readiblity Review
**Author** : Ziwei Jin (jin.517)
**Date**   : 31th May 2019
**Sprint** : 2 (Refactored)

**File Name**:  MarioStatePattern & Mario.cs
**Author of File**: Matthew Harrow
**Number of mins** : 2
**Comments** : Matt's state pattern works with two seprated State, one for movement and one for power up.
			   By doing this Matt is able to avoid repeated code since all the mario has same basic move
			   except poweruped state has cruch move. There is still some duplicated code remain, for exam
			   .Updateart work is called in every state function. Which could be move to constructor and to 
			   appear once in each state.


**File Name**:  Command 
**Author of File**: Rayan Hamza
**Number of mins** : 2
**Comments** : Rayan's initial design on command pattern is easy to use, simple to read and remained solid part
			   of the project since sprint0 with no need to change. This represent the care initial plan
			   Rayan made to construct such reusble code for the entire project.


**File Name**:  Coin.cs
**Author of File**: Keith Chin
**Number of mins** : 2
**Comments** : The coin class is short and concise, made into an extremely short class thanks to the abstract
			   game object, however this clear indicate a free loader class withch is class does too less.
			   However considering the function of it is just simple game item, this is acccepted code smell for
			   such class.