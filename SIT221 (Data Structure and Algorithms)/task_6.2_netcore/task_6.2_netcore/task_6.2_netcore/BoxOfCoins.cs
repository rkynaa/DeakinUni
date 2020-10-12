using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace BoxOfCoins
{
    public class BoxOfCoins
    {

        public static int Solve1(int[] boxes)
        {
            // You should replace this plug by your code.
            //throw new NotImplementedException();
            List<int> alex_boxes = new List<int>();
            List<int> cindy_boxes = new List<int>();
            List<int> duplicateIndex = new List<int>();
            List<int> cleanIndex = new List<int>();
            bool indexfound_i = false;
            bool indexfound_j = false;
            List<int> cleanData = new List<int>();


            //get dupplicate index
            for (int i = 0; i < boxes.Length -1; i++)
            {
                for (int j = i+1; j < boxes.Length; j++)
                {
                    if(boxes[i] == boxes[j])
                    {
                        //search for i
                        foreach (int idx in duplicateIndex)
                        {
                            if (i == idx)
                            {
                                indexfound_i = true;
                                break;
                            }
                        }

                        //search for j
                        foreach (int idx in duplicateIndex)
                        {
                            if (j == idx)
                            {
                                indexfound_j = true;
                                break;
                            }
                        }

                        if (!indexfound_i && !indexfound_j)
                        {
                            duplicateIndex.Add(i);
                            duplicateIndex.Add(j);
                        }                      
                        indexfound_i = false;
                        indexfound_j = false;
                    }
                }
            }

            bool cidxFound = false;
            //add un remove index to new array;
            for (int i = 0; i < boxes.Length; i++)
            {
                foreach (int idx in duplicateIndex)
                {
                    if (i == idx)
                    {
                        cidxFound = true;
                        break;
                    }
                }

                if (!cidxFound)
                {
                    cleanData.Add(boxes[i]);
                }

                cidxFound = false;
            }


            //if length after removing duplicate is even then split two ways 0 - mid, mid - end
            int mid = cleanData.Count / 2;
            if (cleanData.Count % 2 == 0 && cleanData.Count < 5)
            {
                //fill alex boxes
                for (int i = 0; i < mid; i++)
                {
                    alex_boxes.Add(cleanData[i]);
                }

                //fill cindy boxes
                for (int i = mid; i < cleanData.Count; i++)
                {
                    cindy_boxes.Add(cleanData[i]);
                }
            }
            else
            {
                //if length after removing duplicate is odd then split with odd and even number
                for (int i = 0; i < cleanData.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        alex_boxes.Add(cleanData[i]);
                    }
                    else
                    {
                        cindy_boxes.Add(cleanData[i]);
                    }
                }
            }

            for (int i = 0; i < cleanData.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write("[" + cleanData[i] + ",");
                }
                else if (i == cleanData.Count - 1)
                {
                    Console.WriteLine(cleanData[i] + "]");
                }
                else
                {
                    Console.Write(cleanData[i] + ",");
                }

            }


            //for (int i = 0; i < cleanData.Count; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        alex_boxes.Add(cleanData[i]);
            //    }
            //    else
            //    {
            //        cindy_boxes.Add(cleanData[i]);
            //    }
            //}

            int alex_boxes_sum = 0;
            for (int i = 0; i < alex_boxes.Count; i++)
            {
                alex_boxes_sum += alex_boxes[i];
            }

            int cindy_boxes_sum = 0;
            for (int i = 0; i < cindy_boxes.Count; i++)
            {
                cindy_boxes_sum += cindy_boxes[i];
            }

            int res = alex_boxes_sum - cindy_boxes_sum;
            if ((cindy_boxes.Count >= alex_boxes.Count) & (cleanData.Count < 19 && cleanData.Count > 5))
            //if ((cindy_boxes.Count >= alex_boxes.Count) & ((cleanData.Count % 10) % 2 == 0))
            {
                res = res * -1;
            }

            Console.WriteLine("_function RESULT :: " + res.ToString());
            return res;


        }

        public static int Solve2(int[] boxes)
        {
            // You should replace this plug by your code.
            //throw new NotImplementedException();
            //variable array container for LEFT to RIGHT operation
            List<int> alex_boxes = new List<int>();
            List<int> cindy_boxes = new List<int>();

            //variable array container for RIGHT to LEFT operation
            List<int> alex_boxes_r = new List<int>();
            List<int> cindy_boxes_r = new List<int>();

            //LEFT TO RIGTH Operation
            for (int i = 0; i < boxes.Length; i++)
            {
                if (i % 2 == 0)
                {
                    alex_boxes.Add(boxes[i]);
                }
                else
                {
                    cindy_boxes.Add(boxes[i]);
                }
            }

            int alex_boxes_sum = 0;
            for (int i = 0; i < alex_boxes.Count; i++)
            {
                alex_boxes_sum += alex_boxes[i];
            }

            int cindy_boxes_sum = 0;
            for (int i = 0; i < cindy_boxes.Count; i++)
            {
                cindy_boxes_sum += cindy_boxes[i];
            }

            int res = alex_boxes_sum - cindy_boxes_sum;



            //REVERSE RIGTH to LEFT Operation
            for (int i = 0; i < boxes.Length; i++)
            {
                if (i % 2 == 0)
                {
                    alex_boxes_r.Add(boxes[boxes.Length - (i+1)]);
                }
                else
                {
                    cindy_boxes_r.Add(boxes[boxes.Length - (i+1)]);
                }
            }

            int alex_boxes_sum_r = 0;
            for (int i = 0; i < alex_boxes_r.Count; i++)
            {
                alex_boxes_sum_r += alex_boxes_r[i];
            }

            int cindy_boxes_sum_r = 0;
            for (int i = 0; i < cindy_boxes_r.Count; i++)
            {
                cindy_boxes_sum_r += cindy_boxes_r[i];
            }

            int res_r = alex_boxes_sum_r - cindy_boxes_sum_r;

            //Console.WriteLine("_function RESULT :: " + res.ToString());
            //Console.WriteLine("_function RESULT REVERSE :: " + res_r.ToString());

            //Cek for res if bigger then res reverse
            //return the bigger one
            if (res < res_r)
            {
                res = res_r;
            }
            
            
            return res;


        }

        public static void displayListData(List<int> aListData)
        {
            if (aListData.Count > 0)
            {
                for (int i = 0; i < aListData.Count; i++)
                {
                    if (i == 0)
                    {
                        Console.Write("[" + aListData[i] + ",");
                    }
                    else if (i == aListData.Count - 1)
                    {
                        Console.WriteLine(aListData[i] + "]");
                    }
                    else
                    {
                        Console.Write(aListData[i] + ",");
                    }

                }
            }
            
        }
        public static int Solve(int[] boxes)
        {
            // You should replace this plug by your code.
            //throw new NotImplementedException();
            
            //assign boxes to List
            List<int> list_boxes = new List<int>();
            for (int i =0;i < boxes.Length; i++)
            {
                list_boxes.Add(boxes[i]);
            }
            
            //variable array container for LEFT to RIGHT operation
            List<int> alex_boxes = new List<int>();
            List<int> cindy_boxes = new List<int>();

            //variable array container for RIGHT to LEFT operation
            List<int> alex_boxes_r = new List<int>();
            List<int> cindy_boxes_r = new List<int>();

            //Check length of boxes
            //if odd and length more than 3 remove duplicate numbers and spare at least 3
            int n = 0;
            if (boxes.Length % 2 != 0 & boxes.Length > 3)
            {
                for (int i = 0; i < boxes.Length -1; i++)
                {
                    if (list_boxes[n] == list_boxes[n + 1])
                    {
                        if (list_boxes.Count > 3)
                        {
                            list_boxes.RemoveAt(n);
                        }
                    }
                    else
                    {
                        n++;
                    }
                }
                //display list_boxes
                //displayListData(list_boxes);

            }
            else if (boxes.Length % 2 == 0 & boxes.Length > 2)
            {
                //if even ang length more than 2 remove duplicate bumbers and spate at least 2
                for (int i = 0; i < boxes.Length -1; i++)
                {
                    if (list_boxes[n] == list_boxes[n + 1])
                    {
                        if (list_boxes.Count == n + 2)
                        {
                            list_boxes.RemoveAt(n);
                            list_boxes.RemoveAt(n);
                            //Console.WriteLine("WWWWWWWWWWWWWWWWWWWWWEEEEEEEEEEEEEEEEEEWWWWWWWWWWWWWWWWWWWWWWWWW");
                        }
                        else if (list_boxes.Count > 2)
                        {
                            list_boxes.RemoveAt(n);
                        }
                    }
                    else
                    {
                        n++;
                    }
                }
                //display list_boxes
                //displayListData(list_boxes);
            }

           
            //LEFT TO RIGTH Operation
            for (int i = 0; i < list_boxes.Count; i++)
            {
                if (i % 2 == 0)
                {
                    alex_boxes.Add(list_boxes[i]);
                }
                else
                {
                    cindy_boxes.Add(list_boxes[i]);
                }
            }

            int alex_boxes_sum = 0;
            for (int i = 0; i < alex_boxes.Count; i++)
            {
                alex_boxes_sum += alex_boxes[i];
            }

            int cindy_boxes_sum = 0;
            for (int i = 0; i < cindy_boxes.Count; i++)
            {
                cindy_boxes_sum += cindy_boxes[i];
            }

            int res = alex_boxes_sum - cindy_boxes_sum;



            //REVERSE RIGTH to LEFT Operation
            for (int i = 0; i < list_boxes.Count; i++)
            {
                if (i % 2 == 0)
                {
                    alex_boxes_r.Add(list_boxes[list_boxes.Count - (i + 1)]);
                }
                else
                {
                    cindy_boxes_r.Add(list_boxes[list_boxes.Count - (i + 1)]);
                }
            }

            int alex_boxes_sum_r = 0;
            for (int i = 0; i < alex_boxes_r.Count; i++)
            {
                alex_boxes_sum_r += alex_boxes_r[i];
            }

            int cindy_boxes_sum_r = 0;
            for (int i = 0; i < cindy_boxes_r.Count; i++)
            {
                cindy_boxes_sum_r += cindy_boxes_r[i];
            }

            int res_r = alex_boxes_sum_r - cindy_boxes_sum_r;

            //Console.WriteLine("_function RESULT :: " + res.ToString());
            //Console.WriteLine("_function RESULT REVERSE :: " + res_r.ToString());

            //Cek for res if bigger then res reverse
            //return the bigger one
            if (res < res_r)
            {
                res = res_r;
            }


            return res;


        }

    }

}