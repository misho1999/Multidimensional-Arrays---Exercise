using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitDriver driver;
        private UnitCar car;
        private RaceEntry race;
        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
        }

        [Test]
        public void WhenDriverIsNull_ShouldThrowException()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                driver = null;
                race.AddDriver(driver);
            });
            Assert.AreEqual(ex.Message, "Driver cannot be null.");
        }
        [Test]
        public void WhenDriverIsAlreadyAdded_ShouldThrowException()
        {
            car = new UnitCar("Bmw", 170, 2200);
            driver = new UnitDriver("Misho", car);
            race.AddDriver(driver);
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver);
            });
            Assert.AreEqual(ex.Message, $"Driver {driver.Name} is already added.");
        }
        [Test]
        public void AddDriverMethod_ShouldAddDriver()
        {
            car = new UnitCar("Bmw", 170, 2200);
            driver = new UnitDriver("Misho", car);
            race.AddDriver(driver);

            Assert.AreEqual(race.Counter, 1);
        }
        [Test]
        public void AddDriverMethod_ShouldReturnCorrectOutput()
        {
            car = new UnitCar("Bmw", 170, 2200);
            driver = new UnitDriver("Misho", car);
            string result = race.AddDriver(driver);

            Assert.AreEqual(result, $"Driver {driver.Name} added in race.");
        }
        [Test]
        public void WhenParticipantsIsLessThan2_ShouldThrowException()
        {
            car = new UnitCar("Bmw", 170, 2200);
            driver = new UnitDriver("Misho", car);
            race.AddDriver(driver);
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();
            });

            Assert.AreEqual(ex.Message, $"The race cannot start with less than {2} participants.");
        }
        [Test]
        public void WhenCalculateAverageHorsePower_ShouldReturnCorrectOutput()
        {
            car = new UnitCar("Bmw", 170, 2200);
            driver = new UnitDriver("Misho", car);
            UnitCar car2 = new UnitCar("Lada", 150, 1900);
            UnitDriver driver2 = new UnitDriver("Toni", car);
            UnitCar car3 = new UnitCar("Mercedes", 300, 3000);
            UnitDriver driver3 = new UnitDriver("Melisa", car);

            race.AddDriver(driver);
            race.AddDriver(driver2);
            race.AddDriver(driver3);

            double result = race.CalculateAverageHorsePower();

            Assert.AreEqual(result, 170.0d);
        }

    }
}