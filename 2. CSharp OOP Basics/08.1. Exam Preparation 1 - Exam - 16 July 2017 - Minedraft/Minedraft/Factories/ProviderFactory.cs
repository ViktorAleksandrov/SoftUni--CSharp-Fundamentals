using System.Collections.Generic;

public class ProviderFactory
{
    public Provider CreateProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        if (type == "Solar")
        {
            return new SolarProvider(id, energyOutput);
        }

        return new PressureProvider(id, energyOutput);
    }
}