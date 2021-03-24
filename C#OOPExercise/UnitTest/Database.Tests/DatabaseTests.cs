using NUnit.Framework;
using System;
using System.Linq;


namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {

        
        private Database database;
        [SetUp]
        public void Setup()
        {

            this.database = new Database();

        }

        [Test]
        public void Add_AddElementToDatabase()
        {
            int element = 123;

            this.database.Add(element);
            int[] elements = this.database.Fetch();
            Assert.IsTrue(elements.Contains(element));

        }
        [Test]
        public void Add_IncreasesDatabaseCount_WhenAddIsValidOperation()
        {
            int n = 10;
            
            for (int i = 0; i < n; i++)
            {
                this.database.Add(123);
            }
            Assert.That(this.database.Count, Is.EqualTo(n));
        }
        [Test]
        public void When_TryToAdd17thElementShould_ThrowInvalidOperationException()
        {
            
            for (int i = 0; i < 16; i++)
            {
                this.database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }
        [Test]
        public void Remove_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void Remove_DereaseDatabaseCount() 
        {

            this.database.Add(1);
            this.database.Add(2);
            this.database.Add(3);

            this.database.Remove();
            int expectedCount = 2;
            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }
        [Test]
        public void Remove_DereasesElementFromDatabase()
        {

            int lastElement = 3;
            this.database.Add(1);
            this.database.Add(2);
            this.database.Add(3);

            this.database.Remove();
            int[] elements = database.Fetch();
            Assert.IsFalse(elements.Contains(lastElement));
        }
        [Test]
        public void Fetch_ReturnDatabaseCopyInsteadOfReference()
        {
            this.database.Add(1);
            this.database.Add(2);

            int[] firstCopy = this.database.Fetch();

            this.database.Add(3);

            int[] secondCopy = this.database.Fetch();

            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }
        [Test]
        public void Count_ReturnsZero_WhenDatabaseIsEmpty()
        {
            Assert.That(this.database.Count, Is.EqualTo(0));
        }
        [Test]
        public void Ctor_ThrowException_WhenDatabaseCapacityIsExceeded()
        {
            Assert.Throws<InvalidOperationException>(() => this.database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }
        [Test]
        public void Ctor_AddElementsToDatabase()
        {
            int[] arr = new[] { 1, 2, 3 };
            this.database = new Database(arr);
            Assert.That(this.database.Count, Is.EqualTo(arr.Length));
            Assert.That(this.database.Fetch(), Is.EquivalentTo(arr));
        }
    }
}