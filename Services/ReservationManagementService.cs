using System;
using System.Collections.Generic;
using System.Text;
using ManagementSystem.Repository;

namespace ManagementSystem.Services
{
    class ReservationManagementService
    {
        private ReservationRepository reservationRepository = new ReservationRepository();

        public void Create(Customer customer, Room room)
        {
            string result = reservationRepository.Create(room, customer, false);
            Console.WriteLine(result);
        }

        public void Edit(Payment payment)
        {
            Reservation reservation = Get();
            if (reservation != null)
            {
                if (payment != null)
                {
                    reservation.payment = true;
                    reservation.status = true;
                }
                else
                {
                    Console.WriteLine("Is Reservation no longer active; YES/NO");
                    string response = Console.ReadLine();
                    if (response == "YES")
                    {
                        reservation.status = false;
                    }
                }
            }
        }

        public Reservation Get()
        {
            Console.WriteLine("Enter Reservation reference: ");
            string reference = Console.ReadLine();
            Reservation reservation = reservationRepository.Find(reference);
            return reservation;
        }

        public void List()
        {
            Console.WriteLine("Do you what to see all reservation; YES/NO");
            string response = Console.ReadLine();
            if (response == "YES")
            {
                reservationRepository.List(status: null);
            }
            else
            {
                Console.WriteLine("List Available reservation or not; YES/NO");
                string ans = Console.ReadLine();
                if (ans == "YES")
                {
                    reservationRepository.List(status: true);
                }
                else
                {
                    reservationRepository.List(status: false);
                }
            }
        }

        public void Deatils()
        {
            Reservation reservation = Get();
            if (reservation != null)
            {
                reservationRepository.Details(reservation);
            }
            else
            {
                Console.WriteLine("Record found");
            }
        }

        public void showMyReservation(Customer customer)
        {
            reservationRepository.ListCustomerReservation(customer);
        }
    }
}
