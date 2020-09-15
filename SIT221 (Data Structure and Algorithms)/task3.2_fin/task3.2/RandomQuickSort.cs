using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    // Randomized Quick Sort
    public class RandomizedQuickSort : ISorter
    {

        static void RandQuickSort<K>(K[] sequence, int start, int end) where K : IComparable<K>
        {
            if (start < end)
            {
                //Stores the position of pivot element
                int piv_pos = partition(sequence, start, end);
                RandQuickSort(sequence, start, piv_pos - 1); //sorts the left side of pivot.
                RandQuickSort(sequence, piv_pos + 1, end); //sorts the right side of pivot.
            }
        }
        static int partition<K>(K[] arr, int start, int end) where K : IComparable<K>
        {
            int i = start - 1;

            // Make the last element as pivot element.
            K piv = arr[end];

            for (int j = start; j <= end - 1; j++)
            {
                /*rearrange the array by putting elements which are less than pivot
                on left side and which are greater than pivot on right side. */

                int aCPR = arr[j].CompareTo(piv);
                if (aCPR < 0)
                {
                    i++;
                    swap(ref arr[i], ref arr[j]);
                }
            }
            swap(ref arr[end], ref arr[i + 1]);  //put the pivot element in its proper place.
            return i + 1;                      //return the position of the pivot
        }

        public static void swap<K>(ref K a, ref K b) where K : IComparable<K>
        {
            K temp = a;
            a = b;
            b = temp;
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {

            int low = 0;
            int high = sequence.Length-1;

            RandQuickSort(sequence, low, high);
        }
    }
}