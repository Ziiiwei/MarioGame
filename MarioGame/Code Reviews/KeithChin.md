
### Code Readiblity Review
**Author** : Keith Lou Jian Chin (chin.204)
**Date**   : 29th May 2019
**Sprint** : 2


**Class Name**: Goomba
**Author of class**: Ziwei Jin
**Number of mins** : 5
**Comments** : The Goomba class that Ziwei implemented follows our team's strategy of
			   implementing the game object interface for each sprite in the Mario Game.
			   The code contained in the class is highly readable and it allows us to create a 
			   Goomba from the sprite factory.

**Class Name**:  SpriteFactory
**Author of class**: Matthew Harrow
**Number of mins** : 5
**Comments** : The SpriteFactory class was created by Matthew and his implementation of the Factory
			   Pattern has proved crucial for our Sprint. The SpriteFactory class is readable and is 
			   useful for loading textures and containing methods to create each sprite in the Mario 
			   Game. A potential smell, however, is the excessive use of literals when loading each 
			   sprite's texture. We plan to rectify this code smell by using a data-driven approach
			   in future sprints.


**Class Name**:  IMario
**Author of class**: Rayan Hamza
**Number of mins** : 5
**Comments** : The IMario interface created by Rayan was an important stepping stone for our team
			   as we began Sprint 2. We settled on Rayan's version of IMario as proved to be the best
			   approach for implmenting the Mario class. The code in the interface does not have any
			   known code smells and is highly readable.


               