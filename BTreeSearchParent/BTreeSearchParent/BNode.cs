using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BTreeSearchParent
{
    public class BNode : Node
    {        
        public BNode(int node) : base(node)
        {
        }

        public static Node BTreeParentFinder(Node head, Node leaf1, Node leaf2)
        {
            if (leaf1.Value > leaf2.Value)
            {
                Node temp = leaf1;
                leaf1 = leaf2;
                leaf2 = temp;
            }

            if (head.Value < leaf1.Value)
                return BTreeParentFinder(head.RightNode, leaf1, leaf2);
            else if (head.Value > leaf2.Value)
                return BTreeParentFinder(head.LeftNode, leaf1, leaf2);
            else
            {
                if (FoundLeaf(head, leaf1) && FoundLeaf(head, leaf2))
                    return head;
                return null;
            }
        }


        public static bool FoundLeaf(Node head, Node leaf)
        {
            if (head == null)
                return false;

            if (head.Value == leaf.Value)
                return true;
            else if (head.Value < leaf.Value)
                return FoundLeaf(head.RightNode, leaf);
            else
                return FoundLeaf(head.LeftNode, leaf);
        }

    }
}
