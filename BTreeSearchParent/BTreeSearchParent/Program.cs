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
            BNode node1 = new BNode(1);
            BNode node2 = new BNode(2);
            BNode node3 = new BNode(3);
            BNode node4 = new BNode(4);
            BNode node5 = new BNode(5);
            BNode node6 = new BNode(6);
            BNode node7 = new BNode(7);
            node1.LeftNode = node2;
            node1.RightNode = node3;
            node3.LeftNode = node4;
            node3.RightNode = node5;
            node5.LeftNode = node6;
            node5.RightNode = node7;

            BNode node8 = new BNode(8);
            BNode node9 = new BNode(9);
            
            BNode node = BNode.ParentFinder(node1, node4, node9);
            PrintNode(node1, 0);
            Console.WriteLine("Nearest Parent for Node {0} & {1} is: {2}", node4.BValue, node7.BValue, node.BValue);

        }

        private static void PrintNode(BNode node, int padding)
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
                Console.WriteLine(node.BValue);
                PrintNode(node.LeftNode, padding + 1);
            }
        }        
    }
}
