using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DoE.Quota.Repositories.BusinessServices
{
    using System.Data.SqlClient;
    using Core.Logger.Models;
    using Data.Models;
    using Services.Contracts;
    using Core.Repositories.Data.Models;

    public class SurveyService<TModel> : ISurveyService
    {

        #region Generic Repository implementations
        public void Add(Survey entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Survey> entities)
        {
            throw new NotImplementedException();
        }

        public void ExecuteCommand(CallStack callStack, string sql, out int tresult, params SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void ExecuteCommand<RModel>(CallStack callStack, string sql, out TResult<RModel> tresults, params SqlParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public Survey LoadSurveyEntities(string emisCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Survey> Many(Expression<Func<Survey, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Survey> ManyAsync(Expression<Func<Survey, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(Survey entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Survey> entities)
        {
            throw new NotImplementedException();
        }

        public Survey Single(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Survey> SingleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void TryAdd(Survey entity, CallStack callStack)
        {
            throw new NotImplementedException();
        }

        public void TryAddRange(IEnumerable<Survey> entities, CallStack callStack)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Survey> TryMany(Expression<Func<Survey, bool>> predicate, CallStack callStack)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Survey> TryManyAsync(Expression<Func<Survey, bool>> predicate, CallStack callStack)
        {
            throw new NotImplementedException();
        }

        public void TryRemove(Survey entity, Core.Logger.Models.CallStack callStack)
        {
            throw new NotImplementedException();
        }

        public void TryRemoveRange(IEnumerable<Survey> entities, Core.Logger.Models.CallStack callStack)
        {
            throw new NotImplementedException();
        }

        public Survey TrySingle(int id, Core.Logger.Models.CallStack callStack)
        {
            throw new NotImplementedException();
        }

        public Task<Survey> TrySingleAsync(int id, Core.Logger.Models.CallStack callStack)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}
