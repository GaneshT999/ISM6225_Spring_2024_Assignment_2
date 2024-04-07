/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Handling the edge case where the array is empty
                if (nums.Length == 0)
                {
                    return 0;
                }
                // Initializing the index to 1 as the first element is always unique
                int index = 1;
                // Traversing the array starting from the second element
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element is different from the previous one, 

                    if (nums[i] != nums[i - 1])
                    {
                        // Initializing the indexth element in the array with current.
                        nums[index] = nums[i];
                        // increasing the count of index by 1 and move the index forward
                        index++;
                    }
                }
                // returns the number of unique elements
                return index;
            }
            catch (Exception)
            {
                // Rethrows the exception if any unexpected error occurs
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {

                int l = 0; // Pointer for non-zero elements will only increase if the element is non zero.

                for (int r = 0; r < nums.Length; r++)
                {
                    if (nums[r] != 0)
                    {
                        // Swaping non-zero element with the element at l
                        int temp = nums[l];
                        nums[l] = nums[r];
                        nums[r] = temp;

                        // Move l pointer forward
                        l++;
                    }
                }
            

                return nums; // Returns the modified array
                             }
        
            catch (Exception)
            {
                throw; 
            }
        }


        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                IList<IList<int>> ans = new List<IList<int>>(); // Initializing the ans list to return

                // Sorting the array
                Array.Sort(nums);

                // Using 2 pointer approach
                int first; // Index for the first pointer
                int second; // Index for the second pointer
                int sum = 0; // Variable to store the sum of elements

                // Iterate through the array to find triplets
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1]) // Skiping the duplicate elements
                    {
                        continue; 
                    }

                    first = i + 1; // Initializing the first pointer
                    second = nums.Length - 1; // Initializing the second pointer

                    // Iterating with two pointers
                    while (first < second)
                    {
                        sum = nums[i] + nums[first] + nums[second]; // Calculating the sum of elements

                        if (sum == 0) // checking if the sum is 0
                        {
                            //If the sum=0 then adding that triplet to the ans list
                            ans.Add(new List<int> { nums[i], nums[first], nums[second] });

                            // Skiping duplicate elements from both sides of the array
                            while (first < second && nums[first] == nums[first + 1])
                            {
                                first++;
                            }
                            while (first < second && nums[second] == nums[second - 1])
                            {
                                second--;
                            }
                            first++;
                            second--;
                        }
                        else if (sum < 0)
                        {
                            first++; // Increment first pointer if sum is less than 0
                        }
                        else
                        {
                            second--; // Decrement second pointer if sum is greater than 0
                        }
                    }
                }

                return ans; // Returns the list of triplets
            }
            catch (Exception)
            {
                throw; // Throw any exceptions that occur during execution
            }
        }
       /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Handling the case where the input array is empty
                if (nums.Length < 1)
                {
                    return 0; // Returns 0 if the array is empty
                }

                int count = 0;
                int maxOne = 0;

                // Loop through the array to find consecutive ones
                for (int i = 0; i < nums.Length; i++)
                {
                    // Increment count if current element is 1
                    if (nums[i] == 1)
                    {
                        count++;
                    }
                    else // If current element is 0
                    {
                        // Check if the count of consecutive ones is greater than previous max
                        if (count > maxOne)
                        {
                            maxOne = count; // Update the maxOne with current count
                        }
                        count = 0; // Reset count for next sequence
                    }

                    // Check if the count of consecutive ones at the end of the array
                    // is greater than previous max (necessary for cases where sequence ends with ones)
                    if (count > maxOne)
                    {
                        maxOne = count; // Update maxOne with current count
                    }
                }

                return maxOne; // Return the maximum count of consecutive ones

            }
            catch (Exception)
            {
                throw; 
            }
        }


        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int ans = 0; // Initializing the variable to store the decimal equivalent
                int powerTwo = 1; // Initializing the variable to represent the current power of 2

                // Loop through each digit of the binary number
                while (binary > 0)
                {
                    int digit = binary % 10; // Extracting the least significant digit of the binary number
                    binary /= 10; // Removing the least significant digit from the binary number

                    // Calculating the contribution of the current digit to the decimal value
                    ans += digit * powerTwo;

                    // Updating the power of 2 for the next iteration
                    powerTwo *= 2;
                }

                return ans; // Returns the computed decimal value
            }
            catch (Exception)
            {
                throw; 
            }
        }


        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Checking if the array has less than 2 elements for any edge cases
                if (nums.Length < 2)
                    return 0;

                // Initializing variables to store maximum gap and current gap
                int max = 0;
                int gap = 0;

                // Sorting the array in ascending order
                Array.Sort(nums);

                // Iterating through the array to find the maximum gap between two successive elements in its sorted form
                for (int i = 1; i < nums.Length; i++)
                {
                    // Calculating the gap between adjacent elements
                    gap = nums[i] - nums[i - 1];

                    // If the current gap is greater than the current maximum gap, update the maximum gap
                    if (gap > max)
                    {
                        max = gap;
                    }
                }

                // Returns the maximum gap found
                return max;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

 
    public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Checking if the array has less than 3 elements incase of any corner cases
                if (nums.Length < 3)
                {
                    return 0;
                }

                // Sorting the array in ascending order
                Array.Sort(nums);

                // Reversing the sorted array to start from the largest elements
                Array.Reverse(nums);

                //Iterating through the array to find the largest perimeter till 2 elements less than array length to avoid 
                //any inbound limitation errors 
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Checking if the current triplet forms a valid triangle as it is sorted in descending order
                    // it will be enough to check condition for first element
                    if (nums[i] < nums[i + 1] + nums[i + 2])
                    {
                        // If the current triplet forms a valid triangle, return its perimeter as it will be the largest
                        return nums[i] + nums[i + 1] + nums[i + 2];
                    }
                }

                // If no valid triangle is found, return 0
                return 0;
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Finding the index of the first occurrence of 'part' in 's' using IndexOf function
                int index = s.IndexOf(part);

                // If 'part' is not found in 's', return 's' as it is
                if (index == -1)
                    return s;

                // Removing the first occurrence of 'part' from 's'
                s = s.Remove(index, part.Length);

                // Recursively call RemoveOccurrences to remove all occurrences of 'part' from 's'
                return RemoveOccurrences(s, part);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}