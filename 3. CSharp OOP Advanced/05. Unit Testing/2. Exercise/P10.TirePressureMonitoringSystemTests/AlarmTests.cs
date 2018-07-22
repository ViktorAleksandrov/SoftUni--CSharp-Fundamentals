using Moq;
using NUnit.Framework;
using P10.TirePressureMonitoringSystem;

namespace P10.TirePressureMonitoringSystemTests
{
    public class AlarmTests
    {
        [Test]
        public void AlarmTurnsOn()
        {
            var alarmFake = new Mock<IAlarm>();

            alarmFake.Setup(a => a.AlarmOn).Returns(true);

            Assert.That(alarmFake.Object.AlarmOn, Is.True);
        }

        [Test]
        public void AlarmTurnsOff()
        {
            var alarmFake = new Mock<IAlarm>();

            alarmFake.Setup(a => a.AlarmOn).Returns(false);

            Assert.That(alarmFake.Object.AlarmOn, Is.False);
        }
    }
}
