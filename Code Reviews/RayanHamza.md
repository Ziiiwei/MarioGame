### Code Readiblity Review
**Author** : Keith Lou Jian Chin (chin.204)
**Date**   : 29th May 2019
**Sprint** : 2

**File Name**:  Sprite.cs
**Author of File**: Matthew Harrow
**Number of mins** : 5
**Comments** : The Sprite class is coherent in that its only purpose is to update the sprite,
			   It was easy to read and understand. The "too many parameters" code smell can
			   come to mind, since the sprites are all on one row, Columns and totalFrames are
			   essentially the same thing, doubling the magic number content.

**File Name**:  Coin.cs
**Author of File**: Keith Chin
**Number of mins** : 5
**Comments** : The coin barely does anything, and that is certainly shown in the code, it is
			   the length I expected it to be. The code was not complex and easy to read, if
			   there is a problem, it may have something to do with the sprite being public,
			   but I would not be sure yet, on whether this was for speed or this was something
			   for the long run as well, rest assured, it will be addressed sometime in the 
			   future.

**File Name**:  ???.cs
**Author of File**: Ziwei Jin
**Number of mins** : 5
**Comments** : The code Ziwei wrote gets the job done and is easy to read and understand.