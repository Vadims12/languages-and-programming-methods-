using System;

namespace Figures
{
    public class Triangle : Figure
    {
        public Triangle()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите длину первой стороны треугольника (число)");
                    FirstSide = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введите длину второй стороны треугольника (число)");
                    SecondSide = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введите длину третьей стороны треугольника (число)");
                    ThirdSide = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                if (FirstSide <= 0 || SecondSide <= 0 || ThirdSide <= 0)
                {
                    Console.WriteLine("Попробуйте ещё раз, сторона треугольника не может быть меньше или равна нулю.");
                    continue;
                }

                GetInfo();
                break;
            }
        }

        public Triangle(int firstSide, int secondSide, int thirdSide, int id)
        {
            Random rand = new Random();
            while (true)
            {
                if (firstSide + secondSide > thirdSide && firstSide + thirdSide > secondSide && secondSide + thirdSide > firstSide)
                {
                    this.FirstSide = firstSide;
                    this.SecondSide = secondSide;
                    this.ThirdSide = thirdSide;
                    this.Id = id;
                    break;
                }
                else
                {
                    firstSide = rand.Next(1, 4);
                    secondSide = rand.Next(1, 4);
                    thirdSide = rand.Next(1, 4);
                    continue;
                }
            }
        }

        public double FirstSide { get; set; }
        public double SecondSide { get; set; }
        public double ThirdSide { get; set; }
        public override double GetPerimeter()
        {
            return FirstSide + SecondSide + ThirdSide;
        }

        public override double GetSquare()
        {
            double p = (FirstSide + SecondSide + ThirdSide) / 2;
            return Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide));
        }

        public override string GetInfo()
        {
            if 
                (FirstSide == SecondSide && FirstSide != ThirdSide && SecondSide != ThirdSide 
                 || FirstSide == ThirdSide && FirstSide != SecondSide && ThirdSide != SecondSide 
                 || SecondSide == ThirdSide && SecondSide != FirstSide && ThirdSide != FirstSide)
            {
                return "Равнобедренный треугольник";
            }
            else if (FirstSide == SecondSide && FirstSide == ThirdSide && SecondSide == ThirdSide)
            {
                return "Равносторонний треугольник";
            }
            else
            {
                return "Произвольный треугольник";
            }
        }
        public override bool Equals(Object obj)
        {
            Triangle o = (Triangle)obj;
            if (obj == null || !(obj is Ellipse))
                return false;
            else
                return FirstSide == FirstSide &&
                       SecondSide == o.SecondSide &&
                       GetPerimeter() == o.GetPerimeter() &&
                       GetSquare() == o.GetSquare();
        }

        public override int GetHashCode()
        {
            return (int)Math.Ceiling(FirstSide * SecondSide * GetPerimeter() * GetSquare());
        }
    }
}