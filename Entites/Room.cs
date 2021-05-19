using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem
{
    class Room
    {
        public int number;
        public string type;
        public bool status;

        public Room(int room_number, string room_type, bool status= false)
        {
            this.number = room_number;
            this.status = status;
            this.type = room_type;
        }
    }
}
