﻿using System;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.WriteLine("Введите N");
            } while (!int.TryParse(Console.ReadLine(), out N));

            char[][] Array1 = new char[N][];

            FillArray(ref Array1);
            PrintArray(ref Array1);
        }

        /// <summary>
        /// Метод печатает элементы на экран.
        /// </summary>
        /// <param name="Array"></param>
        private static void PrintArray(ref char[][] Array1)
        {
            for (int k = 0; k < Array1.GetLength(0); k++, Console.WriteLine())
            {
                for (int j = 0; j < Array1[k].GetLength(0); j++)
                {
                    Console.Write(Array1[k][j] + "\t"); ;
                }
            }
        }

        /// <summary>
        /// Метод заполняет массив числами.
        /// </summary>
        /// <param name="Array"></param>
        private static void FillArray(ref char[][] Array1)
        {
            for (int i = 0; i < Array1.GetLength(0); i++)
            {
                Array1[i] = new char[i + 1];
            }

            for (int k = 0; k < Array1.GetLength(0); k++)
            {
                for (int j = 0; j < Array1[k].GetLength(0); j++)
                {
                    Array1[k][j] = '*';
                }
            }
        }
    }
}

