using System;
using System.Diagnostics;

namespace SumOfTwoNumbers
{
    internal class Program
    {
        static void Main()
        {
            int[] sectors = { 24, 60, 42, 52, 10 };
            bool isOpen = true;

            while (isOpen)
            {
                Console.SetCursorPosition(0, 18);
                for (int i = 0; i < sectors.Length; i++)
                {
                    Console.WriteLine($"В секторе {i + 1} осталось {sectors[i]} мест.");
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Регистрация рейса.");
                Console.WriteLine("\n\n1 - забронировать места.\n\n2 - выход из программы.\n\n");
                Console.WriteLine("Введите номер команды: ");
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            int clientSector, clientPlaceAmount;
                            Console.WriteLine("В каком секторе Вы хотите лететь?");
                            clientSector = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (clientSector < 0 || clientSector > sectors.Length)
                            {
                                Console.WriteLine("Такого сектора не существует.");
                                break;
                            }
                            Console.WriteLine("Сколько мест Вы хотите забронировать?");
                            clientPlaceAmount = Convert.ToInt32(Console.ReadLine());
                            if (sectors[clientSector] < clientPlaceAmount || clientPlaceAmount < 0)
                            {
                                Console.WriteLine("Запрошено недопустимое кол-во мест.");
                                break;
                            }

                            sectors[clientSector] -= clientPlaceAmount;
                            Console.WriteLine("Бронирование прошло успешно!");
                            break;
                        case 2:
                            isOpen = false;
                            break;
                        default:
                            Console.WriteLine("Неверное значение. Попробуйте еще раз.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошло исключение: " + ex.Message);
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}