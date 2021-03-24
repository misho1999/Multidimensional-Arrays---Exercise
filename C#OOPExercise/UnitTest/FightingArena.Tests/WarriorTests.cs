using NUnit.Framework;
//using FightingArena;

namespace Tests
{
    using FightingArena;
    using System;

    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
            •	Name cannot be null, empty or whitespace.
            •	Damage cannot be zero or negative.
            •	HP cannot be negative.
            •	Warrior cannot attack if his HP are below 30.
            •	Warrior cannot attack Warriors which HP are below 30.
            •	Warrior cannot attack stronger enemies.
         */

        [Test]
        public void Warrior_Constructor()
        {
            Warrior warrior = new Warrior("ABC", 25, 50);
            var expectedName = "ABC";
            var expectedDmg = 25;
            var expectedHp = 50;
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDmg, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("   ")]
        [TestCase(null)]
        public void WarriorTest_ArguemtException_NameNullEmptyOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior(name, 6, 6));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-11)]
        [TestCase(-22)]
        public void WarriorTest_ArguemtException_DamageZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior("Bai Ivan", damage, 6));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-11)]
        [TestCase(-22)]
        public void WarriorTest_ArguemtException_HpNegative(int hp)
        {
            Assert.Throws<ArgumentException>
                (() => new Warrior("Bai Ivan", 11, hp));
        }

        [Test]
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(20)]
        [TestCase(10)]
        [TestCase(30)]
        public void WarriorTest_ArguemtException_WarriorCantAttackWithLessThan30Hp(int hp)
        {
            Warrior attacker = new Warrior("Bai Ivan", 10, hp);
            Warrior defender = new Warrior("Bai Pesho", 10, 40);

            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));

            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }

        [Test]
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(20)]
        [TestCase(10)]
        [TestCase(30)]
        public void WarriorTest_ArguemtException_WarriorCantBeAttackedWhenLessThan30Hp(int hp)
        {
            Warrior attacker = new Warrior("Bai Ivan", 10, 40);
            Warrior defender = new Warrior("Bai Pesho", 10, hp);

            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }

        [Test]
        [TestCase(58)]
        [TestCase(59)]
        [TestCase(50)]
        [TestCase(41)]
        public void WarriorTest_ArguemtException_AtackingStrongerOpponent(int dmg)
        {
            Warrior attacker = new Warrior("Bai Ivan", 10, 40);
            Warrior defender = new Warrior("Bai Pesho", dmg, 40);

            Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));
        }

        [Test]
        [TestCase(22, 40)]
        [TestCase(49, 40)]
        [TestCase(50, 40)]
        public void WarriorTest_Atacks_Correctly(int dmg, int hp)
        {
            Warrior attacker = new Warrior("Bai Ivan", dmg, hp);
            Warrior defender = new Warrior("Bai Pesho", 20, 50);

            attacker.Attack(defender);

            int expected = 50 - dmg;
            int actual = defender.HP;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(51, 40)]
        [TestCase(52, 40)]
        [TestCase(120, 40)]
        public void WarriorTest_Atacks_Correctly_WithMoreDamage(int dmg, int hp)
        {
            Warrior attacker = new Warrior("Bai Ivan", dmg, hp);
            Warrior defender = new Warrior("Bai Pesho", 20, 50);

            attacker.Attack(defender);

            int expected = 0;
            int actual = defender.HP;

            Assert.AreEqual(expected, actual);
        }
    }
}