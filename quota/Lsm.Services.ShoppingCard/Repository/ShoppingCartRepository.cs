using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DoE.Lsm.Web.ShoppingCart
{
    using Lsm.ShoppingCart.Api;
    using Data.Repositories;
    using Data.Repositories.EF;

    using static Core.Constants.VettingOutcome;
    using global::Lsm.Services.Component.Requisitions.Api;
    using Services.Component.Cache.Proxies;
    using Services.Validations.Rules;
    using Services.Validations.Api;

    public class ShoppingCartRepository : IShoppingCartRepository
    {

        private readonly string bookYear;
        protected readonly IUnitOfWork       _repositoryManager;
        protected readonly IValidationCallbackProvider _validationCallbaksContainer;
        private readonly TeacherGuideValidationRule teacherGuideValidation;
        protected readonly ISurveyRepository _norms;


        public ShoppingCartRepository(IUnitOfWork repositoryManager, IValidationCallbackProvider validationCallbacksContainer, ISurveyRepository nrms )
        {
            this._repositoryManager            = repositoryManager;
            this.bookYear = "";// repositoryManager.SnE.BookYear;
            this._validationCallbaksContainer = validationCallbacksContainer;
            this._norms                        =  nrms;

            teacherGuideValidation = new TeacherGuideValidationRule(nrms.TEACHER_GUIDE_CD_OPTION_O1 , nrms.TEACHER_GUIDE_CD_OPTION_O2);
        }

        public async Task<int> AddToCardAsync(string inventoryId, string instanceId, string reqNo, string emisCode, string calendar,  string surveyKey, byte minGrade, byte maxGrade, string status, int quantity)
        {

            var inventoryItem = _repositoryManager.InventoryService.IsInventoryAvailable(inventoryId, quantity);

            if (inventoryItem == null) throw new ArgumentNullException("inventoryId");

            var quota = inventoryItem.Quota ?? 0;

            teacherGuideValidation.ActionTeacherGuideValidationWorker(_validationCallbaksContainer, quantity, ref quota, inventoryItem.CategoryCD, inventoryItem.Teacher_Enr);

            switch (teacherGuideValidation.output)
            {
             case Passed:

             var requisitionNumber = await _repositoryManager.RequisitionService.MergeUsingAsync<Requisition>(instanceId, reqNo, emisCode , minGrade , maxGrade , calendar , status, surveyKey );

             if (string.IsNullOrEmpty(requisitionNumber))
             {
                return 0;
             }

             try
             {
                _repositoryManager.InventoryService.UpdateInventory(inventoryId, quantity);
                _repositoryManager.InventoryService.SubEntityUpdatesCallback<Inventory, InventoryRequest>(instanceId, inventoryItem.InstanceId.ToString(), quantity, inventoryItem.CategoryCD, emisCode, inventoryItem.Price);
             }
             catch
             {
               return 0;
             }
               return 1;
             case Failed: return 0;
             default    : return 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reqId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IEnumerable<vw_ShoppingCardItems>> ShoppingCardListAsync(string reqId, int id)
        {
//            return _databaseContextRepository.RequisitionOrderItems.GetRequisitionOrderOItems(reqId, id, bookYear);
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="itemId"></param>
        public void RemoveFromCard( string entityType, string entityId, string itemId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="sender"></param>
        /// <param name="receiver"></param>
        /// <returns></returns>
        public async Task<int> CheckOut(string entityId, int sender, int receiver)
        {


            //var requisition = await _databaseContextRepository.Requisitions.GetRequisitionByReqNoAsync(reqId);

            //var task = new WF.Jobs.Task
            //{
            //    Receiver = receiver,
            //    Sender = sender,
            //    Action = WF.Jobs.Task.Activity.Submit
            //};

            ////            int wfTask = await Principal.ProcessRequestAsync<Education.Repository.EF.Requisition>(requisition, task);

            ////          return wfTask;
            //return 1;

            var testToken = 0;

            await Task.FromResult(testToken);

            throw new NotImplementedException();

        }

        public decimal GetTotalPrice<T>(string entityType, string entityId, int id) where T : class
        {
            return 0.00M;
        }

        public async Task<ShoppingCardModelProxy> LoadCartInstanceAsync(string instanceId)
        {

            if (_norms.EffectiveFrom >= _norms.ExpiresOn || DateTime.Today > _norms.ExpiresOn)
            {
                return new ShoppingCardModelProxy { ModelStatus = "INVALID" };
            }
                var validModel = new ShoppingCardModelProxy {  ModelStatus ="VALID" };

                return await Task.FromResult(validModel);             
        }
    }
}