using System;
using System.Collections.Generic;
using System.Text;
using ManagementSystem.Entites;

namespace ManagementSystem
{
    class CustomerRepository
    {
        public List<Customer> customers = new List<Customer>();

        public Customer CreateCustomer(string lastName, string email, string phonNumber, string address, string firstName = "")
        {
            Customer customer = new Customer(last: lastName, first: firstName)
            {
                address = address,
                email = email,
                phoneNumber = phonNumber
            };
            customers.Add(customer);
            return customer;
        }


        public string EditCustomer(Customer customer , string email,  string lastName, string phonNumber, string address, string firstName)
        {
            customer.ChangeName(lastName, firstName);
            customer.phoneNumber = phonNumber;
            customer.address = address;
            return "Edit sucessfull!";
        }

        public void Details(Customer customer)
        {
            this.Show(customer, 1);
        }
            

        public void ListCustomers()
        {
            for(int i = 0; i < this.customers.Count; i++)
            {
                this.Show(customer: this.customers[i], index: i);
            }
        }

        public Customer Find(string email)
        {
            foreach (Customer customer in customers)
            {
                if (customer.email.Equals(email)) { return customer; }
            }

            return null;
        }
        
        public string Delete(Customer customer)
        {
            customers.Remove(customer);
            return "Customer Deleted";
        }
        private void Show(Customer customer, int index)
        {
            Console.WriteLine($"{index}. - {customer.name}\n - {customer.email}\n - {customer.phoneNumber}\n - {customer.address}");
        }

        public Customer Login(string email, string password)
        {
            foreach (Customer customer in customers)
            {
                if (customer.email == email)
                {
                   Person person =  customer.login(email, password);
                   if (person != null)
                   {
                        Customer user = Find(person.email);
                        return user;
                   }
                  
                }
            }
            return null;
        }

    }
}
