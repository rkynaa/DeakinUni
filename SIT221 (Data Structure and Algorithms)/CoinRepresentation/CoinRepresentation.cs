using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace CoinRepresentation
{
    public class CoinRepresentation
    {
        public static List<List<long>> listosRes = new List<List<long>>();
        public static List<long> listFisrtArray = new List<long>();
        public static int resCount = 0;
        public static long dataSum = 0;

        public static long Solve(long sum)
        {
            //You should replace this plug by your code.

            //throw new NotImplementedException();
            dataSum = sum;

            if (sum == 1)
            {
                return 1;
            }
            else
            {
                listosRes.Clear();

                List<long> simonCoins = new List<long>();
                List<List<long>> result = new List<List<long>>();

                simonCoins = getListOfValueNearestToSum(sum);
                //displayListItems(simonCoins);
                getItemMatchValue(simonCoins, sum, simonCoins.Count - 1);
                //Console.WriteLine("++++++++++++++++++++++++++++++++");
                //displayListItems(listosRes[0]);
                listosRes[0].Sort();

                resCount = listosRes.Count;
                getOtherRepresentations(listosRes[0]);
                //displayListItemsx(listosRes);

                return listosRes.Count;
            }
            
        }

        public static List<long> getListOfValueNearestToSum(long sum)
        {
            List<long> lres = new List<long>();
            int n = 0;
            double res = Math.Pow(2,n);
            //Console.WriteLine("RES :: " + res.ToString());
            //Console.WriteLine("press ENTER to continue..");
            //Console.ReadLine();
            while (res <= sum)
            {
                
                lres.Add((long) res);
                lres.Add((long) res);
                n++;
                res = Math.Pow(2, n);
            }

            return lres;
        }
        
        public static long getSumOfList(List<long> aList)
        {
            long sumOfList = 0;

            for (int i = 0; i < aList.Count; i++)
            {
                sumOfList += aList[i];
            }
            return sumOfList;
        }

        public static void getItemMatchValue(List<long> itemsList, long sum, int n)
        {
            
            List<long> aRes = new List<long>();
            //Console.WriteLine("N VALUE is " + n.ToString());

            
            if (n > 0)
            {
                if (listosRes.Count > 0)
                {
                    long tmpSum = getSumOfList(listosRes[0]);
                    if (tmpSum + itemsList[n] == sum)
                    {
                        listosRes[0].Add(itemsList[n]);
                        //finish add thhe lattest item
                    }
                    else if (tmpSum + itemsList[n] < sum)
                    {
                        listosRes[0].Add(itemsList[n]);
                        getItemMatchValue(itemsList, sum, n - 1);
                    }
                    else
                    {
                        getItemMatchValue(itemsList, sum, n - 1);
                    } 
                }
                else
                {
                    if (itemsList[itemsList.Count - 1] == sum)
                    {
                        aRes.Add(sum);
                        listosRes.Add(aRes);
                        if (sum > 1)
                        {
                            sum = sum / 2;
                            getItemMatchValue(itemsList, sum, n - 1);
                        }

                    }
                    else
                    {
                        if (itemsList[itemsList.Count - 1] + itemsList[n] == sum)
                        {
                            //Console.WriteLine("FOUND A MATCH " + n.ToString());
                            aRes.Add(itemsList[itemsList.Count - 1]);
                            aRes.Add(itemsList[n]);
                            listosRes.Add(aRes);
                            //displayListItemsx(listosRes);
                        }
                        else if (itemsList[itemsList.Count - 1] + itemsList[n] > sum)
                        {
                            getItemMatchValue(itemsList, sum, n - 1);
                        }
                        else if (itemsList[itemsList.Count - 1] + itemsList[n] < sum)
                        {
                            aRes.Add(itemsList[itemsList.Count - 1]);
                            aRes.Add(itemsList[n]);
                            listosRes.Add(aRes);
                            getItemMatchValue(itemsList, sum, n - 1);
                        }
                    }
                }
                
            }
        }

        public static bool isValueExist(long aNumber, List<long> aList)
        {
            bool res = false;

            for (int i  = 0; i < aList.Count; i++)
            {
                if (aNumber == aList[i])
                {
                    res = true;
                    break;
                }
            }

            return res;

        }

        public static bool isValueExistAllList(long aNumber, List<List<long>> aList)
        {
            bool res = false;

            for (int i = 0; i < aList.Count; i++)
            {
                if (isValueExist(aNumber, aList[i]))
                {
                    res = true;
                    break;
                }
            }

            return res;

        }

        public static void getOtherRepresentations(List<long> aList)
        {
            //Console.WriteLine("--------------------------------------");
            //displayListItems(aList);

            bool newRepFound = false;
            List<long> aRes = new List<long>();
            
            for (int i = 0; i < aList.Count; i++)
            {
                if (!newRepFound)
                {
                    if (aList[i] > 1)
                    {
                        long aNumber = aList[i] / 2;
                        //Console.WriteLine("NUMBER :: " + aNumber.ToString());
                        bool aNumberFound = isValueExist(aNumber, aList);
                        if (!aNumberFound)
                        {
                            aRes.Add(aNumber);
                            aRes.Add(aNumber);
                            newRepFound = true;
                        }
                        else
                        {
                            aRes.Add(aList[i]);
                        }
                    }
                    else
                    {
                        aRes.Add(aList[i]);
                    }
                }
                else
                {
                    aRes.Add(aList[i]);
                }
                
            }

            //Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&");
            //displayListItems(aRes);

            if (getSumOfList(aRes) == dataSum )
            {
                if (!isListExist(aRes, listosRes))
                {
                    listosRes.Add(aRes);
                    getOtherRepresentations(aRes);
                }                
            }
            
        }

        public static bool itemListExist(List<long> aList, List<long> bList)
        {
            bool res = false;
            int n = aList.Count;
            if (aList.Count == bList.Count)
            {
                for (int i = 0; i < aList.Count; i++)
                {
                    
                    if (aList[i] == bList[i])
                    {
                        n--;
                    }
                    
                }
                if (n == 0)
                {
                    res = true;
                }
            }
            else
            {
                res = false;
            }
            return res;
        }

        public static bool isListExist(List<long> aList, List<List<long>> listOfList)
        {
            bool res = false;
            for (int i = 0; i< listOfList.Count; i++)
            {
                if (itemListExist(aList, listOfList[i]))
                {
                    res = true;
                    break;
                }
            }
            return res; 
        }

        public static void displayListItems(List<long> aList)
        {
            for (int i = 0; i< aList.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write("{" + aList[i].ToString());
                }else if (i == aList.Count - 1)
                {
                    Console.WriteLine(","+aList[i].ToString() + "}");
                }
                else
                {
                    Console.Write("," + aList[i].ToString());
                }
                
            }
        }

        public static void displayListItemsx(List<List<long>> aList)
        {
            Console.WriteLine("Display coins representation here :");
            for (int i = 0; i < aList.Count; i++)
            {
                displayListItems(aList[i]);
            }
        }
    }
}