﻿using System;

public class Car
{
    public Car(string model, Engine engine, string weight, string color)
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        return $"{Model}:{Environment.NewLine}" +
               $"{Engine}{Environment.NewLine}" +
               $"  Weight: {Weight}{Environment.NewLine}" +
               $"  Color: {Color}";
    }
}