using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem
{
    class Reservation
    {
        public Customer customer;
        public bool payment;
        public Room room;
        public DateTime date;
        public bool status;
        public string reference;

        public Reservation(Customer customer, Room room, bool status)
        {
            this.customer = customer;
            this.payment = false;
            this.room = room;
            this.date = DateTime.Now;
            this.status = status;
            reference = Guid.NewGuid().ToString().Replace('-', 'A').Trim().ToUpper().Substring(0, 10);
        }
    }
}
