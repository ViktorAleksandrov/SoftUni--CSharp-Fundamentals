using System;

public class PriceCalculator
{
    private decimal pricePerDay;
    private int numberOfDays;
    private Season season;
    private Discount discountType;

    public PriceCalculator(string[] reservationInfo)
    {
        pricePerDay = decimal.Parse(reservationInfo[0]);
        numberOfDays = int.Parse(reservationInfo[1]);
        season = Enum.Parse<Season>(reservationInfo[2]);
        discountType = Discount.None;

        if (reservationInfo.Length == 4)
        {
            discountType = Enum.Parse<Discount>(reservationInfo[3]);
        }
    }

    public decimal CalculatePrice()
    {
        return pricePerDay * numberOfDays * (int)season * (decimal)discountType / 100;
    }
}