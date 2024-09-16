using System.Threading.Tasks.Dataflow;

namespace Demo1
{
    using System;

    class Program
    {
        static (double perimeter, double area) CalculateSquare(double side)
        {
            double perimeter = 4 * side;
            double area = side * side;
            return (perimeter, area);
        }

        static (double perimeter, double area) CalculateRectangle(double length, double width)
        {
            double perimeter = 2 * (length + width);
            double area = length * width;
            return (perimeter, area);
        }

        static (double perimeter, double area) CalculateTriangle(double sideA, double sideB, double sideC)
        {
            double perimeter = sideA + sideB + sideC;
            double semiPerimeter = perimeter / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
            return (perimeter, area);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=============================");
            Console.WriteLine("======= Assignment 1 ========");
            Console.WriteLine("=============================");
            Console.WriteLine("");
            Console.WriteLine("Choose what calculator below:");
            Console.WriteLine("1. Square");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Triangle");
            Console.WriteLine("4. Exit");
            while (true)
            {
                try
                {
                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter side: ");
                            double side = double.Parse(Console.ReadLine());
                            var (perimeter, area) = CalculateSquare(side);
                            Console.Write($"Square: Perimeter = {perimeter}, Area = {area}");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Enter length: ");
                            double length1 = double.Parse(Console.ReadLine());
                            Console.Write("Enter width: ");
                            double width1 = double.Parse(Console.ReadLine());
                            var (perimeter1, area1) = CalculateRectangle(length1, width1);
                            Console.Write($"Rectangle: Perimeter = {perimeter1}, Area = {area1}");
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Enter a: ");
                            double sideA1 = double.Parse(Console.ReadLine());
                            Console.Write("Enter b: ");
                            double sideB1 = double.Parse(Console.ReadLine());
                            Console.Write("Enter c: ");
                            double sideC1 = double.Parse(Console.ReadLine());
                            if(sideA1 + sideB1 <= sideC1 || sideA1 + sideC1 <= sideB1 || sideB1 + sideC1 <= sideA1)
                            {
                                throw new Exception("Invalid triangle");
                            }
                            var (perimeter2, area2) = CalculateTriangle(sideA1, sideB1, sideC1);
                            Console.Write($"Triangle: Perimeter = {perimeter2}, Area = {area2}");
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Exit");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Out of range");
                            break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

}
