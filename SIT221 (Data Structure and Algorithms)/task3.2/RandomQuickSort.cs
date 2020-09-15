using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3._2
{
    // Bubble Sort
    public class RandomizedQuickSort : ISorter
    {

        public int partition<K>(K[] sequence, int low, int high, IComparer<K> comparer) where K : IComparable<K>
        {
            var pivot = sequence[high];
            var tmp = pivot;
            int i = (low - 1);

            for (int j = low; j <= high-1; j++)
            {
                if (comparer.Compare(sequence[j], pivot) > 0)
                {
                    i++;
                    tmp = sequence[i];
                    sequence[i] = sequence[j];
                    sequence[j] = tmp;
                }
            }
            tmp = sequence[i+1];
            sequence[i+1] = sequence[high];
            sequence[high] = tmp;
            return (i+1);
        }

        public int partition_r<K>(K[] sequence, int low, int high, IComparer<K> comparer) where K : IComparable<K>
        {
            // Get a random number between 0 and length
            Random rnd = new Random(1000);
            int rnd_ind = rnd.Next(0, high);

            // Swap sequence[random] with sequence[high]
            var tmp = sequence[rnd_ind];
            sequence[rnd_ind] = sequence[high];
            sequence[high] = tmp;

            return partition(sequence, 0, sequence.Length-1, comparer);
        }

        public void RandQuicksort<K>(K[] sequence, int low, int high, IComparer<K> comparer) where K : IComparable<K>
        {
            if (low < high)
            {
                int pi = partition_r(sequence, low, high, comparer);

                RandQuicksort(sequence, low, pi - 1, comparer);
                RandQuicksort(sequence, pi + 1, high, comparer);
            }
        }
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {

            int low = 0;
            int high = sequence.Length-1;

            RandQuicksort(sequence, low, high, comparer);
        }
    }
}