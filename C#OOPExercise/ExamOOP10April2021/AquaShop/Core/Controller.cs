using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<Decoration> decorationRepository;
        private List<IAquarium> aquarium;
        private FreshwaterAquarium freshwaterAquarium;
        private SaltwaterAquarium saltwaterAquarium;
        private Ornament ornament;
        private Plant plant;
        private IFish fish;
        public Controller()
        {
            aquarium = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                freshwaterAquarium = new FreshwaterAquarium(aquariumName);
                aquarium.Add(freshwaterAquarium);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                saltwaterAquarium = new SaltwaterAquarium(aquariumName);
                aquarium.Add(saltwaterAquarium);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                ornament = new Ornament();
                decorationRepository.Add(ornament);
            }
            if (decorationType == "Plant")
            {
                plant = new Plant();
                decorationRepository.Add(plant);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                string name = null;
                foreach (var item in aquarium)
                {
                    if (item.Name == aquariumName)
                    {
                        name = item.Name;
                    }
                }
                if (aquariumName == name)
                {
                    if (name == "SaltwaterAquarium")
                    {
                        saltwaterAquarium.AddFish(fish);
                        return $"Water not suitable.";
                    }

                }
                else
                {
                    freshwaterAquarium.AddFish(fish);
                }
            }
            if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
                string name = null;
                foreach (var item in aquarium)
                {
                    if (item.Name == aquariumName)
                    {
                        name = item.Name;
                    }
                }
                if (aquariumName == name)
                {
                    if (name == "SaltwaterAquarium")
                    {

                        freshwaterAquarium.AddFish(fish);
                        return $"Water not suitable.";
                    }
                }
                else
                {
                    saltwaterAquarium.AddFish(fish);
                }
            }
            return $"Successfully added {fishType} to {aquariumName}.";

        }

        public string CalculateValue(string aquariumName)
        {
            decimal aquariumValue = 0;
            foreach (var item in aquarium)
            {
                if (item.Name == aquariumName)
                {
                    var sumDecoration = item.Decorations.Sum(d => d.Price);
                    var sumFish = item.Fish.Sum(f => f.Price);
                    aquariumValue = sumDecoration + sumFish;
                }
            }
            return $"The value of Aquarium {aquariumName} is {aquariumValue:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            int fedCount = 0;
            foreach (var item in aquarium)
            {
                if (item.Name == aquariumName)
                {

                    freshwaterAquarium.Feed();
                }
            }
            fedCount = freshwaterAquarium.Fish.Count();
            return $"Fish fed: {fedCount}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var find = decorationRepository.FindByType(decorationType);

            if (find == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            var findAquarium = aquarium.FirstOrDefault(d => d.Name == aquariumName);
            foreach (var item in aquarium)
            {
                if (item.Name == aquariumName)
                {
                    item.AddDecoration(find);
                    decorationRepository.Remove(find);
                }
            }
            return $"Successfully added {decorationType} to {aquariumName}.";


        }

        public string Report()
        {
            string firstGetInfo = "";
            string secondGetInfo = "";
            foreach (var item in aquarium)
            {
                if (item.Name == "SaltwaterAquarium")
                {
                    firstGetInfo = item.GetInfo();
                }
                else
                {
                    secondGetInfo = item.GetInfo();
                }
            }
            return firstGetInfo + secondGetInfo;
        }
        public void Exit()
        {

        }
    }
}
