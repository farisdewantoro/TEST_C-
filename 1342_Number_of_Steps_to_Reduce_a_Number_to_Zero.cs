using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace C_SHARP_LEETCODE_TEST
{
    public class _1342_Number_of_Steps_to_Reduce_a_Number_to_Zero
    {
        //Given a non-negative integer num, return the number of steps to reduce it to zero.If the current number is even, you have to divide it by 2, otherwise, you have to subtract 1 from it.

        //Example 1:

        //Input: num = 14
        //Output: 6
        //Explanation: 
        //Step 1) 14 is even; divide by 2 and obtain 7. 
        //Step 2) 7 is odd; subtract 1 and obtain 6.
        //Step 3) 6 is even; divide by 2 and obtain 3. 
        //Step 4) 3 is odd; subtract 1 and obtain 2. 
        //Step 5) 2 is even; divide by 2 and obtain 1. 
        //Step 6) 1 is odd; subtract 1 and obtain 0.
        //Example 2:

        //Input: num = 8
        //Output: 4
        //Explanation: 
        //Step 1) 8 is even; divide by 2 and obtain 4. 
        //Step 2) 4 is even; divide by 2 and obtain 2. 
        //Step 3) 2 is even; divide by 2 and obtain 1. 
        //Step 4) 1 is odd; subtract 1 and obtain 0.
        //Example 3:

        //Input: num = 123
        //Output: 12
        [Theory]
        [
            InlineData(14,6),
            InlineData(8, 4)
        ]
        public void Test(int input,int result)
        {
            var res = FindNumberOfSteps(input);
            Assert.True(res == result);
        }

        [Theory]
        [
        InlineData(14, 6),
        InlineData(8, 4)
        ]
        public void TestTerbaik(int input, int result)
        {
            var res = NumberOfSteps(input);
            Assert.True(res == result);
        }
        public int FindNumberOfSteps(int value)
        {
            int result = 0;
            while (value > 0)
            {
                value = value % 2 == 0 ? value / 2 : value - 1;
                result++;
            }
            return result;
        }
        public int NumberOfSteps(int num)
        {
            //BIT-WISE -> pake & ('AND') operator gerbang logika
            //BOOL -> pake &&

            var tes = (14 & 5);
            // 00001110 = 14
            // 00000101 = 5
            // ---------
            // 00000100 = 4

            var te2 = (15 & 3); 
            // 00001111 = 15
            // 00000011 = 3
            // ---------
            // 00000011 = 3

            int count = 0;
            while (num != 0)
            {
                // all even numbers have 0 at the end so logical "and" returns 0
                if ((num & 1) == 0)
                {
                    //uint value = 15;              // 00001111
                                                

                    //uint doubled = value << 1;    // Result = 00011110 = 30
                    //uint shiftFour = value << 4;  // Result = 11110000 = 240


                    // bitwise right shift operator discards the low-order bit, making it half
                    num = num >> 1;
                }
                else
                {
                    num -= 1;
                }
                count++;
            }

            return count;
        }
    }
}
