using System;
using System.Linq;
using ContosoPizza.Models;
using ContosoPizza.Database;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Repository
{
    public class EfRepository<T> : IRepository<T> where T : EntityBase
    {
        private ContosoPizzaDb _db;

        public EfRepository(ContosoPizzaDb db)
        {
            _db = db;
        }

        private DbSet<T> _entity;

        protected DbSet<T> Entity
        {
            get
            {
                if (_entity == null)
                {
                    _entity = _db.Set<T>();
                }
                return _entity;
            }
        }

        public IQueryable<T> Table
        {
            get
            {
                return Entity.AsQueryable<T>();
            }
        }

        public void Delete(object id)
        {
            var _id = Entity.Find(id);
            _db.Remove(_id);
            _db.SaveChanges();
        }

        public void DeleteRange(IEnumerable<object> ids)
        {
            var user = new List<int>();
            foreach (var item in ids)
            {
                var tmp = (int)item;
                user.Add(tmp);
            }
            var ts = Entity.Where(x => user.Contains(x.Id)).ToList();
            _db.RemoveRange(ts);
            _db.SaveChanges();
        }

        public T GetById(object id)
        {
            return Entity.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            entity.IsActived = true;
            entity.IsDeleted = false;
            entity.DisplayOrder = 0;

            Entity.Add(entity);
            _db.SaveChanges();
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            entity.IsActived = true;
            entity.IsDeleted = false;
            entity.DisplayOrder = 0;

            await Entity.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsActived = true;
                entity.IsDeleted = false;
                entity.DisplayOrder = 0;
            }
            Entity.AddRange(entities);
            _db.SaveChanges();
        }

        public async Task InsertBulkAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsActived = true;
                entity.IsDeleted = false;
                entity.DisplayOrder = 0;
            }
            await Entity.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entity.UpdateTime = DateTime.Now;
            _db.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {

            Entity.UpdateRange(entities);
            _db.SaveChanges();
        }
    }


}