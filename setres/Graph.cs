using System;

namespace Stima
{
    public class Node
    {
        // Atribut
        private int numPred;
        private string name;
        private Node next;
        private SuccessorNode trail;

        // Constructor
        public Node() { }

        public Node(string _name)
        {
            this.name = _name;
            this.numPred = 0;
            this.next = null;
            this.trail = null;
        }

        // Getter Setter
        public int nPred
        {
            get { return numPred; }
            set { numPred = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Node Next {
            get { return next; }
            set { next = value; }
        }

        public SuccessorNode Trail
        {
            get { return trail; }
            set { trail = value; }
        }


    }

    public class SuccessorNode
    {
        // Attribute
        private Node succ;
        private SuccessorNode next;

        //Constructor
        public SuccessorNode(Node pNode)
        {
            succ = pNode;
        }

        // Getter Setter
        public Node Succ
        {
            get { return succ; }
            set { succ = value; }
        }

        public SuccessorNode Next
        {
            get { return next; }
            set { next = value; }
        }
    }

    /*
     * Graph Representation :
     * 
     * [G1] --> [G2] -> [G4]
     * note : G2 and G4 are successorNode; G2 == G1.Succ
     * [G2] --> [G1]
     * [G3]
     * [G4] --> [G1]
     */

    public class Graph
    {
        //Attribute
        private Node head;

        // Constructor
        public Graph(string _name)
        {
            Node P = new Node(_name);
            this.head = P;
        }

        // Getter Setter
        public Node Head
        {
            get { return head; }
            set { head = value; }
        }

        // Methods
        public void InsertNode(string X)
        {
            Node LastG;

            LastG = head;
            Node pNode = new Node(X); // Allocation of Node
            if (pNode != null) // if the allocation is success
            {
                while (LastG.Next != null)  // Traversal until the last node of the graph
                {
                    LastG = LastG.Next;
                }
                LastG.Next = pNode; // Assign the last node of the graph with pNode
            }
        }

        public void InsertEdge(string source, string destination)
        {
            Node Pprec = SearchNode(source);        // search sourceNode
            Node Psucc = SearchNode(destination);   // search destinationNode
            SuccessorNode T;

            if (SearchEdge(source, destination) == null) // if the edge doesn't exist
            {
                T = Pprec.Trail; // assign T with successorNode of sourceNode

                if (T == null) // if the sourceNode doesn't have any neighbor
                {
                    SuccessorNode temp = new SuccessorNode(Psucc);
                    Pprec.Trail = temp;
                }
                else
                {
                    while (T.Next != null) // traversal until the last node of sourceNode's successorNode
                    {
                        T = T.Next;
                    }
                    SuccessorNode temp = new SuccessorNode(Psucc);
                    T.Next = temp;
                }
                Psucc.nPred += 1; // add neighbor counter
            }

        }

        public Node SearchNode(string X)
        {
            Node P;
            P = head;
            while (P != null && P.Name != X) // traversal until the last node of the graph or node X is found
            {
                P = P.Next;
            }
            return P;
        }

        public SuccessorNode SearchEdge(string prec, string succ)
        {
            Node P;
            SuccessorNode T;

            P = SearchNode(prec); // search for sourceNode

            if (P == null)  // if the sourceNode doesn't exist
            {
                return null;
            }
            else
            {
                T = P.Trail;
                if (T == null) // if sourceNode doesn't have any neighbor
                {
                    return null;
                }
                else
                {
                    while ((T.Succ).Name != succ && (T.Next != null)) // traversal until last node of sourceNode's successorNode or until succ is found in sourceNode's successorNode
                    {
                        T = T.Next;
                    }

                    if (T.Succ.Name != succ) // if the edge not found
                    {
                        return null;
                    }
                    else
                    {
                        return T;
                    }
                }
            }
        }
    }
}