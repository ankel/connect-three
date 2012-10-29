Connect three, by Binh Tran

AI class, PSU Fall 2012

The game of Connect-Four has been widely studied. A less-widely-studied variant is Connect-Three. We will be working on Connect-Three on a board 3 wide.

It turns out that this game is a draw with best play by both sides for any height greater than 3. Your first job is to construct a program that proves that Connect-Three on a board 3 wide and 4 high is a draw with best play by both sides, by doing a minimax search. This should require less than a minute of runtime on a reasonable machine. For the CS 441 students, this is all you need to do.

For the CS 541 students, and optionally for 441-ers, make a game out of your code on the 3 wide 10 high board. Provide for some way for humans to input moves and see the board state. This need not be fancy graphics: ASCII displays and move numbers are fine. Verify that the code will beat you in a game when allowed to play first, in spite of the drawish nature of this game :-) . I will discuss in class some programming tricks for this assignment.

You may use any programming language you like. I strongly recommend the use of a build tool such as make, and a source-code management system such as Git or Mercurial.

Turn in a tar or zip archive of your source code including the SCMS repository (if possible), your solution files, and a brief writeup saying how your code works, how to build it, how it did, and any other info you think the TA and I might find interesting. Describe the hardware and software setup under which you did the experiments. Be sure to put a copyright notice on your source code, and your name and email on your writeup. Do not include object files, executable files, or other large binary files that are likely useless to us.

Above all, have fun!


Write-up:

This is definitely a fun project.

The first challenge I met was how to define a winner. Of course he must have 3-in-a-row, but how? My very first attempt was to use Exception as control flow, check all cell and catch Out-of-Bound. This is of course very very very slow. But it get the job done. My second approach was to use some 'if' statement to avoid the out of bound case, which ran faster. Then I decided that if we fix the size & shape of the board (like any game should be) then the same check will have to be done tons of time, so hardcoding all the position need checking will make it even faster because there will be no need for branch-prediction.

I tried to model the board as 3 "stacks" but finally decided against it because checking / displaying requires access across stacks and thus the data structure needs not to be encapsulated. So a 2-d array. I'm still stuck at how to display the game from bottom up.

The actual "player" component is a simple depth first search involving a MakeAMove function that uses information passed back from the MakeAMoveHelper fuction. The helper repeately drop a ball, switch side, drop another ball, etc and check for win/lose/draw before pop all the balls out. One of the bug I encoutered is to grade the final board from MakeAMoveHelper as the player passed down by MakeAMove, not their respective player at that time (otherwise there will be no lose). This took me quite some time to figure out.

The program runs really fast, less than 1s for the 3x4 board. The result is always the same because of the deterministic nature of the game. Thus if we fix the board and it's shown that the outcome is fixed if best-played by both side, we can speed up the run time by hardcoding each move instead of rely on MinMax algorithm (I kid)

Binh