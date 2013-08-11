using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    public class Node
    {
        public int data { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node() { }

        public Node(int data, Node left, Node right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        public Node(int data)
            : this(data, null, null)
        { }

    }

    public class BTree : Node
    {
        private Node newNode(int data)
        {
            Node cur = new Node(data);
            return cur;
        }

        public Node insert(Node node, int data) 
        {
            if (node == null)
            {
                return newNode(data);
            }
            else
            {
                if ( node.data >= data)
                    node.left = insert(node.left, data);
                else
                    node.right = insert(node.right, data);
                return node;
            }
        }

        public void inorder(Node node)
        {
            if (node == null)
                return;

            inorder(node.left);
            Console.Write(" {0} ", node.data);
            inorder(node.right);
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            BTree tree = new BTree();
            Node node = new Node(); ;

            for (int i = 1; i < 10; i++)
                node = tree.insert(node, i);

            tree.inorder(node);
            Console.ReadLine();
        }
    }
}
