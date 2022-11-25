using System;
using System.Collections.Generic;

namespace P03.HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Class solution
            //List<Hero> heroList = new List<Hero>();
            Dictionary<string, int> heroesWithHP = new Dictionary<string, int>();
            Dictionary<string, int> heroesWithMP = new Dictionary<string, int>();

            InitializeHeroes(heroesWithHP, heroesWithMP);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                ProcessCommand(heroesWithMP, heroesWithHP, command);
            }

            PrintAliveHeroes(heroesWithHP, heroesWithMP);
        }

        static void InitializeHeroes(Dictionary<string, int> heroesWithHP, Dictionary<string, int> heroesWithMP)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] heroArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string heroName = heroArgs[0];
                int healthPoints = int.Parse(heroArgs[1]);
                int manaPoints = int.Parse(heroArgs[2]);

                heroesWithHP[heroName] = healthPoints;
                heroesWithMP[heroName] = manaPoints;
            }
        }

        static void ProcessCommand(Dictionary<string, int> heroesWithMP, Dictionary<string, int> heroesWithHP, string command)
        {
            string[] cmdArgs = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            string cmdType = cmdArgs[0];
            string heroName = cmdArgs[1];

            if (cmdType == "CastSpell")
            {
                int manaPointsNeeded = int.Parse(cmdArgs[2]);
                string spellName = cmdArgs[3];

                CastSpell(heroesWithMP, heroName, manaPointsNeeded, spellName);
            }
            else if (cmdType == "TakeDamage")
            {
                int damage = int.Parse(cmdArgs[2]);
                string attacker = cmdArgs[3];

                TakeDamage(heroesWithHP, heroesWithMP, heroName, damage, attacker);
            }
            else if (cmdType == "Recharge")
            {
                int amount = int.Parse(cmdArgs[2]);

                Recharge(heroesWithMP, heroName, amount);
            }
            else if (cmdType == "Heal")
            {
                int amount = int.Parse(cmdArgs[2]);

                Heal(heroesWithHP, heroName, amount);
            }
        }

        static void CastSpell(Dictionary<string, int> heroesWithMP, string heroName, int manaPointsNeeded, string spellName)
        {
            if (heroesWithMP[heroName] >= manaPointsNeeded)
            {
                heroesWithMP[heroName] -= manaPointsNeeded;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroesWithMP[heroName]} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }

        static void TakeDamage(Dictionary<string, int> heroesWithHP, Dictionary<string, int> heroesWithMP, string heroName, int damage, string attacker)
        {
            heroesWithHP[heroName] -= damage;
            if (heroesWithHP[heroName] > 0)
            {
                //Still alive
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroesWithHP[heroName]} HP left!");
            }
            else
            {
                heroesWithHP.Remove(heroName);
                heroesWithMP.Remove(heroName);

                Console.WriteLine($"{heroName} has been killed by {attacker}!");
            }
        }

        static void Recharge(Dictionary<string, int> heroesWithMP, string heroName, int amount)
        {
            if (heroesWithMP[heroName] + amount > 200)
            {
                amount = 200 - heroesWithMP[heroName]; //Max recharge
            }

            heroesWithMP[heroName] += amount;
            Console.WriteLine($"{heroName} recharged for {amount} MP!");
        }

        static void Heal(Dictionary<string, int> heroesWithHP, string heroName, int amount)
        {
            if (heroesWithHP[heroName] + amount > 100)
            {
                amount = 100 - heroesWithHP[heroName]; //Max recharge
            }

            heroesWithHP[heroName] += amount;
            Console.WriteLine($"{heroName} healed for {amount} HP!");
        }

        static void PrintAliveHeroes(Dictionary<string, int> heroesWithHP, Dictionary<string, int> heroesWithMP)
        {
            foreach (var kvp in heroesWithMP)
            {
                string heroName = kvp.Key;
                int manaPoints = kvp.Value;
                int healthPoints = heroesWithHP[heroName];

                Console.WriteLine($"{heroName}");
                Console.WriteLine($"  HP: {healthPoints}");
                Console.WriteLine($"  MP: {manaPoints}");
            }
        }
    }

    //TODO: Write up and solve using class
    class Hero
    {
        public Hero(string name, int helathPoints, int manaPoints)
        {
            Name = name;
            HelathPoints = helathPoints;
            ManaPoints = manaPoints;
        }

        public string Name { get; set; }

        public int HelathPoints { get; set; }

        public int ManaPoints { get; set; }

        public void Heal(int amount)
        {

        }

        public void Recharge(int amount)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
