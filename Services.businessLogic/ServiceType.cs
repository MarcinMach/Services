//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Services.businessLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceType
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int ServiceID { get; set; }
        public string ServiceTypeName { get; set; }
        public Nullable<int> Amount { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }
    }
}
