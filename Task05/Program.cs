﻿using System;
using System.Globalization;

/*
Источник: https://metanit.com/

Класс Dollar представляет сумму в долларах, а Euro - сумму в евро.

Определите операторы преобразования от типа Dollar в Euro и наоборот.
Допустим, 1 евро стоит 1,14 долларов. При этом один оператор должен подразумевать явное,
и один - неявное преобразование. Обработайте ситуации с отрицательными аргументами
(в этом случае должен быть выброшен ArgumentException).

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки - количество долларов и количество евро.
10
100
Программа должна вывести на экран количество евро и долларов, соответственно,
с использованием перегруженных операторов (округлять до 2 знаков после запятой):
8,77
114,00

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task05
{
    class Dollar
    {
        public decimal Sum { get; set; }

        public static implicit operator Dollar(Euro euro)
        {
            if (euro.Sum < 0)
                throw new ArgumentException();
            return new Dollar { Sum = euro.Sum * 1.14m };
        }

        public override string ToString()
        {
            return $"{Sum:f2}";
        }
    }
    class Euro
    {
        public decimal Sum { get; set; }

        public static explicit operator Euro(Dollar dollar)
        {
            if (dollar.Sum < 0)
                throw new ArgumentException();
            return new Euro { Sum = dollar.Sum / 1.14m };
        }

        public override string ToString()
        {
            return $"{Sum:f2}";
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
                Dollar dollar = new Dollar() { Sum = int.Parse(Console.ReadLine()) };
                Euro euro = new Euro() { Sum = int.Parse(Console.ReadLine()) };

                Console.WriteLine((Euro)dollar);
                Dollar newDollar = euro;
                Console.WriteLine(newDollar);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
        }
    }
}
