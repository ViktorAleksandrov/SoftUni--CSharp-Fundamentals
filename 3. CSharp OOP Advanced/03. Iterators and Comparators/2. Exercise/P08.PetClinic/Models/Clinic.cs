using System;
using System.Linq;

namespace P08.PetClinic.Models
{
    public class Clinic
    {
        private readonly Pet[] petRooms;
        private readonly int roomsCount;
        private readonly int centralRoom;

        public Clinic(string name, int roomsCount)
        {
            this.Name = name;
            this.ValidateRoomsCount(roomsCount);
            this.petRooms = new Pet[roomsCount];
            this.roomsCount = roomsCount;
            this.centralRoom = roomsCount / 2;
        }

        public string Name { get; }

        public bool HasEmptyRooms => this.petRooms.Any(p => p == null);

        public bool Add(Pet pet)
        {
            if (!this.HasEmptyRooms)
            {
                return false;
            }

            int currentRoom = this.centralRoom;

            for (int counter = 0; counter < this.roomsCount; counter++)
            {
                if (counter % 2 == 0)
                {
                    currentRoom += counter;
                }
                else
                {
                    currentRoom -= counter;
                }

                if (this.petRooms[currentRoom] == null)
                {
                    this.petRooms[currentRoom] = pet;
                    return true;
                }
            }

            return false;
        }

        public bool Release()
        {
            for (int counter = 0; counter < this.roomsCount; counter++)
            {
                int currentRoom = (this.centralRoom + counter) % this.roomsCount;

                if (this.petRooms[currentRoom] != null)
                {
                    this.petRooms[currentRoom] = null;
                    return true;
                }
            }

            return false;
        }

        public void Print(int roomNumber)
        {
            Pet pet = this.petRooms[roomNumber - 1];

            Console.WriteLine(pet == null ? "Room empty" : pet.ToString());
        }

        public void PrintAll()
        {
            for (int index = 1; index <= this.roomsCount; index++)
            {
                this.Print(index);
            }
        }

        private void ValidateRoomsCount(int roomsCount)
        {
            if (roomsCount % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }
    }
}
