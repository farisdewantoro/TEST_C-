

/*
International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows: "a" maps to ".-", "b" maps to "-...", "c" maps to "-.-.", and so on.

For convenience, the full table for the 26 letters of the English alphabet is given below:

[".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
Now, given a list of words, each word can be written as a concatenation of the Morse code of each letter. For example, "cba" can be written as "-.-..--...", (which is the concatenation "-.-." + "-..." + ".-"). We'll call such a concatenation, the transformation of a word.

Return the number of different transformations among all words we have.

Example:
Input: words = ["gin", "zen", "gig", "msg"]
Output: 2
Explanation: 
The transformation of each word is:
"gin" -> "--...-."
"zen" -> "--...-."
"gig" -> "--...--."
"msg" -> "--...--."

There are 2 different transformations, "--...-." and "--...--.".
Note:

The length of words will be at most 100.
Each words[i] will have length in range [1, 12].
words[i] will only consist of lowercase letters.

 */

using System;
using System.Collections.Generic;

namespace LeetCode
 {
     public class UniqueMorse
     {
         public int diffTransform(string[] input)
         {
            Dictionary<char,string> dic = new Dictionary<char,string>();
            string[] strList = {".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."};
            int code =97;
            for (int i = 0; i < strList.Length; i++)
            {
                int keyInt = i+code;
                char key = Convert.ToChar(keyInt);
                dic.Add(key,strList[i]);
            }
            HashSet<string> total = new HashSet<string>();
       
            for (int j = 0; j < input.Length; j++)
            {
                string store = String.Empty;
                for (int k = 0; k < input[j].Length; k++)
                {
                    if(dic[input[j][k]] != null)
                    {
                        store +=dic.GetValueOrDefault(input[j][k]) ;
                    }
                    
                }
                total.Add(store);
            }
      
          
             
             return total.Count;
         }
     }
 }