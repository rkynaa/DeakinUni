using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    // Selection Sort
    public class SelectionSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            // For loop for first indicator
            for(int i = 0; i < sequence.Length - 1; i++)
            {
                // A variable for smallest value in the sequence
                // at the beginning, the first element assumed to be the smallest
                var smallest = i;

                // For loop for second indicator
                for (int j = i + 1; j < sequence.Length; j++)
                {
                    // If condition to see if it's actually the smallest or not
                    // if not, then the variable 'smallest' changed the value
                    if(comparer.Compare(sequence[smallest], sequence[j]) > 0)
                    {
                        smallest = j;
                    }
                }
                // the swapping process
                var temp = sequence[smallest];
                sequence[smallest] = sequence[i];
                sequence[i] = temp;
            }
        }
    }
}