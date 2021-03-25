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
            // initalization of DFS
            Node V = g.Head;

            // foreach element in graph, assign default value
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
            visited[startNode] = 1; // startNode visited, set the visited value to 1
            Interval[startNode][0] = t; // time when the startNode visited for the first time

            result.Add(startNode); // add startNode to result list
            t++;

            SuccessorNode TrailNode = startNode.Trail;  // set trailNode with startNode's successorNode
            while (TrailNode != null) // traversal until all of the startNode's visited
            {
                if (visited[TrailNode.Succ] == 0)   // if the succ of trailNode haven't visited
                {
                    parentNode[TrailNode.Succ] = startNode; // set the trailNode's succ with startNode
                    DFS(TrailNode.Succ);    // Recursively call DFS until reaching the leaf
                }
                TrailNode = TrailNode.Next;
            }

            visited[startNode] = 2; // Backtrack
            interval[startNode][1] = t; // time when the startNode visited for the second time
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
                // searching the ancestor path from the EndNode
                path.Add(V);
                V = parentNode[V];
            }
            // the path need to be reversed
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

        public string PrintStringDFS(List<Node> path)
        {
            string hasil = "";
            foreach (Node n in path)
            {
                hasil += n.Name + " ";
            }
            hasil += "\r\n";

            return hasil;
        }


    }
}