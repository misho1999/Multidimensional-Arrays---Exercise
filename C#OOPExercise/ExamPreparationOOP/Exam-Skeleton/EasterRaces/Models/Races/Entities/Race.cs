using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private IReadOnlyCollection<IDriver> drivers;
        private List<IDriver> driverss;
        public Race(string name,int laps)
        {
            this.Name = name;
            this.Laps = laps;
            driverss = new List<IDriver>();
            
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public int Laps 
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers { get { return driverss; } private set { this.drivers = value; } }

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("Driver cannot be null.");
            }
            if (driver.CanParticipate == false)
            {
                throw new ArgumentException($"Driver {driver.Name} could not participate in race.");
            }
            foreach (var item in this.drivers)
            {
                if (item == driver )
                {
                    throw new ArgumentNullException($"Driver {driver.Name} is already added in {this.name} race.");
                }
            }
           
            this.driverss.Add(driver);
           
        }
    }
}
