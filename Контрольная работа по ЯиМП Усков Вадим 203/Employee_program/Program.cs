using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee_program
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                employees.Add(new Employee(i, rnd.Next(10000, 100000)));
            }
            
            Console.WriteLine($"{0,-8}{1,-16}{2,-14}{3,-18}{4,-14}{5,-7}");
            Console.WriteLine($"{"Id",-8}{"Фамилия",-16}{"Имя",-14}{"Отчество",-18}{"Отдел",-14}{"Номер телефона",-7}\n");
            foreach (Employee employee in employees)
            {
                employee.Info();
            }

            Console.Write("\n\nВведите номер столбца для сортировки: ");
            string num = Console.ReadLine();
            List<Employee> emplList = new List<Employee>();

            switch (num)
            {
                case "0": // Сортировка по id
                    emplList = employees.OrderBy(x => x.Id).ToList();
                    break;
                case "1": // Сортировка по фамилии
                    emplList = employees.OrderBy(x => x.LastName).ToList();
                    break;
                case "2": // Сортировка по имени
                    emplList = employees.OrderBy(x => x.FirstName).ToList();
                    break;
                case "3": // Сортировка по отчеству
                    emplList = employees.OrderBy(x => x.ParentName).ToList();
                    break;
                case "4": // Сортировка по отделу
                    emplList = employees.OrderBy(x => x.Department).ToList();
                    break;
                case "5": // Сортировка по номеру телефона
                    emplList = employees.OrderBy(x => x.Phone).ToList();
                    break;
                default:
                    Console.WriteLine("Ошибка ввода данных! Введенного номера столбца не существует.");
                    break;
            }

            foreach (Employee employee in emplList)
            {
                employee.Info();
            }

            Console.Write("\n\nВведите фамилию для поиска информации: ");
            string lastName = Console.ReadLine();
            List<Employee> employeeInfo = employees.Where(x => x.LastName.Equals(lastName)).ToList();

            if (employeeInfo.Count == 0)
            {
                Console.WriteLine("Ошибка ввода данных! Введенной фамилии нет в списке.");
            }
            else
            {
                foreach (Employee employee in employeeInfo)
                {
                    employee.Info();
                }
            }

            Console.Write("\n\nГруппировка по отделам: ");
            var emplGroupByDep = employees.GroupBy(x => x.Department).ToList();
            Console.WriteLine("\n");
            foreach (IGrouping<string, Employee> group in emplGroupByDep)
            {
                Console.WriteLine($"{group.Key}: {group.ToList().Count}");
                foreach (Employee employee in group)
                {
                    employee.Info();
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
