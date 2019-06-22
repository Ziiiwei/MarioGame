
### Code Readiblity Review
Author : Matthew Harrow (harrow.13)
Date   : 21st June 2019
Sprint : 4
Name   : Keith
File   : CSVParser
Minutes: 15

Readability:
- The line String[][] data = File.ReadLines("MarioGame/Data/level1.csv").Select(x => x.Split(',')).ToArray(); has a very long chain
of function calls which makes this line very busy. It was also unclear if the class kept a file steam open (it doesn't, but it
was unclear at the time). 
- The path specified in the body of the loops could be moved towards to top, or probably moved into a set of constants for the program.
- The naming _X and _Y is unclear. Also, the line name = shortcuts[data[i][j]]; is consice, but more intermediate names would help
with reading.
- The Json header approach could be more clear, its a weird way to prepend something. 
- The base unit for the game is specified in this class. This type of constant would be more appropriate in the MarioGame class.
- Naming is also unclear from the outside. While it does read a CSV file, it only reads a very specifically formatted one. - The unit being specified in this class couples it to art and scaling. This could create a hard to track bug.
- The file is highly coupled to the CSV format, but this of course must be the case. The file could make the format more clear.
For instance, checking for the literal "+" could be placed into  variable called rewardSeparator. 
-The serialization helps to decouple the format and the implemenation of this class and makes it easy to add new fields.
