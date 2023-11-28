using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public DNode head;
        public int Length => GetLenght();
        private int GetLenght() 
        {
            SetLastElement();
            int lenght = 0;
            DNode temp = head;
            while (temp != null)
            {
                lenght++;
                temp = temp.prev;
            }

            return lenght;
        }
        public void Add(T e)
        {
            DNode newNode = new DNode(e);
            newNode.next = head;
            newNode.prev = null;
            if (head != null)
                head.prev = newNode;
            head = newNode;
        }

        public void AddAt(int index, T e)
        {
            SetLastElement();

            DNode temp = head;
            for (int i = 0; i < index; i++)
			{
                temp = temp.prev;
			}
            DNode newNode = new DNode(e);
            newNode.prev = temp;
            newNode.next = null;

            if (temp == null && index == Length)
            {
                SetFisrtElement();
                temp = head;
                newNode.next = temp;
                temp.prev = newNode;
                head = newNode;
                return;
            }
            if (index != 0 && temp != null)
            {
                newNode.next = temp.next;
                temp.next = newNode;
                newNode.next.prev = newNode;
            }
            if (index == 0)
                temp.next = newNode;
            head = newNode;
        }

        public T ElementAt(int index)
        {
            if (head == null)
                throw new IndexOutOfRangeException();
            if (index < 0)
                throw new IndexOutOfRangeException();
            if (index > Length-1)
                throw new IndexOutOfRangeException();
            SetLastElement();
            DNode temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.prev;
            }
            return (T)(object)temp.data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int len = GetLenght();
            SetLastElement();
            var temp = head;
            for (int i = 0; i < len; i++)
			{
                yield return (T)temp.data;
                temp = temp.prev;
            }
		}

        public void Remove(T item)
        {
            SetLastElement();
            DNode temp = head;
            bool found = false;
            while (!found) 
            {
                if (item.Equals(temp.data)) 
                {
                    if (temp.next != null) 
                    {
                        temp.next.prev = temp.prev;
                        head = temp.next;
                    }
                    if (temp.prev != null) 
                    {
                        temp.prev.next = temp.next;
                        head = temp.prev;
                    }

                    found = true;
                }
                else
                    temp = temp.prev;
				if (temp == null)
                    found = true;
            }
            SetFisrtElement();

        }

        public T RemoveAt(int index)
        {
			if (head==null)
                throw new IndexOutOfRangeException();
            if (index < 0)
                throw new IndexOutOfRangeException();
			if (index > Length-1)
                throw new IndexOutOfRangeException();

            SetLastElement();
            DNode temp = head;

            for (int i = 0; i < index; i++)
			{
                temp = temp.prev;
            }

            if (temp.next != null)
            {
                temp.next.prev = temp.prev;
                head = temp.next;
            }
            if (temp.prev != null)
            {
                temp.prev.next = temp.next;
                head = temp.prev;
            }

            return (T)(object)temp.data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void SetFisrtElement() 
        {
            DNode temp = head;
            while (temp.prev != null)
            {
                temp = temp.prev;
            }
            head = temp;
        }
        private void SetLastElement()
        {
            DNode temp = head;
			if (temp != null)
			{
                while (temp.next != null)
                {
                    temp = temp.next;
                }
            }
            
            head = temp;
        }
    }
    
}
