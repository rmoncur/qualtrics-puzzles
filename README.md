qualtrics-puzzles
=================
by Rob Moncur on 3/6/2013

Included here are two c# projects to complete the interview puzzles for the Professional Services Group

### System Requirements
* Visual Studio 2010
* .NET 4.0 (Required for the JSON parsing library)

MatrixSum
--------
The MatrixSum program computes the maximum matrix sum of an n x n matrix using the Hungarian Algorithm

* Input is expected in a JSON array like such: [[7,53,183],[497,383,563],[287,63,169]]
* All values of the JSON array should be positive or negative integers. Decimals will be cast as integers.
* Input is accepted from the console while the program is running, or from the command line as a single parameter like so:
MatrixSum.exe "[[7,53,183],[497,383,563],[287,63,169]]"
* Output is written to the console with the location and values of the matrix values that would give the maximum matrix sum 




Reversible Integers
--------
The ReversibleIntegers program computes	all	reversible numbers below a given natural number, n

* Input is expected to be a single positive integer n
* Input is entered from the console
* Output is written to the console and a text file results.txt
