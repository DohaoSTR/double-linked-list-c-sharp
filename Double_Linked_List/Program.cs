using System;
using System.Collections.Generic;

namespace Double_Linked_List
{
    public class Program
    {
        private static List<object> ListDoubleLinkedLists;

        private delegate void OutMethod(string message);

        private delegate string InMethod();

        private static readonly OutMethod write = Console.Write;

        private static readonly InMethod readLine = Console.ReadLine;

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
            write("0 - Выход из программы." +
                  "\n1 - Создать двусвязный линейный список." +
                  "\n2 - Добавить элемент в список." +
                  "\n3 - Удалить элемент из списка." +
                  "\n4 - Найти элемент в списке." +
                  "\n5 - Определить содержится ли значение в списке." +
                  "\n5 - Скопировать значения из одного списка в другой." +
                  "\n6 - Вывести количество элементов в списке." +
                  "\n7 - Вывести список по его номеру." +
                  "\n8 - Вывести все созданные списки." +
                  "\nВведите цифру от 0 до 8 - ");
        }

        private static void SelectMenuItem(int pressedNumber)
        {
            switch (pressedNumber)
            {
                case 0:
                    return;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    return;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
            }
        }

        private static void PrintMenuCreateDoubleLinkedList()
        {
            
        }

        private static void CreateDoubleLinkedList<T>() => ListDoubleLinkedLists.Add(new DoubleLinkedList<T>());

        private static int PressedNumber => Convert.ToInt32(readLine());
    }
}
