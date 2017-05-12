//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template made by Louis-Guillaume Morand.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace USP.Models.ViewModel
{
    
    
    public class TableDownLoadMetaData
    {
        [Required] 
        public virtual long ID
        {
            get;
            set;
        }
    	
        [StringLength(500, ErrorMessage="最多可输入500个字符")]
        [Display(Name ="表格标题")]
        public virtual string Title
        {
            get;
            set;
        }
    	
        [StringLength(8000, ErrorMessage="最多可输入8000个字符")]
        [Display(Name = "表格URL")]
        public virtual string TableUrl
        {
            get;
            set;
        }
        [Display(Name = "下载次数")]
        public virtual Nullable<long> DownLoadCount
        {
            get;
            set;
        }
    	
        [StringLength(250, ErrorMessage="最多可输入250个字符")]
        [Display(Name = "说明")]
        public virtual string Reserve
        {
            get;
            set;
        }
    	
        [StringLength(250, ErrorMessage="最多可输入250个字符")]
        [Display(Name = "备注")]
        public virtual string Remark
        {
            get;
            set;
        }
        [Display(Name = "创建人")]
        public virtual Nullable<long> Creator
        {
            get;
            set;
        }
        [Display(Name = "创建时间")]
        public virtual Nullable<System.DateTime> CreateTime
        {
            get;
            set;
        }
        [Display(Name = "审批人")]
        public virtual Nullable<long> Auditor
        {
            get;
            set;
        }
        [Display(Name = "审批时间")]
        public virtual Nullable<System.DateTime> AuditTime
        {
            get;
            set;
        }
        [Display(Name = "注销人")]
        public virtual Nullable<long> Canceler
        {
            get;
            set;
        }
        [Display(Name = "注销时间")]
        public virtual Nullable<System.DateTime> CancelTime
        {
            get;
            set;
        }
    }
}