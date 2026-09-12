using System;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");
int a;
int b;
int c;
Console.Write("Nhap a: ");
a = Convert.ToInt32(Console.ReadLine());
while (true)
{
    Console.Write("Nhap b: ");
    try
    {
        b = int.Parse(Console.ReadLine());
        break;
    }
    catch (FormatException)
    {
        Console.WriteLine("So ba nhap khong hop le. Vui long nhap lai.");
    }
}

bool k;
while (true)
{
    Console.Write("Nhap c: ");
    k = int.TryParse(Console.ReadLine(), out c);
    if (k)
    {
        break;
    }
    else
    {
        Console.WriteLine("So ba nhap khong hop le. Vui long nhap lai.");
    }
}

Console.WriteLine($"{a} + {b} + {c} = {a + b + c}");
