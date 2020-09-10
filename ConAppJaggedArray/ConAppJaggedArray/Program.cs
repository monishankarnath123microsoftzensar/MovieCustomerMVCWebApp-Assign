﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppJaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare the array of two elements.
            int[][] arr = new int[2][];

            // Initialize the elements.
            arr[0] = new int[5] { 1, 3, 5, 7, 9 };
            arr[1] = new int[4] { 2, 4, 6, 8 };

            // Display the array elements.
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Element({0}): ", i);

                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
                }
                Console.WriteLine();
            }
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }
    }
}
