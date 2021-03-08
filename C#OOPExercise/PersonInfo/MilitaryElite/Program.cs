using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,ISoldier> soldiers = new Dictionary<string, ISoldier>();
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }
                string[] parts = line.Split();
                string type = parts[0];
                string id = parts[1];
                string firstName = parts[2];
                string lastName = parts[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(parts[4]);
                    soldiers[id] = (new Private(id, firstName, lastName, salary));
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(parts[4]);
                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                    for (int i = 5; i < parts.Length; i++)
                    {
                        string privateId = parts[i];

                        if (!soldiers.ContainsKey(privateId))
                        {
                            continue;
                        }
                        lieutenantGeneral.AddPrivate((IPrivate)soldiers[privateId]);
                    }
                    soldiers[id] = (ISoldier)lieutenantGeneral;

                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(parts[4]);

                    bool isCorpsValid = Enum.TryParse(parts[5],out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }
                    IEngineer engineer = new Engineer(id, firstName, lastName, salary,corps);

                    for (int i = 6; i < parts.Length; i += 2)
                    {
                        string part = parts[i];
                        int hoursWorked = int.Parse(parts[i + 1]);

                        IRepair repair = new Repair(part, hoursWorked);
                        engineer.AddRepair(repair);

                    }
                    soldiers[id] = engineer;
                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(parts[4]);
                    bool isCorpsValid = Enum.TryParse(parts[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < parts.Length; i += 2)
                    {
                        string codeName = parts[i];
                        string state = parts[i + 1];

                        bool isMissionStateValid = Enum.TryParse(state, out MissionState missionState);

                        if (!isMissionStateValid)
                        {
                            continue;
                        }
                        IMission mission = new Mission(codeName, missionState);

                        commando.AddMission(mission);
                    }
                    soldiers[id] = commando;

                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(parts[4]);
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers[id] = spy;
                }

            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
