using System;
using System.Collections.Generic;
using System.Text;
using ManagementSystem.Repository;

namespace ManagementSystem.Services
{
    class PaymentManagementService
    {
        private PaymentRepository paymentRepository = new PaymentRepository();

        public void Create(Reservation reservation)
        {
            Console.WriteLine("Enter the amount to be paid");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            string result = paymentRepository.Create(reservation, amount);
            Console.WriteLine(result);
        }

        public void list()
        {
            paymentRepository.List();
        }

        public Payment Get()
        {
            Console.WriteLine("Enter your payment refernce number");
            string reference = Console.ReadLine();
            Payment payment = paymentRepository.Find(reference);
            if (payment != null)
            {
                return payment;
            }
            return null;
        }

        public void Details(Payment payment)
        {
            paymentRepository.Datails(payment);
        }
    }
}
