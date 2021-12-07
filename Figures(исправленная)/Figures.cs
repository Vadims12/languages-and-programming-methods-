using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Figures
{
    public class Figures : IEnumerable
    {
        public List<Figure> list = new List<Figure>();
        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public void Add(Figure figure)
        {
            list.Add(figure);
        }
    }
}