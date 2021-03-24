using NUnit.Framework;

namespace Tests
{
    using FightingArena;
    using System;
    using System.Collections.Generic;

    public class ArenaTests
    {
        private Warrior gosho;
        private Warrior pesho;

        [SetUp]
        public void Setup()
        {
            gosho = new Warrior("Gosho", 25, 35);
            pesho = new Warrior("Pesho", 20, 60);
        }

        [Test]
        public void Arena_Constr()
        {
            Arena arena = new Arena();
            var list = new List<Warrior>();
            CollectionAssert.AreEqual(list, arena.Warriors);
        }

        [Test]
        public void Arena_Enroll_InvalidOperationException_WarriorAlreadyEnrolled()
        {
            Arena arena = new Arena();
            arena.Enroll(gosho);
            Assert.Throws<InvalidOperationException>
                (() => arena.Enroll(gosho));
        }

        [Test]
        public void Arena_Enroll_CorrectList()
        {
            Arena arena = new Arena();
            arena.Enroll(gosho);
            arena.Enroll(pesho);

            var expected = new List<Warrior> { gosho, pesho };

            CollectionAssert.AreEqual(expected, arena.Warriors);
        }

        [Test]
        public void Arena_Enroll_CorrectList_Count()
        {
            Arena arena = new Arena();
            arena.Enroll(gosho);
            arena.Enroll(pesho);

            var expected = new List<Warrior> { gosho, pesho }.Count;
            var actual = arena.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Arena_Fight_InvalidOperationException_DefenderNotEnrolled()
        {
            Arena arena = new Arena();
            arena.Enroll(gosho);
            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Gosho", "Pesho"));
        }

        [Test]
        public void Arena_Fight_InvalidOperationException_AttackerNotEnrolled()
        {
            Arena arena = new Arena();
            arena.Enroll(pesho);
            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Gosho", "Pesho"));
        }

        [Test]
        public void Fight_Correctly()
        {
            Arena arena = new Arena();
            arena.Enroll(gosho);
            arena.Enroll(pesho);

            arena.Fight("Gosho", "Pesho");

            var expectedPeshoHp = 35;
            var actual = pesho.HP;
            Assert.AreEqual(expectedPeshoHp, actual);
        }
    }
}