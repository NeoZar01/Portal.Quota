
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DoE.Quota.Repositories.Data.EF
{

using System;
    using System.Collections.Generic;
    
public partial class BusinessRule
{

    public int Id { get; set; }

    public System.Guid RowGuid { get; set; }

    public string BRRNO { get; set; }

    public string BookYear { get; set; }

    public System.DateTime SODate { get; set; }

    public System.DateTime CreationDate { get; set; }

    public System.DateTime ExprDate { get; set; }

    public int BusinessYear { get; set; }

    public int BusinessTerm { get; set; }

    public Nullable<bool> IsActive { get; set; }

    public Nullable<int> EmisCode { get; set; }

    public string Application { get; set; }

    public byte Gr1 { get; set; }

    public byte Gr2 { get; set; }

    public byte Gr3 { get; set; }

    public byte Gr4 { get; set; }

    public byte Gr5 { get; set; }

    public byte Gr6 { get; set; }

    public byte Gr7 { get; set; }

    public byte Gr8 { get; set; }

    public byte Gr9 { get; set; }

    public byte Gr10 { get; set; }

    public byte Gr11 { get; set; }

    public byte Gr12 { get; set; }

}

}