using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable 693

namespace DoublyLinkedListLibrary
{
    public class DoublyLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        public int Count { private set; get; }

        public DoublyLinkedList(Node<T> node )
        {
            _head = node;
            _tail = _head;
            Count++;
        }

        public Node<T> this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("index");
                }
                var result = _head;
                for (int i = 1; i < index; i++)
                {
                    if (result.NextNode == null)
                    {
                        throw new IndexOutOfRangeException("index");
                    }
                    result = result.NextNode;
                }
                return result;
            }
            set
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("index");
                }
                var result = _head;
                for (int i = 1; i < index; i++)
                {
                    if (result.NextNode == null)
                    {
                        throw new IndexOutOfRangeException("index");
                    }
                    result = result.NextNode;
                }
                result.Data = value.Data;
            }
           
        }

        public void Add(Node<T> node, int index)
        {
            var temp = this[index];
            this[index] = node;
            this[index].NextNode = temp;
            Count++;
        }

        public void Remove(int index)
        {
            this[index - 1].NextNode = this[index].NextNode;
            Count--;
        }
    }

    public class Node<T>
    {
        public T Data { set; get; }
        public Node<T> PrevNode { set; get; }
        public Node<T> NextNode { set; get; }

        public Node(T data)
        {
            Data = data;
        }
        public Node(T data, Node<T> nodeNext)
        {
            Data = data;
            NextNode = nodeNext;
        }
    }
}
