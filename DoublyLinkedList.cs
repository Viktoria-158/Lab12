using System;
using System.Collections;
using System.Collections.Generic;
using PlantsLibrary;

namespace PlantsLibrary
{
    public class DoublyLinkedList<T> : IEnumerable<T>, ICloneable where T : IInit, ICloneable, new()
    {
        public Point<T>? Begin { get; private set; }
        public Point<T>? End { get; private set; }

        public int Count
        {
            get
            {
                int count = 0;
                Point<T>? current = Begin;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }

        public bool IsEmpty => Begin == null;

        public DoublyLinkedList()
        {
            Begin = null;
            End = null;
        }

        public DoublyLinkedList(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size), "Размер не может быть отрицательным");

            for (int i = 0; i < size; i++)
            {
                T item = new T();
                item.RandomInit();
                AddToEnd(item);
            }
        }

        public DoublyLinkedList(DoublyLinkedList<T> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (other.Begin == null) return;

            Begin = new Point<T>((T)other.Begin.Data.Clone());
            Point<T>? currentOther = other.Begin.Next;
            Point<T>? currentThis = Begin;

            while (currentOther != null)
            {
                Point<T> newPoint = new Point<T>((T)currentOther.Data.Clone());
                currentThis.Next = newPoint;
                newPoint.Prev = currentThis;
                currentThis = newPoint;
                currentOther = currentOther.Next;
            }
            End = currentThis;
        }

        public void AddToBegin(T data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            Point<T> newPoint = new Point<T>(data);
            if (IsEmpty)
            {
                Begin = newPoint;
                End = newPoint;
            }
            else
            {
                newPoint.Next = Begin;
                Begin.Prev = newPoint;
                Begin = newPoint;
            }
        }

        public void AddToEnd(T data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            Point<T> newPoint = new Point<T>(data);
            if (IsEmpty)
            {
                Begin = newPoint;
                End = newPoint;
            }
            else
            {
                End.Next = newPoint;
                newPoint.Prev = End;
                End = newPoint;
            }
        }

        public bool AddAfterElement(T data, T afterData)
        {
            if (data == null || afterData == null)
                return false;

            if (IsEmpty) return false;

            Point<T>? current = Begin;
            while (current != null && !current.Data.Equals(afterData))
            {
                current = current.Next;
            }

            if (current == null) return false;

            Point<T> newPoint = new Point<T>(data);
            newPoint.Next = current.Next;
            newPoint.Prev = current;

            if (current.Next != null)
                current.Next.Prev = newPoint;
            else
                End = newPoint;

            current.Next = newPoint;
            return true;
        }

        public bool RemoveElement(T data)
        {
            if (data == null || IsEmpty)
                return false;

            if (Begin.Data.Equals(data))
            {
                Begin = Begin.Next;
                if (Begin != null)
                    Begin.Prev = null;
                else
                    End = null;
                return true;
            }

            Point<T>? current = Begin.Next;
            while (current != null && !current.Data.Equals(data))
            {
                current = current.Next;
            }

            if (current == null) return false;

            if (current.Next != null)
                current.Next.Prev = current.Prev;
            else
                End = current.Prev;

            current.Prev.Next = current.Next;
            return true;
        }

        public void Clear()
        {
            Begin = null;
            End = null;
        }

        public bool Contains(T data)
        {
            if (data == null || IsEmpty)
                return false;

            Point<T>? current = Begin;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void PrintList()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Point<T>? current = Begin;
            int i = 1;
            while (current != null)
            {
                Console.WriteLine($"{i}. {current.Data}");
                current = current.Next;
                i++;
            }
        }

        public object Clone()
        {
            return new DoublyLinkedList<T>(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Point<T>? current = Begin;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}