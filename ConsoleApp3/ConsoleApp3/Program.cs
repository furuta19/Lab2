﻿using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int k, ke;

            Console.WriteLine("Введите размерность массива. *Размер будет увеличен в 4 раза*");

            k = int.Parse(Console.ReadLine());

            ke = k;

            k *= 4; //Увеличиваем размер k в 4 раза

            int[] a = new int[k]; //Инициализация нашего главного массива

            Console.WriteLine($"Размерность вашего массива - {k},\nВведите данные в массив.");


            for (int i = 0; i < k; i++) { a[i] = int.Parse(Console.ReadLine()); } //Вводим данные в массив 
                                                                                  //Создаем массивы для "свёртывания" нашего главного массива
            int[] a1 = new int[k / 2]; //и массив sum для хранения значений суммы наших свёрнутых массивов a1 и a2
            int[] a2 = new int[k / 2]; //
            int[] sum = new int[k / 2]; //
            int[] reva11 = new int[ke]; // Массив для первой половины а1
            int[] reva12 = new int[ke]; //Массив для второй половины а1
            int j = 0, j1 = 0;

            for (int i = 0; i < k; i++)
            {
                if ((i < ke) || (i >= (k - ke))) // Если какое то i меньше ke(ke=k/2; То есть если k=4, то ke=2.) ИЛИ если какое то i больше или равно k-ke
                {                                //Тут идёт "игра" с индексами, так как те числа которые нужно свернуть, их индексы фигурируют в радиусе (либо от 0 до ke либо от k-ke и до конца)
                    a1[j] = a[i];  //Если так, то эти значения которые нужно свернуть, мы запишем в отдельный массив
                    j++;
                }
                else //Ну и запишем ещё в отдельный массив те значения которые не были свёрнутыми
                {
                    a2[j1] = a[i];
                    j1++;
                }

            }
            int q = ke - 1;
            for (int i = 0; i < ke; i++)
            {
                reva11[q] = a1[i]; //Реверсивно записываем первую половину свёрнутых элементов в массив reva11
                q--;
            }

            for (int i = 0; i < ke; i++) { a1[i] = reva11[i]; } //Заполняем первую половину нашего свёрнутого массива, уже реверсными значения 

            int q1 = ke - 1;
            q = a1.Length / 2;
            for (int i = q; i < a1.Length; i++) //Реверсивно записываем вторую половину свёрнутых элементов в массив reva12
            {
                reva12[q1] = a1[i];
                q1--;
            }
            q1 = 0;
            for (int i = q; i < a1.Length; i++) { a1[i] = reva12[q1]; q1++; } //Заполняем вторую половину нашего свёрнутого массива, уже реверсными значения 

            int k1 = k / 2;
            for (int i = 0; i < k1; i++) { sum[i] = a1[i] + a2[i]; }

            for (int i = 0; i < a1.Length; i++) { Console.Write(a1[i] + "\t"); }

            Console.Write("+\n");

            for (int i = 0; i < a2.Length; i++) { Console.Write(a2[i] + "\t"); }

            Console.Write("=\n");

            for (int i = 0; i < k1; i++) { Console.Write(sum[i] + "\t"); }

            Console.WriteLine();

        }
    }
    }

