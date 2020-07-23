using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Double_Linked_List
{
    public class Program
    {
        private static List<DoubleLinkedList<int>> ListDoubleLinkedLists;

        private static readonly OutMethod write = Console.Write;

        private static readonly InMethod readLine = Console.ReadLine;

        private delegate void OutMethod(string message);

        private delegate string InMethod();

        private static int PressedNumber => Convert.ToInt32(readLine());

        public static void Main()
        {
            while (true)
            {
                PrintMenuItems();
                SelectMenuItem(PressedNumber);
            }
        }

        private static void PrintMenuItems()
        {
            write("\n0 - Выход из программы." +
                  "\n1 - Создать двусвязный линейный список." +
                  "\n2 - Добавить элемент в список." +
                  "\n3 - Удалить элемент из списка." +
                  "\n4 - Определить содержится ли значение в списке." +
                  "\n5 - Вывести количество элементов в списке." +
                  "\n6 - Вывести минимальное и максимальное значение в списке." +
                  "\n7 - Отсортировать массив методом слияния." +
                  "\n8 - Отсортировать массив методом вставки." +
                  "\n9 - Вывести список по его номеру." +
                  "\nВведите цифру от 0 до 9 - ");
        }

        private static void SelectMenuItem(int pressedNumber)
        {
            int id, index, value;

            switch (pressedNumber)
            {
                case 0:
                    Process.GetCurrentProcess().Kill();
                    break;
                case 1:
                    ListDoubleLinkedLists = new List<DoubleLinkedList<int>>();
                    CreateDoubleLinkedList();

                    write("\nИдентификатор списка - " + (ListDoubleLinkedLists.Count - 1));
                    break;
                case 2:
                    write("\nВведите идентификатор списка - ");
                    id = PressedNumber;

                    write("\nВведите индекс вставки элемента - ");
                    index = PressedNumber;

                    write("\nВведите значение элемента - ");
                    value = PressedNumber;

                    ListDoubleLinkedLists[id].Insert(index, value);
                    write("\nЭлемент добавлен!");
                    break;
                case 3:
                    write("\nВведите идентификатор списка - ");
                    id = PressedNumber;

                    write("\nВведите индекс удаляемого элемента - ");
                    index = PressedNumber;
                    bool remove = ListDoubleLinkedLists[id].Remove(index);

                    if (remove)
                    {
                        write("\nЭлемент удален!");
                    }
                    else
                    {
                        write("\nЭлемент не удален!");
                    }
                    break;
                case 4:
                    write("\nВведите идентификатор списка - ");
                    id = PressedNumber;

                    write("\nВведите значение искомого элемента - ");
                    value = PressedNumber;

                    bool find = ListDoubleLinkedLists[id].Find(value);

                    if (find)
                    {
                        write("\nЭлемент найден!");
                    }
                    else
                    {
                        write("\nЭлемент не найден!");
                    }
                    break;
                case 5:
                    write("\nВведите идентификатор списка - ");
                    id = PressedNumber;

                    write("\nКоличество элементов в списке - " + ListDoubleLinkedLists[id].Count);
                    break;
                case 6:
                    write("\nВведите идентификатор списка - ");
                    id = PressedNumber;

                    write("\nМинимальное значение списка" + ListDoubleLinkedLists[id].Min);
                    write("\nМаксимальное значение списка" + ListDoubleLinkedLists[id].Max);
                    break;
                case 7:
                    write("\nВведите идентификатор списка - ");
                    id = PressedNumber;

                    ListDoubleLinkedLists[id].MergeSort();
                    break;
                case 8:
                    write("\nВведите идентификатор списка - ");
                    id = PressedNumber;

                    ListDoubleLinkedLists[id].InsertionSort();
                    break;
                case 9:
                    write("\nВведите идентификатор списка - ");
                    id = PressedNumber;

                    write("\nЭлементы списка: ");

                    foreach (int element in ListDoubleLinkedLists[id])
                    {
                        write(element + " ");
                    }
                    break;
            }
        }

        private static void CreateDoubleLinkedList() => ListDoubleLinkedLists.Add(new DoubleLinkedList<int>());
    }
}
