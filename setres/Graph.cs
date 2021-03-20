using System;
using System.Collections;
using System.Linq;
using System.text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

// This is based on the graph implementation found at: https://msdn.microsoft.com/en-us/library/ms379574(v=vs.80).aspx
// But is updated to work in the latest C# and Net Core
namespace Graph1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> web = new Graph<string>();
            web.AddNode("Privacy.aspx");
            web.AddNode("People.aspx");
            web.AddNode("About.aspx");
            web.AddNode("Index.aspx");
            web.AddNode("Products.aspx");
            web.AddNode("Contact.aspx");

            var people = new GraphNode<string>("People.aspx");
            var privacy = new GraphNode<string>("Privacy.aspx");
            var index = new GraphNode<string>("Index.aspx");
            var about = new GraphNode<string>("About.aspx");
            var contact = new GraphNode<string>("Contact.aspx");
            var products = new GraphNode<string>("Products.aspx");

            web.AddUndirectedEdge(people, privacy);  // People -> Privacy
            web.AddUndirectedEdge(privacy, index);    // Privacy -> Index
            web.AddUndirectedEdge(privacy, about);    // Privacy -> About
            web.AddUndirectedEdge(about, privacy);    // About -> Privacy
            web.AddUndirectedEdge(about, people);    // About -> People
            web.AddUndirectedEdge(about, contact);   // About -> Contact
            web.AddUndirectedEdge(index, about);      // Index -> About
            web.AddUndirectedEdge(index, contact);   // Index -> Contacts
            web.AddUndirectedEdge(index, products);  // Index -> Products
            web.AddUndirectedEdge(products, index);  // Products -> Index
            web.AddUndirectedEdge(products, people);// Products -> People

            Console.WriteLine("C# Graph Example - Updated for latest C# Net Core");
        }
    }

    public class Node<T>
    {
        private T data;
        private NodeList<T> neighbors = null;

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        public T Value { get; set; }

        protected NodeList<T> Neighbors { get; set; }

    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
                base.Items.Add(default(Node<T>));
            }
        }

        public Node<T> FindByValue(T value)
        {
            foreach(Node<T> node in Items)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }
    }

    public class GraphNode<T> : Node<T>
    {
        // private List<int> costs;

        public GraphNode() : base() { }
        public GraphNode(T value) : base(value) { }
        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }

        // WTF IS THIS?
        new public NodeList<T> Neighbors
        {
            get
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>();

                return base.Neighbors;
            }
        }

        // public List<int> Costs
        // {
        //     get
        //     {
        //         if (costs == null)
        //             costs = new List<int>();

        //         return costs;
        //     }
        // }

    }

    public class Graph<T> : IEnumerable<Node<T>>
    {
        private NodeList<T> nodeSet;

        public NodeList<T> Nodes { get; }

        public Graph() : this(null) { }
        public Graph(NodeList<T> nodeSet)
        {
            if (nodeSet == null)
            {
                this.nodeSet = new NodeList<T>();
            } else {
                this.nodeSet = nodeSet;
            }
        }

        public void AddNode(GraphNode<T> node)
        {
            nodeSet.Add(node);
        }

        public void AddNode(T value)
        {
            nodeSet.Add(new GraphNode<T>(value));
        }

        // public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        // public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to)
        // {
        //     from.Neighbors.Add(to);
        // }

        // public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to)
        {
            from.Neighbors.Add(to);
            to.Neighbors.Add(from);
            // to.Costs.Add(cost);
        }

        public bool contains(T value)
        {
            return nodeSet.FindByValue(value) != null;
        }

        public bool Remove(T value)
        {
            // Remove node from nodeset
            GraphNode<T> nodeToRemove = (GraphNode<T>)nodeSet.FindByValue(value);
            if (nodeToRemove == null)
            {
                // wasnt found
                return false;
            }

            // was found
            nodeSet.Remove(nodeToRemove);

            // enumerate through each node in nodeSet, removing edges to this node
            foreach(GraphNode<T> gnode in nodeSet)
            {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    gnode.Neighbors.RemoveAt(index);
                    // gnode.Costs.RemoveAt(index);
                }
            }

            return true;
        }

        public int Count
        {
            get { return nodeSet.Count; }
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return nodeSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    

}