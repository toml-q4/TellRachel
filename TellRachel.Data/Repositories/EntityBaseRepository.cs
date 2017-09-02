﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TellRachel.Domain.Entities;

namespace TellRachel.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
        where T : class, IEntityBase, new()
    {
        protected readonly TellRachelContext Context;

        #region Properties
        public EntityBaseRepository(TellRachelContext context)
        {
            Context = context;
        }
        #endregion
        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsEnumerable();
        }

        public virtual int Count()
        {
            return Context.Set<T>().Count();
        }
        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public T GetSingle(Guid id)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T GetSingle(Guid id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault(x => x.Id == id);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = Context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = Context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = Context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                Context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public virtual bool Save()
        {
            return Context.SaveChanges() > 0;
        }

        public bool Exist(Guid id)
        {
            return Context.Set<T>().Any(x => x.Id == id);
        }

        public bool ExistWhere(Expression<Func<T, bool>> predicate) {
            return Context.Set<T>().Any(predicate);
        }
    }
}
