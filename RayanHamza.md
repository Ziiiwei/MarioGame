### Code Readiblity Review
**Author** : Keith Lou Jian Chin (chin.204)
**Date**   : 29th May 2019
**Sprint** : 2

**File Name**: SpriteFactory
**Author of File**: Matt Harrow
**Number of mins** : 5

-Overall, the code does serve one purpose, it makes sprites. 
This code is supposed to deal with concretions, but we still
have not taken the step of fully data driving, so the "too
many magic numbers" problem. 
-"Too many parameters" comes to mind, because the sprites are 
all one row, so the number of columns is the total amount of 
frames, basically, the samemagic number for columns was 
entered again for total frames,although that would be 
something to coordinate with on the Sprite class.
-The code is short and easy to understand, all methods
return an ISprite based on the name of the method.
-This is also something to look ahead to, but upon
instantiating, there is a texture list that just gets
loaded, so that might be a too many lines issue.
