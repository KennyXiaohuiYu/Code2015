using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeSearchParent
{
    class Program
    {
        static void Main(string[] args)
        {
            BNode node1 = new BNode(2);
            BNode node2 = new BNode(1);
            BNode node3 = new BNode(4);
            BNode node4 = new BNode(3);
            BNode node5 = new BNode(6);
            BNode node6 = new BNode(5);
            BNode node7 = new BNode(7);
            BNode node8 = new BNode(8);
            BNode node9 = new BNode(9);
            node1.LeftNode = node2;
            node1.RightNode = node3;
            node3.LeftNode = node4;
            node3.RightNode = node5;
            node5.LeftNode = node6;
            node5.RightNode = node7;
            node7.RightNode = node8;
            node8.RightNode = node9;

            Node nodet1 = new Node(1);
            Node nodet2 = new Node(2);
            Node nodet3 = new Node(3);
            Node nodet4 = new Node(4);
            Node nodet5 = new Node(5);
            Node nodet6 = new Node(6);
            Node nodet7 = new Node(7);
            Node nodet8 = new Node(8);
            Node nodet9 = new Node(9);
            nodet1.LeftNode = nodet2;
            nodet1.RightNode = nodet3;
            nodet3.LeftNode = nodet4;
            nodet3.RightNode = nodet5;
            nodet5.LeftNode = nodet6;
            nodet5.RightNode = nodet7;
            nodet7.RightNode = nodet8;
            nodet8.RightNode = nodet9;

            DateTime d1 = DateTime.Now;
            Node node = BNode.BTreeParentFinder(node1, node4, node7);
            DateTime d2 = DateTime.Now;
            Node nodet = Node.ParentFinder(nodet1, nodet4, nodet7);
            DateTime d3 = DateTime.Now;
            Console.WriteLine("BTree: {0}", d2.Ticks - d1.Ticks);
            Console.WriteLine("Node Tree: {0}", d3.Ticks - d2.Ticks);
            PrintNode(node1, 0);
            Console.WriteLine("Nearest Parent for BNode {0} & {1} is: {2}", node4.Value, node7.Value, node.Value);
            PrintNode(nodet1, 0);
            Console.WriteLine("Nearest Parent for Tree Node {0} & {1} is: {2}", nodet4.Value, nodet7.Value, nodet.Value);

        }

        private static void PrintNode(Node node, int padding)
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
    }
}
