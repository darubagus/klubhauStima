using System;
using System.Collections.Generic;
using Stima;

namespace Stima
{
    public class DepthFirstSearch
    {
        //Attribute
        private Node startNode;
        private Graph g;
        private Queue q = new Queue();
        private int t = 0;
        private List<Node> result = new List<Node>();

        private IDictionary<Node, int> visited = new Dictionary<Node, int>();
        private IDictionary<Node, int[]> interval = new Dictionary<Node, int[]>();
        private IDictionary<Node, Node> parentNode = new Dictionary<Node, Node>();

        //Constructor
        public DepthFirstSearch(Graph g, string startNode)
        {
            this.g = g;
            this.startNode = g.SearchNode(startNode);
            InitializeDFS();
        }

        //Methods
        private void InitializeDFS()
        {
            Node V = g.Head;

            while (V != null)
            {
                int[] tempInterval = new int[2] { -1, -1 }; // intialize interval with default value of {-1, -1}
                visited.Add(V, 0); // initialize visited dictionary with startNode and 0 value
                parentNode.Add(V, null);
                interval.Add(V, tempInterval); // initialize start vertex's level with templevel
                V = V.Next;
            }
        }

        private void DFS(Node startNode)
        {
            visited[startNode] = 1;
            Interval[startNode][0] = t;

            result.Add(startNode);
            t++;

            SuccessorNode TrailNode = startNode.Trail;
            while (TrailNode != null)
            {
                if (visited[TrailNode.Succ] == 0)
                {
                    parentNode[TrailNode.Succ] = startNode;
                    DFS(TrailNode.Succ);
                }
                TrailNode = TrailNode.Next;
            }

            visited[startNode] = 2;
            interval[startNode][1] = t;
            t++;
        }

        public void RunDFS()
        {
            DFS(startNode);
        }

        public List<Node> Path(string EndNode)
        {
            List<Node> path = new List<Node>();
            Node V = g.SearchNode(EndNode);

            while (V != null)  // for each vertex in g
            {
                path.Add(V);
                V = parentNode[V];
            }

            return path;
        }



        //Getter Setter
        public Graph G
        {
            set { g = value; }
            get { return g; }
        }

        public IDictionary<Node, int[]> Interval
        {
            set { interval = value; }
            get { return interval; }
        }

        public Node StartNode
        {
            set { startNode = value; }
            get { return startNode; }
        }


        //DEBUG
        public void PrintPath(List<Node> path)
        {
            foreach (Node n in path)
            {
                Console.Write("{0} ", n.Name);
            }
            Console.WriteLine();
        }

        public void PrintVisited()
        {
            foreach (KeyValuePair<Node, int> kvp in visited)
            {
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key.Name, kvp.Value);
            }
        }

        public void PrintInterval()
        {
            foreach (KeyValuePair<Node, int[]> kvp in interval)
            {
                Console.WriteLine("Key: {0}, Value: [{1}]", kvp.Key.Name, string.Join(", ", kvp.Value));
            }
        }



        public void PrintParent()
        {
            foreach (KeyValuePair<Node, Node> kvp in parentNode)
            {
                if (kvp.Value == null)
                {
                    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key.Name, kvp.Value);
                }
                else
                {
                    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key.Name, kvp.Value.Name);
                }

            }

        }

        public void PrintResult()
        {
            foreach (Node node in result)
            {
                Console.Write("{0} ", node.Name);

            }
            Console.WriteLine();
        }


    }
}