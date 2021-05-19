using System;
using System.Collections.Generic;
using System.Text;
using ManagementSystem.Entites;

namespace ManagementSystem.Repository
{
    class EmployeeRepository
    {
        List<Employee> employees = new List<Employee>();

        public string Create(string lastName, string email, string role, string firstName, DateTime dateOfEmployment, string phoneNumber, int age)
        {
            Employee employee = new Employee(lastName, firstName, role);
            employee.email = email;
            employee.phoneNumber = phoneNumber;
            employee.age = age;
            employees.Add(employee);
            return "Employee created";
        }

        public string Edit(Employee employee ,string lastName, string email, string firstName, string phoneNumber, int age)
        {
            if (employee != null)
            {
                employee.ChangeName(lastName, firstName);
                employee.email = email;
                employee.phoneNumber = phoneNumber;
                employee.age = age;
                return "Employee updated";
            }
            return "No matching record found";
        }

        public void Details(Employee employee)
        {
            if (employee != null)
            {
                Show(employee, 1);
            }
            Console.WriteLine("Matching record not found");
        }

        public string Delete(Employee employee)
        {
            if (employee != null)
            {
                employees.Remove(employee);
                return "Employee deleted";
            }
            return "Matching record not found";
        }

        public Employee Find(string email)
        {
            foreach(Employee employee in employees)
            {
                if (employee.email.Equals(email))
                {
                    return employee;
                }
            }
            return null;
        }

        public void List()
        {
            foreach(Employee employee in employees)
            {
                Show(employee, employees.IndexOf(employee));
            }
        }

        public void Show(Employee employee, int index)
        {
            Console.WriteLine($"{index}. - {employee.name}\n - {employee.email}\n - {employee.phoneNumber}\n - {employee.age}");
        }

        public Employee login(string email, string password)
        {
            foreach( Employee employee in employees)
            {
                if (employee.email == email)
                {
                    Person person = employee.login(email, password);
                    if ( person != null)
                    {
                        Employee user = Find(person.email);
                        return user;
                    }
                }
            }
            return null;
        }
    }
}
