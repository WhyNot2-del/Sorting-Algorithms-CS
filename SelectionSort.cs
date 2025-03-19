using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sorting_Algorithms_CS
{   //This is a selection sort. It is comprised of nested for loops that loop through the arrays and swaps values depending on if the values are greater or lesser.
    internal class SelectionSort
    {
        public static  void selectionSort<T>(T[] Array) where T : IComparable
        {

            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = 0; j < Array.Length; j++)
                {
                    if (Array[i].CompareTo(Array[j]) < 0)
                    {
                        T tempVar = Array[i];
                        Array[i] = Array[j];
                        Array[j] = tempVar;
                    }
                }

            }
        }
    }

}
