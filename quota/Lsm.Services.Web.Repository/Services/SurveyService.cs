using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Services.Web.Repository
{

    using Api;
    using Data.Repositories.Models;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    public class SurveyService : ISurveyService
    {

        public Surveys LoadSurveyEntities(string emisCode)
        {
            throw new NotImplementedException();
        }

        #region Generic Repository implementations

        public IEnumerable<Surveys> Many(Expression<Func<Surveys, bool>> predicate, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Surveys> ManyAsync(Expression<Func<Surveys, bool>> predicate, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            throw new NotImplementedException();
        }

        public void Push(Surveys entity, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            throw new NotImplementedException();
        }

        public void PushRange(IEnumerable<Surveys> entities, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            throw new NotImplementedException();
        }

        public void Remove(Surveys entity, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Surveys> entities, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            throw new NotImplementedException();
        }

        public Surveys Single(int id, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            throw new NotImplementedException();
        }

        public Task<Surveys> SingleAsync(int id, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            throw new NotImplementedException();
        }

        public void TryPush(Surveys entity, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
