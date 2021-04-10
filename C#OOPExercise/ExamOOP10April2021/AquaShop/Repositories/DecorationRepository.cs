using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public abstract class DecorationRepository<T> : IRepository<T>
    {
        private List<T> decorations;
        public DecorationRepository()
        {
            decorations = new List<T>();
        }
        public IReadOnlyCollection<T> Models
        {
            get
            {
                return this.decorations;
            }
            private set
            {
                this.Models = value;
            }
        }

        public void Add(T model)
        {
            decorations.Add(model);
        }

        public T FindByType(string type)
        {
            var output = decorations.FirstOrDefault(d => d.GetType().Name == type);
            return output;
        }

        public bool Remove(T model)
        {
            bool isRemove = false;
            foreach (IDecoration item in decorations)
            {
                if (item == (IDecoration)model)
                {
                    isRemove = true;
                }
            }
            if (isRemove)
            {
                decorations.Remove(model);
            }
            return isRemove;
        }
    }
}
