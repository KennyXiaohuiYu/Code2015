using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeSearchParent
{
    public class Node
    {
        public int Value { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }

        public Node(int node)
        {
            Value = node;
        }

        public static Node ParentFinder(Node head, Node leaf1, Node leaf2)
        {
            Stack<Node> sLeaf1 = new Stack<Node>();
            Stack<Node> sLeaf2 = new Stack<Node>();
            if (!FoundLeaf(head, leaf1, ref sLeaf1) || !FoundLeaf(head, leaf2, ref sLeaf2))
                return null;

            Stack<Node> sLeaf1Reverse = ReverseStack(sLeaf1);
            Stack<Node> sLeaf2Reverse = ReverseStack(sLeaf2);
            Node prePopped = null;
            bool bFound = false;
            while (sLeaf1Reverse.Any() && sLeaf2Reverse.Any())
            {
                Node leaf1Parent = sLeaf1Reverse.Pop();
                Node leaf2Parent = sLeaf2Reverse.Pop();
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


        public static bool FoundLeaf(Node head, Node leaf, ref Stack<Node> stack)
        {
            if (head == null)
                return false;

            stack.Push(head);
            Node curNode = head;

            if (curNode.Value == leaf.Value)
                return true;

            if (FoundLeaf(curNode.LeftNode, leaf, ref stack))
                return true;

            if (FoundLeaf(curNode.RightNode, leaf, ref stack))
                return true;

            stack.Pop();
            return false;
        }

        private static Stack<Node> ReverseStack(Stack<Node> stack)
        {
            Stack<Node> sReverse = new Stack<Node>();
            while (stack.Any())
                sReverse.Push(stack.Pop());
            return sReverse;
        }
    }
}
