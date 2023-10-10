﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Valuegate.Infrastructure.Data;

namespace Valuegate.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);

            SaveChanges();

            return entity;
        }


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>

            _dbContext.Set<T>()
            .Where(expression);




        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            SaveChanges();

        }


        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression);
        }

        public IEnumerable<T> FindandInclude(Expression<Func<T, bool>> expression, bool eager)
        {
            var query = _dbContext.Set<T>().Where(expression);
            if (eager)
            {
                var navigations = _dbContext.Model.FindEntityType(typeof(T))
                    .GetDerivedTypesInclusive()
                    .SelectMany(type => type.GetNavigations())
                    .Distinct();

                foreach (var property in navigations)
                    query = query.Include(property.Name);
            }
            return query;
        }

        public IEnumerable<T> GetAll(bool eager)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (eager)
            {
                var navigations = _dbContext.Model.FindEntityType(typeof(T))
                    .GetDerivedTypesInclusive()
                    .SelectMany(type => type.GetNavigations())
                    .Distinct();

                foreach (var property in navigations)
                    query = query.Include(property.Name);
            }
            return query;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            SaveChanges();

        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            SaveChanges();
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }


    }
}
