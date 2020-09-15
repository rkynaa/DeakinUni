using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    // Insertion Sort
    public class InsertionSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            // For loop for first indicator
            for(int i = 0; i < sequence.Length - 1; i++)
            {
                // For loop for second indicator
                for(int j = i + 1; j > 0; j--)
                {
                    if(comparer.Compare(sequence[j - 1], sequence[j]) > 0)
                    {
                        // The swapping process
                        var tmp = sequence[j - 1];
                        sequence[j - 1] = sequence[j];
                        sequence[j] = tmp;
                    }
                }
            }
        }
    }
}