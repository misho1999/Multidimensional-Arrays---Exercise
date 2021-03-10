using System;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BaseHero baseHero = null; ;
            int druidCount = 0;
            int paladinCount = 0;
            int rogueCount = 0;
            int warriorCount = 0;
            int n = int.Parse(Console.ReadLine());
            string output = string.Empty;
            int countDamage = 0;

            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                try
                {

                    if (heroType == "Druid")
                    {
                        if (druidCount == 0)
                        {
                            baseHero = new Druid(heroName);
                            druidCount++;
                        }
                        else
                        {
                            i--;
                            continue;
                        }

                    }
                    else if (heroType == "Paladin")
                    {
                        if (paladinCount == 0)
                        {
                            baseHero = new Paladin(heroName);
                            paladinCount++;
                        }
                        else
                        {
                            i--;
                            continue;
                        }
                    }
                    else if (heroType == "Rogue")
                    {
                        if (rogueCount == 0)
                        {
                            baseHero = new Rogue(heroName);
                            rogueCount++;
                        }
                        else
                        {
                            i--;
                            continue;
                        }
                    }
                    else if (heroType == "Warrior")
                    {
                        if (warriorCount == 0)
                        {
                            baseHero = new Warrior(heroName);
                            warriorCount++;
                        }
                        else
                        {
                            i--;
                            continue;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid hero!");

                    }

                }
                catch (InvalidOperationException ex)
                {
                    i--;
                    Console.WriteLine(ex.Message);
                    continue;
                }

                output = baseHero.CastAbility();

                Console.WriteLine(output);

                countDamage += baseHero.Power;


            }
            int bossHeal = int.Parse(Console.ReadLine());

            if (bossHeal <= countDamage)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
