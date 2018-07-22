public class Ferrari : ICar
{
    public Ferrari(string driver)
    {
        Driver = driver;
    }

    public string Model => "488-Spider";

    public string Driver { get; private set; }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{Model}/{UseBrakes()}/{PushGasPedal()}/{Driver}";
    }
}