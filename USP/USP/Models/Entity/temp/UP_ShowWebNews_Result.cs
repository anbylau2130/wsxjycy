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
    
    public partial class UP_ShowWebNews_Result
    {
        public Nullable<long> RowNo { get; set; }
        public Nullable<long> RowCnt { get; set; }
        public long ID { get; set; }
        public string Title { get; set; }
        public Nullable<long> BroweCount { get; set; }
        public string Content { get; set; }
        public string Reserve { get; set; }
        public string Remark { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Auditor { get; set; }
        public Nullable<System.DateTime> AuditTime { get; set; }
        public string Canceler { get; set; }
        public Nullable<System.DateTime> CancelTime { get; set; }
    }
}
