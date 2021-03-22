using System;
using System.Collections.Generic;


namespace Stima
{
    public class BreadthFirstSearch
    {
        //Attribute
        private Node startNode;
        private Graph g;
        private Queue q = new Queue();
        //private int t = 0;
        private List<Node> result = new List<Node>();

        private IDictionary<Node, bool> visited = new Dictionary<Node, bool>();
        private IDictionary<Node, int> level = new Dictionary<Node, int>();
        private IDictionary<Node, Node> parentNode = new Dictionary<Node, Node>();

        // Constructor
        public BreadthFirstSearch(Graph g, string startNode)
        {
            this.g = g;
            this.startNode = g.SearchNode(startNode);
            InitializeBFS();
        }

        // Methods
        private void InitializeBFS()
        {
            Node V = g.Head;
            
            while (V != null)
            {
                visited.Add(V, false);
                parentNode.Add(V, null);
                level.Add(V, -1);
                V = V.Next;
            }
        }

        private void BFS(Node startNode)
        {
            visited[startNode] = true;
            level[startNode] = 0;
            q.Enqueue(startNode);

            while (!q.IsEmpty())
            {
                Node V = q.Dequeue();
                result.Add(V);

                SuccessorNode Child = V.Trail;
                while (Child != null)
                {
                    if (!visited[Child.Succ])
                    {
                        visited[Child.Succ] = true;
                        parentNode[Child.Succ] = V;
                        level[Child.Succ] = level[V] + 1;
                        q.Enqueue(Child.Succ);
                    }
                    Child = Child.Next;
                }
            }
        }

        public void RunBFS()
        {
            BFS(startNode);
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


        // Getter Setter
        public Graph G
        {
            set { g = value; }
            get { return g; }
        }

        public IDictionary<Node, int> Level
        {
            set { level = value; }
            get { return level; }
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
            foreach (KeyValuePair<Node, bool> kvp in visited)
            {
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key.Name, kvp.Value);
            }
        }

        public void PrintLevel()
        {
            foreach (KeyValuePair<Node, int> kvp in level)
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