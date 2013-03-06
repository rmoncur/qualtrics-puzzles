/* 
 * Reversible Integers Algorithm
 * for the Qualtrics Professional Services Interview Puzzles
 * by Rob Moncur on 3/1/2013
 * 
 * See README.md for explanation of program
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ReversibleIntegers {
    class Program {

        /// <summary>
        /// This is the main entry point of the program
        /// </summary>
        /// <param name="args">Command line parameters are not used in this program</param>
        static void Main(string[] args) {
            
            // ----- Initializing ----- //
            int n;
            try {
                Console.WriteLine("Find all reversible integers below (positive integer): ");
                n = int.Parse(Console.ReadLine());
                if (n < 0) {
                    Console.WriteLine("Invalid Input. Terminating Program.");
                    return;
                }
            } catch (Exception e) {
                Console.WriteLine("Invalid Input. Terminating Program.");
                return;
            }

            //Dictionary to keep track of the reversibles
            Dictionary<int,int> reversibles = new Dictionary<int,int>();
            
            //Stopwatch to time the algorithm
            Stopwatch s = new Stopwatch();
            s.Start();
            Console.WriteLine("Computing...");

            // ----- Finding all the reversible numbers in the given set ----- //

            //Looping through all the numbers below 1000
            for (int i = 1; i < n; i++) {

                //Skipping multiples of ten as leading/trailing zeros are not allowed
                if (i % 10 == 0) continue;

                //Determining if this reversible has already been found
                int ir = Program.ReverseInt(i);
                if(reversibles.ContainsKey(ir)) continue;

                //Determining if the number is reversible
                if (Program.isReversible(i)) {
                    reversibles.Add(i,i+ir);                    
                }
            }

            //Writing stats to the console
            Console.WriteLine("Time to Complete Algorithm");
            Console.WriteLine("Elapsed Ticks: " + s.ElapsedTicks);
            Console.WriteLine("Elapsed Milleseconds: " + s.ElapsedMilliseconds);

            // ----- Writing results to a file & Console ----- //
            string filetext = "";
            int count = 0;
            foreach (KeyValuePair<int, int> pair in reversibles) {
                count++;
                filetext += count + ") " +  pair.Key + " + " + Program.ReverseInt(pair.Key) + " = " + pair.Value + "\n";                
            }
            filetext +="Elapsed Ticks: " + s.ElapsedTicks;
            filetext +="\nElapsed Milleseconds: " + s.ElapsedMilliseconds;
            s.Restart();
            Program.WriteFile(filetext);
            s.Stop();
            
            //Writing output to the console
            Console.WriteLine(filetext);

            //Writing stats to the console
            Console.WriteLine("\nTime to Write Results to results.txt");
            Console.WriteLine("Elapsed Ticks: " + s.ElapsedTicks);
            Console.WriteLine("Elapsed Milleseconds: " + s.ElapsedMilliseconds);            
                        
            //Pausing at the end
            Console.WriteLine("\n\nProgram Complete.");
            Console.ReadKey();
        }

        /// <summary>
        /// Determines if a number is reversible
        /// </summary>
        /// <param name="x1"></param>
        /// <returns>True - if the number is reversible, False - if the number is not reversible</returns>
        static bool isReversible(int x1) {

            //Finding the reverse of x1
            int x1r = Program.ReverseInt(x1);

            //If the sum is even then the number is not reversible
            if (Program.isEven(x1 + x1r))
                return false;            
            else 
                return true;
        }

        /// <summary>
        /// Determines if a number is reversible
        /// This is an overload that requires a pre-calculated reversed integer (to speed up the algorithm)
        /// </summary>
        /// <param name="x1">an integer</param>
        /// <param name="x1r">the reverse of that integer</param>
        /// <returns>True - if the number is reversible, False - if the number is not reversible</returns>
        static bool isReversible(int x1, int x1r) {
            if (Program.isEven(x1 + x1r))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Returns true if x is even, false if x is odd
        /// </summary>
        /// <param name="x">an integer that will be checked if it is even or odd</param>       
        public static bool isEven(int x) {
            if (x % 2 == 0) return true;
            else return false;
        }
        

        /// <summary>
        /// Reverses an integer i.e. input -> 23, return -> 32
        /// </summary>
        /// <param name="x">integer to be reversed</param>
        /// <returns>The reversed integer</returns>
        public static int ReverseInt(int x) {
            string s = x.ToString();
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);            
            return int.Parse(new string(charArray));
        }
        
        /// <summary>
        /// This function writes a string to the file results.txt
        /// </summary>
        /// <param name="s">string to be written to a file</param>
        public static void WriteFile(string s){
            using(StreamWriter writer = new StreamWriter("results.txt", true))
            {
              writer.WriteLine(s);
            }
        }
    }
}
