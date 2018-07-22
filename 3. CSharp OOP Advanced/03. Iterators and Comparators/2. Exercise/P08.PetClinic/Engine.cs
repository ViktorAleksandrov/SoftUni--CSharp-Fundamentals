using System;
using System.Collections.Generic;
using System.Linq;
using P08.PetClinic.Models;

namespace P08.PetClinic
{
    public class Engine
    {
        private readonly List<Pet> pets;
        private readonly List<Clinic> clinics;

        public Engine()
        {
            this.pets = new List<Pet>();
            this.clinics = new List<Clinic>();
        }

        public void Run()
        {
            int commandsCount = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < commandsCount; counter++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                string command = inputArgs[0];

                string[] commandArgs = inputArgs.Skip(1).ToArray();

                switch (command)
                {
                    case "Create":
                        this.Create(commandArgs);
                        break;
                    case "Add":
                        this.Add(commandArgs);
                        break;
                    case "Release":
                        this.Release(commandArgs);
                        break;
                    case "HasEmptyRooms":
                        this.HasEmptyRooms(commandArgs);
                        break;
                    case "Print":
                        this.Print(commandArgs);
                        break;
                }
            }
        }

        private void Print(string[] commandArgs)
        {
            string clinicName = commandArgs[0];
            Clinic clinic = GetClinic(clinicName);

            if (commandArgs.Length > 1)
            {
                int roomNumber = int.Parse(commandArgs[1]);

                clinic.Print(roomNumber);
            }
            else
            {
                clinic.PrintAll();
            }
        }

        private void HasEmptyRooms(string[] commandArgs)
        {
            string clinicName = commandArgs[0];
            Clinic clinic = GetClinic(clinicName);

            Console.WriteLine(clinic.HasEmptyRooms);
        }

        private void Release(string[] commandArgs)
        {
            string clinicName = commandArgs[0];
            Clinic clinic = GetClinic(clinicName);

            Console.WriteLine(clinic.Release());
        }

        private void Add(string[] commandArgs)
        {
            string petName = commandArgs[0];
            Pet pet = this.pets.FirstOrDefault(p => p.Name == petName);

            string clinicName = commandArgs[1];
            Clinic clinic = GetClinic(clinicName);

            Console.WriteLine(clinic.Add(pet));
        }

        private void Create(string[] commandArgs)
        {
            string creationType = commandArgs[0];
            string name = commandArgs[1];

            if (creationType == "Pet")
            {
                int age = int.Parse(commandArgs[2]);
                string kind = commandArgs[3];

                var pet = new Pet(name, age, kind);

                this.pets.Add(pet);
            }
            else if (creationType == "Clinic")
            {
                int roomsCount = int.Parse(commandArgs[2]);

                try
                {
                    var clinic = new Clinic(name, roomsCount);

                    this.clinics.Add(clinic);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private Clinic GetClinic(string clinicName)
        {
            return this.clinics.First(c => c.Name == clinicName);
        }
    }
}
