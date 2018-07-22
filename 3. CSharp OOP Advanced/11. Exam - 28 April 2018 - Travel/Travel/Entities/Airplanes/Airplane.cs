namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Entities.Contracts;

    public abstract class Airplane : IAirplane
    {
        private readonly List<IPassenger> passengers;
        private readonly List<IBag> bags;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;

            this.passengers = new List<IPassenger>();
            this.bags = new List<IBag>();
        }

        public int Seats { get; }

        public int BaggageCompartments { get; }

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public IReadOnlyCollection<IBag> BaggageCompartment => this.bags.AsReadOnly();

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seat)
        {
            IPassenger passenger = this.passengers[seat];

            this.passengers.RemoveAt(seat);

            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            IBag[] passengerBags = this.bags
                .Where(b => b.Owner == passenger)
                .ToArray();

            foreach (IBag bag in passengerBags)
            {
                this.bags.Remove(bag);
            }

            return passengerBags;
        }

        public void LoadBag(IBag bag)
        {
            bool isBaggageCompartmentFull = this.BaggageCompartment.Count >= this.BaggageCompartments;

            if (isBaggageCompartmentFull)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }

            this.bags.Add(bag);
        }
    }
}