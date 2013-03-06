/* 
 * Reversible Integers Algorithm
 * for the Qualtrics Professional Services Interview Puzzles
 * by Rob Moncur (robmonc@gmail.com) on 3/1/2013
 * 
 * Dear Qualtrics Code Reviewers,
 * Welcome to my code. This program computes the matrix sum for an n by n matrix with only integer values.
 * Any non-integer input will be cast to integers.
 * 
 * The Hungarian Algorithm to solve the matrix sum is not my explicit work, but is properly cited in it's header
 * 
 * Please let me know if you have any questions or comments. Thanks!
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MatrixSum {
    class Program {
        static void Main(string[] args) {

            string json;

            if (args.Length == 0) {

                //Asking for input
                Console.Write("Input matrix in json array");
                Console.WriteLine(" i.e. [[7,53,183],[497,383,563],[287,63,169]]");

                //If you'd like to hardcode in some input... comment out the Console.ReadLine() and uncommend the sample input below
                Console.Write("Input: ");
                json = Console.ReadLine();
                //string json = "[[-7,-53,-183,-439],[-1497,-1383,-3,10973],[287,63,169,583],[627,773,959,943]]";
                //string json = "[[7,53,183,439,863],[497,383,563,79,973],[287,63,343,169,583],[627,343,773,959,943],[767,473,103,699,303]]";
                //string json = "[[7,53,183],[497,383,563],[287,169,583]]";

            } else if (args.Length == 1) {
                json = args[0];
                Console.WriteLine("Input: " + json);
                //return;
            } else {
                Console.WriteLine("\n\n==========Invalid Arguments. Terminating Program.==========");
                if (args.Length != 1) Console.ReadKey();
                return;
            }

            //Parsing the JSON input - Catching invalid input in the process
            Newtonsoft.Json.Linq.JToken[] matrix;
            try {
                Console.WriteLine("Parsing JSON");
                Newtonsoft.Json.Linq.JArray o = (Newtonsoft.Json.Linq.JArray)JsonConvert.DeserializeObject(json);
                matrix = o.ToArray();
            } catch (Exception e) {
                Console.WriteLine("\n\n==========Invalid Input. Terminating Program.==========");
                if (args.Length != 1) Console.ReadKey();
                return;
            }
            
            //Validating to make sure the matrix is square
            int rows = matrix.Length;
            int cols = matrix[0].Count();
            if (rows != cols) {
                Console.WriteLine("==========Input matrix has invalid dimensions. The matrix must be square. Terminating Program.==========");                
                if( args.Length != 1 ) Console.ReadKey();
                return;
            }

            //Converting the JToken Array to an int array - And catching invalid input
            int[,] m = new int[rows, cols];
            for (int i = 0; i < rows; i++) {
                Newtonsoft.Json.Linq.JToken row = matrix[i];
                for (int j = 0; j < cols; j++) {
                    //Catching invalid input
                    try {
                        m[i, j] = (int)row[j];
                    } catch (Exception e) {
                        Console.WriteLine("\n\n==========Invalid Input. Terminating Program==========");
                        Console.ReadKey();
                        return;
                    }
                }
            }

            //Creating a copy of the matrix (for output purposes... the algorithm chews up the original)
            int[,] matrixCopy = new int[rows, cols];
            Array.Copy(m, matrixCopy, rows*cols);            

            //Making the Array Negative (required, as this implementation of the Hungarian Algorithm finds the smallest matrix sum)            
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    m[i, j] = -1 * m[i, j];

            Console.WriteLine("Solving");
            //Finding the matrix sum using the Hungarian Algorithm
            int[] answer = HungarianAlgorithm.FindAssignments(m);

            //Writing the answer to the console (using values from matrixCopy)
            Console.WriteLine("\n\nResults:");
            for (int i = 0; i < rows; i++) {
                int a = answer[i];
                int mx = matrixCopy[i, a];
                Console.Write("("+i+","+answer[i]+")" + mx + " ");
            }

            //Wrapping things up            
            Console.WriteLine("\n\nProgram Complete. \n\n");
            if (args.Length != 1) Console.ReadKey();

        }
    }
}

