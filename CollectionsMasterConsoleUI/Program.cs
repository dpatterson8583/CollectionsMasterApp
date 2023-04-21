using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DONE: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //DONE: Create an integer Array of size 50
            Console.WriteLine("---- New empty array -----");
            int[] ints = new int[50];
            for(int i = 0;i<50;i++)   {   Console.WriteLine($"Value:  ints[{i}] = {ints[i]}");        }
            Console.WriteLine("--------------------------------");
            Console.ReadLine();

            //DONE: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Console.WriteLine("---- Random number population of new array -----");
            Populater(ints);
            for (int i = 0; i < 50; i++)    {   Console.WriteLine($"Value:  ints[{i}] = {ints[i]}");   }
            Console.WriteLine("--------------------------------");
            Console.ReadLine();

            //DONE: Print the first number of the array
            Console.WriteLine("---- Print the first number of the array -----");
            Console.WriteLine(ints[0]);
            Console.WriteLine("--------------------------------");
            Console.ReadLine();

            //DONE: Print the last number of the array
            Console.WriteLine("---- Print the last number of the array -----");
            Console.WriteLine(ints[ints.Length - 1]);
            Console.WriteLine("--------------------------------");
            Console.ReadLine();

            //UNCOMMENT this method to print out your numbers from arrays or lists
            Console.WriteLine("------------All Numbers Original-------------");
            NumberPrinter(ints);
            Console.WriteLine("-------------------");
            Console.ReadLine();

            //DONE: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */
            Console.WriteLine("------------------All Numbers Reversed------------");
            Array.Reverse(ints);
            for (int i = 0; i < 50; i++) { Console.WriteLine($"Value:  ints[{i}] = {ints[i]}"); }
            Array.Reverse(ints);
            Console.WriteLine("-------------------");
            Console.ReadLine();

            Console.WriteLine("---------REVERSE CUSTOM------------");
            ReverseArray(ints);
            for (int i = 0; i < 50; i++) { Console.WriteLine($"Value:  ints[{i}] = {ints[i]}"); }
            ints.Reverse();
            Console.WriteLine("-------------------");
            Console.ReadLine();

            //DONE: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("---------Multiple of three = 0------------");
            ThreeKiller(ints);
            for (int i = 0; i < 50; i++) { Console.WriteLine($"Value:  ints[{i}] = {ints[i]}"); }
            Console.WriteLine("-------------------");
            Console.ReadLine();

            //DONE: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("---------Sorted Numbers------------");
            Array.Sort(ints);
            for (int i = 0; i < 50; i++) { Console.WriteLine($"Value:  ints[{i}] = {ints[i]}"); }
            Console.WriteLine("-------------------");
            Console.WriteLine("\n************End Arrays*************** \n");
            Console.ReadLine();
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //DONE: Create an integer List
            Console.WriteLine("--------List Setup-------------");
            var iList = new List<int>();

            //DONE: Print the capacity of the list to the console
            Console.WriteLine(iList.Capacity);

            //DONE: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(iList);

            //DONE: Print the new capacity
            Console.WriteLine(iList.Capacity);
            Console.WriteLine("---------------------");
            Console.ReadLine();

            //DONE: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("-------Number Checker-------------");
            Console.WriteLine("What number will you search for in the number list?");
            var findNum = Console.ReadLine();
            int result1;
            if(int.TryParse(findNum, out result1))
            {
                NumberChecker(iList,result1);
            }
            else
            {
                Console.WriteLine("** You entered the wrong type of data.");
            }
            
            Console.WriteLine("-------------------");
            Console.ReadLine();

            Console.WriteLine("-------All Numbers-------------");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(iList);
            Console.WriteLine("-------------------");
            Console.ReadLine();

            //DONE: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("-------Evens Only!!-------------");
            OddKiller(iList);
            NumberPrinter(iList);
            Console.WriteLine("------------------");
            Console.ReadLine();

            //DONE: Sort the list then print results
            Console.WriteLine("-------Sorted Evens Only!!------");
            iList.Sort();
            NumberPrinter(iList);
            Console.WriteLine("------------------");
            Console.ReadLine();

            //DONE: Convert the list to an array and store that into a variable
            int[] newArr = iList.ToArray();

            //DONE: Clear the list
            iList.Clear();

            Console.WriteLine($"iList: {iList.Count}");

            Console.WriteLine("*******************************End of Program*************************");
            #endregion
        }

        public static void ThreeKiller(int[] numbers)
        {
            for(int i=0; i<numbers.Length; i++)
            {
                if (numbers[i]%3 == 0)
                {
                    numbers[i] = 0;
                }
            }
        }

        public static void OddKiller(List<int> numberList)
        {
            foreach(int i in numberList.ToList())
            {
                if(i % 2 > 0)
                {
                    numberList.Remove(i);
                }
            }
        }

        public static void NumberChecker(List<int> numberList, int searchNumber)
        {
            foreach (int i in numberList)
            {
                if (i == searchNumber)
                {
                    Console.WriteLine(i);
                }
            }
        }

         static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
            {
                numberList.Add(rng.Next(50));
            }
        }

         static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for (int i=0; i<numbers.Length;i++)
            {
                numbers[i] = rng.Next(numbers.Length);
            }
        }        

         static void ReverseArray(int[] arr)
        {
            int low;
            int high;

            for (int i=0; i<arr.Length/2 ; i++) 
            { 
                low = arr[i];
                high = arr[arr.Length-i-1];

                arr[i] = high;
                arr[arr.Length - i-1] = low;
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
