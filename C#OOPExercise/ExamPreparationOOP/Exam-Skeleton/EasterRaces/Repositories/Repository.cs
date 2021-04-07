using EasterRaces.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        private List<T> list;
        private IReadOnlyCollection<T> repositorys;
        private IReadOnlyCollection<T> Repositorys { get { return list; } set { this.repositorys = value; } }
        public void Add(T model)
        {
            
            list.Add(model);

        }

        public IReadOnlyCollection<T> GetAll()
        {
            return list;   
        }

        public T GetByName(string name)
        {
            var copy = list.FirstOrDefault(n => n.GetType().Name == name);
            return copy;
        }

        public bool Remove(T model)
        {
            if (list.Contains(model))
            {
                list.Remove(model);
                return true;
            }
            return false;
        }
    }
}
