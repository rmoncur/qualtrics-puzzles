using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MatrixSum {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Input matrix in json:");
            Console.WriteLine("i.e. [[7,53,183,439],[497,383,563,973],[287,63,169,583],[627,773,959,943]]");
            string json = Console.ReadLine();

            //string json = "[[7,53,183,439,863],[497,383,563,79,973],[287,63,343,169,583],[627,343,773,959,943],[767,473,103,699,303]]";
            Newtonsoft.Json.Linq.JArray o = (Newtonsoft.Json.Linq.JArray)JsonConvert.DeserializeObject(json);
            Newtonsoft.Json.Linq.JToken[] asdf = o.ToArray();
            int l = asdf.Length;
            int c = asdf[0].Count();

            //Converting the JToken Array to an int array
            int[,] m = new int[l, c];
            for (int i = 0; i < l; i++) {
                Newtonsoft.Json.Linq.JToken row = asdf[i];
                for (int j = 0; j < c; j++) {
                    m[i, j] = (int)row[j];                    
                }
            }

            //int ase = (int[])asdf[0];
            //int[,] tre = (int[,])asdf;
            
            //int[,] sdfg = asdf.ToArray();

            //Initializing the Matrix
            /*
            int[,] m = {
               {  7, 53,183,439,863},
               {497,383,563, 79,973},
               {287, 63,343,169,583},
               {627,343,773,959,943},
               {767,473,103,699,303},
            };
             */

            //Validating the input
            var h = m.GetLength(0);
            var w = m.GetLength(1);

            if (w != h) {
                Console.WriteLine("Input matrix has invalid dimensions.  The matrix must be square");
                return;
            }

            //Creating a copy of the matrix (for output purposes... the algorithm chews up the original)
            int[,] n = new int[w, h];
            Array.Copy(m, n, w*h);
            //Console.WriteLine(m[1, 3]);

            //Making the Array Negative (required, as this implementation of the Hungarian Algorithm findest the smallest matrix sum)            
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    m[i, j] = -1 * m[i, j];

            //Finding the matrix sum using the Hungarian Algorithm
            int[] answer = HungarianAlgorithm.FindAssignments(m);

            //Writing the answer to the console
            for (int i = 0; w < 5; i++) {
                int a = answer[i];
                int mx = n[i, a];
                Console.Write("("+i+","+answer[i]+")" + mx + " ");
            }

            Console.WriteLine("\nover");
            Console.ReadLine();

        }
    }
}

