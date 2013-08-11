using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFS
{
    public class Node<T>
    {
        public T data { get; set; }
        public bool visited { get; set; }
        public List<Node<T>> adj { get; set; }
        public List<int> cost { get; set; }

        public Node() { }
        public Node(T data) : this(data, null, null) { }
        public Node(T data, List<Node<T>> adj, List<int> cost)
        {
            this.data = data;
            if (adj == null)
                this.adj = new List<Node<T>>();
            else
                this.adj = adj;

            if (cost == null)
                this.cost = new List<int>();
            else
                this.cost = cost;
        }
    }

    public class Graph<T> : Node<T>
    {
        public List<Node<T>> nodeset = new List<Node<T>>();
        public Node<T> start { get; set; }

        public Graph() { }

        public bool AddNode(Node<T> node)
        {
            nodeset.Add(node);
            return true;
        }
        public Node<T> AddNewNode(T data)
        {
            Node<T> node = new Node<T>(data);
            return node;
        }

        public bool AddEdge(Node<T> n1, Node<T> n2, int cost)
        {
            n1.adj.Add(n2);
            n1.cost.Add(cost);
            n2.adj.Add(n1);
            n2.cost.Add(cost);
            return true;
        }

        public bool DFS(T x)
        {
            Stack<Node<T>> stk = new Stack<Node<T>>();
            Node<T> cur = start;
            cur.visited = true;
            Console.WriteLine("Order of dfs traversal = ");
            while (cur != null)
            {
                Console.Write(" {0} ", cur.data.ToString());
                if (cur.data.ToString() == x.ToString())
                    return true;
                foreach (Node<T> node in cur.adj)
                {
                    if (!node.visited)
                    {
                        node.visited = true;
                        stk.Push(node);
                    }
                }
                cur = stk.Pop();
            }
            return false;
        }

        public bool DFSRecur(Node<T> node, T data)
        {
            if (node == null)
                return false;
            Console.Write(" {0} ", node.data);
            if (node.data.ToString() == data.ToString())
                return true;
            
            node.visited = true;
            foreach (Node<T> neighbor in node.adj)
                if (!neighbor.visited)
                    if (DFSRecur(neighbor, data))
                        return true;
            
            return false;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> g = createGraph();
            Console.WriteLine("Is element found = " + g.DFSRecur(g.start, 30));
            Console.ReadLine();
        }

        private static Graph<int> createGraph()
        {
            Graph<int> g = new Graph<int>();
            Node<int> n1 = g.AddNewNode(3);
            g.start = n1;
            Node<int> n2 = g.AddNewNode(2);
            Node<int> n3 = g.AddNewNode(10);
            Node<int> n4 = g.AddNewNode(6);
            Node<int> n5 = g.AddNewNode(20);
            g.AddEdge(n1, n2, 5);
            
            g.AddEdge(n1, n1, 6);
            g.AddEdge(n1, n3, 13);
            //g.AddEdge(n2, n3, 12);
            g.AddEdge(n2, n4, 8);
            g.AddEdge(n4, n5, 26);
            return g;
        }
    }
}
