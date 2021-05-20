using System;
using ManagementSystem.Services;

namespace ManagementSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            CustomerManagementService customerManagementService = new CustomerManagementService();
            EmployeeManagementService employeeManagementService = new EmployeeManagementService();
            ReservationManagementService reservationManagementService = new ReservationManagementService();
            RoomManagementService roomManagementService = new RoomManagementService();
            PaymentManagementService paymentManagementService = new PaymentManagementService();
            void MainMenu()
            {
                Console.WriteLine("Welcome to Test hotels!\nEnter 1 to Register;\nAlready have an account, Enter 2 to login;\nEnter 0 to quit");
                Console.WriteLine("This is good beginning");
                Console.WriteLine("Very Affordable");
            }

            void HandleMainMenu(int option)
            {
                if (option == 1)
                {
                    Customer customer = customerManagementService.Create();
                    customerManagementService.Login(customer.email, "password");
                    CustomerMenu();
                }
                else if (option == 2)
                {
                    Console.WriteLine("Login as, Customer/Employee");
                    string response = Console.ReadLine();
                    if (response == "Customer")
                    {
                        Console.WriteLine("Enter your email");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter your password");
                        string password = Console.ReadLine();
                        bool loggedin = customerManagementService.Login(email, password);
                        if (loggedin) { Console.WriteLine("Login sucessfull"); CustomerMenu(); }
                        else { Console.WriteLine("Username or password incorrect!"); }
                    }
                    else
                    {
                        Console.WriteLine("Enter your email");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter your password");
                        string password = Console.ReadLine();
                        bool loggedin = employeeManagementService.Login(email, password);
                        if (loggedin) { Console.WriteLine("Login sucessfull"); EmployeeMenu(); }
                        else { Console.WriteLine("Username or password incorrect"); }
                    }
                }
            }

            void CustomerMenu()
            {
                Console.WriteLine("Enter 1 to make reservation:\nEnter 2 to make payment for a reservation:\nEnter 3 to edit details:\nEnter 4 to show all reservations:\nEnter 5 to change password:\nEnter 0 to logout");
                int action = Convert.ToInt32(Console.ReadLine());
                HandleCustomerMenuOption(action);
            }

            void HandleCustomerMenuOption(int action)
            {
                Customer customer = customerManagementService.Get();
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Here are the available rooms");
                        roomManagementService.List(true);
                        Room room = roomManagementService.Get();
                        reservationManagementService.Create(customer, room);
                        CustomerMenu();
                        break;
                    case 2:
                        Reservation reservation = reservationManagementService.Get();
                        Console.WriteLine("Enter the amount to be paid: ");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                        paymentManagementService.Create(reservation);
                        CustomerMenu();
                        break;
                    case 3:
                        customerManagementService.Edit();
                        CustomerMenu();
                        break;
                    case 4:
                        reservationManagementService.showMyReservation(customer);
                        CustomerMenu();
                        break;
                    case 0:
                        customerManagementService.Logout();
                        MainMenu();
                        int option = Convert.ToInt32(Console.ReadLine());
                        HandleMainMenu(option);
                        break;
                    case 5:
                        Console.WriteLine("Enter your new password");
                        string new_password = Console.ReadLine();
                        customerManagementService.ChangePassword(customer, new_password);
                        break;
                }
            }

            void EmployeeMenu()
            {
                Console.WriteLine("Enter 1 for customer menu\nEnter 2 for Reservation menu\nEnter 3 for payment menu\nEnter 4 for Room menu\nEnter 5 for Employee menu\nEnter 6 to edit details\nEnter 0 to logout");
                int option = Convert.ToInt32(Console.ReadLine());
                HandleEmployeeMenu(option);
            }

            void CreateAdmin()
            {
                Console.WriteLine("Welcome You are seeing this cos this is the first lauch of the application\nRegister as admin");
                employeeManagementService.Create();
            }

            void Customer()
            {
                Console.WriteLine("Enter 1 to list customers\nEnter 2 to view customer's details\nEnter 3 to edit customer\nEnter 4 to create customer\nEnter 0 to go back");
                int action = Convert.ToInt32(Console.ReadLine());
                HandleCustomer(action);
            }

            void Employee()
            {
                Console.WriteLine("Enter 1 to list employees\nEnter 2 to view employee's details\nEnter 3 to edit employee\nEnter 4 to create employee\nEnter 0 to go back");
                int action = Convert.ToInt32(Console.ReadLine());
                HandleEmployee(action);
            }

            void Reservation()
            {
                Console.WriteLine("Enter 1 to list reservations\nEnter 2 to view reservation's details\nEnter 3 to edit reservation\nEnter 0 to go back");
                int action = Convert.ToInt32(Console.ReadLine());
                HandleReservation(action);
            }

            void Payment()
            {
                Console.WriteLine("Enter 1 to list payments\nEnter 2 to view payment's details\nEnter 0 to go back");
                int action = Convert.ToInt32(Console.ReadLine());
                HandlePayment(action);

            }

            void Room()
            {
                Console.WriteLine("Enter 1 to list Room\nEnter 2 to view Room's details\nEnter 3 to create Many Room\nEnter 4 to create one room\nEnter 0 to go back");
                int action = Convert.ToInt32(Console.ReadLine());
                HandleRoom(action);
            }

            void HandleCustomer(int action)
            {
                switch (action)
                {
                    case 1:
                        customerManagementService.List();
                        Customer();
                        break;
                    case 2:
                        customerManagementService.Details();
                        Customer();
                        break;
                    case 3:
                        customerManagementService.Edit();
                        Customer();
                        break;
                    case 4:
                        customerManagementService.Create();
                        Customer();
                        break;
                    case 0:
                        EmployeeMenu();
                        break;
                }
            }

            void HandleReservation(int action)
            {
                switch (action)
                {
                    case 1:
                        reservationManagementService.List();
                        Reservation();
                        break;
                    case 2:
                        reservationManagementService.Deatils();
                        Reservation();
                        break;
                    case 3:
                        Payment payment = paymentManagementService.Get();
                        reservationManagementService.Edit(payment);
                        Reservation();
                        break;
                    case 0:
                        EmployeeMenu();
                        break;
                }
            }

            void HandlePayment(int action)
            {
                switch (action)
                {
                    case 1:
                        paymentManagementService.list();
                        Payment();
                        break;
                    case 2:
                        Payment payment = paymentManagementService.Get();
                        paymentManagementService.Details(payment);
                        Payment();
                        break;
                    case 0:
                        EmployeeMenu();
                        break;
                }
            }

            void HandleEmployee(int action)
            {
                switch (action)
                {
                    case 1:
                        employeeManagementService.List();
                        Employee();
                        break;
                    case 2:
                        employeeManagementService.Details();
                        Employee();
                        break;
                    case 3:
                        employeeManagementService.Edit();
                        Employee();
                        break;
                    case 4:
                        employeeManagementService.Create();
                        Employee();
                        break;
                    case 0:
                        EmployeeMenu();
                        break;
                }
            }

            void HandleRoom(int action)
            {
                switch (action)
                {
                    case 1:
                        roomManagementService.List(status: null);
                        Room();
                        break;
                    case 2:
                        roomManagementService.Details();
                        Room();
                        break;
                    case 3:
                        roomManagementService.CreateMany();
                        Room();
                        break;
                    case 4:
                        roomManagementService.CreateOne();
                        Room();
                        break;
                    case 0:
                        EmployeeMenu();
                        break;
                }
            }

            void HandleEmployeeMenu(int option)
            {
                switch (option)
                {
                    case 1:
                        Customer();
                        break;
                    case 2:
                        Reservation();
                        break;
                    case 3:
                        Payment();
                        break;
                    case 4:
                        Room();
                        break;
                    case 5:
                        Employee();
                        break;
                    case 0:
                        employeeManagementService.Logout();
                        MainMenu();
                        break;
                }
            }

            void Main()
            {
                bool flag = true;
                CreateAdmin();
                while (flag)
                {
                    MainMenu();
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (option == 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        HandleMainMenu(option);
                    }
                }
            }
            void newMain();
            {
                Console.WriteLine("Welcome to git");
            }
        }
    }
}
