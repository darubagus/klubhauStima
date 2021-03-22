using System;

namespace Stima
{
    public class Node
    {
        private int numPred;
        private string name;
        private Node next;
        private SuccessorNode trail;

        public Node() { }

        public Node(string _name)
        {
            this.name = _name;
            this.numPred = 0;
            this.next = null;
            this.trail = null;
        }

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
        private Node succ;
        private SuccessorNode next;

        //Ctor
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
     * [G1] -> [G2] -> [G4]
     * [G2] -> [G1]
     * [G3]
     * [G4] -> [G1]
     */

    public class Graph
    {
        private Node head;

        public Graph(string _name)
        {
            Node P = new Node(_name);
            this.head = P;
        }

        public Node Head
        {
            get { return head; }
            set { head = value; }
        }

        public void InsertNode(string X)
        {
            Node LastG;

            LastG = head;
            Node pNode = new Node(X);
            if (pNode != null)
            {
                while (LastG.Next != null)
                {
                    LastG = LastG.Next;
                }
                LastG.Next = pNode;
            }
        }

        public void InsertEdge(string source, string destination)
        {
            Node Pprec = SearchNode(source);
            Node Psucc = SearchNode(destination);
            SuccessorNode T;

            if (SearchEdge(source, destination) == null)
            {
                T = Pprec.Trail;
                if (T == null)
                {
                    SuccessorNode temp = new SuccessorNode(Psucc);
                    Pprec.Trail = temp;
                }
                else
                {
                    while (T.Next != null)
                    {
                        T = T.Next;
                    }
                    SuccessorNode temp = new SuccessorNode(Psucc);
                    T.Next = temp;
                }
                Psucc.nPred += 1;
            }

        }

        public Node SearchNode(string X)
        {
            Node P;
            P = head;
            while (P != null && P.Name != X)
            {
                P = P.Next;
            }
            return P;
        }

        public SuccessorNode SearchEdge(string prec, string succ)
        {
            Node P;
            SuccessorNode T;

            P = SearchNode(prec);

            if (P == null) { return null; }
            else
            {
                T = P.Trail;
                if (T == null) { return null; }
                else
                {
                    while ((T.Succ).Name != succ && (T.Next != null))
                    {
                        T = T.Next;
                    }
                    if (T.Succ.Name != succ) { return null; }
                    else { return T; }
                }
            }
        }
    }
}