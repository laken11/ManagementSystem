using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem
{
    class Payment
    {
        public Reservation reservation;
        public decimal amount;
        public DateTime date;
        public string reference; 

        public Payment(Reservation reservation, decimal amount)
        {
            this.reservation = reservation;
            this.amount = amount;
            this.date = DateTime.Now;
            this.reference = Guid.NewGuid().ToString().Replace('-', 'A').Trim().ToUpper().Substring(0, 10);
        }
    }
}
