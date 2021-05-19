using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Repository
{
    class ReservationRepository
    {
        public List<Reservation> reservations = new List<Reservation>();


        public string Create(Room room, Customer customer, bool status)
        {
            Reservation reservation = new Reservation(customer, room, status);
            this.reservations.Add(reservation);
            return $"Reservation made with refernce {reservation.reference}";
        }

        public string Edit(string reference, bool payment = false, bool status = false)
        {
            Reservation reservation = this.Find(reference);
            if(status)
            {
                reservation.status = status;
                reservation.payment = payment;
                return "Reservaion edited";
            }

            else
            {
                reservation.payment = payment;
                return "Reservaion edited";
            }
        }

        public void List(bool? status)
        {
            foreach(Reservation reservation in this.reservations)
            {
                if (status != null)
                {
                    if (reservation.Equals(status))
                    {
                        Show(reservation, reservations.IndexOf(reservation));
                    }
                }
                else
                {
                    Show(reservation, reservations.IndexOf(reservation));
                }
                
            }
        }

        public void Details(Reservation reservation)
        {
           
            if (reservation != null)
            {
                this.Show(reservation, 1);
            }
            else { Console.WriteLine("Reservation not found"); }
        }
    
        public Reservation Find(string reference)
        {
            foreach(Reservation reservation in this.reservations)
            {
                if (reservation.reference.Equals(reference))
                {
                    return reservation;
                }
            }

            return null;
        }

        public void ListCustomerReservation(Customer customer)
        {
            foreach (Reservation reservation in reservations)
            {
                if (reservation.customer.Equals(customer))
                {
                    Show(reservation, reservations.IndexOf(reservation));
                }
            }
        }

        private void Show(Reservation reservation, int index)
        {
            Console.WriteLine($"{index}. - {reservation.customer.name}\n - {reservation.room.number}\n - {reservation.status}\n - {reservation.date}");
        }
    }
}
