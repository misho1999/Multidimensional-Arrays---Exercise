using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private Car car;
        private Driver driver;
        private Race race;
        private DriverRepository<Driver> repositoryDriver;
        private CarRepository<Car> repositoryCar;
        private RaceRepository<Race> repositoryRace;
        public ChampionshipController()
        {
            repositoryDriver = new DriverRepository<Driver>();
            repositoryCar = new CarRepository<Car>();
            repositoryRace = new RaceRepository<Race>();
        }
    public string AddCarToDriver(string driverName, string carModel)
        {
            var existDriver = repositoryDriver.GetByName(driverName);
            if (existDriver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            var existCar = repositoryCar.GetByName(carModel);
            if (existCar == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }
            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var existRace = repositoryRace.GetByName(raceName);
            if (existRace == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            var existDriver = repositoryDriver.GetByName(driverName);
            if (existDriver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";

        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (type == "Muscle")
            {
                car = new MuscleCar(model,horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            var result = repositoryCar.GetByName(model);
            if (car == result)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            repositoryCar.Add(car);

            return $"{type} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
           var result = repositoryDriver.GetByName(driverName);
            driver = new Driver(driverName);
            if (result == driver)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            repositoryDriver.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            race = new Race(name,laps);
            var result = repositoryRace.GetByName(name);
            if (race == result)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var result = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(1));
            var exsistRace = repositoryRace.GetByName(raceName);
            if (exsistRace == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (result.Count() < 3 )
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            Queue<IDriver> drivers = new Queue<IDriver>();
            foreach (var item in result)
            {
                drivers.Enqueue(item);
            }
            var driver1 = drivers.Dequeue();
            var driver2 = drivers.Dequeue();
            var driver3 = drivers.Dequeue();
            return $"Driver {driver1.Name} wins {raceName} race.\r\n" + $"Driver {driver2.Name} is second in {raceName} race.\r\n" + $"Driver {driver3.Name} is third in {raceName} race.";

        }
        public void Exit()
        {
            this.Exit();
        }
    }
}
