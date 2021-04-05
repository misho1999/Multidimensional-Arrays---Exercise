using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private Stack<Item> poolItems;
		private Item item;
		private Character character;
		public WarController()
		{
			party = new List<Character>();
			poolItems = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

            if (characterType != "Warrior" && characterType != "Priest")
            {
				throw new ArgumentException(ExceptionMessages.InvalidCharacterType);
			}
            if (characterType == "Warrior")
            {
				character = new Warrior(name);
            }
			if (characterType == "Priest")
			{
				character = new Priest(name);
			}

				party.Add(character);
			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
            if (itemName != "FirePotion" && itemName != "HealthPotion")
            {
				throw new ArgumentException(ExceptionMessages.InvalidItem);
            }
            if (itemName == "FirePotion")
            {
				item = new FirePotion();
            }
            if (itemName == "HealthPotion")
            {
				item = new HealthPotion();
            }

			poolItems.Push(item);
			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			bool isValid = false;
			

			foreach (var item in party)
            {
                if (characterName == item.Name)
                {
					isValid = true;
					this.item = poolItems.Peek();
					 item.Bag.AddItem(poolItems.Pop());
                }
            }
            if (!isValid)
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty);
            }
            if (poolItems.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			return $"{characterName} picked up {this.item.GetType().Name}!";

		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			bool isValid = false;
			foreach (var item in party)
			{
				if (characterName == item.Name)
				{
					isValid = true;

					item.Bag.GetItem(itemName);
				}
			}
			if (!isValid)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty);
			}
			return $"{characterName} used {itemName}.";
		}

		public string GetStats()
		{
			party = party.OrderByDescending(a => a.IsAlive)
				.ThenByDescending(h => h.Health)
				.ToList();
			string result = "";
			string aliveOrDead = "";
            for (int i = 0; i < party.Count; i++)
            {
                if (party[i].IsAlive)
                {
					aliveOrDead = "Alive";
                }
                else
                {
					aliveOrDead = "Dead";
                }
				result += $"{party[i].Name} - HP: {party[i].Health}/{party[i].BaseHealth}, AP: {party[i].Armor}/{party[i].BaseArmor}, Status: {aliveOrDead}\r\n";
				if (party.Count == i)
                {
					continue;
                }
				//return result;
			}
			return result;
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];
			bool isAtacker = false;
			bool isReceiver = false;
			foreach (var item in party)
			{
				if (attackerName == item.Name)
				{
					isAtacker = true;
				}
                if (receiverName == item.Name)
                {
					isReceiver = true;
                }
			}
			if (!isAtacker || !isReceiver)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty);
			}

			string result = "";
			foreach (var atacker in party)
            {
                if (attackerName == atacker.Name)
                {
                    foreach (var receiver in party)
                    {
                        if (receiverName == receiver.Name )
                        {
							atacker.Attack(receiver);
							result = $"{attackerName} attacks {receiverName} for {atacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

							if (!receiver.IsAlive)
                            {
								 result = $"{attackerName} attacks {receiverName} for {atacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!\r\n" + 
									$"{receiver.Name} is dead!";
							}
						}
                    }
                }
            }

			return result;

		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];
			bool isAtacker = false;
			bool isReceiver = false;
			foreach (var item in party)
			{
				if (healerName == item.Name)
				{
					isAtacker = true;
				}
				if (healingReceiverName == item.Name)
				{
					isReceiver = true;
				}
			}
			if (!isAtacker || !isReceiver)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty);
			}
			string result = "";

			foreach (var healer in party)
			{
				if (healerName == healer.Name)
				{
					foreach (var receiver in party)
					{
						if (healingReceiverName == receiver.Name)
						{
							healer.Heal(receiver);
							result = $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
						}
					}
				}
			}
			return result;
		}
	}
}
