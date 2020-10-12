using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    // Bubble Sort
    public class BubbleSort : ISorter
    {

        public int swap<K>(K[] sequence, int j) where K : IComparable<K>
        {
            var tmp = sequence[j + 1];
            sequence[j + 1] = sequence[j];
            sequence[j] = tmp;
        }
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            // For loop for the first bubble
            for (int i = 1; i < sequence.Length; i++)
            {
                // the swaps variable is being used to make sure that in the best case (already sorted), it ends faster
                // meaning, it can run more efficiently
                int swaps = 0;
                
                // For loop for the second bubble
                for (int j = 0; j < sequence.Length - i; j++)
                {
                    if(comparer.Compare(sequence[j], sequence[j + 1]) > 0)
                    {
                        // The bubble swapping
                        var tmp = sequence[j + 1];
                        sequence[j + 1] = sequence[j];
                        sequence[j] = tmp;

                        // adds one every time it swaps
                        swaps += 1;
                    }
                }
                // If there is no swaps at all, then it breaks
                // meaning, no swapping was needed, ended the sorting sooner
                if (swaps == 0) break;
            }
        }
    }
}