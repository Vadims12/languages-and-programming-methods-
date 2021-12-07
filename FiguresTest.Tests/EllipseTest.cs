using System;
using System.Diagnostics;
using Xunit;
using Figures_L.Figures_L;

namespace FiguresTest.Tests
{
    public class EllipseTest
    {
        [Fact]
        public void Generation_of_1000_Objects_And_Their_Hashcodes_Will_Take_Less_Than_One_Minute()
        {
            //Arrange

            var rand = new Random();
            Stopwatch sw = new Stopwatch();

            //Act

            sw.Start();

            for (int i = 0; i < 1000; i++)
            {
               Ellipse ellipse = new Ellipse();
                ellipse.GetHashCode();
            }

            sw.Stop();

            //Assert

            Assert.InRange(sw.ElapsedMilliseconds, 0, 60000);
        }

        [Fact]
        public void Generation_of_10000_Objects_And_Their_Hashcodes_Will_Take_Less_Than_One_Minute()
        {
            //Arrange

            var rand = new Random();
            Stopwatch sw = new Stopwatch();

            //Act

            sw.Start();

            for (int i = 0; i < 10000; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.GetHashCode();
            }

            sw.Stop();

            //Assert

            Assert.InRange(sw.ElapsedMilliseconds, 0, 60000);
        }

        [Fact]
        public void Generation_of_100000_Objects_And_Their_Hashcodes_Will_Take_Less_Than_One_Minute()
        {
            //Arrange

            var rand = new Random();
            Stopwatch sw = new Stopwatch();

            //Act

            sw.Start();

            for (int i = 0; i < 100000; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.GetHashCode();
            }

            sw.Stop();

            //Assert

            Assert.InRange(sw.ElapsedMilliseconds, 0, 60000);
        }

        [Fact]
        public void Generation_of_1000000_Objects_And_Their_Hashcodes_Will_Take_Less_Than_One_Minute()
        {
            //Arrange

            var rand = new Random();
            Stopwatch sw = new Stopwatch();

            //Act

            sw.Start();

            for (int i = 0; i < 1000000; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.GetHashCode();
            }

            sw.Stop();

            //Assert

            Assert.InRange(sw.ElapsedMilliseconds, 0, 60000);
        }
    }
}
