using System;

namespace Figures
{
    public class Ellipse : Figure
    {
        public Ellipse()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите значение (число) первой полуоси эллипса");
                    FirstRadius = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введите значение (число) второй полуоси эллипса");
                    SecondRadius = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                if (FirstRadius <= 0 || SecondRadius <= 0)
                {
                    Console.WriteLine("Попробуйте ещё раз, радиусы эллипса не могут быть меньше либо равными нулю");
                    continue;
                }

                GetInfo();
                break;
            }
        }

        public Ellipse(double firstRadius, double secondRadius, int id)
        {
            this.FirstRadius = firstRadius;
            this.SecondRadius = secondRadius;
            this.Id = id;
        }
        public double FirstRadius { get; set; }
        public double SecondRadius { get; set; }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * Math.Sqrt((Math.Pow(FirstRadius, 2) + Math.Pow(SecondRadius, 2)) / 8);
        }

        public override double GetSquare()
        {
            return Math.PI * FirstRadius * SecondRadius;
        }

        public override string GetInfo()
        {
            if (FirstRadius == SecondRadius)
            {
                return "Круг";
            }
            else
            {
                return "Эллипс";
            }
        }
        public override bool Equals(Object obj)
        {
            Ellipse o = (Ellipse) obj;
            if (obj == null || !(obj is Ellipse))
                return false;
            else
                return FirstRadius == o.FirstRadius && SecondRadius == o.SecondRadius && GetSquare() == o.GetSquare() && GetPerimeter() == o.GetPerimeter();
        }

        public override int GetHashCode()
        {
            return (int)Math.Ceiling(FirstRadius * SecondRadius * GetPerimeter() * GetSquare());
        }
    }
}