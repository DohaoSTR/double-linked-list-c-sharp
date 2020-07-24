using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace Double_Linked_List
{
    public class Program
    {

        private static readonly List<DoubleLinkedList<int>> ListDoubleLinkedLists;

        private static readonly OutMethod write = Console.Write;

        private static readonly InMethod readLine = Console.ReadLine;

        private static readonly Dictionary<int, MenuOperation> operations;

        static Program()
        {
            ListDoubleLinkedLists = new List<DoubleLinkedList<int>>();

            operations = new Dictionary<int, MenuOperation>
            {
                { 0, DoExit },
                { 1, CreateDoubleLinkedList },
                { 2, AddElementToList },
                { 3, DeleteElementFromList },
                { 4, FindElementInList },
                { 5, PrintCountOfList },
                { 6, PrintMinElementOfList },
                { 7, PrintMaxElementOfList },
                { 8, SortListByTheMergeSort },
                { 9, SortListByTheInsertionSort },
                { 10, PrintAllElementsOfList }
            };
        }

        private delegate void OutMethod(string message);

        private delegate string InMethod();

        private delegate void MenuOperation();

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
                  "\n6 - Вывести минимальное значение в списке." +
                  "\n7 - Вывести максимальное значение в списке." +
                  "\n8 - Отсортировать массив методом слияния." +
                  "\n9 - Отсортировать массив методом вставки." +
                  "\n10 - Вывести список по его номеру." +
                  "\nВведите цифру от 0 до 10 - ");
        }

        private static void SelectMenuItem(int operationNumber)
        {
            if (!operations.ContainsKey(operationNumber))
                throw new Exception("Данной операции не существует!");
            else
                operations[operationNumber]();
        }

        private static void DoExit() => Process.GetCurrentProcess().Kill();

        private static void CreateDoubleLinkedList()
        {
            ListDoubleLinkedLists.Add(new DoubleLinkedList<int>());

            write("\nИдентификатор списка - " + (ListDoubleLinkedLists.Count - 1));
        }

        private static int GetIdOfList()
        {
            write("\nВведите идентификатор списка - ");
            return PressedNumber;
        }

        private static void AddElementToList()
        {
            int index, value;
            int id = GetIdOfList();

            write("\nВведите индекс вставки элемента - ");
            index = PressedNumber;

            write("\nВведите значение элемента - ");
            value = PressedNumber;

            ListDoubleLinkedLists[id].Insert(index, value);
            write("\nЭлемент добавлен!");
        }

        private static void DeleteElementFromList()
        {
            int index;
            int id = GetIdOfList();

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
        }

        private static void FindElementInList()
        {
            int value;
            int id = GetIdOfList();

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
        }

        private static void PrintCountOfList()
        {
            int id = GetIdOfList();

            write("\nКоличество элементов в списке - " + ListDoubleLinkedLists[id].Count);
        }

        private static void PrintMinElementOfList()
        {
            int id = GetIdOfList();

            write("\nМинимальное значение списка" + ListDoubleLinkedLists[id].Min);
        }

        private static void PrintMaxElementOfList()
        {
            int id = GetIdOfList();

            write("\nМаксимальное значение списка" + ListDoubleLinkedLists[id].Max);
        }

        private static void SortListByTheMergeSort()
        {
            int id = GetIdOfList();

            ListDoubleLinkedLists[id].MergeSort();
        }

        private static void SortListByTheInsertionSort()
        {
            int id = GetIdOfList();

            ListDoubleLinkedLists[id].InsertionSort();
        }

        private static void PrintAllElementsOfList()
        {
            int id = GetIdOfList();

            write("\nЭлементы списка: ");

            foreach (int element in ListDoubleLinkedLists[id])
            {
                write(element + " ");
            }
        }
    }
}
