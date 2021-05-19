using System;
using System.Collections.Generic;
using System.Text;
using ManagementSystem.Entites;

namespace ManagementSystem
{
    class Employee : Person
    {
        public DateTime dateOfEmployment { get; set; }
        public int age { get; set; }
        public Employee(string last, string first, string role): base() 
        { 
            base.lastName = last;
            base.firstName = first;
            base.role = role;
            dateOfEmployment = DateTime.Now;
        }

        public void ChangeName(string lastName, string firstName)
        {
            base.firstName = firstName;
            base.lastName = lastName;

        }

        public override bool ChangePassword(string password, string Email)
        {
            if (email == Email)
            {
                return base.ChangePassword(password, Email);
            }
            return false;
        }
    }
}
