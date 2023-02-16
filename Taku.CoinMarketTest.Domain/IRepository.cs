﻿using System.Linq.Expressions;

namespace Taku.CoinMarketTest.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIDAsync(object id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where = null);

        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> where = null);
        Task InsertAsync(TEntity entity);

        void Update(TEntity entity);
    }
}