using System;
using System.Collections.Generic;
using System.Linq;
using OpenRpg.Data.Queries;
using OpenRpg.Data.Repositories;

namespace OpenRpg.Demos.Web.Infrastructure.OpenRpg.Data
{
    public abstract class Repository<T, K> : IRepository<T, K>, IReadRepository<T, K>, IWriteRepository<T>
    {
        public List<T> Data { get; protected set; }

        public Repository(IEnumerable<T> data) => this.Data = data.ToList<T>();
        protected Repository() {}

        protected abstract K GetKeyFromEntity(T entity);

        public T Retrieve(K id) => this.Data.SingleOrDefault<T>((Func<T, bool>)(x => this.GetKeyFromEntity(x).Equals((object)id)));

        public IEnumerable<T> Find(IFindQuery<T> dataQuery) => dataQuery.Find((object)this.Data);

        public IEnumerable<T2> Find<T2>(IFindQuery<T2> dataQuery) => dataQuery.Find((object)this.Data);

        public void Create(T entry) => this.Data.Add(entry);

        public void Update(T entry)
        {
        }

        public void Delete(T entry) => this.Data.Remove(entry);
    }
}