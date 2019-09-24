using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LINQ
{
    public partial class frmEmployeeGrid : Form
    {
        public frmEmployeeGrid()
        {
            InitializeComponent();
            var employeeList = GetEmployeeList();
            SetDataIntoGrid(employeeList);
        }

        private void SetDataIntoGrid(List<Employee> employeeList)
        {
            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = GenerateTable(employeeList);
            AutoSizeGridColumn();
        }

        private DataTable GenerateTable(List<Employee> employeeList)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Surname", typeof(string));
            dataTable.Columns.Add("Age", typeof(int));
            dataTable.Columns.Add("Course", typeof(int));
            dataTable.Columns.Add("FacultyName", typeof(string));


            foreach (var employee in employeeList)
            {
                dataTable.Rows.Add(
                    employee.Name,
                    employee.Surname,
                    employee.Age,
                    employee.Course,
                    employee.FacultyName
                );
            }

            return dataTable;
        }

        private List<Employee> GetEmployeeList()
        {
            return new List<Employee>
            {
                new Employee("Tom", "Svensson", 22, 1, "Faculty of Power and Electrical Engineering"),
                new Employee("Bill", "Francis", 19, 1, "Faculty of Architecture"),
                new Employee("John", "Robertson", 20, 2, "Faculty of Electronics and Telecommunications"),
                new Employee("Steven", "Simpson", 23, 4, "Faculty of Computer Science and Information Technology"),
                new Employee("Jack", "Koch", 18, 1, "Faculty of Architecture"),
                new Employee("Kate", "Morgan", 20, 2, "Faculty of Materials Science and Applied Chemistry"),
                new Employee("Maria", "Whitney", 21, 1, "Faculty of Computer Science and Information Technology"),
                new Employee("Christina", "Hardy", 24, 4, "Faculty of Architecture"),
                new Employee("Stefan", "Chambers", 22, 3, "Faculty of Electronics and Telecommunications"),
                new Employee("Bill", "Burton", 20, 2, "Faculty of Power and Electrical Engineering"),
                new Employee("Eduard", "Gross", 19, 1, "Faculty of Architecture"),
                new Employee("Jason", "Bennett", 18, 1, "Faculty of Computer Science and Information Technology"),
                new Employee("Nill", "Campbell", 20, 2, "Faculty of Power and Electrical Engineering"),
                new Employee("Chuck", "Fletcher", 23, 2, "Faculty of Architecture"),
                new Employee("Lucy", "Keith", 25, 5, "Faculty of Electronics and Telecommunications"),
            };
        }

        private void AutoSizeGridColumn()
        {
            for (int i = 0; i < dgvEmployees.Columns.Count; i++)
            {
                dgvEmployees.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnOrderByName_Click(object sender, EventArgs e)
        {
            var employeeList = GetEmployeeList();
            SetDataIntoGrid(employeeList.OrderBy(x => x.Name).ToList());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var employeeList = GetEmployeeList();
            SetDataIntoGrid(employeeList.Where(x => x.Name.ToUpper().Contains("c".ToUpper()) && x.Name.ToUpper().Contains("j".ToUpper())).ToList());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var employeeList = GetEmployeeList();
            SetDataIntoGrid(employeeList
                .Where(x => x.Name.ToUpper().Contains("i".ToUpper()) || x.Name.ToUpper().Contains("e".ToUpper()))
                .OrderByDescending(x => x.Surname)
                .ThenByDescending(x => x.Name)
                .ToList());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var employeeList = GetEmployeeList();
            SetDataIntoGrid(employeeList
                .Where(x => x.Age >= 20 && x.Age <= 23)
                .ToList());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //var employeeList = GetEmployeeList();
            //var sortedEmpList = new List<Employee>();

            //foreach (var employee in employeeList)
            //{
            //    char[] nameCharArray = employee.Name.ToUpper().ToCharArray();
            //    char[] surnameCharArray = employee.Surname.ToUpper().ToCharArray();
            //    char[] facultyNameCharArray = employee.FacultyName.ToUpper().ToCharArray();

            //    if (nameCharArray.Intersect(surnameCharArray).ToList().Count > 1)
            //    {
            //        if (surnameCharArray.Intersect(facultyNameCharArray).ToList().Count > 1)
            //        {
            //            sortedEmpList.Add(employee);
            //        }
            //    }
            //}

            //SetDataIntoGrid(sortedEmpList);

            var employeeList = GetEmployeeList()
           .Where(x =>
               x.Name
               .ToUpper()
               .ToCharArray()
               .Intersect(x.Surname.ToUpper().ToCharArray())
               .ToList().Count > 1 &&
               x.Surname
               .ToUpper()
               .ToCharArray()
               .Intersect(x.FacultyName.ToUpper().ToCharArray())
               .ToList().Count > 1)
           .ToList();

            SetDataIntoGrid(employeeList);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var employeeList = GetEmployeeList();
            SetDataIntoGrid(employeeList
                .Where(x => x.Surname.Length >= x.Name.Length)
                .ToList());
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var employeeList = GetEmployeeList();
            SetDataIntoGrid(employeeList
                .Where(x => x.Age + x.Course < x.FacultyName.Length)
                .ToList());
        }


    }
}
