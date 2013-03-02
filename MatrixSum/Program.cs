using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixSum {
    class Program {
        static void Main(string[] args) {

            int[,] m = {
               {  7, 53,183,439,863},
               {497,383,563, 79,973},
               {287, 63,343,169,583},
               {627,343,773,959,943},
               {767,473,103,699,303},
            };

            int[,] n = new int[5,5];

            Array.Copy(m,n,25);

            Console.WriteLine(m[1,3]);

            int[] answer = HungarianAlgorithm.FindAssignments(m);

            for (int i = 0; i < 5; i++) {
                int a = answer[i];
                int mx = n[i, a];
                Console.Write("("+i+","+answer[i]+")" + mx + " ");
            }

            Console.WriteLine("\nover");

        }
    }
}

