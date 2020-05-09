using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing_C_
{
    public class DecimalToBinary
    {
        public int number{get;set;}
        public DecimalToBinary(int num)
        {
            this.number = num;
        }

        public string convert()
        {
            string result = String.Empty;
            int num = this.number;
             while(num >0)
            {
            int reminder = num%2;
            result = Convert.ToString(reminder) + result;
            num /=2;
            }
           
            string[] binary = result.Split("1");
            var listB = new List<string>(binary);
            listB.RemoveAll(v=>v==String.Empty);
            int MaxLength = 0;
            
            if(listB.Count >= 2)
            {
                string max = listB.Max(x=>x);
                MaxLength = max.Length;
            }
           
    
         
            return MaxLength.ToString();
        }
    }
}
