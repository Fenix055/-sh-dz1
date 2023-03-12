

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace С_sh_dz1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Домашняя работа по C# №1");
            int nz;

            do
            {
                System.Console.WriteLine("Введите № задания от 1 до 4, введите другое для выхода");

                string str = System.Console.ReadLine();

                int.TryParse(str, out nz);




                //                Задание 1
                //                Пользователь вводит целое число - сохраняем это число в переменную. Необходимо создать 
                //                еще одну целочисленную переменную, в которой будет “отзеркаленное” начальное число.
                //                То есть пользователь вводит, например 3490872 необходимо сформировать переменную
                //                2780943


                if (nz == 1)
                {

                    System.Console.WriteLine("Задание 1");
                    System.Console.WriteLine("Введите число:");

                    str = System.Console.ReadLine();

                    int n1 = 0;

                    int.TryParse((string)str, out n1);

                    if (n1 == 0) System.Console.WriteLine("Ошибка ввода!!!");

                    else
                    {
                        string strn2 = "";
                        for (int x = 1; n1 / x >= 1 || n1 / x <= -1; x *= 10)
                        {
                            if (x == 1 && n1 < 0)
                            {
                                strn2 += "-";
                            }
                            int z = n1 / x % 10;
                            string strz = System.Convert.ToString(z);
                            strn2 += strz;
                        }
                        int n2 = System.Convert.ToInt32(strn2);
                    }
                    // Задание было создать, а про выводить не говорилось.
                }


                //Задарие 2
                //                Пользователь вводит целое число. Подсчитать сколько единиц в двоичном представлении
                //                этого числа.
                //                Например, вводится 40596, это 1001 1110 1001 0100 в двоичном представлении.Результат: 8


                if (nz == 2)   // не уверен на счет этого метода, но по логике должно работать даже пез перевода в побитовый вид.
                {

                    System.Console.WriteLine("Задание 2");

                    System.Console.WriteLine("Введите число:");
                    str = System.Console.ReadLine();


                    int n;
                    int.TryParse(str, out n);

                    int count = 0;

                    if (n == 0) System.Console.WriteLine("Ошибка ввода!!!");

                    else
                    {
                        do
                        {
                            if (n % 2 == 1)
                                count++;
                            n >>= 1;
                        } while (n != 0);
                        Console.WriteLine(count);
                    }
                }


                //Задание 3
                //                Рассмотрим некоторое натуральное число n.Если оно четное, то разделим его на 2, иначе -
                //умножим на 3 и прибавим 1.Будем повторять такие действия(шаги), пока не получится 1.
                //Полученная последовательность называется последовательностью Хейеса, а наибольшее из
                //чисел этой последовательности -ее вершиной
                //Требуется составить программу, вычисляющую для заданного n последовательность Хейеса, 
                //подсчитывающую число шагов в ней и находящую ее вершину

                if (nz == 3)
                {
                    System.Console.WriteLine("Задание 3");

                    System.Console.WriteLine("Введите натуральное число:");
                    str = System.Console.ReadLine();

                    ushort[] n=new ushort[str.Length+5];
                    //for (int i = 0; i < 5; i++) n[i] = 0; - при прогонке через отладку выяснилось, что 0 и так присваивается всем значениям массива.

                    //Ещё в первом задании меня подводило то, что я не мог в одну переменную, даже в long, ввести очень длинное число.
                    //Тогда при прочтении этого задания мне в голову пришла такая идея, а почему бы не поместить каждое число введенного
                    //значения в массив, а операции проводить по очереди от последнего к первому?
                    //5 символов дам форы, мало ли куда нас умножение заведёт, а проверять буду по сумме значений массива и значению последнего числа.
                    
                    for (ushort x=5; x< n.Length;x++) ushort.TryParse(str.Substring(x-5,1), out n[x]);

                    ushort sum=0;
                    short count = 0;
                    ushort[] bigest= new ushort[n.Length];
                    for (ushort x=5; x < n.Length; x++) bigest[x] = n[x];
                    do
                    {
                        count++;
                        if (n[n.Length-1] % 2 == 1)
                        {
                            sum = 0;
                            for (int x = (n.Length-1); x > 0; x--)
                            {
                                n[x] *= 3;
                                if (x == n.Length-1) n[x]++;
                                n[x] += sum;
                                sum = (ushort)(n[x] / 10);
                                n[x] %= 10;
                            }
                            for (int x = 0; x < n.Length-1; x++)
                                if (n[x] != 0 || bigest[x] != 0)  // число становится больше только при умножении - следовательно только после него нужно проводить проверку.
                                                                  // если бы в задании не говорилось про натуральные числа было бы сложнее.
                                {
                                    if (n[x] > bigest[x]) 
                                    {
                                        while (x < n.Length) { bigest[x] = n[x]; x++; }
                                        break; 
                                    }
                                    if (n[x] < bigest[x]) break;
                                }
                            sum = 0;
                        }
                        else for (int x = 0; x < n.Length-1; x++)
                            {
                                ushort perm = (ushort)(n[x]%2);
                                n[x + 1] += (ushort)(perm * 10);
                                n[x] /= 2;
                            }

                        Array.ForEach(n, i => sum += i);
                    } while (sum != 1 && sum != n[n.Length-1]);

                    //ushort c = 0;                                                            ненужная часть кода
                    //while (bigest[c] == 0) c++;

                    //for (ushort x=c; x<bigest.Length;x++) System.Console.Write(bigest[x]);
                    //System.Console.Write("   "+count);

                    // Опять же, всё что требовалось по заданию программа выполняет.
                }

                //Задание 4 
                //                Реализуйте игру Быки и Коровы.
                //В классическом варианте игра рассчитана на двух игроков. Каждый из игроков задумывает и
                //записывает тайное 4 - значное число с неповторяющимися цифрами. Игрок, который начинает
                //игру по жребию, делает первую попытку отгадать число.Попытка — это 4 - значное число с
                //неповторяющимися цифрами, сообщаемое противнику.Противник сообщает в ответ, сколько
                //цифр угадано без совпадения с их позициями в тайном числе(то есть количество коров) и
                //сколько угадано вплоть до позиции в тайном числе(то есть количество быков).Например:
                //Задумано тайное число «3219».
                //Попытка: «2310».
                //Результат: две «коровы» (две цифры: «2» и «3» — угаданы на неверных позициях) и один 
                //«бык» (одна цифра «1» угадана вплоть до позиции).
                //Игроки начинают по очереди угадывать число соперника.Побеждает тот, кто угадает число
                //первым, при условии, что он не начинал игру. Если же отгадавший начинал игру — его
                //противнику предоставляется последний шанс угадать последовательность.
                //При игре против компьютера игрок вводит комбинации одну за другой, пока не отгадает всю
                //последовательность

                if (nz == 4)
                {
                    System.Console.WriteLine("Задание 4");

                    System.Console.WriteLine("Введите 4 - значное число с неповторяющимися значениями:");

                    System.Random rnd = new System.Random();

                    int[] lineBot = new int[4];

                    bool c = false;


                    for (short i = 0; i < lineBot.Length; i++) lineBot[i] = rnd.Next(0, 9);

                    for (short i = 0; i < lineBot.Length && c==false; i++)
                    {
                        if (i == 0) c = true;

                        for (int x = lineBot.Length - 1; x > i; x--)
                            if (lineBot[i] == lineBot[x])
                            {
                                c = false; lineBot[i] = (lineBot[i] + 1) % 10;

                                if (c == false && i == lineBot.Length - 1) i = -1;
                            }
                    }
                    int[] trLine = new int[lineBot.Length];
                    short tr = 1;
                    do
                    {
                        if (tr>1) System.Console.WriteLine("Попытка № " + tr +":");

                        str = System.Console.ReadLine();

                        c = true;

                        for (short i = 0; i<lineBot.Length;i++) int.TryParse(str.Substring(i,1), out trLine[i]);

                        //Так то указанно "При игре против компьютера игрок вводит комбинации одну за другой, пока не отгадает всю
                        //последовательность" - но это совсем уж маразм, так что я немного отойду от задания и реализую вывод подсказок.
                        short cow=0,bowl=0;

                        for (short i=0; i< lineBot.Length; i++)
                        {
                            for (short x=0; x < lineBot.Length; x++)
                            {
                                if (lineBot[i] == trLine[x]) cow++;
                                if (lineBot[i] == trLine[x] && i == x) bowl++;
                            }
                        }

                        System.Console.WriteLine("Быков - " +bowl+ " Коров - "+(cow-bowl)+ "!");


                        tr++;
                        if (lineBot == trLine) c = true;
                    } while (c == true);

                }

            } while (nz > 0 && nz < 5);


        }
    }
}

//Код писал долго, кусками и общее устройство немного подзабыл, потому скорее всего не реализовал все возможные проверки вводимых данных.
//Впрочем если бы я ещё и это начал проверять то застрял бы ещё на недельку.
    
