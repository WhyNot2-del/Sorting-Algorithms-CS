using System;

namespace algorithms;

public class QuickSort
{    
    //  quickSort algorithm for sorting items
    public static void quickSort<T>(T[] data, int begin, int end) where T : IComparable
    {
        //  base case for recursion, if there is only one or zero items being sorted
        if (begin < end)
        {
            //  breaks down the data into two smaller arrays
            int partitionIndex = Partition(data, begin, end);

            //  sorts the two broken down arrays
            quickSort(data, begin, partitionIndex - 1);
            quickSort(data, partitionIndex + 1, end);
        }
    }

    //  breaks down the data into smaller two arrays
    private static int Partition<T>(T[] data, int begin, int end) where T : IComparable
    {
        T pivot = data[end];
        int partitionIndex = begin - 1;
        T temp;

        //  checks every value in current array
        //  if value is smaller or the same as pivot value, swap the two values and increase the partitionIndex
        for (int i = begin; end > i; i++)
        {
            if (data[i].CompareTo(pivot) == -1 || data[i].CompareTo(pivot) == 0)
            {
                partitionIndex++;
                temp = data[partitionIndex];
                data[partitionIndex] = data[i];
                data[i] = temp;
            }
        }

        //  after all values have been checked, swap pivot value to final position
        temp = data[partitionIndex + 1];
        data[partitionIndex + 1] = data[end];
        data[end] = temp;

        //  return index of the final position of the pivot value
        return partitionIndex + 1;
    }
}
