using System;

/*
Источник: https://metanit.com/

Как известно, неотъемлемыми компонентами бутерброда являются хлеб и масло.
Допустим, у нас есть классы Bread, Butter, Sandwich.
Добавьте в один из классов оператор сложения, чтобы при объединении хлеба (Bread) и масла (Butter)
получался бутерброд (Sandwich), и, тем самым, компилировался и выполнялся без ошибок код в методе Main.
Обработайте ситуации, когда вес отрицательный (в этом случае должен быть выброшен ArgumentException).

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход может поступить строка (веса компонентов бутерброда, разделенные через пробел):
10 10
Программа должна вывести на экран:
20
Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task01
{
    class Bread
    {
        public int Weight { get; set; }
        public static Sandwich operator +(Bread bread, Butter butter)
        {
            if (bread.Weight < 0 || butter.Weight < 0)
                throw new ArgumentException();
            return new Sandwich(bread.Weight + butter.Weight);
        }
    }
    class Butter
    {
        public int Weight { get; set; }
    }
    class Sandwich
    {
        public int Weight { get; set; }
        public Sandwich(int weight)
        {
            Weight = weight;
        }
    }

    class MainClass
    {
        public static void Main()
        {
            string[] strs = Console.ReadLine().Split();
            Sandwich sandwich = new Sandwich(0);
            try
            {
                Bread bread = new Bread { Weight = int.Parse(strs[0]) };
                Butter butter = new Butter { Weight = int.Parse(strs[1]) };
                sandwich = bread + butter;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            Console.WriteLine(sandwich.Weight);
        }
    }
}