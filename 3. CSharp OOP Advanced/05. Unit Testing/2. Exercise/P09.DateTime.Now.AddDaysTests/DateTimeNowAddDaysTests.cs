using System;
using Moq;
using NUnit.Framework;

public class DateTimeNowAddDaysTests
{
    private const int DaysToAdd = 1;
    private const int DaysToSubtract = -1;

    private DateTime middleOfMonthDate = new DateTime(2018, 5, 16);
    private DateTime endOfMonthDate = new DateTime(2018, 5, 31);
    private DateTime startOfMonthDate = new DateTime(2018, 6, 1);
    private DateTime leapYearDate = new DateTime(2016, 2, 28);
    private DateTime nonLeapYearDate = new DateTime(2018, 2, 28);

    private Mock<IDateTime> mockedDateTime;

    [SetUp]
    public void MockedDateTimeInit()
    {
        this.mockedDateTime = new Mock<IDateTime>();
    }

    [Test]
    public void DateTimeNowWorksCorrectly()
    {
        this.mockedDateTime.Setup(m => m.Now).Returns(DateTime.Now.Date);

        Assert.That(this.mockedDateTime.Object.Now, Is.EqualTo(DateTime.Now.Date));
    }

    [Test]
    public void DateTimeNowAddDaysInTheMiddleOfMonth()
    {
        this.mockedDateTime.Setup(m => m.Now).Returns(this.middleOfMonthDate);

        Assert.That(this.mockedDateTime.Object.Now.AddDays(DaysToAdd), Is.EqualTo(this.middleOfMonthDate.AddDays(DaysToAdd)));
    }

    [Test]
    public void DateTimeNowAddDaysAtTheEndOfMonth()
    {
        this.mockedDateTime.Setup(m => m.Now).Returns(this.endOfMonthDate);

        Assert.That(this.mockedDateTime.Object.Now.AddDays(DaysToAdd), Is.EqualTo(this.endOfMonthDate.AddDays(DaysToAdd)));
    }

    [Test]
    public void DateTimeNowSubtractDaysAtTheBeginningOfMonth()
    {
        this.mockedDateTime.Setup(m => m.Now).Returns(this.startOfMonthDate);

        Assert.That(this.mockedDateTime.Object.Now.AddDays(DaysToSubtract),
            Is.EqualTo(this.startOfMonthDate.AddDays(DaysToSubtract)));
    }

    [Test]
    public void DateTimeNowAddDaysAtLeapYearFebruary()
    {
        this.mockedDateTime.Setup(m => m.Now).Returns(this.leapYearDate);

        Assert.That(this.mockedDateTime.Object.Now.AddDays(DaysToAdd), Is.EqualTo(this.leapYearDate.AddDays(DaysToAdd)));
    }

    [Test]
    public void DateTimeNowAddDaysAtNonLeapYearFebruary()
    {
        this.mockedDateTime.Setup(m => m.Now).Returns(this.nonLeapYearDate);

        Assert.That(this.mockedDateTime.Object.Now.AddDays(DaysToAdd), Is.EqualTo(this.nonLeapYearDate.AddDays(DaysToAdd)));
    }

    [Test]
    public void DateTimeNowSubtractDaysFromDateTimeMaxValue()
    {
        this.mockedDateTime.Setup(m => m.Now).Returns(DateTime.MaxValue);

        Assert.That(this.mockedDateTime.Object.Now.AddDays(DaysToSubtract),
            Is.EqualTo(DateTime.MaxValue.AddDays(DaysToSubtract)));
    }

    [Test]
    public void DateTimeNowAddDaysToDateTimeMaxValueThrowsException()
    {
        this.mockedDateTime.Setup(m => m.Now).Returns(DateTime.MaxValue);

        Assert.Throws<ArgumentOutOfRangeException>(() => this.mockedDateTime.Object.Now.AddDays(DaysToAdd));
    }

    [Test]
    public void DateTimeNowAddDaysToDateTimeMinValue()
    {
        this.mockedDateTime.Setup(m => m.Now).Returns(DateTime.MinValue);

        Assert.That(this.mockedDateTime.Object.Now.AddDays(DaysToAdd), Is.EqualTo(DateTime.MinValue.AddDays(DaysToAdd)));
    }

    [Test]
    public void DateTimeNowSubtractDaysFromDateTimeMinValueThrowsException()
    {
        this.mockedDateTime.Setup(m => m.Now).Returns(DateTime.MinValue);

        Assert.Throws<ArgumentOutOfRangeException>(() => this.mockedDateTime.Object.Now.AddDays(DaysToSubtract));
    }
}
