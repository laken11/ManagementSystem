using System;
using System.Collections.Generic;
using System.Text;
using ManagementSystem.Repository;

namespace ManagementSystem.Services
{
    class RoomManagementService
    {
        private RoomRepository roomRepository = new RoomRepository();

        public void CreateMany()
        {
            Console.WriteLine("Enter the number to start from");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number to End from, if just a room enter 0");
            int end = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the room type to create");
            string type = Console.ReadLine();
            string result = roomRepository.Create(start, type, end);
            Console.WriteLine(result);
        }

        public void CreateOne()
        {
            Console.WriteLine("Enter the number");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the room type to create");
            string type = Console.ReadLine();
            string result = roomRepository.Create(start, type);
            Console.WriteLine(result);
        }

        public void List(bool? status)
        {
            if (status == null)
            {
                Console.WriteLine("Do you what to see all rooms; YES/NO");
                string response = Console.ReadLine();
                if (response == "YES")
                {
                    roomRepository.List(status: null);
                }
                else
                {
                    Console.WriteLine("List Available rooms or not; YES/NO");
                    string ans = Console.ReadLine();
                    if (ans == "YES")
                    {
                        roomRepository.List(status: true);
                    }
                    else
                    {
                        roomRepository.List(status: false);
                    }
                }
            }
            else
            {
                roomRepository.List(status);
            }
            
        }

        public void ChangeStatua(Room room, bool status)
        {
            room.status = status;
            Console.WriteLine("Room Status changed");
        }

        public Room Get()
        {
            Console.WriteLine("Enter the room number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Room room = roomRepository.Find(number);
            return room;
        }

        public void Details()
        {
            Room room = Get();
            roomRepository.Datails(room);
        }
    }
}
