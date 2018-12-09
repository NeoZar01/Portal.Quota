﻿namespace DoE.Lsm.Data.Repositories
{
    using System;
    using UI;
    using Norms;
    using Persons;
    using Subcity;
    using Orders;
    using Profile;
    using Inventories;

    public interface IRepositoryStoreManager : IDisposable
    {

        ///<summary>
        ///      Handles inventory queries
        ///</summary>
        InventoryRepository InventoryRegistry
        { get; set; }


        RequisitionRepository RequisitionsStoreManager
        { get; set; }

        ///<summary>
        ///     Handles scales and norms queries.
        ///   <remark> This should be a read-only class</remark>
        ///</summary>
        SurveyRepository SnE
        { get; set; }

        #region ProfileStore
        ///<summary>
        ///    Handles profile related queries.
        ///    The <c>ASPNETProfile entity should no longer be used since we split it into </c>
        ///    <see> <c>IPrinciple</c> class and how we can extend its methods to add more custom queries.All methods in this class should be moved to this customization. </see>
        ///</summary>
        [Obsolete]
        ProfileRepository ProfileStore
        { get; set; }

        PersonRepository Person
        { get; set; }



        #endregion

        OrderRepository Orders
        { get; set; }

        RequisitionSubcityRepository Subcity
        { get; set; }

        UIManagerRepository UI
        { get; set; }

    }
}
