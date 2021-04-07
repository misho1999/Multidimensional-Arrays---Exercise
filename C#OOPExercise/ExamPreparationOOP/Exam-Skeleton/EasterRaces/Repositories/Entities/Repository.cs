using EasterRaces.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly List<T> list;
        private IReadOnlyCollection<T> repositorys;
        private IReadOnlyCollection<T> Repositorys { get { return list; } set { this.repositorys = value; } }
        public Repository()
        {
            list = new List<T>();
        }
        public void Add(T model)
        {
           
            list.Add(model);
            repositorys = list;

        }

        public IReadOnlyCollection<T> GetAll()
        {
            repositorys = list;
            return repositorys;   
        }

        public T GetByName(string name)
        {
            var copy = list.FirstOrDefault(n => n.GetType().);
            return copy;
        }

        public bool Remove(T model)
        {
            if (list.Contains(model))
            {
                list.Remove(model);
                repositorys = list;
                return true;
            }
            return false;
        }
    }
}
