using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoE.Quota.Repositories.Data.Api
{
    using EF;
    using Core.Repositories.Data.Contracts;


    public interface IRequisitionsRepository : IRepository<Requisition>
    {

        string LastInMemoryRequisition      { get; set; }
        string State                        { get; set; }


        bool MergeCondition(string instanceId, string requisitionNo, string emisCode, string calendar, out Requisition entity);
        Task<string> MergeUsingAsync<T>(string instanceId, string instanceReferenceValue, string emisCode, byte minGrade, byte maxGrade, string calendar, string status, string surveyKey) where T : class;

        //ExecutionResult Park(Requisition e, string stage, string state);
        //Task<ExecutionResult> ParkAsync(Requisition e, string stage, string state);
        Requisition FindByInstanceId(Guid entityId);
        Task<Requisition> GetRequisitionByEntityIdAsync(Guid requisitionNo);
        int RequisitionsPerCalendar(string emisEntityId, string calendar);
        decimal TotalPricePerCalendar(string emisId, string calendar, string status);
        IEnumerable<Requisition> GetRequisitionsByState(string emisCode, string stage , string state);
        Task<bool> IsInstanceReadWriteAsync(string reqNo, string emisId);
    }
}
