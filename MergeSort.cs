using System;

namespace algorithms;

public static class MergeSortUtil {


    /*
     * static void Method (uses references for modifications)
     * Performs the comparison and merging of our two arrays.
     * After the split performed in the mergeSort method, we then iterate over the values in each array
     * Swapping their positions in the original array, depending upon which value is lesser.
     * 
     * Parameters:
     *  left  (T Array), the split array on the left to compare.
     *  right (T Array), the split array on the right to compare.
     *  arr   (T Array), the original array, in which our sorted values will go into.
     */
    private static void Merge<T>(T[] left, T[] right, T[] arr) where T : IComparable<T> {
        int leftLength = left.Length;
        int rightLength = right.Length;

        int leftIndex = 0, rightIndex = 0, primaryIndex = 0;
        while(leftIndex < leftLength && rightIndex < rightLength){
            if(left[leftIndex].CompareTo(right[rightIndex]) < 0){
                arr[primaryIndex] = left[leftIndex];
                leftIndex++;
                primaryIndex++;
            } else {
                arr[primaryIndex] = right[rightIndex];
                rightIndex++;
                primaryIndex++;
            }
        }
        while(leftIndex < leftLength){
            arr[primaryIndex] = left[leftIndex];
            leftIndex++;
            primaryIndex++;
        }
        while(rightIndex < rightLength){
            arr[primaryIndex] = right[rightIndex];
            rightIndex++;
            primaryIndex++;
        }

    }

    /*
     * static void mergeSort (Modifies through reference)
     * This method takes in the original array we wish to sort.
     * The method will split our array down by recursively calling this method.
     * Base case is when the array called upon has a length of 1, which means it can no longer split.
     * Once the arrays have been fully split, we call the merge function, to sort each split array.
     * It is the merge function that actually performs the sorting of the array, with the comparison.
     */
    public static void MergeSort<T>(T[] arr) where T : IComparable<T>{
        if(arr.Length == 1){
            return;
        }
        int leftLength = arr.Length/2;
        int rightLength = arr.Length - leftLength;

        T[] left = new T[leftLength];
        T[] right = new T[rightLength];
        Array.Copy(arr, left, leftLength);
        Array.Copy(arr, leftLength, right, 0, rightLength);

        MergeSort(left);
        MergeSort(right);

        Merge(left, right, arr);
    }
}