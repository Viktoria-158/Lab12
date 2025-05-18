using System;
using PlantsLibrary;

namespace PlantsLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<Plant> plantList = new DoublyLinkedList<Plant>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nМеню работы с двунаправленным списком растений");
                Console.WriteLine("1. Сформировать список случайных растений");
                Console.WriteLine("2. Распечатать список");
                Console.WriteLine("3. Удалить растения с заданным названием");
                Console.WriteLine("4. Добавить K случайных растений в начало");
                Console.WriteLine("5. Выполнить глубокое клонирование списка");
                Console.WriteLine("6. Удалить список из памяти");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Введите количество растений: ");
                            if (!int.TryParse(Console.ReadLine(), out int count) || count < 0)
                            {
                                Console.WriteLine("Некорректное количество.");
                                break;
                            }

                            plantList = new DoublyLinkedList<Plant>(count);
                            Console.WriteLine($"Создан список из {count} растений");
                            break;

                        case 2:
                            Console.WriteLine("Текущий список растений:");
                            plantList.PrintList();
                            break;

                        case 3:
                            if (plantList.IsEmpty)
                            {
                                Console.WriteLine("Список пуст.");
                                break;
                            }

                            Console.Write("Введите название растения для удаления: ");
                            string nameToRemove = Console.ReadLine();

                            int removedCount = 0;
                            bool found = false;
                            do
                            {
                                found = plantList.RemoveElement(new Plant { Name = nameToRemove });
                                if (found) removedCount++;
                            } while (found);

                            Console.WriteLine($"Удалено {removedCount} растений с навзванием '{nameToRemove}'.");
                            break;

                        case 4:
                            Console.Write("Введите количество растений для добавления: ");
                            if (!int.TryParse(Console.ReadLine(), out int k) || k < 0)
                            {
                                Console.WriteLine("Некорректное количество элементов для добавления");
                                break;
                            }

                            for (int i = 0; i < k; i++)
                            {
                                Plant newPlant = new Plant();
                                newPlant.RandomInit();
                                plantList.AddToBegin(newPlant);
                            }

                            Console.WriteLine($"Добавлено {k} случайных растений в начало списка");
                            break;

                        case 5:
                            if (plantList.IsEmpty)
                            {
                                Console.WriteLine("Список пуст, клонировать нечего");
                                break;
                            }

                            var clonedList = (DoublyLinkedList<Plant>)plantList.Clone();
                            Console.WriteLine("Клонированный список:");
                            clonedList.PrintList();
                            break;

                        case 6:
                            plantList.Clear();
                            Console.WriteLine("Список удален из памяти");
                            break;

                        case 0:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Некорректный выбор, попробуйте снова");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}