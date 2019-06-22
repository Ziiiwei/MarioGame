### Code Maintainability Review
Author: Rayan Hamza
Date: 6/13/19
Sprint: 3
Name: Kieth Chin
File: CSVParser.cs
Minutes: 4

Coupling: Data only
-Since this is a parser meant to read datafiles, its outcome is 
certainly determined by the data file, but that would not be
something classified as dangerous.
-Main code interaction is with the CSV file, other interactions
would include the JSON list the levelloader uses.

Cohesion: Not broken down enough
- It reads from a CSV file, and it organizes the locations into their
respective positions in the list, all in one big blob of a method.
- It is really long, and tries to do more than it should at once.
-there is only one method in the entire class to begin with.

Complexity: perhaps additive, pretty long
-The constructor alone takes up the whole page, but since it is just the 
dictionary, I would moreso classify this as large data, and with that,
I cannot identify anything major here.
-There are nested loops under the method.
-There is a pretty hefty comment in the middle of the method, perhaps
implying that the code itself was difficult to read, but it does 
explain explicitly what is going on, and what the rest of the 
method does.

Additional Notes:
- Magic numbers exist, this is something we are going to have to
get rid of very soon, starting 8 days from this date (6/21/19).
- This is somewhat controversial, since this is not really behavioral
code as much as it is data code.