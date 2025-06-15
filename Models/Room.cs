using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.Models
{
    public class Room
    {
        int ID { get; }    
        int RoomNum { get; }
        int Capacity { get; }
        public Room(int id, int roomNum, int capacity)
        {
            ID = id;
            RoomNum = roomNum;
            Capacity = capacity;
        }
    }
}
