using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Entites
{
    class Person
    {
        public string name { get => $"{lastName}' '{firstName}"; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        protected string firstName { get; set; }
        protected string lastName { get; set; }
        protected string role { get; set; }

        private string _password;


        public Person() 
        {
            _password = "password";
        }

        public virtual bool ChangePassword(string password, string Email)
        {
            _password = password;
            return true;
        }

        public Person login(string email, string password)
        {
            if (email == this.email && password == this._password)
            {
                return this;
            }
            return null;
        }



    }
}
