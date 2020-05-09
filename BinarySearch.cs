using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace C_SHARP_LEETCODE_TEST
{
    public class BinarySearch
    {
        [Theory]
        [InlineData(new int[] {1,5,9,10,22,44,56,89,100,200,300,400,450,460}, 200, true)]
        [InlineData(new int[] { 1, 5, 9, 10, 22 }, 6, false)]
        [InlineData(new int[] { 1, 5, 9, 10 }, 10, true)]
        public void boolSearchRecursive_Interger_bool(int[] data, int key, bool result)
        {
            bool res = boolSearchRecursive(data, key);
            Assert.True(res == result);
        }

        [Theory]
        [InlineData(new string[] {"Asep","Nana","Udin","Parto","Deden", "Asep", "Nana", "Udin", "Parto", "Xeden" }, "Xeden", true)]
        //[InlineData(new string[] { "Sule", "Nana", "Mamat", "Parto" }, "Nana", true)]
        //[InlineData(new string[] { "Eweuh", "Nana", "Mamat", "Parto" }, "Gada", false)]
        public void boolSearchIterative_string_bool(string[] data, string key, bool result)
        {
            bool res = boolSearchIterative(data, key);
            Assert.True(res == result);
        }
        public bool boolSearchRecursive(int[] data, int key,int left,int right)
        {
            if(left > right)
            {
                return false;
            }

            //CARI TITIK TENGAH

            //UNTUK MENGATASI DECIMAL
                //int mid = left+((right-left) / 2);
            decimal count = (right + left) / 2;
            int mid = (int)Math.Floor(count);
            
           
            if(data[mid] == key)//compare apakah data tengah sama dengan yang dicari
            {
                return true;
            
            }else if(data[mid] > key) //ignore left,jika data tengah lebih besar dari data yang di cari maka geser ke kanan (mid-1)->yang kanan dikurangin
            {
                return boolSearchRecursive(data, key, left, mid-1);
            }
            else //ignore right, geser ke kiri (mid+1)-> yang kiri ditambahin
            {
                return boolSearchRecursive(data, key, mid + 1, right);
            }
        }
        public bool boolSearchRecursive(int[] data,int key)
        {
            return boolSearchRecursive(data, key, 0, data.Length-1);
        }

        public bool boolSearchIterative(string[] data, string key)
        {
            //KARENA DATANYA BELUM DI SORT MAKA :
             Array.Sort(data,StringComparer.InvariantCulture);
            int left = 0;
            int right = data.Length-1;
            int step = 0;
            while (left <= right)
            {
                //decimal count = (right + left) / 2;
                //int mid = (int)Math.Floor(count);
                int mid = left + ((right - left) / 2);
                int compareString = String.Compare(data[mid], key);
                step++;
                if (data[mid] == key)
                {
                    return true;
                }
                else if (compareString > 0)
                {
                    right = mid-1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return false;
        }

    }
}
