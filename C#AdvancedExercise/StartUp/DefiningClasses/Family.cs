using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            this.Member = new List<Person>();
        }

            public List<Person> Member { get; set; }

        public void AddMember(Person person)
        {
            Member.Add(person);
        }
        public Person GetOldestMember()
        {

            Person oldestPerson = Member.OrderByDescending(x => x.Age).FirstOrDefault();

            return oldestPerson;
        }
        public List<Person> PrintPersonsAgeMoreThan30()
        {
            List<Person> ageMoreThan30Years = new List<Person>();
            foreach (var item in Member)
            {
                if (item.Age > 30)
                {
                Person ageMoreThan30 = item;
                    ageMoreThan30Years.Add(item);
                }
            }
            
            return ageMoreThan30Years;
        }


    }

}
