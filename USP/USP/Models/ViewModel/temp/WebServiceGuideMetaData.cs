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
    
    
    public class WebServiceGuideMetaData
    {
        [Required]
        [Display(Name = "ID")]
        public virtual long ID
        {
            get;
            set;
        }
    	
        [StringLength(500, ErrorMessage="最多可输入500个字符")]
        [Display(Name = "业务标题")]
        public virtual string Title
        {
            get;
            set;
        }
    	
        [StringLength(250, ErrorMessage="最多可输入250个字符")]
        [Display(Name = "业务名称")]
        public virtual string GuideName
        {
            get;
            set;
        }
    	
        [StringLength(250, ErrorMessage="最多可输入250个字符")]
        [Display(Name = "受理部门")]
        public virtual string DealDeptName
        {
            get;
            set;
        }
    	
        [StringLength(500, ErrorMessage="最多可输入500个字符")]
        [Display(Name = "受理地址")]
        public virtual string DealAddress
        {
            get;
            set;
        }
    	
        [StringLength(250, ErrorMessage="最多可输入250个字符")]
        [Display(Name = "联系人")]
        public virtual string Contacts
        {
            get;
            set;
        }
        [Display(Name = "联系电话")]
        [StringLength(250, ErrorMessage="最多可输入250个字符")]
        public virtual string PhoneNumber
        {
            get;
            set;
        }
        [Display(Name = "受理时间")]
        [StringLength(500, ErrorMessage="最多可输入500个字符")]
        public virtual string DealTime
        {
            get;
            set;
        }
        [Display(Name = "设立依据")]
        public virtual string BaseEstablishment
        {
            get;
            set;
        }
        [Display(Name = "受理条件")]
        public virtual string EstablishmentCondition
        {
            get;
            set;
        }
        [Display(Name = "申请材料")]
        public virtual string ApplicationMaterials
        {
            get;
            set;
        }
        [Display(Name = "办理流程")]
        public virtual string ManagementProcess
        {
            get;
            set;
        }
        [Display(Name = "办理流程图")]
        public virtual string FlowChart
        {
            get;
            set;
        }
        [Display(Name = "浏览次数")]
        public virtual Nullable<long> BrowseCount
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
        [Display(Name = "审核时间")]
        public virtual Nullable<System.DateTime> AuditTime
        {
            get;
            set;
        }
        [Display(Name = "禁用人")]
        public virtual Nullable<long> Canceler
        {
            get;
            set;
        }
        [Display(Name = "禁用时间")]
        public virtual Nullable<System.DateTime> CancelTime
        {
            get;
            set;
        }
    }
}