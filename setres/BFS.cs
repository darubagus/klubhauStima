using System;
using System.Collections.Generic;
using System.Linq;


namespace Stima
{
    public class BreadthFirstSearch
    {
        //Attribute
        private Node startNode;
        private Graph g;
        private Queue q = new Queue();
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
            
            while (V != null) // foreach element in graph, assign default value
            {
                visited.Add(V, false);
                parentNode.Add(V, null);
                level.Add(V, -1);
                V = V.Next;
            }
        }

        private void BFS(Node startNode)
        {
            // startNode visited, set the visited value with true
            visited[startNode] = true;
            // set the level of startNode with 0
            level[startNode] = 0;
            // add startNode into queue
            q.Enqueue(startNode);

            while (!q.IsEmpty())    
            {
                // to process the node, dequeue it.
                Node V = q.Dequeue();
                // add the node into result list
                result.Add(V);

                // assign child with node V's neighbors
                SuccessorNode Child = V.Trail;
                // traversal all of V's neighbors
                while (Child != null)           
                {
                    // if the succ haven't visited, visit
                    if (!visited[Child.Succ])   
                    {
                        // assign visited with true
                        visited[Child.Succ] = true;
                        // assign V as the parent
                        parentNode[Child.Succ] = V;
                        // assign the level with the parent's level + 1
                        level[Child.Succ] = level[V] + 1;
                        // enqueue
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

            // for each vertex in g
            while (V != null)  
            {
                // searching the ancestor path from the EndNode
                path.Add(V);
                V = parentNode[V];
            }
            // the path need to be reversed
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

        public string PrintStringBFS(List<Node> path)
        {
            string hasil = "";
            foreach (Node n in path)
            {
                if (n != path.Last())
                {
                    hasil += n.Name + " > ";
                }
                else
                {
                    hasil += n.Name;
                }
                //hasil += n.Name + " > ";
            }
            hasil += "\r\n";

            return hasil;
        }

        public int PrintLevel(string EndNode)
        {
            foreach (KeyValuePair<Node, int> kvp in level)
            {
                if (kvp.Key.Name == EndNode)
                {
                    return kvp.Value;
                }
            }
            return 0;
        }

    }

}