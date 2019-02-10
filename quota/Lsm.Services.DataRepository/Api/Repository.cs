namespace DoE.Lsm.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using DoE.Lsm.Logger;
    using System.Runtime.CompilerServices;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        #region Constructor Implementations
        protected readonly DbContext _DbContext;
        protected readonly ILogger _logger;

        /// <summary>
        ///     This will default to [0] to prevent unwanted locking of entities.
        /// </summary>
        protected readonly bool requiresLock = false;

        public Repository(DbContext context, ILogger logger)
        {
            this._DbContext = context;
            this._logger    = logger;
        }

        #endregion
        //[CallStack]
        public virtual TEntity Single(int id, 
                                      [CallerMemberName] string memberName = "",
                                      [CallerFilePathAttribute] string filePath = "",
                                      [CallerLineNumberAttribute] int lineNumber = 0)
        {
            return _DbContext.Set<TEntity>().Find(id);
        }

        //[CallStack]
        public async virtual Task<TEntity> SingleAsync(int id, 
                                  [CallerMemberName] string memberName = "",
                                  [CallerFilePathAttribute] string filePath = "",
                                  [CallerLineNumberAttribute] int lineNumber = 0)
        {
            return await _DbContext.Set<TEntity>().FindAsync(id);
        }

        //[CallStack]
        public virtual void Push(TEntity entity, 
                                  [CallerMemberName] string memberName = "",
                                  [CallerFilePathAttribute] string filePath = "",
                                  [CallerLineNumberAttribute] int lineNumber = 0)
        {
            _DbContext.Set<TEntity>().Add(entity);
        }

        //[CallStack]
        public virtual void PushRange(IEnumerable<TEntity> entities, 
                                  [CallerMemberName] string memberName = "",
                                  [CallerFilePathAttribute] string filePath = "",
                                  [CallerLineNumberAttribute] int lineNumber = 0)
        {
            _DbContext.Set<TEntity>().AddRange(entities);
        }

        //[CallStack]
        public virtual IEnumerable<TEntity> ManyAsync(Expression<Func<TEntity , bool>> predicate, 
                                  [CallerMemberName] string memberName = "",
                                  [CallerFilePathAttribute] string filePath = "",
                                  [CallerLineNumberAttribute] int lineNumber = 0)
        {
            return _DbContext.Set<TEntity>().Where(predicate);
        }

        //[CallStack]
        public virtual void Remove(TEntity entity, 
                                  [CallerMemberName] string memberName = "",
                                  [CallerFilePathAttribute] string filePath = "",
                                  [CallerLineNumberAttribute] int lineNumber = 0)
        {
            _DbContext.Set<TEntity>().Remove(entity);
        }

        //[CallStack]
        public virtual void RemoveRange(IEnumerable<TEntity> entities, 
                                  [CallerMemberName] string memberName = "",
                                  [CallerFilePathAttribute] string filePath = "",
                                  [CallerLineNumberAttribute] int lineNumber = 0)
        {
            _DbContext.Set<TEntity>().RemoveRange(entities);
        }

        //[CallStack]
        public IEnumerable<TEntity> Many(Expression<Func<TEntity, bool>> predicate, 
                                  [CallerMemberName] string memberName = "",
                                  [CallerFilePathAttribute] string filePath = "",
                                  [CallerLineNumberAttribute] int lineNumber = 0)
        {
            return _DbContext.Set<TEntity>().Where(predicate);
        }

        //[WatchException]
        //[CallStack]
        public void TryPush(TEntity entity, 
                                  [CallerMemberName] string memberName  = "", 
                                  [CallerFilePath]   string filePath    = "", 
                                  [CallerLineNumber] int lineNumber     = 0)
        {
            try
            {
                _DbContext.Set<TEntity>().Add(entity);
            }
            catch
            {
                throw new ApplicationException("");
            }
        }
    }
}
