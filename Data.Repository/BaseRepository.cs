﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.Data.Entitys;
using X.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    /// <summary>
    /// EntityFramework的仓储实现
    /// </summary>
    public class BaseRepository : IBaseRepository

    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<T> Update<T>(T entity, bool isCommit = true) where T : EntityBase
        {
            await _context.Set<T>().AddAsync(entity);
            if (isCommit)
                await Commit();
            return entity;
        }
        public IQueryable<T> Get<T>() where T : EntityBase
        {
            return _context.Set<T>();
        }
        public IQueryable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : EntityBase
        {
            return _context.Set<T>().Where(predicate);
        }
        public async Task<int> Delete<T>(Expression<Func<T, bool>> predicate) where T : EntityBase
        {
            var entitys = await _context.Set<T>().Where(predicate).ToArrayAsync();
            _context.Set<T>().RemoveRange(entitys);
            return await Commit();
        }
        public async Task<T> Put<T>(T entity, bool isCommit = true) where T : EntityBase
        {
            entity.Id = entity.Id == Guid.Empty
               ? EntityBase.NewId()
               : entity.Id;
            _context.Set<T>().Add(entity);
            if (isCommit)
                await Commit();
            return entity;
        }
        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

    }
}