using System;

namespace Stima
{
    public class EQueue
    {
        // Attribute
        private Node info;
        private EQueue next;

        //Constructor
        public EQueue(Node X)
        {
            next = null;
            info = X;
        }

        // Getter Setter
        public Node Info
        {
            set { info = value; }
            get { return info; }
        }

        public EQueue Next
        {
            set { next = value; }
            get { return next; }
        }
    }

    public class Queue
    {
        //Attribute
        private EQueue head;
        private EQueue tail;

        //Constructor
        public Queue()
        {
            head = null;
            tail = null;
        }

        //Methods
        public bool IsEmpty()
        {
            return (head == null && tail == null);
        }

        public int NbElment()
        {
            int i = 0;
            EQueue P= head;

            while (P != null)
            {
                i++;
                P = P.Next;
            }

            return i;
        }

        public void Enqueue(Node X)
        {
            EQueue P = new EQueue(X);

            if (P != null) // will only continue if the allocation is succeed
            {
                if (!IsEmpty())
                {
                    tail.Next = P;
                }
                else
                {
                    head = P;
                }

                tail = P;
            }
        }

        public Node Dequeue()
        {
            EQueue P = head;
            head = P.Next;

            if (head == null)
            {
                tail = null;
            }

            P.Next = null;
            return P.Info;
        }

        // Getter Setter
        public EQueue Head
        {
            set { head = value; }
            get { return head; }
        }

        public EQueue Tail
        {
            set { tail = value; }
            get { return tail; }
        }

        public Node InfoHead
        {
            get { return head.Info; }
        }

        public Node InfoTail
        {
            get { return tail.Info; }
        }

    }
}