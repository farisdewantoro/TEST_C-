using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace C_SHARP_LEETCODE_TEST
{
    //    Given a binary tree, return the tilt of the whole tree.

    //The tilt of a tree node is defined as the absolute difference between the sum of all left subtree node values and the sum of all right subtree node values.Null node has tilt 0.

    //The tilt of the whole tree is defined as the sum of all nodes' tilt.

    //Example:
    //Input: 
    //         1
    //       /   \
    //      2     3
    //Output: 1
    //Explanation: 
    //Tilt of node 2 : 0
    //Tilt of node 3 : 0
    //Tilt of node 1 : |2-3| = 1
    //Tilt of binary tree : 0 + 0 + 1 = 1
    //Note:

    //The sum of node values in any subtree won't exceed the range of 32-bit integer.
    //All the tilt values won't exceed the range of 32-bit integer.
    public class _563_Binary_Tree_Tilt
    {
        public int tilt { get; set; }
        [Theory]
        [ClassData(typeof(TreeClassData))]
        public void Test(TreeNode node,int result)
        {
            var res = FindTilt(node);
            Assert.True(result == res);
        }
        public int FindTilt(TreeNode root)
        {
            //deep-first-search
            //Example:
            //Input: 
            //         1
            //       /   \
            //      2     3

            //LEFT:
            // --Traverse to 2 
            // left = 0 -> karena tidak ada child
            // right = 0 -> karena tidak ada child
            // tilt = 0;
            // result = 2

            //RIGHT:
            // --Traverse to 3
            // left = 0 -> karena tidak ada child
            // right = 0 -> karena tidak ada child
            // tilt = 0;
            // result = 3

            // tilt = Math.abs(2-3) = 1;

            //RUMUS LEFT - RIGHT;

            //deep-first-search
            //Example:
            //Input: 
            //         1
            //       /   \
            //      2     3
            //     / \
            //    2   4
            //LEFT:
            // --Traverse to 2 
            // left = 2 -> 2+0
            // right = 4 -> 4+0
            // tilt = (2-4) = 2;
            // result = {2+2+4} = 8 

            //RIGHT:
            // --Traverse to 3
            // left = 0 -> karena tidak ada child
            // right = 0 -> karena tidak ada child
            // tilt = 0;
            // result = 3

            // tilt = (2 + Math.abs(8-3)) = 7;
            var result = Traverse(root);
            return tilt;
         
        }
        public int Traverse(TreeNode root)
        {

            if (root == null)
            {
                return 0;
            }
            int left = Traverse(root.left);
            int right = Traverse(root.right);
            tilt += Math.Abs(left - right);
            return root.val +left+right;
        }
    }
  



    public class TreeClassData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
    {
        new object[] { new TreeNode(1,new TreeNode(2),new TreeNode(3)),1},
        new object[] {
            new TreeNode(1,
            new TreeNode(2,new TreeNode(2), new TreeNode(4)),
            new TreeNode(3)
            ),7},
    };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
    // Definition for a binary tree node.
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
       }
  }

}
