using System;
using System.Collections.Generic;
using System.Text;
using ManagementSystem.Entites;

namespace ManagementSystem
{
    class Customer : Person
    {
        public string address { get; set; }
        

        public Customer(string last, string first="") : base() 
        {
            lastName = last;
            firstName = first;
            role = "customer";
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
