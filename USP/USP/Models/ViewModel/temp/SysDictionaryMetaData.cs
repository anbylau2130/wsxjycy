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
    
    
    public class SysDictionaryMetaData
    {
        [Required]
        [Display(Name = "唯一标识")]
        public virtual long ID
        {
            get;
            set;
        }
    	
        [StringLength(255, ErrorMessage="最多可输入255个字符")]
        [Required]
        [Display(Name = "节点名称")]
        public virtual string Name
        {
            get;
            set;
        }
        [Display(Name = "父节点ID")]
        public virtual Nullable<long> Parent
        {
            get;
            set;
        }
    	
        [StringLength(250, ErrorMessage="最多可输入250个字符")]
        [Display(Name = "备注")]
        public virtual string Reserve
        {
            get;
            set;
        }
    	
        [StringLength(250, ErrorMessage="最多可输入250个字符")]
        [Display(Name = "说明")]
        public virtual string Remark
        {
            get;
            set;
        }
        //[Required] 
        [Display(Name = "创建人")]
        public virtual long Creator
        {
            get;
            set;
        }
        [Display(Name = "节点类型")]
        [StringLength(50, ErrorMessage="最多可输入50个字符")]
        public virtual string Type
        {
            get;
            set;
        }
        //[Required] 
        [Display(Name = "创建时间")]
        public virtual System.DateTime CreateTime
        {
            get;
            set;
        }
        [Display(Name = "审核人")]
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