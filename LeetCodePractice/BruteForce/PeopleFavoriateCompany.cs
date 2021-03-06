﻿using System;
using System.Collections;
using System.Collections.Generic;

/*
Given the array favoriteCompanies where favoriteCompanies[i] is the list of favorites companies for the ith person (indexed from 0).

Return the indices of people whose list of favorite companies is not a subset of any other list of favorites companies. You must return the indices in increasing order.

 

Example 1:

Input: favoriteCompanies = [["leetcode","google","facebook"],["google","microsoft"],["google","facebook"],["google"],["amazon"]]
Output: [0,1,4] 
Explanation: 
Person with index=2 has favoriteCompanies[2]=["google","facebook"] which is a subset of favoriteCompanies[0]=["leetcode","google","facebook"] corresponding to the person with index 0. 
Person with index=3 has favoriteCompanies[3]=["google"] which is a subset of favoriteCompanies[0]=["leetcode","google","facebook"] and favoriteCompanies[1]=["google","microsoft"]. 
Other lists of favorite companies are not a subset of another list, therefore, the answer is [0,1,4].
Example 2:

Input: favoriteCompanies = [["leetcode","google","facebook"],["leetcode","amazon"],["facebook","google"]]
Output: [0,1] 
Explanation: In this case favoriteCompanies[2]=["facebook","google"] is a subset of favoriteCompanies[0]=["leetcode","google","facebook"], therefore, the answer is [0,1].
Example 3:

Input: favoriteCompanies = [["leetcode"],["google"],["facebook"],["amazon"]]
Output: [0,1,2,3]
 

Constraints:

1 <= favoriteCompanies.length <= 100
1 <= favoriteCompanies[i].length <= 500
1 <= favoriteCompanies[i][j].length <= 20
All strings in favoriteCompanies[i] are distinct.
All lists of favorite companies are distinct, that is, If we sort alphabetically each list then favoriteCompanies[i] != favoriteCompanies[j].
All strings consist of lowercase English letters only.

Sol1 Brute Force:
Turn all favorite companies into set, and use subset comparison method.

Sol2 Bit operation:
1. Assign a number to each string(since string is unique, there will not be a duplicate)
2. Create a bit map for each favorite company lise
3. Use bit & operation to compare, if a & b == a, then b is a subset of a
 */
namespace LeetCodePractice.BruteForce
{
    class PeopleFavoriateCompany
    {
        //static void Main()
        static void Main1452()
        {
            List<IList<string>> fc = new List<IList<String>>() {new List<string>(){"leetcode","google","facebook" },
                                                                new List<string>(){"google","microsoft" },
                                                                new List<string>(){"google","facebook" },
                                                                new List<string>(){"google"},
                                                                new List<string>(){"amazon"}};            
            Console.Out.WriteLine(PeopleIndexes(fc));
            Console.In.ReadLine();
        }

        public static IList<int> PeopleIndexes(IList<IList<string>> favoriteCompanies)
        {
            List<int> res = new List<int>();
            Dictionary<string, int> companyId = new Dictionary<string, int>();
            int id = 0;
            foreach (IList<string> fc in favoriteCompanies)
            {
                foreach(string s in fc)
                {
                    if (!companyId.ContainsKey(s))
                    {
                        companyId[s] = id++;
                    }
                }
            }

            List<BitArray> fcBitArr = new List<BitArray>();
            foreach (IList<string> fc in favoriteCompanies)
            {
                BitArray temp = new BitArray(id);
                foreach (string s in fc)
                {
                    temp[companyId[s]] = true;                    
                }
                fcBitArr.Add(temp);
            }

            for (int i = 0; i < favoriteCompanies.Count; i++)
            {
                bool subset = false;
                for (int j = 0; j < favoriteCompanies.Count; j++)
                {
                    if (i != j)
                    {
                        BitArray temp = new BitArray(fcBitArr[i]);
                        subset = BitArrayCompare(fcBitArr[i].And(fcBitArr[j]), temp);
                        fcBitArr[i] = temp;
                    }
                    if (subset)
                    {
                        break;
                    }
                }
                if (!subset)
                {
                    res.Add(i);
                }
            }

            return res;
        }

        //This compare method cause time limit to exceed if number of distint string is large enough
        public static bool BitArrayCompare(BitArray a, BitArray b)
        {
            bool identical = true;
            //assume length is same
            for(int i = 0; i < a.Length; i++)
            {
                if(a[i] != b[i])
                {
                    identical = false;
                }
            }
            return identical;
        }
        //public static IList<int> PeopleIndexes(IList<IList<string>> favoriteCompanies)
        //{
        //    List<int> res = new List<int>();
        //    List<HashSet<String>> fcs = new List<HashSet<string>>();            
        //    foreach(IList<string> fc in favoriteCompanies)
        //    {
        //        fcs.Add(new HashSet<string>(fc));
        //    }

        //    for(int i = 0; i < fcs.Count; i++)
        //    {
        //        bool subset = false;
        //        for (int j = 0; j < fcs.Count; j++)
        //        {
        //            if (i != j)
        //            {
        //                subset = fcs[i].IsSubsetOf(fcs[j]);
        //            }
        //            if (subset)
        //                break;
        //        }
        //        if (!subset)
        //        {
        //            res.Add(i);
        //        }
        //    }

        //    return res;
        //}

    }
}
