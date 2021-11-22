using System;
using System.Collections;

namespace Figures
{
    public abstract class Figure : IComparable<Figure>
    {
        public abstract double GetPerimeter();
        public abstract double GetSquare();
        public abstract string GetInfo();

        public int Id { get; set; }
        public int CompareTo(Figure obj)
        {
            return this.GetPerimeter().CompareTo(obj.GetPerimeter());
        }
    }
}