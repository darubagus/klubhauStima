using System;
using System.Collections.Generic;
using System.Linq;

namespace Stima
{
    public class MutualFriend
    {
        // Attribute
        private Graph g;
        private string startNode;
        private IDictionary<Node, List<Node>> result = new Dictionary<Node, List<Node>>();

        // Constructor
        public MutualFriend(Graph g, string startNode)
        {
            this.g = g;
            this.startNode = startNode;
        }

        // Method
        public void FindMutualFriend()
        {
            // Bikin traversal graph pake bfs
            BreadthFirstSearch bfs = new BreadthFirstSearch(g, startNode);

            // shortest distance dari masing-masing account
            bfs.RunBFS(); 
            foreach (KeyValuePair<Node, int> NodeLevel in bfs.Level)
            {
                List<Node> mutual = new List<Node>();

                // Hanya memproses node dengan level == 2 karena ya kalo lebih gapunya mutual friend berarti
                if (NodeLevel.Value == 2)
                {
                    // 0th degree node
                    Node V = bfs.StartNode;

                    // 1st degree nodes
                    SuccessorNode TNode = V.Trail; 

                    // foreach node yang ada di 1st degree connections
                    while (TNode != null)
                    {
                        // 2nd degree node
                        Node TChild = TNode.Succ;

                        // 2nd degree nodes
                        SuccessorNode ChildTrail = TChild.Trail;

                        // flag buat ngecek namanya sama atau engga, defaultnya false
                        bool status = false; 

                        // foreach 2nd degree connections
                        while (!status && ChildTrail != null)
                        {
                            // ngecek namanya sama atau engga sama Nodelevel yang ada di level 2, kalo iya, tambahin ke list mutual
                            if (NodeLevel.Key.Name == ChildTrail.Succ.Name)
                            {
                                mutual.Add(TChild);
                                status = true;
                                
                            }
                            ChildTrail = ChildTrail.Next;
                        }
                        TNode = TNode.Next;
                    }
                    result.Add(NodeLevel.Key, mutual);
                }
            }

            // sorting descending berdasarkan mutual yang paling banyak
            result = result.OrderByDescending(l => l.Value.Count).ToDictionary(l => l.Key, l => l.Value);
        }

        // Getter Setter
        public Graph G
        {
            set { g = value; }
            get { return g; }
        }

        public IDictionary<Node, List<Node>> Result
        {
            set { result = value; }
            get { return result; }
        }

        public string StartNode
        {
            set { startNode = value; }
            get { return startNode; }
        }

        // Print result
        public void PrintResult()
        {
            FindMutualFriend();
            foreach (KeyValuePair<Node, List<Node>> Node in result)
            {
                Console.WriteLine("Nama Akun : " + Node.Key.Name);
                Console.WriteLine("{0} mutual friend(s) :", Node.Value.Count);
                foreach (Node mutualFriend in Node.Value)
                {
                    Console.WriteLine("{0} ", mutualFriend.Name);
                }
            }
        }

        public string PrintHasil()
        {
            FindMutualFriend();
            string hasil = "";
            foreach (KeyValuePair<Node, List<Node>> Node in result)
            {
                hasil += "Nama Akun : " + Node.Key.Name + "\n";
                hasil += Node.Value.Count.ToString() + " mutual friend(s) :" + "\n";
                foreach (Node mutualFriend in Node.Value)
                {
                    hasil += mutualFriend.Name + "\n";
                }

                hasil += "\n";
            }

            return hasil;
        }

    }
}