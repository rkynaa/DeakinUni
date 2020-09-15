using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    // Merge Sort (Top Down)
    public class MergeSortTopDown : ISorter
    {


        public K[] MergeSort<K>(K[] X, IComparer<K> comparer) where K : IComparable<K>
        {
            int n = X.Length;
            int ft = 0;
            X = Merge(X, ft, n);
            return X;
        }

        public K[] Merge<K>(K[] a, int low, int high) where K : IComparable<K>
        {
            int N = high - low;
            if (N <= 1)
                return a;

            int mid = low + N / 2;

            Merge(a, low, mid);
            Merge(a, mid, high);

            K[] aux = new K[N];
            int i = low, j = mid;
            for (int k = 0; k < N; k++)
            {
                if (i == mid) aux[k] = a[j++];
                else if (j == high) aux[k] = a[i++];
                else if (a[j].CompareTo(a[i]) > 0) aux[k] = a[j++];
                else aux[k] = a[i++];
            }

            for (int k = 0; k < N; k++)
            {
                a[low + k] = aux[k];
            }

            return a;
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            MergeSort(sequence, comparer);
        }
    }
}
