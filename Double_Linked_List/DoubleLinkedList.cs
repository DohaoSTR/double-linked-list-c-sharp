using System.Collections;
using System.Collections.Generic;

namespace Double_Linked_List
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoubleNode<T> current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public DoubleNode<T> Last { get; set; }

        public DoubleNode<T> First { get; set; }

        public int Count { get; set; }

        public T Min
        {
            get
            {
                DoubleNode<T> current = First;
                dynamic min = current.Value;
                while (current != null)
                {
                    if (min > current.Value)
                        min = current.Value;
                    current = current.Next;
                }
                return min;
            }
        }

        public T Max
        {
            get
            {
                DoubleNode<T> current = First;
                dynamic max = current.Value;
                while (current != null)
                {
                    if (max < current.Value)
                        max = current.Value;
                    current = current.Next;
                }
                return max;
            }
        }

        public T this[int index]
        {
            get
            {
                DoubleNode<T> current = First;
                int i = 0;
                while (current != null)
                {
                    if (index == i)
                        return current.Value;
                    current = current.Next;
                    i++;
                }
                return default;
            }
            set
            {
                DoubleNode<T> current = First;
                int i = 0;
                while (current != null)
                {
                    if (index == i)
                        current.Value = value;
                    current = current.Next;
                    i++;
                }
            }
        }

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

        public void MergeSort()
        {
            MergeSort(this, 0, Count - 1);
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

        public void AddFirst(T value)
        {
            DoubleNode<T> node = new DoubleNode<T>(value);
            DoubleNode<T> temp = First;
            node.Next = temp;
            node.Previous = null;
            if (Count == 0)
            {
                First = node;
                Last = First;
            }
            else
            {
                First = node;
                temp.Previous = node;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            DoubleNode<T> node = new DoubleNode<T>(value);
            DoubleNode<T> temp = Last;
            node.Previous = temp;
            node.Next = null;
            Last = node;
            if (Count == 0)
            {
                Last = node;
                First = Last;
            }
            else
            {
                Last = node;
                temp.Next = node;
            }
            Count++;
        }

        public bool Find(T value)
        {
            DoubleNode<T> current = First;
            for (int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(value))
                    return true;
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
            else if (index == Count - 1)
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

        public void Insert(int index, T value)
        {
            DoubleNode<T> node = new DoubleNode<T>(value);
            if (index == 0)
                AddFirst(value);
            else if (index >= Count)
                AddLast(value);
            else
            {
                DoubleNode<T> temp = First;
                int i = 0;
                while (temp != null)
                {
                    if (index == i)
                    {
                        node.Previous = temp.Previous;
                        node.Next = temp;
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
    }
}
