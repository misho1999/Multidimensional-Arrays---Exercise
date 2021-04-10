namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;


    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;
        private List<Fish> list;
        [Test]
        public void ShouldReturnCorrectName()
        {
            aquarium = new Aquarium("Fish", 1);
            Assert.AreEqual(aquarium.Name, "Fish");
        }
        [Test]
        public void WhenNameIsNullOrEmpty_ShouldThrowException()
        {
            string param = "Invalid aquarium name!";
            string wrongName = null;
            var paramFail = typeof(ArgumentNullException);
            Exception ex = Assert.Throws<ArgumentNullException>(() =>
            {
                aquarium = new Aquarium(wrongName, 1);
            });

        }
        [Test]
        public void ShouldReturnCorrectCapacity()
        {
            aquarium = new Aquarium("Fish", 1);
            Assert.AreEqual(aquarium.Capacity, 1);
        }
        [Test]
        public void WhenCapacityIsNegative_ShouldThrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                aquarium = new Aquarium("Fish", -1);
            });
            Assert.AreEqual(ex.Message, "Invalid aquarium capacity!");
        }
        [Test]
        public void WhenCapacityIsFull_ShouldThrowException()
        {
            fish = new Fish("Pesho");
            Fish fish2 = new Fish("Peshos");
            aquarium = new Aquarium("Fish", 1);
            aquarium.Add(fish);
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish2);
            });
            Assert.AreEqual(ex.Message, "Aquarium is full!");
        }
        [Test]
        public void WhenHaveEnoughSpace_ShouldAddFishToAquarium()
        {
            fish = new Fish("Pesho");
            aquarium = new Aquarium("Fish", 1);
            aquarium.Add(fish);
            Assert.AreEqual(aquarium.Count, 1);
        }
        [Test]
        public void ShouldRemoveCorrectFishFromAquarium()
        {
            fish = new Fish("Pesho");
            aquarium = new Aquarium("Fish", 1);
            aquarium.Add(fish);
            aquarium.RemoveFish("Pesho");
            Assert.AreEqual(aquarium.Count, 0);
        }
        [Test]
        public void RemoveWhenFishNameDoesntExist_ShouldThrowException()
        {
            fish = new Fish("Pesho");
            aquarium = new Aquarium("Fish", 1);
            aquarium.Add(fish);
            string fishName = "Nqma go";
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(fishName);
            });
            Assert.AreEqual(ex.Message, $"Fish with the name {fishName} doesn't exist!");
        }
        [Test]
        public void SellWhenFishNameDoesntExist_ShouldThrowException()
        {
            fish = new Fish("Pesho");
            aquarium = new Aquarium("Fish", 1);
            aquarium.Add(fish);
            string fishName = "Nqma go";
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish(fishName);
            });
            Assert.AreEqual(ex.Message, $"Fish with the name {fishName} doesn't exist!");
        }

        [Test]
        public void ShouldSellCorrectFishFromAquarium()
        {
            fish = new Fish("Pesho");
            aquarium = new Aquarium("Fish", 1);
            aquarium.Add(fish);
            aquarium.SellFish("Pesho");
            Assert.AreEqual(fish.Available, false);
        }
        [Test]
        public void ShouldReturnCorrectFishFromAquarium()
        {
            fish = new Fish("Pesho");
            aquarium = new Aquarium("Fish", 1);
            aquarium.Add(fish);
            var fish2 = aquarium.SellFish("Pesho");
            Assert.AreEqual(fish, fish2);
        }
        [Test]
        public void ShouldReturnCorrectReportMessage()
        {
            fish = new Fish("Pesho");
            aquarium = new Aquarium("Fish", 1);
            aquarium.Add(fish);
            var fish2 = aquarium.Report();
            Assert.AreEqual(aquarium.Report(), fish2);
        }
    }
}
