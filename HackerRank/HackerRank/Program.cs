using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int iResult = 0;
            long lResult = 0;

            iResult = luckBalance(3, new int[][] { new int[] { 5, 1 }, new int[] { 2, 1 }, new int[] { 1, 1 }, new int[] { 8, 1 }, new int[] { 10, 0 }, new int[] { 5, 0 } }); // 29
            iResult = luckBalance(5, new int[][] {new int[] { 13, 1 }, 
                                                  new int[] { 10, 1 }, 
                                                  new int[] { 9, 1 }, 
                                                  new int[] { 8, 1 }, 
                                                  new int[] { 13, 1 }, 
                                                  new int[] { 12, 1 },
                                                  new int[] { 18, 1 },
                                                  new int[] { 13, 1 }}); // 42

            string result = gridChallenge(new string[] { "mpxz", "abcd", "wlmf" });

            lResult = marcsCakewalk(new int[] { 1, 3, 2 }); // 11
            lResult = marcsCakewalk(new int[] { 7, 4, 9, 6, }); // 79

            iResult = minimumAbsoluteDifference(new int[] { -59, -36, -13, 1, -53, -92, -2, -96, -54, 75 }); // 1
            iResult = minimumAbsoluteDifference(new int[] { 1, -3, 71, 68, 17 }); // 3

            string military = timeConversion("07:05:45PM");

            iResult = birthdayCakeCandles(new int[] { 3, 2, 1, 3 }); // 2

            miniMaxSum(new int[] { 1, 2, 3, 4, 5 }); // 10  14
            miniMaxSum(new int[] { 7, 69, 2, 221, 8974 }); // 299 9271 

            staircase(6); // "     #", "    ##", "   ###", "  ####", " #####", "######"

            plusMinus(new int[] { -4, 3, -9, 0, 4, 1 }); // 0.500000, 0.333333, 0.166667

            int absDif = diagonalDifference(new int[][] { new int[] { 11, 2, 4 }, new int[] { 4, 5, 6 }, new int[] { 10, 8, -12 } }); // 15

            long sum = aVeryBigSum(new long[] { 1000000001, 1000000002, 1000000003, 1000000004, 1000000005 }); // 5000000015

            List<int> res = compareTriplets(new List<int> { 5, 6, 7 }, new List<int> { 3, 6, 10 }); // {1, 1}

            iResult = simpleArraySum(new int[] { 1, 2, 3, 4, 10, 11 });
        }

        static int[] maximumPerimeterTriangle(int[] sticks)
        {
            int[] rtn = new int[] { };

            for (int i = 0; i < sticks.Length - 2; i++)
            {
                for (int j = i + 1; j < sticks.Length - 1; j++)
                {
                    for (int k = j + 1; k < sticks.Length; k++)
                    {
                        if (((sticks[i] + sticks[j]) > sticks[k]) && ((sticks[i] + sticks[k]) > sticks[j]) && ((sticks[j] + sticks[k]) > sticks[i]))
                        {
                        }
                    }
                }
            }

            return (rtn);
        }

        static int luckBalance(int k, int[][] contests)
        {
            int total = 0;
            List<int> iIL = new List<int> { };

            for (int i = 0; i < contests.Length; i++)
            {
                total += contests[i][0];
                if (contests[i][1] == 1)
                    iIL.Add(contests[i][0]);
            }

            IEnumerable<int> sortedIL = iIL.OrderBy(x => x);

            for (int i = 0; i < sortedIL.Count() - k; i++)
                total -= (2 * sortedIL.ElementAt(i));

            return (total);
        }

        static string gridChallenge(string[] grid)
        {
            string sorted = "YES";
            List<string> sortedGrid = new List<string> { };

            for (int i = 0; i < grid.Count(); i++)
            {
                IEnumerable<char> row = grid[i].ToList().OrderBy(x => x);
                sortedGrid.Add(String.Concat(row));
            }
            for (int c = 0; c < grid[0].Length; c++)
            {
                for (int r = 0; r < sortedGrid.Count() - 1; r++)
                {
                    string row1 = sortedGrid.ElementAt(r);
                    string row2 = sortedGrid.ElementAt(r + 1);
                    if (row1[c] > row2[c])
                        return ("NO");
                }
            }

            return (sorted);
        }

        static long marcsCakewalk(int[] calorie)
        {
            long miles = 0;
            IEnumerable<int> arSorted = calorie.OrderByDescending(x => x).ToList();
            for (int i = 0; i < arSorted.Count(); i++)
            {
                miles += (long)Math.Pow(2.0, (double)i) * arSorted.ElementAt(i);
            }
            return (miles);
        }

        static int minimumAbsoluteDifference(int[] arr)
        {
            IEnumerable<int> arSorted = arr.OrderBy(x => x).ToList();

            int smallest = Math.Abs(arSorted.ElementAt(0) - arSorted.ElementAt(arSorted.Count() - 1));
            for (int i = 0; i < arSorted.Count() - 1; i++)
            {
                int val = Math.Abs(arSorted.ElementAt(i) - arSorted.ElementAt(i + 1));
                if (val < smallest)
                    smallest = val;
            }
            return (smallest);
        }

        static string timeConversion(string s)
        {
            return (DateTime.Parse(s).TimeOfDay.ToString());
        }

        static int birthdayCakeCandles(int[] ar)
        {
            int tallest = 1;
            IEnumerable<int> arSorted = ar.OrderByDescending(x => x).ToList();
            for (int i = 1; i < arSorted.Count(); i++)
            {
                if (arSorted.ElementAt(0) == arSorted.ElementAt(i))
                    tallest++;
                else
                    break;
            }

            return (tallest);
        }

        static void miniMaxSum(int[] arr)
        {
            long min = 0;
            long max = 0;

            IEnumerable<int> arSorted = arr.OrderBy(x => x).ToList();
            for (int i = 0; i < arSorted.Count(); i++)
            {
                if (i < (arSorted.Count() - 1))
                    min += arSorted.ElementAt(i);
                if (i > 0)
                    max += arSorted.ElementAt(i);
            }
            Console.WriteLine("{0}  {1}", min, max);
        }

        static void staircase(int n)
        {
            string tread = "";
            for (int i = 0; i < n; i++)
                Console.WriteLine(tread.PadLeft(n - 1 - i, ' ') + tread.PadRight(i + 1, '#'));
        }

        static void plusMinus(int[] arr)
        {
            int[] pnz = new int[] { 0, 0, 0 };

            for (int i = 0; i < arr.Count(); i++)
            {
                if (arr[i] > 0)
                    pnz[0]++;
                if (arr[i] < 0)
                    pnz[1]++;
                if (arr[i] == 0)
                    pnz[2]++;
            }
            for (int i = 0; i < pnz.Count(); i++)
                Console.WriteLine((double)pnz[i] / arr.Count());
        }

        static int diagonalDifference(int[][] arr)
        {
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < arr[0].Count(); i++)
                sum1 += arr[i][i];
            for (int i = arr[0].Count() - 1; i >= 0; i--)
            {
                int j = (arr[0].Count() - 1) - i;
                sum2 += arr[i][j];
            }

            return (Math.Abs(sum1 - sum2));
        }

        static long aVeryBigSum(long[] ar)
        {
            return (ar.Sum());
        }

        static List<int> compareTriplets(List<int> a, List<int> b)
        {
            List<int> compPts = new List<int> { 0, 0 };

            for (int i = 0; i < a.Count(); i++)
            {
                if (a[i] > b[i])
                    compPts[0]++;
                if (a[i] < b[i])
                    compPts[1]++;
            }
            return (compPts);
        }

        static int simpleArraySum(int[] ar)
        {
            return (ar.Sum());
        }
    }
}
