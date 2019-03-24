using System.Threading.Tasks;

namespace DoE.Lsm.Web.Models
{
    using Annotations;
    using DoE.Web.Mvc.Api;
    using Data.Repositories;

    /// <summary>
    ///     
    /// </summary>
    [InstanceType(nameof(EntityType.School), "School")]
    public partial class SchoolDashboardViewModel : DashboardFactoryViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public override async Task<DashboardFactoryViewModel> TakeModel(string instanceId, IUnitOfWork uow)
        {        
            return await Task.FromResult( new SchoolDashboardViewModel {
                        Page     = "_mainpagedashboard_school"
            });
        }
    }

    /// <summary>
    ///     
    /// </summary>
    [InstanceType(nameof(EntityType.CircuitManager) , "CircuitManager")]
    public partial class CircuitDashboardViewModel : DashboardFactoryViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public override async Task<DashboardFactoryViewModel> TakeModel(string instanceId, IUnitOfWork dataSource)
        {
            return await Task.FromResult(new CircuitDashboardViewModel
            {
            });
        }
    }

    /// <summary>
    ///     
    /// </summary>
    [InstanceType(nameof(EntityType.Administrator), "Administrator")]
    public partial class AdministratorDashboardViewModel : DashboardFactoryViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public override async Task<DashboardFactoryViewModel> TakeModel(string instanceId, IUnitOfWork uow)
        {
            return await Task.FromResult(new AdministratorDashboardViewModel
            {   Page     = "_mainpagedashboard_administrator"
            });
        }
    }

    public abstract class DashboardFactoryViewModel
    {

        public virtual async Task<DashboardFactoryViewModel> TakeModel(string instanceId, IUnitOfWork uwo)
        {return await Task.FromResult(this);}

        public int IsThereInMemoryRequisitions    { get; set; }
        public string Page                        { get; set; }
        public string BookYear                    { get; set; }
        public int SubmittedRequisitions          { get; set; }
        public int SubmissionTotalPrice           { get; set; }
        public int InDrafts                       { get; set; }
        public int DraftsTotalPrice               { get; set; }
        public int Rejects                        { get; set; }
        public int RejectsTotalPrice              { get; set; }
        public int Approved                       { get; set; }
        public int ApprovedTotalPrice             { get; set; }
    }

    public class WebSearchViewModel
    {}

}