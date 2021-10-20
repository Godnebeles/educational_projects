using System;
using System.Collections;
using System.Collections.Generic;

namespace linked_list
{
    public class LinkedList<T> : IEnumerable
    {
        private ListNode head;
        private ListNode tail;
        private int size;

        private class ListNode
        {
            public T value = default(T);
            public ListNode nextNode;
            public ListNode(T value)
            {
                this.value = value;
            }
        }

        public T GetFirst()
        {
            return head.value;
        }

        public T GetLast()
        {
            return tail.value;
        }

        public int GetSize()
        {
            return size;
        }

        public void Add(T value)
        {
            ListNode newNode = new ListNode(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                ListNode currentNode = this.head;
                while (currentNode.nextNode != null)
                {
                    currentNode = currentNode.nextNode;
                }
                currentNode.nextNode = newNode;
            }

            //if (tail == null)
            //{ // empty list
            //    head = newNode;
            //}
            //else
            //{ // has at least one element
            //    tail.nextNode = newNode;
            //}

            tail = newNode;
            size++;
        }

        public void AddHead(T value)
        {
            ListNode newNode = new ListNode(value);
            newNode.nextNode = head;
            head = newNode;

            size++;
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                head = head.nextNode;
            }
            else
            {
                ListNode previousNode = FindNode(index - 1);
                ListNode toDelete  = previousNode.nextNode;

                previousNode.nextNode = toDelete.nextNode;
                toDelete = null;
            }
            size--;
        }

        public T this[int i]
        {
            get
            {
                return FindNode(i).value;
            }
            set
            {
                FindNode(i).value = value;
            }
        }


        private ListNode FindNode(int index)
        {
            if (index >= size || index < 0)
                throw new Exception("IndexOutOfRange");

            if(index == size-1)
                return tail;

            int counter = 0;
            ListNode currentNode = head;
            while (counter != index)
            {
                currentNode = currentNode.nextNode;
                counter++;
            }
            return currentNode;
            
        }


        public IEnumerator<T> GetEnumerator()
        {
            ListNode current = head;
            while (current != null)
            {
                yield return current.value;
                current = current.nextNode;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
