using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_program
{
    public class Employee
    {
        private List<string> _firstNames = new List<string> { "Владимир", "Петр", "Олег", "Константин", "Александр" };
        private List<string> _lastNames = new List<string> { "Гордиенко", "Гончар", "Филиппов", "Узун", "Григорьев" };
        private List<string> _parentNames = new List<string> { "Сегеевич", "Викторович", "Алексеевич", "Васильевич", "Александрович" };
        private List<string> _departments = new List<string> { "devops", "backend", "gamedev" };
        private Random _rnd = new Random();

        public readonly string LastName;
        public readonly string FirstName;
        public readonly string ParentName;
        public readonly string Department;

        public int Id { get; }
        public int Phone { get; }

        public Employee(int id, int phone)
        {
            Id = id;
            Phone = phone;

            LastName = _lastNames[_rnd.Next(0, _lastNames.Count)];
            FirstName = _firstNames[_rnd.Next(0, _firstNames.Count)];
            ParentName = _parentNames[_rnd.Next(0, _parentNames.Count)];
            Department = _departments[_rnd.Next(0, _departments.Count)];
        }

        public void Info()
        {
            Console.WriteLine($"{Id.ToString("D4"),-8}{LastName,-16}{FirstName,-14}{ParentName,-18}{Department,-14}{Phone,-7}");
        }
    }
}
