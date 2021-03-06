using System;
using System.Diagnostics;
using Xunit;

namespace Figures.Tests
{
    public class QuadrangleTest
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
                Quadrangle quadrangle = new Quadrangle(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 1000000));
                quadrangle.GetHashCode();
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
                Quadrangle quadrangle = new Quadrangle(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 1000000));
                quadrangle.GetHashCode();
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
                Quadrangle quadrangle = new Quadrangle(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 1000000));
                quadrangle.GetHashCode();
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
                Quadrangle quadrangle = new Quadrangle(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 1000000));
                quadrangle.GetHashCode();
            }

            sw.Stop();

            //Assert

            Assert.InRange(sw.ElapsedMilliseconds, 0, 60000);
        }
    }
}
