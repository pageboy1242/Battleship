# Battleship
## Console Battleship Game

## Technology Stack
- .Net Core Console Application (C#)
- MSTest Unit Tests

## Building the Solution
1. Clone the Solution to a local directory, or download the Zip and extract
2. Open the solution in Visual Studio 2017
3. Build
4. Open a Command Prompt (CMD)
5. Navigate to the Solution folder directory created in step 1
6. Run command 'dotnet run'

## Running the Unit Tests
- Unit tests are written in MSTest and can be run in Visual Studio from the menu ('Test'->'Run'-'All Tests') or Ctrl-R, A. 
- Unit tests can also be run from the Command Line (eg.'dotnet test')

## Playing the Game
The game is console based and runs like a simulator as the output of both players boards are visible.

### Game Sequence
- Player 1 places a battleship by specifying a column [A-H] delimited by a space, then a row [1-8], a space, then a direction [U,D,L,R] (Up, Down, Left, Right).  The battleship will be placed with its stern at the column and row specified and in the direction given (Like a vector).
- The board is then displayed with the battleship placement.  The battleship is printed with 'O' characters.
- Player 2 then places their battleship using the same input rules.
- Once the battleships are placed, players alternate firing at each other.
- Shot coordinates are entered as column [A-H], space, and row [1-8].
- If a shot hits the battleship (I.e. hits one of the coordinates the ship is on), the message 'Hit!' is displayed.
- If a shot misses, the message 'Miss!' is displayed.
- The game will not prevent players from shooting duplicate shots, so players should take note of which shots they've fired.
- After a shot is fired the opponents board will be output, displaying their battleship and the location of all shots fired so far.

### Winning the Game
- The game will continue until one players has fired enough shots to sink the opponent's battleship.  This means firing a shot at each of the 3 coordinates the battleship is on.


