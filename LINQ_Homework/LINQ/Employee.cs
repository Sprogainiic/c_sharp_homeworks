using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Employee
    {
        public Employee(string name, string surname, int age, int course, string facultyName)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Course = course;
            FacultyName = facultyName;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Course { get; set; }
        public string FacultyName { get; set; }

    }
}
