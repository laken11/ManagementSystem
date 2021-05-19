using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Repository
{
    class RoomRepository
    {
        public List<Room> rooms = new List<Room>();

        public string Create(int start, string type, int end = 0) 
        {
            if (this.rooms.Count < start)
            {
                if (start < end && start != end)
                {
                    for (int i = start; i <= end; i++)
                    {
                        Room room = new Room(room_number: i, room_type: type);
                        this.rooms.Add(room);
                    }
                    return "Rooms created!";
                }
                else
                {
                    Room room = new Room(room_number: start, room_type: type);
                    this.rooms.Add(room);
                    return "Room created!";
                }
            }
            else { return "Room with numbers or number already exits"; }
        }

        public string Edit(Room room, bool status)
        {
            room.status = status;
            return "room edited";
        }

        public void List(bool? status)
        {
            foreach(Room room in rooms)
            {
                if (status != null)
                {
                    if (room.status.Equals(status))
                    {
                        Show(room, rooms.IndexOf(room));
                    }
                }
                else
                {
                    Show(room, rooms.IndexOf(room));
                }
            }
        }

        public void Datails(Room room)
        {
            if (room != null)
            {
                this.Show(room, 1);
            }
            else
            {
                Console.WriteLine("Room not found");
            }
        }

        private void Show(Room room, int index)
        {
            Console.WriteLine($"{index}.- Room numner: {room.number}\n  - Room status: {room.status}");
        }

        public Room Find(int number)
        {
            foreach(Room room in this.rooms)
            {
                if (room.number.Equals(number))
                {
                    return room;
                }
            }
            return null;
        }
    }
}
