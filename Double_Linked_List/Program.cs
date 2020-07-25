using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Double_Linked_List
{
    public class Program
    {
        private static readonly List<DoubleLinkedList<int>> ListDoubleLinkedLists;

        private static readonly OutMethod write = Console.Write;

        private static readonly InMethod readLine = Console.ReadLine;

        private static readonly Dictionary<int, Operation> operations;

        static Program()
        {
            ListDoubleLinkedLists = new List<DoubleLinkedList<int>>();

            operations = new Dictionary<int, Operation>
            {
                { 0, new Operation("Выход из программы.", DoExit) },
                { 1, new Operation("Создать двусвязный линейный список.", CreateDoubleLinkedList) },
                { 2, new Operation("Добавить элемент в список.", AddElementToList) },
                { 3, new Operation("Удалить элемент из списка.", DeleteElementFromList) },
                { 4, new Operation("Определить содержится ли значение в списке.", FindElementInList) },
                { 5, new Operation("Вывести количество элементов в списке.", PrintCountOfList) },
                { 6, new Operation("Вывести минимальное значение в списке.", PrintMinElementOfList) },
                { 7, new Operation("Вывести максимальное значение в списке.", PrintMaxElementOfList) },
                { 8, new Operation("Отсортировать массив методом слияния.", SortListByTheMergeSort) },
                { 9, new Operation("Отсортировать массив методом вставки.", SortListByTheInsertionSort) },
                { 10, new Operation("Вывести список по его номеру.", PrintAllElementsOfList) }
            };
        }

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
            foreach(var el in operations)
            {
                write("\n" + el.Key + " - " + el.Value.Name);
            }

            write("\nВведите номер операции - ");
        }

        private static void SelectMenuItem(int operationNumber)
        {
            if (!operations.ContainsKey(operationNumber))
                throw new Exception("Данной операции не существует!");
            else
                operations[operationNumber].GetOperationDelegate();
        }

        private static void DoExit() => Process.GetCurrentProcess().Kill();

        private static void CreateDoubleLinkedList()
        {
            ListDoubleLinkedLists.Add(new DoubleLinkedList<int>());
            write("\nИдентификатор списка - " + (ListDoubleLinkedLists.Count - 1));
        }

        private static int GetIdOfList
        {
            get
            {
                write("\nВведите идентификатор списка - ");
                return PressedNumber;
            }
        }

        private static void AddElementToList()
        {
            write("\nВведите индекс вставки элемента - ");
            int index = PressedNumber;

            write("\nВведите значение элемента - ");
            int value = PressedNumber;

            ListDoubleLinkedLists[GetIdOfList].Insert(index, value);
            write("\nЭлемент добавлен!");
        }

        private static void DeleteElementFromList()
        {
            write("\nВведите индекс удаляемого элемента - ");
            int index = PressedNumber;
            bool remove = ListDoubleLinkedLists[GetIdOfList].Remove(index);

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
            write("\nВведите значение искомого элемента - ");
            int value = PressedNumber;

            bool find = ListDoubleLinkedLists[GetIdOfList].Find(value);

            if (find)
            {
                write("\nЭлемент найден!"); 
            }
            else
            {
                write("\nЭлемент не найден!");
            }
        }

        private static void PrintCountOfList() => write("\nКоличество элементов в списке - " + ListDoubleLinkedLists[GetIdOfList].Count);

        private static void PrintMinElementOfList() => write("\nМинимальное значение списка" + ListDoubleLinkedLists[GetIdOfList].Min);

        private static void PrintMaxElementOfList() => write("\nМаксимальное значение списка" + ListDoubleLinkedLists[GetIdOfList].Max);

        private static void SortListByTheMergeSort() => ListDoubleLinkedLists[GetIdOfList].MergeSort();

        private static void SortListByTheInsertionSort() => ListDoubleLinkedLists[GetIdOfList].InsertionSort();

        private static void PrintAllElementsOfList()
        {
            write("\nЭлементы списка: ");

            foreach (int element in ListDoubleLinkedLists[GetIdOfList])
            {
                write(element + " ");
            }
        }
    }
}
