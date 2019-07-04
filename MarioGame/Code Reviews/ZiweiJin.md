### Code Readiblity Review
Author: Ziwei Jin
Date: 6/28/19
Sprint: 3
Name: Mutiple team member
File: Phyasics
Minutes: 10

-Physics got major rework and i like it.
-It use to be messy, depending on tediuous length swich case
-But not with new action dictionary all method excute in a clean fasion
-To simplify the game world physics, we neglect the time factor and simply use
frame as our world time minimum unit
-All the change happens with the each frame update and sence proan to be affected by 
the game peeformence.
-So far we still haven't notice any situation as frame rate keep on steady 60fps

-Another potential change could be down in the future is to simplify the colision
supporting part in physics. This is where it has high coupling with the colision handler
and need to either move to a new seprate class or make it more genralized as a physics API

-Another major improvement in the future is to parameterize physic in runing time such 
that game could have more exciting game play such like changing moving speed, flying, dashing
parkour etc.

-New improved physics also detached it's coupling from keyboard in the past.

Overall, as it's function is approaching to the desired fasion, the future plan would be in
how to make it more genralized for more game object to utilizing