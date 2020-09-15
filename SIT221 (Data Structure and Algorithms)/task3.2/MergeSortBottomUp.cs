using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3._2
{
    // Merge Sort (Bottom Up)
    public class MergeSortBottomUp : ISorter
    {

        public void Merge<K>(K[] sequence, int l, int m, int r, IComparer<K> comparer) where K : IComparable<K>
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;

            int []L = new int[n1];
            int []R = new int[n2];

            for (i = 0; i < n1; i++)
            {
                L[i] = sequence[l + i];
            }

            for (j = 0; j < n2; i++)
            {
                R[j] = sequence[m + 1 + j];
            }

            i = 0;
            j = 0;
            k = l;

            while(i < n1)
            {
                sequence[k] = L[i];
                i++;
                k++;
            }

            while(j < n2)
            {
                sequence[k] = R[j];
                j++;
                k++;
            }
        }
        public void MergeSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int curr;
            int start_left;
            int n = sequence.Length;

            for (curr = 1; curr <= n-1; curr = 2*curr)
            {
                for (start_left = 0; start_left < n-1; start_left += 2*curr)
                {
                    int mid = start_left + curr - 1;
                    int end_right = Math.Min(start_left + 2*curr - 1, n-1);

                    Merge(sequence, start_left, mid, end_right, comparer);
                }
            }
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            MergeSort(sequence, comparer);
        }
    }
}