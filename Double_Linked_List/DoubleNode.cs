using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_Linked_List
{
    class DoubleNode<T>
    {
        public DoubleNode(T value)
        {
            Value = value;
        }

        public DoubleNode<T> Next { get; set; }

        public DoubleNode<T> Previous { get; set; }

        public T Value { get; set; }
    }
}
