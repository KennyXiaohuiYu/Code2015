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
        #region static_members
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

        public static void PrintNode(BNode node, int padding)
        {
            if (node == null)
            {
                for (int i = 0; i < padding; i++)
                    Console.Write("\t");
                Console.WriteLine('*');
            }
            else
            {
                PrintNode(node.RightNode, padding + 1);
                for (int i = 0; i < padding; i++)
                    Console.Write("\t");
                Console.WriteLine(node.Value);
                PrintNode(node.LeftNode, padding + 1);
            }
        }        
        #endregion

        public new BNode LeftNode { get; private set; }
        public new BNode RightNode { get; private set; }

        public BNode(int node) : base(node)
        {
        }

        public void Insert(int i)
        {
            Insert(new BNode(i));
            //if (i == Value)
            //    return;

            //if (i < Value)
            //{
            //    if (LeftNode == null)
            //        LeftNode = new BNode(i);
            //    else
            //        LeftNode.Insert(i);
            //}
            //else
            //{
            //    if (RightNode == null)
            //        RightNode = new BNode(i);
            //    else
            //        RightNode.Insert(i);
            //}
        }

        public void Insert(BNode node)
        {
            if (node == null)
                return;

            if (node.LeftNode != null)
                Insert(node.LeftNode);

            if (node.Value == Value)
                return;

            if (node.Value < Value)
            {
                if (LeftNode == null)
                    LeftNode = node;
                else
                    LeftNode.Insert(node);
            }
            else
            {
                if (RightNode == null)
                    RightNode = node;
                else
                    RightNode.Insert(node);
            }

            if (node.RightNode != null)
                Insert(node.RightNode);
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", LeftNode == null ? string.Empty : LeftNode.ToString(), Value,
                RightNode == null ? string.Empty : RightNode.ToString());
        }

        public IEnumerable<BNode> GetAscNext()
        {
            if (LeftNode != null)
            {
                foreach (BNode node in LeftNode.GetAscNext())
                    yield return node;
            }

            yield return this;

            if (RightNode != null)
            {
                foreach (BNode node in RightNode.GetAscNext())
                    yield return node;
            }

            //yield return null;
        }

        public IEnumerable<BNode> GetDescNext()
        {
            if (RightNode != null)
            {
                foreach (BNode node in RightNode.GetDescNext())
                    yield return node;
            }

            yield return this;

            if (LeftNode != null)
            {
                foreach (BNode node in LeftNode.GetDescNext())
                    yield return node;
            }

        }
    }
}
