using System;

/*
Источник: https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/operator-overloading

Fraction - упрощенная структура, представляющая рациональное число.
Необходимо перегрузить операции:
+ (бинарный)
- (бинарный)
*
/ (в случае деления на 0, выбрасывать DivideByZeroException)

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки, содержацие числители и знаменатели двух дробей, разделенные /, соответственно.
1/3
1/6
Программа должна вывести на экран сумму, разность, произведение и частное двух дробей, соответственно,
с использованием перегруженных операторов (при необходимости, сокращать дроби):
1/2
1/6
1/18
2

Обратите внимание, если дробь имеет знаменатель 1, то он уничтожается (2/1 => 2). Если дробь в числителе имеет 0, то 
знаменатель также уничтожается (0/3 => 0).
Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

public readonly struct Fraction
{
    private readonly int numerator;
    private readonly int denomenator;

    public Fraction(int numerator, int denomenator)
    {
        this.numerator = numerator;
        this.denomenator = denomenator;
    }


    public static Fraction operator +(Fraction a, Fraction b)
    {
        int c = nok(a.denomenator, b.denomenator);

        Fraction res = new Fraction(a.numerator * (c / a.denomenator) + b.numerator * (c / b.denomenator), c);
        int soc = nod(res.numerator, res.denomenator);

        if (soc != 0)
            res = new Fraction(res.numerator / soc, res.denomenator / soc);

        if (res.denomenator == 0)
            throw new DivideByZeroException();

        if (res.denomenator < 0)
            res = new Fraction(-res.numerator, -res.denomenator);

        return res;
    }
    public static Fraction operator -(Fraction a, Fraction b)
    {
        int c = nok(a.denomenator, b.denomenator);

        Fraction res = new Fraction(a.numerator * (c / a.denomenator) - b.numerator * (c / b.denomenator), c);
        int soc = nod(res.numerator, res.denomenator);

        if (soc != 0)
            res = new Fraction(res.numerator / soc, res.denomenator / soc);

        if (res.denomenator == 0)
            throw new DivideByZeroException();

        if (res.denomenator < 0)
            res = new Fraction(-res.numerator, -res.denomenator);

        return res;
    }
    public static Fraction operator *(Fraction a, Fraction b)
    {
        Fraction res = new Fraction(a.numerator * b.numerator, a.denomenator * b.denomenator);
        int soc = nod(res.numerator, res.denomenator);

        if (soc != 0)
            res = new Fraction(res.numerator / soc, res.denomenator / soc);

        if (res.denomenator == 0)
            throw new DivideByZeroException();

        if (res.denomenator < 0)
            res = new Fraction(-res.numerator, -res.denomenator);

        return res;
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        Fraction res = new Fraction(a.numerator * b.denomenator, a.denomenator * b.numerator);
        int soc = nod(res.numerator, res.denomenator);

        if (soc != 0)
            res = new Fraction(res.numerator / soc, res.denomenator / soc);

        if (res.denomenator == 0)
            throw new DivideByZeroException();

        if (res.denomenator < 0)
            res = new Fraction(-res.numerator, -res.denomenator);

        return res;
    }

    static int nod(int a, int b)
    {
        if (b < 0)
            b = -b;
        if (a < 0)
            a = -a;
        while (b > 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    static int nok(int a, int b)
    {
        return Math.Abs(a * b) / nod(a, b);
    }

    public override string ToString()
    {
        if (denomenator == 1 || numerator == 0)
            return numerator.ToString();
        return numerator + "/" + denomenator;
    }
}

public static class OperatorOverloading
{
    public static void Main()
    {
        try
        {
            string[] parts = Console.ReadLine().Split('/');
            Fraction a = new Fraction(int.Parse(parts[0]), int.Parse(parts[1]));

            parts = Console.ReadLine().Split('/');
            Fraction b = new Fraction(int.Parse(parts[0]), int.Parse(parts[1]));

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("error");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("zero");
        }
    }
}
