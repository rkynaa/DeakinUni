using System;
using System.Text;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        // Here is the the nested Node<K> class 
        private class Node<K> : INode<K>
        {
            public K Value { get; set; }
            public Node<K> Next { get; set; }
            public Node<K> Previous { get; set; }

            public Node(K value, Node<K> previous, Node<K> next)
            {
                Value = value;
                Previous = previous;
                Next = next;
            }

            // This is a ToString() method for the Node<K>
            // It represents a node as a tuple {'the previous node's value'-(the node's value)-'the next node's value')}. 
            // 'XXX' is used when the current node matches the First or the Last of the DoublyLinkedList<T>
            public override string ToString()
            {
                StringBuilder s = new StringBuilder();
                s.Append("{");
                s.Append(Previous.Previous == null ? "XXX" : Previous.Value.ToString());
                s.Append("-(");
                s.Append(Value);
                s.Append(")-");
                s.Append(Next.Next == null ? "XXX" : Next.Value.ToString());
                s.Append("}");
                return s.ToString();
            }

        }

        // Here is where the description of the methods and attributes of the DoublyLinkedList<T> class starts

        // An important aspect of the DoublyLinkedList<T> is the use of two auxiliary nodes: the Head and the Tail. 
        // The both are introduced in order to significantly simplify the implementation of the class and make insertion functionality reduced just to a AddBetween(...)
        // These properties are private, thus are invisible to a user of the data structure, but are always maintained in it, even when the DoublyLinkedList<T> is formally empty. 
        // Remember about this crucial fact when you design and code other functions of the DoublyLinkedList<T> in this task.
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }
        public int Count { get; private set; } = 0;

        public DoublyLinkedList()
        {
            Head = new Node<T>(default(T), null, null);
            Tail = new Node<T>(default(T), Head, null);
            Head.Next = Tail;
        }

        public INode<T> First
        {
            get
            {
                if (Count == 0) return null;
                else return Head.Next;
            }
        }

        public INode<T> Last
        {
            get
            {
                if (Count == 0) return null;
                else return Tail.Previous;
            }
        }

        public INode<T> After(INode<T> node)
        {
            if (node == null) throw new NullReferenceException();
            Node<T> node_current = node as Node<T>;
            if (node_current.Previous == null || node_current.Next == null) throw new InvalidOperationException("The node referred as 'before' is no longer in the list");
            if (node_current.Next.Equals(Tail)) return null;
            else return node_current.Next;
        }

        public INode<T> AddLast(T value)
        {
            return AddBetween(value, Tail.Previous, Tail);
        }

        // This is a private method that creates a new node and inserts it in between the two given nodes referred as the previous and the next.
        // Use it when you wish to insert a new value (node) into the DoublyLinkedList<T>
        private Node<T> AddBetween(T value, Node<T> previous, Node<T> next)
        {
            Node<T> node = new Node<T>(value, previous, next);
            previous.Next = node;
            next.Previous = node;
            Count++;
            return node;
        }

        public INode<T> Find(T value)
        {
            Node<T> node = Head.Next;
            while (!node.Equals(Tail))
            {
                if (node.Value.Equals(value)) return node;
                node = node.Next;
            }
            return null;
        }

        public override string ToString()
        {
            if (Count == 0) return "[]";
            StringBuilder s = new StringBuilder();
            s.Append("[");
            int k = 0;
            Node<T> node = Head.Next;
            while (!node.Equals(Tail))
            {
                s.Append(node.ToString());
                node = node.Next;
                if (k < Count - 1) s.Append(",");
                k++;
            }
            s.Append("]");
            return s.ToString();
        }

        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.
        public INode<T> Before(INode<T> node)
        {
            // throws NullReferenceException() if the parameter is null
            if (node == null)
            {
                 throw new ArgumentNullException();
            }

            Node<T> new_node = node as Node<T>;

            // throws InvalidPoerationException() if the parameter is not part of the list
            if (new_node.Previous == null || new_node.Next == null)
            {
                 throw new InvalidOperationException("ERROR: The parameter is not in the list");
            }

            if (new_node.Next.Equals(Head))
            {
                return null;
            }
            else
            {
                return new_node.Previous;
            }
        }

        public INode<T> AddFirst(T value)
        {
            return AddBetween(value, Head, Head.Next);
        }

        public INode<T> AddBefore(INode<T> before, T value)
        {
            // throws ArgumentNullException() if the parameter node is null
            if(before == null)
            {
                throw new ArgumentNullException();
            } 

            Node<T> curr = before as Node<T>;

            // throws InvalidOperationException() if the parameter node is not part of the list
            if(curr.Previous == null || curr.Next == null) 
            {
                throw new InvalidOperationException("ERROR: The parameter is not in the list");
            } 

            return AddBetween(value, curr.Previous, curr); 
            
        }

        public INode<T> AddAfter(INode<T> after, T value) 
        {
            // throws ArgumentNullException() if the parameter node is null
            if(after == null)
            {
                throw new ArgumentNullException(); 
            }

            Node<T> curr = after as Node<T>;

            // throws InvalidOperationException() if the parameter is not part of the list
            if(curr.Previous == null || curr.Next == null)
            {
                throw new InvalidOperationException("ERROR: The parameter is not in the list");
            }

            return AddBetween(value, curr, curr.Next); 
        }

        public void Clear()
        {
            Node<T> curr1, curr2;
            curr1 = Head.Next;
            while (curr1 != Tail)
            {
                curr2 = curr1.Next;
                Remove(curr1);
                curr1 = curr2;
            }
            Count = 0;
        }

        public void Remove(INode<T> node)
        {
            // throws ArgumentNullException() if the parameter node is null
            if (node == null)
            {
                throw new ArgumentNullException(); 
            }

            Node<T> curr = node as Node<T>; 

            // throws InvalidOperationException() if the parameter is not part of the list
            if (curr.Previous == null || curr.Next == null)
            {
                throw new InvalidOperationException("ERROR: The parameter is not in the list");
            }

            curr.Previous.Next = curr.Next; 
            curr.Next.Previous = curr.Previous;
            curr.Next = null;
            curr.Previous = null; 
            Count--; 
        }

        public void RemoveFirst()
        {
            // throws InvalidOperationException() if the list is empty
            if(Count == 0)
            {
                throw new InvalidOperationException("ERROR: The list is empty");
            } 
            if(Head == null || Tail == null)
            {
                throw new InvalidOperationException("ERROR: The list is empty"); 
            }

            Remove(Head.Next); 
        }

        public void RemoveLast()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("ERROR: The list is empty"); 
            }
            if(Head == null || Tail == null)
            {
                throw new InvalidOperationException("ERROR: The list is empty");
            } 

            Remove(Tail.Previous); 
        }
    }
}
