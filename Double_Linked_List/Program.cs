using System;

namespace Double_Linked_List
{
    class Program
    {
        static void Main()
        {
            DoubleLinkedList<int> testList1 = new DoubleLinkedList<int>();
            testList1.AddFirst(1);
            testList1.AddLast(30);
            testList1.AddFirst(400);
            testList1.AddFirst(100);
            testList1.AddFirst(20);
            testList1.Insert(3, 33);

            Console.Write("Элементы коллекции: ");
            foreach (var item in testList1)
            {
                Console.Write("{0} ", item);
            }
            testList1.InsertionSort();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Элементы коллекции после сортировки методом вставки: ");
            foreach (var item in testList1)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Поиск элемента 30 - {0}", testList1.Find(30));
            Console.WriteLine("Поиск элемента 130 - {0}", testList1.Find(130));
            Console.WriteLine("Максимальный элемент - {0}", testList1.Max);
            Console.WriteLine("Минимальный элемент - {0}", testList1.Min);
            Console.WriteLine("Удаление элемента 400 - {0}", testList1.Remove(4));
            Console.WriteLine("Редактирование элемента 400 - {0}", testList1.Replace(400, 100));
            Console.WriteLine("Редактирование элемента 100 - {0}", testList1.Replace(20, 133));
            Console.WriteLine("");
            Console.Write("Элементы коллекции после проведенных операций: ");
            foreach (var item in testList1)
            {
                Console.Write("{0} ", item);
            }
            testList1.MergeSort();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Элементы коллекции после сортировки методом слияния: ");
            foreach (var item in testList1)
            {
                Console.Write("{0} ", item);
            }

            DoubleLinkedList<string> testList2 = new DoubleLinkedList<string>();
            testList2.AddFirst("Миша");
            testList2.AddLast("Евгений");
            testList2.AddFirst("Иван");
            testList2.AddFirst("Никита");
            testList2.AddFirst("Александр");
            testList2.Insert(3, "Михаил");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Элементы коллекции: ");
            foreach (var item in testList2)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Поиск элемента Михаил - {0}", testList2.Find("Михаил"));
            Console.WriteLine("Поиск элемента Миша - {0}", testList2.Find("Миша"));
            Console.WriteLine("Удаление элемента Евгений - {0}", testList2.Remove(4));
            Console.WriteLine("Редактирование элемента Михаил - {0}", testList2.Replace(3, "Миша"));
            Console.WriteLine("");
            Console.Write("Элементы коллекции после проведенных операций: ");
            foreach (var item in testList2)
            {
                Console.Write("{0} ", item);
            }

            DoubleLinkedList<int> testList3 = new DoubleLinkedList<int>();
            testList3.Insert(0, 1);
            testList3.Insert(1, 2);
            testList3.Insert(2, 3);
            testList3.Insert(3, 4);
            testList3.Insert(4, 5);
            testList3.Insert(5, 6);
            testList3.Insert(6, 7);
            testList3.Insert(7, 7);
            testList3.Insert(8, 7);
            testList3.Insert(9, 7);
            testList3.Insert(10, 7);
            testList3.Insert(0, 1);
            testList3.Insert(1, 2);
            testList3.Insert(2, 3);
            testList3.Insert(3, 4);
            testList3.Insert(4, 5);
            testList3.Insert(5, 6);
            testList3.Insert(6, 7);
            testList3.Insert(7, 7);
            testList3.Insert(8, 7);
            testList3.Insert(9, 7);
            testList3.Insert(10, 7);

            testList3.Remove(6);
            testList3.InsertionSort();
            testList3.Insert(10, 299);
            testList3.Replace(10, 322);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Минимальный элемент - {0}", testList3.Min);
            Console.WriteLine("Максимальный элемент - {0}", testList3.Max);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Элементы коллекции: ");
            for (int i = 0; i < testList3.Count; i++)
                Console.Write("{0} ", testList3[i]);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Элементы коллекции: ");
            foreach (var el in testList3)
                Console.Write("{0} ", el);
            Console.WriteLine("");
            Console.WriteLine("Количество элементов: {0}", testList3.Count);
            Console.ReadKey();
        }
    }
}
