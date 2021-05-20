using System;
using System.Collections.Generic;
using System.Text;
using ManagementSystem.Repository;

namespace ManagementSystem.Services
{
    class EmployeeManagementService
    {
        Employee user;
        private readonly EmployeeRepository employeeResposiotry = new EmployeeRepository();

       

        public void Create()
        {
            Console.WriteLine("Welcome to Employee Mgt Services");
            Console.WriteLine("Enter your last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your phone: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your role: ");
            string role = Console.ReadLine();
            Console.WriteLine("Enter age");
            int age = Convert.ToInt32(Console.ReadLine());
            DateTime dateEmployment = DateTime.Now;
            Employee employee = employeeResposiotry.Find(email);
            if (employee == null)
            {
                string result = employeeResposiotry.Create(lastName, email, role, firstName, dateEmployment, phoneNumber, age);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Email already exits, try another email");
            }
        }

        public void Edit()
        {
            Employee employee = Get();
            if (employee != null)
            {
                Console.WriteLine("Enter your last name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter your first name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter your email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter your phone: ");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter age");
                int age = Convert.ToInt32(Console.ReadLine());
                string result = employeeResposiotry.Edit(employee, lastName, email, firstName, phoneNumber, age);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("record not found");
            }
        }

        public void Details()
        {
            Employee employee = Get();
            if (employee != null)
            {
                employeeResposiotry.Details(employee);
            }
            else
            {
                Console.WriteLine("No matching record found");
            }
        }

        public void Delete()
        {
            Employee employee = Get();
            if (employee != null)
            {
                employeeResposiotry.Delete(employee);
            }
            else
            {
                Console.WriteLine("No matching record found");
            }
        }

        public Employee Get()
        {
            Employee employee;
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            employee = employeeResposiotry.Find(email);
            return employee;
        }

        public bool Login(string email, string password)
        {
            Employee employee = employeeResposiotry.login(email, password);
            if (employee != null)
            {
                user = employee;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void List()
        {
            employeeResposiotry.List();
        }

        public void Logout()
        {
            user = null;
        }
    }
}
