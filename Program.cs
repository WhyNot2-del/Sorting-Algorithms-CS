/*
 * Authors: Christopher Waschke, Jackson Jenks, Brody Weinkauf
 * Assignment: Week 11 - Sorting Algorithms
 * Description: The UI/Test for our sorting algorithms.
 */
using System;

namespace algorithms;

public class ConsoleApp {

    /*
     * Static String Method
     * Prints our menu, and takes user input, converts to lower case, and returns it.
    */
    public static string Menu(){
        Console.WriteLine("m.) Merge Sort");
        Console.WriteLine("q.) Quick Sort");
        Console.WriteLine("s.) Shell Sort");
        Console.WriteLine("x.) Exit");
        Console.Write("Please select an option> ");
        return Console.ReadLine().ToLower();
    }

    /*
     * static int[] method
     * Reads Integers from the command line, and converts each into a value within an array.
     * Throws ArgumentException if a non integer value is inserted.
    */
    public static int[] getUserInts(){
        List<int> ints = new List<int>();
        Console.WriteLine("Please enter the integers you want to sort.");
        Console.Write("Integers> ");
        string? intStr = Console.ReadLine();
        if(intStr == null){
            Console.WriteLine("Error reading numbers.");
            throw new ArgumentNullException();
        }
        foreach(String numb in intStr.Split(" ")){
            int outNumb;

            // Checks if numb can be parsed, if so, put parsed value into outNumb. (out turns value copy into a reference)
            if(!Int32.TryParse(numb, out outNumb)){
                Console.WriteLine("Please only insert numbers.");
                throw new ArgumentException();
            }

            ints.Add(outNumb);
        }
        return ints.ToArray<int>();
    }

    /*
     * Static string Method
     * Returns a String version of every element in an array, enclosed in [] (Mimicking Java's Arrays.toString())
     * Parameters:
     * arr (T[]) The array which we're converting to a String.
    */
    public static string ArrayToString<T>(T[] arr){
        return "[" + string.Join(", ", arr) + "]";
    }

    /*
     * Static void Method
     * Gets an array of integers from the user, does the merge sort on them
     * And then prints out the sorted array.
     */
    public static void DoMerge(){
        int[] arr;
        try {
            arr = getUserInts();
        } catch(ArgumentException){
            return;
        }
        MergeSortUtil.MergeSort(arr);
        Console.WriteLine(ArrayToString(arr));
    }

    /*
     * Static void Method
     * Gets an array of integers from the user, does the quick sort on them
     * And then prints out the sorted array.
     */
    public static void DoQuick(){
        int[] arr;
        try {
            arr = getUserInts();
        } catch (ArgumentException)
        {
            return;
        }
        QuickSort.quickSort(arr, 0, arr.Length-1);
        Console.WriteLine(ArrayToString(arr));
    }    

    /*
     * Static void Method
     * Gets an array of integers from the user, does the shell sort on them
     * And then prints out the sorted array.
     */
    public static void DoShell(){
        Console.WriteLine("Not implemented yet.");
    }

    /*
     * Main Method (Entry Point)
     * In a loop, gets the user's input from the menu method
     * Then branches into the proper sorting algorithm based upon the selection.
     * Exits the loop when x is requested.
     */
    static void Main(string[] args){
        bool running = true;
        while(running){
            switch(Menu()){
                case "m":
                    DoMerge();
                    break;
                case "q":
                    DoQuick();
                    break;
                case "s":
                    DoShell();
                    break;
                case "x":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please make a valid selection.");
                    break;
            }
        }
    }
}