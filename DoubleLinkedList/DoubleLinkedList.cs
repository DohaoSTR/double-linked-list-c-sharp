﻿using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedList
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            DoubleNode<T> currentNode = First;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public DoubleNode<T> Last { get; private set; }

        public DoubleNode<T> First { get; private set; }

        public int Count { get; private set; }

        public T Min
        {
            get
            {
                DoubleNode<T> currentNode = First;
                dynamic min = currentNode.Value;

                while (currentNode != null)
                {
                    if (min > currentNode.Value)
                    {
                        min = currentNode.Value;
                    }

                    currentNode = currentNode.Next;
                }

                return min;
            }
        }

        public T Max
        {
            get
            {
                DoubleNode<T> currentNode = First;
                dynamic max = currentNode.Value;

                while (currentNode != null)
                {
                    if (max < currentNode.Value)
                    {
                        max = currentNode.Value;
                    }

                    currentNode = currentNode.Next;
                }
                return max;
            }
        }

        public T this[int index]
        {
            get
            {
                DoubleNode<T> currentNode = First;
                int i = 0;

                while (currentNode != null)
                {
                    if (index == i)
                    {
                        return currentNode.Value;
                    }   

                    currentNode = currentNode.Next;
                    i++;
                }
                return default;
            }
            set
            {
                DoubleNode<T> currentNode = First;
                int i = 0;

                while (currentNode != null)
                {
                    if (index == i)
                    {
                        currentNode.Value = value;
                    }

                    currentNode = currentNode.Next;
                    i++;
                }
            }
        }

        public void AddFirst(T value)
        {
            DoubleNode<T> temp = First;

            DoubleNode<T> node = new DoubleNode<T>(value)
            {
                Next = temp,
                Previous = null
            };

            First = node;

            if (Count == 0)
            {
                Last = First;
            }
            else
            {
                temp.Previous = node;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            DoubleNode<T> temp = Last;

            DoubleNode<T> node = new DoubleNode<T>(value)
            {
                Previous = temp,
                Next = null
            };

            Last = node;

            if (Count == 0)
            {
                First = Last;
            }
            else
            {
                temp.Next = node;
            }

            Count++;
        }

        public void Insert(int index, T value)
        {
            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index >= Count)
            {
                AddLast(value);
            }
            else
            {
                DoubleNode<T> temp = First;
                int i = 0;

                while (temp != null)
                {
                    if (index == i)
                    {
                        DoubleNode<T> node = new DoubleNode<T>(value)
                        {
                            Previous = temp.Previous,
                            Next = temp
                        };

                        temp.Previous.Next = node;
                        temp.Previous = node;
                        Count++;

                        break;
                    }

                    i++;
                    temp = temp.Next;
                }
            }
        }

        public bool Find(T value)
        {
            DoubleNode<T> current = First;

            for (int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool Replace(int index, T newValue)
        {
            DoubleNode<T> current = First;
            int i = 0;

            while (current != null)
            {
                if (index == i)
                {
                    current.Value = newValue;
                    return true;
                }

                i++;
                current = current.Next;
            }

            return false;
        }

        public bool Remove(int index)
        {
            DoubleNode<T> temp = First;

            if (index == 0)
            {
                temp.Next.Previous = temp.Next;
                First = First.Next;
                Count--;

                return true;
            }
            else if (index == (Count - 1))
            {
                temp.Previous = null;
                Last = Last.Previous;

                Count--;

                return true;
            }
            else
            {
                int i = 0;

                while (temp != null)
                {
                    if (i == index)
                    {
                        temp.Previous.Next = temp.Next;
                        temp.Next.Previous = temp.Previous;

                        Count--;

                        return true;
                    }

                    temp = temp.Next;
                    i++;
                }
            }

            return false;
        }

        public void InsertionSort()
        {
            DoubleNode<T> current = First;

            while (current != null)
            {
                dynamic key = current.Value;

                while (current.Previous != null && current.Previous.Value > key)
                {
                    var temp = current.Previous.Value;
                    current.Previous.Value = current.Value;
                    current.Value = temp;
                    current = current.Previous;
                }

                current = current.Next;
            }
        }

        public void MergeSort() => MergeSort(this, 0, Count - 1);

        private void Merge(DoubleLinkedList<T> current, int lowIndex, int middleIndex, int highIndex)
        {
            dynamic left = lowIndex;
            dynamic right = middleIndex + 1;
            dynamic tempArray = new int[highIndex - lowIndex + 1];

            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (current[left] < current[right])
                {
                    tempArray[index] = current[left];
                    left++;
                }
                else
                {
                    tempArray[index] = current[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = current[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = current[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                current[lowIndex + i] = tempArray[i];
            }
        }

        private void MergeSort(DoubleLinkedList<T> current, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;

                MergeSort(current, lowIndex, middleIndex);
                MergeSort(current, middleIndex + 1, highIndex);
                Merge(current, lowIndex, middleIndex, highIndex);
            }
        }      
    }
}
