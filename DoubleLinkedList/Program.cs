using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DoubleLinkedList
{
    public class Program
    {
        private static readonly List<DoubleLinkedList<int>> _listDoubleLinkedLists;

        private static readonly OutMethod _write = Console.Write;

        private static readonly InMethod _readLine = Console.ReadLine;

        private static readonly Dictionary<int, Operation> _operations;

        static Program()
        {
            _listDoubleLinkedLists = new List<DoubleLinkedList<int>>();

            _operations = new Dictionary<int, Operation>
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

        private static int PressedNumber => Convert.ToInt32(_readLine());

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
            foreach(var el in _operations)
            {
                _write("\n" + el.Key + " - " + el.Value.Name);
            }

            _write("\nВведите номер операции - ");
        }

        private static void SelectMenuItem(int operationNumber)
        {
            if (!_operations.ContainsKey(operationNumber))
                throw new Exception("Данной операции не существует!");
            else
                _operations[operationNumber].GetOperationDelegate();
        }

        private static void DoExit() => Process.GetCurrentProcess().Kill();

        private static void CreateDoubleLinkedList()
        {
            _listDoubleLinkedLists.Add(new DoubleLinkedList<int>());
            _write("\nИдентификатор списка - " + (_listDoubleLinkedLists.Count - 1));
        }

        private static int GetIdOfList
        {
            get
            {
                _write("\nВведите идентификатор списка - ");
                return PressedNumber;
            }
        }

        private static void AddElementToList()
        {
            _write("\nВведите индекс вставки элемента - ");
            int index = PressedNumber;

            _write("\nВведите значение элемента - ");
            int value = PressedNumber;

            _listDoubleLinkedLists[GetIdOfList].Insert(index, value);
            _write("\nЭлемент добавлен!");
        }

        private static void DeleteElementFromList()
        {
            _write("\nВведите индекс удаляемого элемента - ");
            int index = PressedNumber;
            bool remove = _listDoubleLinkedLists[GetIdOfList].Remove(index);

            if (remove)
            {
                _write("\nЭлемент удален!");
            }
            else
            {
                _write("\nЭлемент не удален!");
            }
        }

        private static void FindElementInList()
        {
            _write("\nВведите значение искомого элемента - ");
            int value = PressedNumber;

            bool find = _listDoubleLinkedLists[GetIdOfList].Find(value);

            if (find)
            {
                _write("\nЭлемент найден!"); 
            }
            else
            {
                _write("\nЭлемент не найден!");
            }
        }

        private static void PrintCountOfList() => _write("\nКоличество элементов в списке - " + _listDoubleLinkedLists[GetIdOfList].Count);

        private static void PrintMinElementOfList() => _write("\nМинимальное значение списка" + _listDoubleLinkedLists[GetIdOfList].Min);

        private static void PrintMaxElementOfList() => _write("\nМаксимальное значение списка" + _listDoubleLinkedLists[GetIdOfList].Max);

        private static void SortListByTheMergeSort() => _listDoubleLinkedLists[GetIdOfList].MergeSort();

        private static void SortListByTheInsertionSort() => _listDoubleLinkedLists[GetIdOfList].InsertionSort();

        private static void PrintAllElementsOfList()
        {
            int id = GetIdOfList;
            _write("\nЭлементы списка: ");

            foreach (int element in _listDoubleLinkedLists[id])
            {
                _write(element + " ");
            }
        }
    }
}