using System;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace DoE.Lsm.Data.Repositories
{
    using EF;
    using Logger;
    using WF.Engine.Context;
    using Annotations.Exceptions;

    public class RequisitionRepository : RepositoryFactory<Requisition>, IRequisitionsRepository
    {

        private string _status;
        private string _requisitionInReadMemory;


        public async Task<string> MergeUsingAsync<T>(string instanceId, string requisitonNo, string emisCode, byte minGrade, byte maxGrade, string calendar, string status , string surveyKey) where T : class
        {
            try
            {

                Requisition entity = null;
                
                
                if (MergeCondition(instanceId , requisitonNo,  emisCode, calendar, out entity))
                {
                    entity.LastModifiedDate = DateTime.Now;
                    entity.Status = status;

                    return requisitonNo;
                }
                else
                {

                    var nwInstanceId = Guid.NewGuid();

                    entity = new Requisition
                            {   Calendar            = calendar,
                                EmisKey             = emisCode,
                                ReqNO               = requisitonNo,
                                GrFrom              = minGrade,
                                GrTo                = maxGrade,
                                CreationDate        = DateTime.Now,
                                LastModifiedDate    = DateTime.Now,
                                Status              = status,
                                SurveyKey           = surveyKey,
                                InstanceId          = nwInstanceId                                 
                    };

                    db.Requisitions.Add(entity);
                }

                var task = await db.SaveChangesAsync();

                return (ExecutionResult)task == ExecutionResult.Success ? entity.ReqNO : null;
            }
            catch
            {
                throw;
            }
        }


        #region Delegates & Helpers
        private delegate ExecutionResult WorkTask(int e);

        private PortalLsm db { get {return this._DbContext as PortalLsm;}}
        public RequisitionRepository(PortalLsm dbContext, ILogger logger) : base(dbContext, logger) { }
        #endregion


        #region Obsolete

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReqId"></param>
        /// <returns></returns>
        public ExecutionResult Park(Requisition requisition, string stage, string state)
        {
            requisition.LastModifiedDate = DateTime.Now;
            requisition.Status = state;

            try
            {
                return db.SaveChanges() == 1 ? ExecutionResult.Success : ExecutionResult.Failed;
            }
            catch
            {
                throw new InvalidDatabaseOperationException("There was an error processing your request. The Workflow engine failed to move your payload to another state");
            }
        }


        public async Task<Requisition> GetRequisitionByEntityIdAsync(Guid ReqId)
        {
            try
            {

                return await db.Requisitions
                                                .Where(c => c.ReqNO.Equals(ReqId))
                                                .SingleOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }


        public Requisition FindByInstanceId(Guid reqId)
        {
            try
            {
                return db.Requisitions
                                          .Where(c => c.InstanceId.Equals(reqId)).SingleOrDefault();
            }
            catch
            {
                return null;
            }
        }




        public async Task<ExecutionResult> ParkAsync(Requisition requisition, string stage, string state)
        {
            requisition.LastModifiedDate = DateTime.Now;
            requisition.Status = state;

            try
            {
                return await db.SaveChangesAsync() == 1 ? ExecutionResult.Success : ExecutionResult.Failed;
            }
            catch
            {
                throw;
            }
        }


        public string State
        {
            get
            {
                return _status;
            }

            set
            {
                var requisitionLinq = db.Requisitions.Where(c => (c.InstanceId.Equals( new Guid(value)))).SingleOrDefault();

                _status = requisitionLinq == null ? "INVALID" : requisitionLinq.Status;
            }
        }


        public string LastInMemoryRequisition
        {
            get
            {
                return _requisitionInReadMemory;
            }
            set
            {

                var requisition = db.Requisitions
                                           .Where(c => c.EmisKey.Equals(value) && c.Status.Equals("IN_MEMORY"))  //make sure it was never send to the drafts or denied
                                           .OrderByDescending((c) => c.LastModifiedDate) //order the last updated requisition
                                           .Take(1)           //take the first on the list
                                           .FirstOrDefault();  //just to be sure.     

                _requisitionInReadMemory = (requisition == null) ? null : requisition.ReqNO;

            }
        }

        public async Task<bool> IsInstanceReadWriteAsync(string reqNo, string emisId)
        {
            try
            {

                var requisitionQuery = await db.Requisitions
                                                                .Where(c => c.ReqNO.Equals(reqNo) && c.EmisKey.Equals(emisId))
                                                                .FirstOrDefaultAsync();

                if (requisitionQuery != null)
                return true;
                return false;
            }
            catch
            {
                return false;
            }


        }


        public IEnumerable<Requisition> GetRequisitionsByState(string emisId, string stage, string state)
        {
            return db.Requisitions
                                      .Where(c => c.EmisKey.Equals(emisId) && c.Status.Equals(state))
                                      .OrderByDescending(c => c.CreationDate);
        }

        public int RequisitionsPerCalendar(string emisEntityId, string calendar)
        {
            try
            {
                return  db.Requisitions
                                           .Where(c => c.EmisKey == emisEntityId && (c.Calendar.Equals(calendar)))
                                           .Count();
            }
            catch
            {
                return 0;
            }
        }


        public decimal TotalPricePerCalendar(string emisId, string calendar, string state)
        {

            try
            {
                var sumLinq = db.Requisitions
                                                .Where(c => c.EmisKey == emisId && c.Calendar.Equals(calendar) && c.Status == state)
                                                .Sum(c => c.TotalPrice);

                return sumLinq != null ?  Math.Round(sumLinq ?? 0, 2, MidpointRounding.AwayFromZero) : 0M;
            }
            catch
            {
                return 0M;
            }
        }


        public bool MergeCondition(string instanceId,  string requisitionNo , string emisCode, string calendar, out Requisition entity)
        {

            if (string.IsNullOrEmpty(instanceId)) throw new ArgumentNullException("instanceId");

            var entityId = Guid.Parse(instanceId);

            try
            {

                entity = db.Requisitions.Where(c => c.InstanceId.Equals(entityId))
                                        .Where(c => c.EmisKey.Equals(emisCode))
                                        .Where(c => c.Calendar.Equals(calendar))
                                        .Where(c => c.ReqNO.Equals(requisitionNo))
                                        .SingleOrDefault();
                return true;

            }
            catch
            {
                entity = null;

                return false;
            }
        }

        #endregion
    }
}