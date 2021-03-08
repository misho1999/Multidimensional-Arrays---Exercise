using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string birthDate, string id )
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthDate;
            this.Id = id;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; private set; }

        public string Birthdate { get; private set; }

        public string Id { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
