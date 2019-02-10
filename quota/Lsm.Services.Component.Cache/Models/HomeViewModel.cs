using System;
using System.Threading.Tasks;

namespace DoE.Lsm.Web.Models 
{
    using Core;
    using Core.Localization;
    using Data.Repositories;
    using Services.Api;
    using Services.Validations.Api;
    using Services.Validations.Rules;

    #region  Home page base builder model 

    public abstract class HomePageBuilder : BaseViewModel
    {
        public readonly GroupPolicyValidationRules gpValidationRule;
        public readonly RequisitionsSurveysValidationRule requisitionsValidationRule;

        public HomePageBuilder(string modelKey) : base(modelKey)
        {
            gpValidationRule = new GroupPolicyValidationRules();
            requisitionsValidationRule = new RequisitionsSurveysValidationRule();
        }

        public virtual HomePageBuilder ResolveHypertext<T>(IUnitOfWork repositoryManager, IValidationCallbackProvider callback, string entityId, string modelKey) where T : class
        {
            string  json = string.Empty;
                    gpValidationRule.ValidateGroupPolicy(callback, entityId, modelKey, out json);
            return null;
        }

        #region Properties
        public virtual string Page              { get; set; }
        public virtual string Status            { get; set; }
        public virtual string BookYear          { get; set; }
        public virtual string ExpiresOn         { get; set; }
        public virtual int DaysLeft             { get; set; }
        public virtual int InMemoryRequisitions { get; set; }
        public virtual int Rejects              { get; set; }
        public virtual int RejectsTotalPrice    { get; set; }
        public virtual int Approved             { get; set; }
        public virtual int ApprovedTotalPrice   { get; set; }
        #endregion
    }
    #endregion


    #region school Dashboard model

    public class SchoolHomePageViewModel : HomePageBuilder
    {
        private string output = "";
        public SchoolHomePageViewModel(string modelKey) : base(modelKey) {}

        public override HomePageBuilder ResolveHypertext<T>(IUnitOfWork uow, IValidationCallbackProvider callback, string instanceId, string identityId)
        {
            GPUpdate(identityId, _modelKey, callback, gpValidationRule);

//          var xprDate = uow.SnE.ExpiresOn;
            var xprDate    = DateTime.Now;
            var surveyCD   = ""; 

            requisitionsValidationRule.ValidateRequisitions(callback, xprDate, surveyCD, identityId, out output);

            return new SchoolHomePageViewModel(_modelKey)
            {
                Page        = "_mainpagedashboard_school",
                Status      = output,
                //BookYear    = uow.SnE.BookYear,
                BookYear    = "2017/2018",
                ExpiresOn   = Localization.ConvertToFormalFormat(xprDate, null),
                DaysLeft    = GlobalFunctions.RemainingDays(DateTime.Now, xprDate)
            };
        }
    }
    #endregion

    
   // [InstanceType(nameof(EntityType.Administrator), "Administrator")]
    public partial class AdministratorDashboardViewModel : HomePageBuilder
    {
        public AdministratorDashboardViewModel(string name) : base(name)  {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public override  HomePageBuilder ResolveHypertext<T>(IUnitOfWork repositoryManager, IValidationCallbackProvider callback, string instanceId, string identityId)
        {
            return  new AdministratorDashboardViewModel("")
            {
                Page                        = "_mainpagedashboard_administrator"
            };
        }
    }
}