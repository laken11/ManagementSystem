using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Repository
{
    class PaymentRepository
    {
        List<Payment> payments = new List<Payment>();

        public string Create(Reservation reservation, decimal amount)
        {
            Payment payment = new Payment(reservation, amount);
            payments.Add(payment);
            return $"Payment made with reference{payment.reference}";
        }

        public void List()
        {
            foreach(Payment payment in payments)
            {
                Show(payment, payments.IndexOf(payment));
            }
        }

        public void Datails(Payment payment)
        {
            if (payment != null)
            {
                Show(payment, 1);
            }
            else
            {
                Console.WriteLine("Payment not found");
            }
        }

        public Payment Find(string referance)
        {
            foreach(Payment payment in payments)
            {
                if (payment.reference.Equals(referance))
                {
                    return payment;
                }
            }
            return null;
        }

        private void Show(Payment payment, int index)
        {
            Console.WriteLine($"{index}. - {payment.reservation.customer.name}\n - {payment.reservation.reference}\n - {payment.reservation.room.number}\n - {payment.amount}\n - {payment.date}");
        }
    }
}
