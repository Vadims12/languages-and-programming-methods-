using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Figures
{
    class Program
    {
        static void Main()
        {
            var rand = new Random();
            var figures = new Figures();
            string figuresType = "";
            int figureNumber = 1;

            Console.WriteLine("Введите число, обозначающее тип фигуры: Треугольник ( 1 ), Эллипс ( 2 ), Четырёхугольник ( 3 )");
            int res = Convert.ToInt32(Console.ReadLine());

            switch (res)
            {
                case 1:
                    for (int i = 0; i < 10; i++)
                    {
                        figures.Add(new Triangle(rand.Next(1, 4), rand.Next(1, 4), rand.Next(1, 4), figureNumber));
                        figureNumber++;
                    }
                    figuresType = "Figures.Triangle";
                    break;

                case 2:
                    for (int i = 0; i < 10; i++)
                    {
                        figures.Add(new Ellipse(rand.Next(1, 4), rand.Next(1, 4), figureNumber));
                        figureNumber++;
                    }
                    figuresType = "Figures.Ellipse";
                    break;

                case 3:
                    for (int i = 0; i < 10; i++)
                    {
                        figures.Add(new Quadrangle(rand.Next(1, 4), rand.Next(1, 4), figureNumber));
                        figureNumber++;
                    }

                    figuresType = "Figures.Quadrangle";
                    break;

                default:
                    Console.WriteLine("Введите одно из предложенных значений");
                    break;
            }

            Console.WriteLine("Вывод foreach");
            switch (figuresType)
            {
                case "Figures.Triangle":
                    foreach (Triangle figure in figures)
                    {
                        Console.WriteLine(
                            $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstSide} |" +
                            $" {figure.SecondSide} | {figure.ThirdSide} | p = {Math.Round(figure.GetPerimeter(), 4),-4} | s = {Math.Round(figure.GetSquare(), 4)}", -4);
                    }
                    break;
                case "Figures.Quadrangle":
                    foreach (Quadrangle figure in figures)
                    {
                        Console.WriteLine(
                            $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstSideCount} |" +
                            $" {figure.SecondSideCount} | p = {Math.Round(figure.GetPerimeter(), 4),-4} | s = {Math.Round(figure.GetSquare(), 4)}", -4);
                    }
                    break;
                case "Figures.Ellipse":
                    foreach (Ellipse figure in figures)
                    {
                        Console.WriteLine(
                            $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstRadius} |" +
                            $" {figure.SecondRadius} | p = {Math.Round(figure.GetPerimeter(), 4),-4} | s = {Math.Round(figure.GetSquare(), 4),-4}");
                    }
                    break;
            }

            Console.WriteLine("\nВывод while");
            int counter = 0;
            switch (figuresType)
            {
                case "Figures.Triangle":

                    while (counter < figures.list.Count)
                    {
                        Triangle obj = (Triangle)figures.list[counter];
                        Console.WriteLine(
                            $"{obj.Id,-6} | {obj.GetInfo(),-32} | {obj.FirstSide} |" +
                            $" {obj.SecondSide} | {obj.ThirdSide} | p = {Math.Round(obj.GetPerimeter(), 4),-4} | s = {Math.Round(obj.GetSquare(), 4)}", -4);
                        counter++;
                    }
                    break;

                case "Figures.Quadrangle":
                    while (counter < figures.list.Count)
                    {
                        Quadrangle obj = (Quadrangle)figures.list[counter];
                        Console.WriteLine(
                            $"{obj.Id,-6} | {obj.GetInfo(),-32} | {obj.FirstSideCount} |" +
                            $" {obj.SecondSideCount} | p = {Math.Round(obj.GetPerimeter(), 4),-4} | s = {Math.Round(obj.GetSquare(), 4)}", -4);
                        counter++;
                    }
                    break;

                case "Figures.Ellipse":
                    while (counter < figures.list.Count)
                    {
                        Ellipse obj = (Ellipse)figures.list[counter];
                        Console.WriteLine(
                            $"{obj.Id,-6} | {obj.GetInfo(),-32} | {obj.FirstRadius} |" +
                            $" {obj.SecondRadius} | p = {Math.Round(obj.GetPerimeter(), 4),-4} | s = {Math.Round(obj.GetSquare(), 4)}", -4);
                        counter++;
                    }
                    break;
            }

            figures.list.Sort();

            Console.WriteLine("\nСортированный список фигур:");
            switch (figuresType)
            {
                case "Figures.Triangle":
                    foreach (Triangle figure in figures)
                    {
                        Console.WriteLine(
                            $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstSide} |" +
                            $" {figure.SecondSide} | {figure.ThirdSide} | p = {Math.Round(figure.GetPerimeter(), 4),-4} | s = {Math.Round(figure.GetSquare(), 4)}", -4);
                    }
                    break;
                case "Figures.Quadrangle":
                    foreach (Quadrangle figure in figures)
                    {
                        Console.WriteLine(
                            $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstSideCount} |" +
                            $" {figure.SecondSideCount} | p = {Math.Round(figure.GetPerimeter(), 4),-4} | s = {Math.Round(figure.GetSquare(), 4)}", -4);
                    }
                    break;
                case "Figures.Ellipse":
                    foreach (Ellipse figure in figures)
                    {
                        Console.WriteLine(
                            $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstRadius} |" +
                            $" {figure.SecondRadius} | p = {Math.Round(figure.GetPerimeter(), 4),-4} | s = {Math.Round(figure.GetSquare(), 4),-4}");
                    }
                    break;
            }

            Console.WriteLine($"\nLINQ запросы:");
            switch (figuresType)
            {
                case "Figures.Triangle":
                    Console.WriteLine("\nСодержит слово 'Равнобедренный':");

                    var filteredTriangleList =
                        figures.list.Where(triangle => triangle.GetInfo().Contains("Равнобедренный"));

                    foreach (Triangle figure in filteredTriangleList)
                    {
                        Console.WriteLine(
                                $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstSide} |" +
                                $" {figure.SecondSide} | {figure.ThirdSide} | p = {Math.Round(figure.GetPerimeter(), 4),-4} |" +
                                $" s = {Math.Round(figure.GetSquare(), 4)}", -4);
                    }

                    Console.WriteLine($"\nЗатем сортировка по ID:");
                    var orderedTriangleList = filteredTriangleList.OrderBy(item => item.Id);

                    foreach (Triangle figure in orderedTriangleList)
                    {
                        Console.WriteLine(
                            $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstSide} |" +
                            $" {figure.SecondSide} | {figure.ThirdSide} | p = {Math.Round(figure.GetPerimeter(), 4),-4} |" +
                            $" s = {Math.Round(figure.GetSquare(), 4)}", -4);
                    }
                    break;

                case "Figures.Quadrangle":
                    Console.WriteLine("\nНачинается с П:");

                    var filteredQuadrangleList = 
                        figures.list.Where(quadrangle => quadrangle.GetInfo().StartsWith("П"));

                    foreach (Quadrangle figure in filteredQuadrangleList)
                    {
                        Console.WriteLine(
                                $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstSideCount} |" +
                                $" {figure.SecondSideCount} | p = {Math.Round(figure.GetPerimeter(), 4),-4} " +
                                $"| s = {Math.Round(figure.GetSquare(), 4)}", -4);
                    }

                    Console.WriteLine($"\nЗатем сортировка по ID:");

                    var orderedQuadrangleList = 
                        filteredQuadrangleList.OrderBy(item => item.Id);

                    foreach (Quadrangle figure in orderedQuadrangleList)
                    {
                        Console.WriteLine(
                                $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstSideCount} |" +
                                $" {figure.SecondSideCount} | p = {Math.Round(figure.GetPerimeter(), 4),-4} " +
                                $"| s = {Math.Round(figure.GetSquare(), 4)}", -4);
                    }
                    break;

                case "Figures.Ellipse":
                    Console.WriteLine("\nЗаканчивается на С");

                    var filteredEllipseList = 
                        figures.list.Where(ellipse => ellipse.GetInfo().EndsWith("с"));

                    foreach (Ellipse figure in filteredEllipseList)
                    {
                        Console.WriteLine(
                                $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstRadius} |" +
                                $" {figure.SecondRadius} | p = {Math.Round(figure.GetPerimeter(), 4),-4} " +
                                $"| s = {Math.Round(figure.GetSquare(), 4),-4}");
                    }

                    Console.WriteLine($"\nЗатем сортировка по ID:");
                    var orderedEllipseList = filteredEllipseList.OrderBy(item => item.Id);

                    foreach (Ellipse figure in orderedEllipseList)
                    {
                        Console.WriteLine(
                                $"{figure.Id,-6} | {figure.GetInfo(),-32} | {figure.FirstRadius} |" +
                                $" {figure.SecondRadius} | p = {Math.Round(figure.GetPerimeter(), 4),-4} " +
                                $"| s = {Math.Round(figure.GetSquare(), 4),-4}");
                    }
                    break;
            }



        }
    }
}
