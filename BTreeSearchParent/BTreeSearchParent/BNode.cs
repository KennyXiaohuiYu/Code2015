using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BTreeSearchParent
{
    public class BNode
    {
        public int BValue { get; set; }
        public BNode LeftNode { get; set; }
        public BNode RightNode { get; set; }

        public BNode(int node)
        {
            BValue = node;
        }

        public static BNode ParentFinder(BNode head, BNode leaf1, BNode leaf2)
        {
            Stack<BNode> sLeaf1 = new Stack<BNode>();
            Stack<BNode> sLeaf2 = new Stack<BNode>();
            if (!FoundLeaf(head, leaf1, ref sLeaf1) || !FoundLeaf(head, leaf2, ref sLeaf2))
                return null;

            Stack<BNode> sLeaf1Reverse = ReverseStack(sLeaf1);
            Stack<BNode> sLeaf2Reverse = ReverseStack(sLeaf2);
            BNode prePopped = null;
            bool bFound = false;
            while (sLeaf1Reverse.Any() && sLeaf2Reverse.Any())
            {
                BNode leaf1Parent = sLeaf1Reverse.Pop();
                BNode leaf2Parent = sLeaf2Reverse.Pop();
                if (leaf1Parent != leaf2Parent)
                {
                    bFound = true;
                    break;
                }                
                prePopped = leaf1Parent;
            }
            if (bFound)
                return prePopped;

            return null;
        }


        public static bool FoundLeaf(BNode head, BNode leaf, ref Stack<BNode> stack)
        {
            if (head == null)
                return false;

            stack.Push(head);
            BNode curNode = head;

            if (curNode.BValue == leaf.BValue)
                return true;
            
            if (FoundLeaf(curNode.LeftNode, leaf, ref stack))
                return true;

            if (FoundLeaf(curNode.RightNode, leaf, ref stack))
                return true;

            stack.Pop();
            return false;
        }

        public static Stack<BNode> ReverseStack(Stack<BNode> stack)
        {
            Stack<BNode> sReverse = new Stack<BNode>();
            while (stack.Any())
                sReverse.Push(stack.Pop());
            return sReverse;
        }
    }
}
