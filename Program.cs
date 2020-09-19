

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

class Assignment1_Fall2020
{
    static void Main()
    {




        // Question-1 print triangle pattern
        Console.WriteLine("");
        Console.WriteLine("Question-1 print triangle pattern");
        Console.WriteLine("please enter number n3 for PrintTriangle");
        int n3 = Convert.ToInt32(Console.ReadLine());
        PrintTriangle(n3);

        // Question - 2 prints the following series(Odd numbers) till n2 terms
        Console.WriteLine("");
        Console.WriteLine("Question-2 Printing series(odd numbers) sum");
        Console.WriteLine("please enter  n2 for seriespattern");
        int n2 = Convert.ToInt32(Console.ReadLine());
        PrintSeriesSum(n2);

        //Quesiton -3 An array is monotonic if it is either monotone increasing or monotone decreasing.

        Console.WriteLine(" ");
        Console.WriteLine("Quesiton -3 checking if given array monotonic or not");
        Console.WriteLine("please enter array length for MonotonicCheck");
        int z = Convert.ToInt32(Console.ReadLine());
        int[] a = new int[z];
        Console.WriteLine("please enter array elements for MonotonicCheck");

        for (int l = 0; l < a.Length; l++)
        {
            a[l] = Convert.ToInt32(Console.ReadLine());
        }
        for (int l = 0; l < a.Length; l++)
        {
            Console.Write(a[l] + " ");
        }
        bool check;
        Console.WriteLine(check = MonotonicCheck(a));


        //Question -4 finding the unique pairs in array elements

        Console.WriteLine(" ");
        Console.WriteLine("Quesiton -4  finding the unique pairs in array elements"); 
        Console.WriteLine("please enter array length to find unique pairs");
        int k = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("please enter the array numbers for to find unique pairs in array");
        int[] nums = new int[k];
        for (int l = 0; l < nums.Length; l++)
        {
            nums[l] = Convert.ToInt32(Console.ReadLine());
        }
        for (int l = 0; l < nums.Length; l++)
        {
            Console.Write(nums[l] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("please enter the absolute difference between the array elements");
        int c = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("number of pairs of elements witht the absolute diference c is " +
            DiffPairs(nums, c));

        //Question -5  special bulls keyboard
        Console.WriteLine(" ");
        Console.WriteLine("Quesiton -5  special bulls keyboard");
        Console.WriteLine("please enter the keyboard layout of length 26");
        string keyboard = Console.ReadLine();
        Console.WriteLine("please enter the string");
        string desired_char = Console.ReadLine();
        BullsKeyboard(keyboard, desired_char);

        // Question - 6 finding the minimum operation for string conversion
        Console.WriteLine(" ");
        Console.WriteLine("Question - 6 finding the minimum operation for string conversion");
        Console.WriteLine("please enter the string1");
        String str1 = Console.ReadLine();
        Console.WriteLine("please enter the string2");
        String str2 = Console.ReadLine();
        Console.Write("minimum edit distance is : " + editDistDP(str1, str2, str1.Length,
                                 str2.Length));
        Console.WriteLine("");
    }

    private static void PrintTriangle(int n)
    {
        try
        {
            // passing elements based on the input number of triangle 
            for (int i = 0; i <= n; i++)
            {

                // leaving the spaces for each row based on the passed value
                for (int j = n; j > i; j--)
                {
                    Console.Write(" ");

                }

                // priting the * after the spaces
                for (int k = 1; k < i * 2; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        catch
        {
            Console.WriteLine("Exception occured while computing PrintTriangle()");
        }

    }

    private static void PrintSeriesSum(int n2)
    {
        try
        {
            int add = 0;

            for (int i = 0; i < n2; i++)
            {
                int sum = 0;

                // updating the sum value iff the value is divisible by 2
                if (i % 2 != 0)
                {
                    sum = sum + i;
                    Console.Write(sum + " ");
                }
                add = add + sum;

            }
            Console.WriteLine();
            Console.WriteLine("sum of odd numbers till " + n2 + " : " + add);
        }
        catch
        {
            Console.WriteLine("Exception occured while computing PrintSeriesSum()");
        }
    }

    private static bool MonotonicCheck(int[] A)
    {
        bool Asc_Order_check = true;
        try
        {


            for (int i = 0; i < A.Length - 1; i++)
            {
                //this loop executed iff array values are less than previous value and return false
                if (A[i] > A[i + 1])
                {
                    Asc_Order_check = false;
                    break;
                }
            }

        }
        catch
        {
            Console.WriteLine("Exception occured while computing MonotonicCheck()");
        }
        return Asc_Order_check;
    }


    public static int DiffPairs(int[] nums, int k)

    {
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] - nums[j] == k || nums[j] - nums[i] == k)
                {
                    count += 1;
                    continue;
                }
            }
        }
        return count;
    }

    public static void BullsKeyboard(string keyboard, string word)
    {
        try
        {
            int sum = 0;
            int index = 0;
            for (int j = 0; j < word.Length; j++)
            {
                for (int i = 0; i < keyboard.Length; i++)

                {
                    if (word[j] == keyboard[i])
                    {
                        index = Math.Abs(index - i);
                        sum = sum + index;
                        index = i;
                        break;

                    }
                }
            }
            Console.WriteLine(sum);
        }

        catch
        {
            Console.WriteLine("Exception occured while computing BullsKeyboard()");
        }
    }

    static int min(int x, int y, int z)
    {
        if (x <= y && x <= z)
            return x;
        if (y <= x && y <= z)
            return y;
        else
            return z;
    }

    static int editDistDP(String str1, String str2, int m, int n)
    {
        // Create a table to store 
        // results of subproblems 
        int[,] dp = new int[m + 1, n + 1];

        // Fill d[][] in bottom up manner 
        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                // If first string is empty, only option is to 
                // insert all characters of second string 
                if (i == 0)

                    // Min. operations = j 
                    dp[i, j] = j;

                // If second string is empty, only option is to 
                // remove all characters of second string 
                else if (j == 0)

                    // Min. operations = i 
                    dp[i, j] = i;

                // If last characters are same, ignore last char 
                // and recur for remaining string 
                else if (str1[i - 1] == str2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1];

                // If the last character is different, consider all 
                // possibilities and find the minimum 
                else
                    dp[i, j] = 1 + min(dp[i, j - 1], // Insert 
                                       dp[i - 1, j], // Remove 
                                       dp[i - 1, j - 1]); // Replace 
            }
        }

        return dp[m, n];
    }
}
