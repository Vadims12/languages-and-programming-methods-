using System;

namespace Figures
{
    public class Quadrangle : Figure
    {
        public Quadrangle()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите длину первой стороны четырехугольника (число)");
                    FirstSideCount = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введите длину второй стороны четырехугольника (число)");
                    SecondSideCount = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                if (FirstSideCount <= 0 || SecondSideCount <= 0)
                {
                    Console.WriteLine("Попробуйте ещё раз, сторона четырёхугольника не может быть меньше или равна нулю.");
                    continue;
                }

                GetInfo();
                break;
            }
        }

        public Quadrangle(int FirstSide, int SecondSide, int id)
        {
            this.FirstSideCount = FirstSide;
            this.SecondSideCount = SecondSide;
            this.Id = id;
        }
        public double FirstSideCount { get; set; }
        public double SecondSideCount { get; set; }
        public override double GetPerimeter()
        {
            return (FirstSideCount + SecondSideCount) * 2;
        }
        public override double GetSquare()
        {
            return FirstSideCount * SecondSideCount;
        }
        public override string GetInfo()
        {
            if (FirstSideCount == SecondSideCount)
            {
                return "Квадрат";
            }
            else
            {
               return "Прямоугольник";
            }
        }
        public override bool Equals(Object obj)
        {
            Quadrangle o = (Quadrangle)obj;
            if (obj == null || !(obj is Ellipse))
                return false;
            else
                return FirstSideCount == FirstSideCount && 
                       SecondSideCount == o.SecondSideCount && 
                       GetPerimeter() == o.GetPerimeter() &&
                       GetSquare() == o.GetSquare();
        }

        public override int GetHashCode()
        {
            return (int)Math.Ceiling(FirstSideCount * SecondSideCount * GetPerimeter() * GetSquare());
        }
    }
}