// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace task3._2
// {
//     // Merge Sort (Top Down)
//     public class MergeSortTopDown : ISorter
//     {

//         public int[] Merge<K>(K[] seq_left, K[] seq_right, IComparer<K> comparer) where K : IComparable<K>
//         {
//             List<int> LeftList = seq_left.OfType<int>().ToList();
//             List<int> RightList = seq_right.OfType<int>().ToList();
//             List<int> ResultList = new List<int>();

//             while (LeftList.Count > 0 || RightList.Count > 0)
//             {
//                 if (LeftList.Count > 0 && RightList.Count > 0)
//                 {
//                     if (comparer.Compare(LeftList[0], RightList[0]) > 0)
//                     {
//                         ResultList.Add(LeftList[0]);
//                         LeftList.RemoveAt(0);
//                     }
//                     else
//                     {
//                         ResultList.Add(RightList[0]);
//                         RightList.RemoveAt(0);
//                     }
//                 }

//                 else if (LeftList.Count > 0)
//                 {
//                     ResultList.Add(LeftList[0]);
//                     LeftList.RemoveAt(0);
//                 }
                

//                 else if (RightList.Count > 0)
//                 {
//                     ResultList.Add(RightList[0]);
//                     RightList.RemoveAt(0);
//                 }
//             }

//             int[] result = ResultList.ToArray();
//             return result;
//         }
//         public int MergeSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
//         {
//             int middleIndex = sequence.Length / 2;

//             int[] seq_left = new int[middleIndex];
//             int[] seq_right = new int[sequence.Length - middleIndex];

//             Array.Copy(sequence, seq_left, middleIndex);
//             Array.Copy(sequence, middleIndex, seq_right, 0, seq_right.Length);

//             MergeSort(seq_left, comparer);
//             MergeSort(seq_right, comparer);

//             return Merge(seq_left, seq_right);
//         }

//         public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
//         {
//             MergeSort(sequence, comparer);
//         }
//     }
// }