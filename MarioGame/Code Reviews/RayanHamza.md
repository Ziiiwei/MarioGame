### Code Readibility Review
Author: Rayan Hamza
Date: 7/10/19
Sprint: 5
Name: Keith Chin
File: SoundManager.cs
Minutes: 6

Coupling: Some, but seemingly needed
-The SoundManager's job is, as the name states, to manage sounds that are
produced by the SoundFactory, and as such, the Instance of SoundFactory
will need to be called to retrieve the appropriate sound to manage. This
class also takes advantage of the Song and MediaPlayer classes as well, 
but seeing as we are dealing with .mp3 files, that should not be 
surprising nor percieved as dangerous in my opinion.

Cohesion: BGM is specified
- As stated above, the SoundManager's job is to manage sound, and thus,
it has them divided into BGM and SFX (SoundEffects). BGM however, is 
divided into 2 kinds, Main BGM and no time BGM. This makes the manager
deal with a little bit more, but the trade-off is having dynamic music
for mario.

Complexity: Minimal
-This code has a total of 4 methods, with the longest being no longer
than 3 lines. The first line is a retrieval from the factory, and the 
second line is typically the call to play the sound (except for the 
case of StopBGM(), in which there is one line to stop the music).
The only other thing in the methods is the defining of volume,
only needed in the PlaySoundEffect method.

Hypothetical change: Randomized BGMs
- this class handles dynamic music, but is vicariously dependent on
something else (gameTime in this case), if we could just remove the
PlayMainBGM method, and abstract it to just PlayBGM, and abstract 
the song retrieved from the Sprite Factory, there would be potential
for more musi

Additional Notes:
- Initially, a magic number was passed in for volume, later brought in from a utility class.
- Keith did all of the music and music management himself, which was an impressive feat for 
our team.