using System;
using System.Collections.Generic;
using System.Text;
using ManagementSystem.Repository;

namespace ManagementSystem.Services
{
    class CustomerManagementService
    {
        public Customer user;

        private readonly CustomerRepository customerRepository = new CustomerRepository();


        public Customer Create() 
        {
            Console.WriteLine("Welcome To Customer Management Service");
            Console.WriteLine("Enter your last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your phone: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter your address: ");
            string address = Console.ReadLine();
            Customer customer = customerRepository.Find(email);
            if (customer == null)
            {
                Customer cus = customerRepository.CreateCustomer(lastName, email, phone, address, firstName);
                Console.WriteLine($"Registration sucessful with email {cus.email}");
                return cus;
            }
            else
            {
                Console.WriteLine("Email already exits try another email");
                return null;
            }
            
        }

        public void Edit()
        {
            Customer customer = Get();
            if (customer != null)
            {
                Console.WriteLine("Enter your last name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter your email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter your first name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter your phone: ");
                string phone = Console.ReadLine();
                Console.WriteLine("Enter your address: ");
                string address = Console.ReadLine();
                string result = customerRepository.EditCustomer(customer, email, lastName, phone, address, firstName);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Email not found");
            }
            
        }

        public void List()
        {
            customerRepository.ListCustomers();
        }

        public void Details()
        {
            Customer customer = Get();
            if (customer != null)
            {
                customerRepository.Details(customer);
            }
            else
            {
                Console.WriteLine("Email not found");
            }

        }

        public void Delete()
        {
            Customer customer = Get();
            if (customer != null)
            {
                customerRepository.Delete(customer);
            }
            else
            {
                Console.WriteLine("Email not found");
            }
        }

        public Customer Get()
        {
            Customer customer;
            if (user == null)
            {
                Console.WriteLine("Enter your email: ");
                string email = Console.ReadLine();
                customer = customerRepository.Find(email);
                return customer;
            }
            else
            {
                customer = customerRepository.Find(email: user.email);
                return customer;
            }
        }

        public bool Login(string email, string password)
        {
            Customer customer =  customerRepository.Login(email, password);
            if (customer != null)
            {
                user = customer;
                return true;
            }
            return false;
        }

        public bool ChangePassword(Customer customer, string new_password)
        {
            return customer.ChangePassword(new_password, customer.email);
        }

        public void Logout()
        {
            user = null;
        }
    }
}
