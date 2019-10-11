using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class TreeNode
    {
        internal TreeNode left;
        internal TreeNode right;
        private int v;

        public TreeNode(int v)
        {
            this.v = v;
        }
    }
    class ArratToBST
    {
        public TreeNode sortedArrayToBST(int[] num)
        {
            return this.sortedArrayToBSTRec(num,0,num.Length-1);
        }

        private TreeNode sortedArrayToBSTRec(int[] num, int low, int high)
        {
            if (low>high)
            {
                return null;
            }
            var mid = (high - low) / 2 + low;
            var newroot = new TreeNode(num[mid]) {
                left = this.sortedArrayToBSTRec(num,low,mid-1),
               right = this.sortedArrayToBSTRec(num,mid+1,high)
            };
            return newroot;
        }
    }
}
