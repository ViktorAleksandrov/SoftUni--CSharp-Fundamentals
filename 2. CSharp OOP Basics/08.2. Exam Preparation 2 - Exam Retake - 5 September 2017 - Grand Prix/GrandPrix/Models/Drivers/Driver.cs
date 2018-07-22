public abstract class Driver
{
    private const double BoxDefaultTime = 20.0;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0.0;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public string Name { get; }

    public double TotalTime { get; set; }

    public Car Car { get; }

    public double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public string FailureReason { get; set; }

    public void Box()
    {
        this.TotalTime += BoxDefaultTime;
    }

    public void CompleteLap(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
        this.Car.ReduceFuel(trackLength, this.FuelConsumptionPerKm);
        this.Car.Tyre.ReduceDegradation();
    }
}