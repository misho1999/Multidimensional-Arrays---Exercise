using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public int Count => data.Count;
        public string Type { get; set; }

        public int Capacity { get; set; }

        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            this.data = new List<Car>();
        }

        public void Add(Car car)
        {

            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            foreach (var item in data)
            {
                if (item.Manufacturer == manufacturer && item.Model == model)
                {
                    data.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Car GetLatestCar()
        {
            int latestYear = 0;
            foreach (var item in data)
            {
                if (item.Year > latestYear)
                {
                    latestYear = item.Year;

                }
            }
            if (latestYear > 0)
            {
                foreach (var item in data)
                {
                    if (item.Year == latestYear)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            foreach (var item in data)
            {
                if (item.Manufacturer == manufacturer && item.Model == model)
                {
                    return item;
                }
            }
            return null;
        }

        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"The cars are parked in {Type}:");

            foreach (var item in data)
            {
                stringBuilder.AppendLine($"{item.Manufacturer} {item.Model} ({item.Year})");
            }
            return stringBuilder.ToString();
        }



    }
}
