# Robot Wars

## Project description

A fleet of hand built robots are due to engage in battle for the annual “Robot Wars” competition. Each robot will be placed within a rectangular battle arena and will navigate their way around the arena using a built-in computer system.

The arena is divided up into a grid to simplify navigation. A robot’s current location and heading is a combination two integers representing the x and y coordinates on the grid, and a single character value representing the current heading. The heading can be one of the four cardinal compass points (N, S, E and W). An example location might be 0, 0, N which means the robot is in the bottom left corner and facing North. The arena size is fixed at 5 by 5, giving 25 possible (x, y) coordinate positions. Assume that the grid point directly North-East from (x, y) is (x+1, y+1).
Each robot is controlled remotely by sending movement instructions. The simple communication protocol has the following two rules... 
1.	Only a single instruction can be sent at once, and
2.	There are 3 valid instructions in the form of single alphabetic characters - ‘L’, ‘R’ and ‘M’. 
‘L’ and ‘R’ make the robot spin 90 degrees to the left or right respectively without moving from its current grid point, while ‘M’ means move forward one grid point and maintain the same heading. 

Each robot must be given an initial location at the start of the battle and must be able report its current location after any subsequent movements.

When a supplied movement instruction causes a robot to collide with the arena boundary then a penalty needs to be applied. The total number of penalties needs to be recorded so that bad navigation can be dealt with after the battle. If a collision occurs the position of the robot remains unchanged.
