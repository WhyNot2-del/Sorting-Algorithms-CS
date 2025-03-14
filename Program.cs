using System;
public class QuickSort
{
    public static void quickSort<T>(T[] data, int begin, int end) where T : IComparable
    {

        if (begin < end)
        {
            int partitionIndex = Partition(data, begin, end);

            quickSort(data, begin, partitionIndex - 1);
            quickSort(data, partitionIndex + 1, end);
        }
    }

    private static int Partition<T>(T[] data, int begin, int end) where T : IComparable
    {
        T pivot = data[end];
        int partitionIndex = begin - 1;
        T temp;

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

        temp = data[partitionIndex + 1];
        data[partitionIndex + 1] = data[end];
        data[end] = temp;

        return partitionIndex + 1;
    }
}
