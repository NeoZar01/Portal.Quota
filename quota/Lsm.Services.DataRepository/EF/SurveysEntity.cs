//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoE.Lsm.Data.Repositories.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class SurveysEntity
    {
        public System.Guid Id { get; set; }
        public string InterfaceSurveyId { get; set; }
        public string EntityId { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> InstalledOn { get; set; }
    }
}
