using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace DoE.Lsm.Web.Models
{

    using Data.Repositories;
    using global::Lsm.Core.Global;
    using ShoppingCart.Norms.Validations.Api;
    using ShoppingCart.Norms.Validations.Rules;

    /// <summary>
    ///     
    /// </summary>
    //[InstanceType(nameof(EntityType.School), "School")]
    public partial class SchoolDashboardViewModel : DashboardFactoryViewModel
    {


        private RequisitionsSurveysValidationRule requisitionsValidationRule;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public override async Task<DashboardFactoryViewModel> ReturnModel(IRepositoryStoreManager repositoryManager, IValidationCallbackContainer callback , string instanceId,  string identityId)
        {

            requisitionsValidationRule = new RequisitionsSurveysValidationRule();

            string output = "";
            var xprDate = repositoryManager.SnE.ExpiresOn;

            requisitionsValidationRule.ActionRequisitionsValidationWorker(callback, xprDate,  repositoryManager.SnE.SurveyCD , identityId,  out output);

            return await Task.FromResult(new SchoolDashboardViewModel
            {
                Page                        = "_mainpagedashboard_school",
                ModelsStatusRequisitions    = output,
                BookYear                    = repositoryManager.SnE.BookYear,
                ExpiresOn                   = GlobalFormatics.ConvertToFormalFormat(xprDate, null),
                DaysLeft                    = GlobalFormatics.RemainingDays(DateTime.Now , xprDate) 
            });
        }
    }

    /// <summary>
    ///     
    /// </summary>
    //[InstanceType(nameof(EntityType.CircuitManager), "CircuitManager")]
    public partial class CircuitDashboardViewModel : DashboardFactoryViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public override async Task<DashboardFactoryViewModel> ReturnModel(IRepositoryStoreManager repositoryManager, IValidationCallbackContainer callback, string instanceId, string identityId)
        {
            return await Task.FromResult(new CircuitDashboardViewModel
            {
            });
        }
    }

    /// <summary>
    ///     
    /// </summary>
   // [InstanceType(nameof(EntityType.Administrator), "Administrator")]
    public partial class AdministratorDashboardViewModel : DashboardFactoryViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public override async Task<DashboardFactoryViewModel> ReturnModel(IRepositoryStoreManager repositoryManager, IValidationCallbackContainer callback, string instanceId, string identityId)
        {
            return await Task.FromResult(new AdministratorDashboardViewModel
            {
                Page                        = "_mainpagedashboard_administrator"
            });
        }
    }

    public abstract class DashboardFactoryViewModel
    {
        public DashboardFactoryViewModel()
        { }

        public virtual async Task<DashboardFactoryViewModel> ReturnModel(IRepositoryStoreManager repositoryManager, IValidationCallbackContainer callback, string instanceId, string identityId)
        { return await Task.FromResult(this); }


        /// <summary>
        /// 
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ModelsStatusRequisitions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BookYear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ExpiresOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DaysLeft { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int InMemoryRequisitions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Rejects { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RejectsTotalPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Approved { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ApprovedTotalPrice { get; set; }

    }

    public class WebSearchViewModel
    { }

}