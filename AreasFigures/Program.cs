using System;
using System.Collections.Specialized;
class Figur
{
    double area;
    double perimetr;

    public void function(int a, int b)
    {
        int[] ints = new int[0];
        int bufer;
        if (a == 1 || a == 3)
        {
            if (b == 1)
            {
                ints = new int[3];
            }
            else if (b < 7)
            {
                ints = new int[4];
            }
            else if (b == 7)
            {
                ints = new int[1];
            }
            else if (b == 8)
            {
                ints = new int[2];
            }
        }
        else if (a == 2)
        {
            if (b == 1 || b == 6)
            {
                ints = new int[3];
            }
            else if (b == 2 || b == 7)
            {
                ints = new int[1];
            }
            else if (b == 3 || b == 4 || b == 5 || b == 8) 
            {
                ints = new int[2];
            }
        }

        for (int i = 0; i < ints.Length; i++)
        {
            ints[i] = 0;
           
            if (a == 1 && b < 7)
            {
                if ((b == 6 || b == 3 || b == 5) && i == 0)
                {
                    Console.WriteLine("Введіть висоту:   ");
                }
                else
                {
                    Console.WriteLine("Введіть " + (i + 1) + " сторону:   ");
                }
                while (ints[i] <= 0) ints[i] = Convert.ToInt32(Console.ReadLine());
            }
            else  if (a == 2 && b < 7)
            {
                Console.WriteLine("Введіть " + (i + 1) + " сторону:   ");
                while (ints[i] <= 0) ints[i] = Convert.ToInt32(Console.ReadLine());
            }
            else if (b == 7)
            {
                Console.WriteLine("Введіть радіус:   ");
                while (ints[i] <= 0) ints[i] = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                if (i == 0)
                {
                    Console.WriteLine("Введіть старший радіус:   ");
                    while (ints[i] <= 0) ints[i] = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Введіть молодший радіус:   ");
                    while (ints[i] <= 0) ints[i] = Convert.ToInt32(Console.ReadLine());
                    if (ints[i] > ints[i-1])
                    {
                        Console.WriteLine("Ви певно помилились, тому ми поміняли місцями радіуси...");
                        bufer = ints[i];
                        ints[i] = ints[i - 1];
                        ints[i - 1] = bufer;
                    }
                }
                
            }
        }
        if (a == 1)
        {
            fperimetr(b, ints);
        }
        else if (a == 2)
        {
            farea(b, ints);
        }
        else if (a == 3)
        {
            fperimetr(b, ints);
            a = 2;
            function(a,b);
        }

    }
  
    public double fperimetr(int b, int[] ints)
    {
        if (b < 7)
        {
            for(int i = 0; i < ints.Length; i++)
            {
                perimetr += ints[i];
            }
        }
        else if(b == 7)
        {
            perimetr = 2 * 3.14 * ints[0];
        }
        else
        {
            perimetr = 4 * (3.14 * ints[0] * ints[1] + (ints[0] - ints[1])) / (ints[0] + ints[1]);
        }
        return perimetr;
    }

    public double farea(int b, int[] ints)
    {
        int bufer;
        if (b == 1) //формула герона
        {
            bufer = (ints[0] + ints[1] + ints[2]) / 2;
            area = bufer * (bufer - ints[0]) * (bufer - ints[1]) * (bufer - ints[2]);
            area = Math.Sqrt(area);
        }
        else if(b == 2) // a * a 
        {
            area = ints[0] * ints[0];
        }
        else if(b == 3 || b == 4 || b == 5)// роmб, паралелограм -> S = a * h; прямокутник -> S = a * b;
        {
            area = ints[0] * ints[1];
        }
        else if(b == 6) // S = a * b * h;
        {
            area = ints[0] * ints[1] * ints[2];
        }
        else if (b == 7) // S = 2 * П * R
        {
            area = 2 * ints[0] * 3.14;
        }
        else if (b == 8) // S = П * r * R
        {
            area = 3.14 * ints[0] * ints[1];
        }
        return area;
    }
}

class Program
{

    public static void Main()
    {
        int a; int b;
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;

        Figur figur = new Figur();

        
        a = 0; b = 0;

        Console.WriteLine("\t\tПлощі Фігур");
        Console.WriteLine();
        Console.WriteLine("Знайти площу\t - 1");
        Console.WriteLine("Знайти периметр\t - 2");
        Console.WriteLine("Знайти обидві\t - 3");
        while (a < 1 || a > 3) a = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        Console.WriteLine("Виберіть фігуру");
        Console.WriteLine();
        Console.WriteLine("Трикутник\t - 1");
        Console.WriteLine("Квадрат\t - 2");
        Console.WriteLine("Ромб\t - 3");
        Console.WriteLine("Прямокутник\t - 4");
        Console.WriteLine("Паралелограм\t - 5");
        Console.WriteLine("Трапеція\t - 6");
        Console.WriteLine("Коло\t - 7");
        Console.WriteLine("Еліпс\t - 8");
        while (b < 1 || b > 8) b = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        figur.function(a, b);
    }
}
