//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace USP.Models.Entity
{
    using System;
    
    public partial class UP_GetMenuTemplate_Result
    {
        public long ID { get; set; }
        public long CorpType { get; set; }
        public string CorpTypeName { get; set; }
        public long Menu { get; set; }
        public string MenuName { get; set; }
        public long Creator { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<long> Auditor { get; set; }
        public Nullable<System.DateTime> AuditTime { get; set; }
        public Nullable<long> Canceler { get; set; }
        public Nullable<System.DateTime> CancelTime { get; set; }
    }
}
