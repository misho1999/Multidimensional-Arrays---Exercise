using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
//using ExtendedDatabase;

namespace Tests
{
    using ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        public Person pesho;
        public Person gosho;

        [SetUp]
        public void TestInit()
        {
            pesho = new Person(114560, "Pesho");
            gosho = new Person(447788556699, "Gosho");
        }

        [Test]
        public void ConstructorShoudInitializeCollection()
        {
            var expected = new Person[] { pesho, gosho };

            var db = new ExtendedDatabase(expected);

            var actual = expected;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddShouldAddValidPerson()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);
            var newPerson = new Person(554466, "Stamat");
            db.Add(newPerson);

            var expected = new Person[] { pesho, gosho, newPerson };
            var actual = expected;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddSameUsernameShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);
            var newPerson = new Person(554466, "Gosho");

            Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void AddSameIdShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);
            var newPerson = new Person(114560, "Stamat");

            Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldRemove()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);
            db.Remove();


            var expected = new Person[] { pesho };
            var actual = expected;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RemoveEmptyCollectionShouldThrow()
        {
            var persons = new Person[] { };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameExistingPersonShouldReturnPerson()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            var expected = pesho;
            var actual = db.FindByUsername("Pesho");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByUsernameNonExistingPersonShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername("Stamat"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNullArgumentShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameIsCaseSensitive()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername("GOSHO"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdExistingPersonShouldReturnPerson()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            var expected = pesho;
            var actual = db.FindById(114560);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByIdNonExistingPersonShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindById(558877), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNegativeArgumentShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindById(-5), Throws.Exception);
        }

        [Test]
        [TestCase(1, "Pesho")]
        [TestCase(444, "Iva")]
        [TestCase(999, "Sxema")]
        [TestCase(444, "Rima")]
        [TestCase(111, "Yuna")]
        public void Person_SuccessfulDataPass(long id, string userName)
        {
            Person person = new Person(id, userName);
            long expectedId = id;
            long actualId = person.Id;
            string expectedUsername = userName;
            string actualUsername = person.UserName;

            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(16)]
        public void ExtendedDB_Constructor_CorrectAmountOfData(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            ExtendedDatabase extDb = new ExtendedDatabase(people);

            int expected = people.Length;
            int actual = extDb.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConstructorPersonShouldInitializeCollection()
        {
            Assert.IsNotNull(pesho);
        }
        [Test]
        public void ConstructorExtendedDBShouldInitializeCollection()
        {
            var expected = new Person[] { pesho, gosho };

            var db = new ExtendedDatabase(expected);

            Assert.IsNotNull(db);
        }

        [Test]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(22)]
        [TestCase(555)]
        [TestCase(100)]
        [TestCase(1000)]
        public void AddRange_Throws_ArgumentException_WhenCountMoreThan16(int count)
        {
            Person[] data = new Person[count];
            Assert.Throws<ArgumentException>
                (() => new ExtendedDatabase(data));
        }

        [Test]
        [TestCase(13)]
        [TestCase(15)]
        [TestCase(14)]
        [TestCase(7)]
        [TestCase(1)]
        public void Add_WorksCorrectly_WhenCountIsLessThan16(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }
            ExtendedDatabase extDb = new ExtendedDatabase(people);

            extDb.Add(new Person(200, "Ivan" + 200));

            int expected = people.Length + 1;
            int actual = extDb.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(16)]
        public void Add_Throws_InvalidOperationException_WhenCountIs16(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }
            ExtendedDatabase extDb = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>
                (() => extDb.Add(new Person(200, "Ivan" + 200)));

        }


        [Test]
        [TestCase(16)]
        [TestCase(14)]
        [TestCase(11)]
        [TestCase(7)]
        public void Add_Throws_InvalidOperationException_UserNameExists(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }
            ExtendedDatabase extDb = new ExtendedDatabase(people);

            Person newExistingPerson = new Person(222, "Ivan" + 5);

            Assert.Throws<InvalidOperationException>
                (() => extDb.Add(newExistingPerson));

        }

        [Test]
        [TestCase(16)]
        [TestCase(14)]
        [TestCase(11)]
        [TestCase(7)]
        public void Add_Throws_InvalidOperationException_IdExists(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }
            ExtendedDatabase extDb = new ExtendedDatabase(people);

            Person newExistingPerson = new Person(5, "Ivan" + 222);

            Assert.Throws<InvalidOperationException>
                (() => extDb.Add(newExistingPerson));

        }

        [Test]
        [TestCase(1)]
        public void Remove_Throws_InvalidOperationException_CountIs0(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }
            ExtendedDatabase extDb = new ExtendedDatabase(people);

            extDb.Remove();

            Assert.Throws<InvalidOperationException>
                (() => extDb.Remove());
        }


        [Test]
        [TestCase(3)]
        [TestCase(15)]
        [TestCase(13)]
        [TestCase(11)]
        [TestCase(16)]
        public void Remove_Works_Correctly(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }
            ExtendedDatabase extDb = new ExtendedDatabase(people);

            extDb.Remove();
            extDb.Remove();
            extDb.Remove();

            int expected = people.Length - 3;
            int actual = extDb.Count;

            Assert.AreEqual(expected, actual);
            Assert.Throws<InvalidOperationException>
                (() => extDb.FindById(people.Length - 2));
            Assert.Throws<InvalidOperationException>
                (() => extDb.FindByUsername("Ivan" + (people.Length - 2)));
        }


        [Test]
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(14)]
        [TestCase(16)]
        [TestCase(8)]
        public void FindByUserName_Throws_InvalidOperationException_NoUserWithSuchName(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }
            ExtendedDatabase extDb = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>
                (() => extDb.FindByUsername("Pesho"));
        }

        [Test]
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(14)]
        [TestCase(16)]
        [TestCase(8)]
        public void FindByUserName_Throws_ArgumentNullException_UserNameGivenIsNull(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }
            ExtendedDatabase extDb = new ExtendedDatabase(people);

            Assert.Throws<ArgumentNullException>
                (() => extDb.FindByUsername(null));
        }



        [Test]
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(14)]
        [TestCase(16)]
        [TestCase(8)]
        public void FindById_Throws_InvalidOperationException_NoSuchID(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }
            ExtendedDatabase extDb = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>
                (() => extDb.FindById(123456));
        }

        [Test]
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(14)]
        [TestCase(16)]
        [TestCase(8)]
        public void FindById_Throws_ArgumentOutOfRangeException_NegativeID(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }
            ExtendedDatabase extDb = new ExtendedDatabase(people);

            Assert.Throws<ArgumentOutOfRangeException>
                (() => extDb.FindById(-3));
        }
    }
}