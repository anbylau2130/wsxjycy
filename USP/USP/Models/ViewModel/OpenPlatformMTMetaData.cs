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
    
    
    public class OpenPlatformMTMetaData
    {
        [Required] 
        public virtual long ID
        {
            get;
            set;
        }
    	
        [StringLength(100, ErrorMessage="最多可输入100个字符")]
        [Required] 
        public virtual string PlatformType
        {
            get;
            set;
        }
        [Required] 
        public virtual long Mo
        {
            get;
            set;
        }
        [Required] 
        public virtual long Msg
        {
            get;
            set;
        }
    	
        [StringLength(32, ErrorMessage="最多可输入32个字符")]
        [Required] 
        public virtual string ToUserName
        {
            get;
            set;
        }
    	
        [StringLength(32, ErrorMessage="最多可输入32个字符")]
        [Required] 
        public virtual string FromUserName
        {
            get;
            set;
        }
    	
        [StringLength(50, ErrorMessage="最多可输入50个字符")]
        [Required] 
        public virtual string MsgType
        {
            get;
            set;
        }
    	
        [StringLength(1000, ErrorMessage="最多可输入1000个字符")]
        [Required] 
        public virtual string Title
        {
            get;
            set;
        }
    	
        [StringLength(1000, ErrorMessage="最多可输入1000个字符")]
        [Required] 
        public virtual string Description
        {
            get;
            set;
        }
    	
        [StringLength(1000, ErrorMessage="最多可输入1000个字符")]
        [Required] 
        public virtual string PicUrl
        {
            get;
            set;
        }
        [Required] 
        public virtual string Content
        {
            get;
            set;
        }
    	
        [StringLength(200, ErrorMessage="最多可输入200个字符")]
        [Required] 
        public virtual string Children
        {
            get;
            set;
        }
        [Required] 
        public virtual byte Priority
        {
            get;
            set;
        }
        [Required] 
        public virtual System.DateTime SendTime
        {
            get;
            set;
        }
        [Required] 
        public virtual int ErrCode
        {
            get;
            set;
        }
    	
        [StringLength(100, ErrorMessage="最多可输入100个字符")]
        [Required] 
        public virtual string ErrMsg
        {
            get;
            set;
        }
    	
        [StringLength(250, ErrorMessage="最多可输入250个字符")]
        public virtual string Reserve
        {
            get;
            set;
        }
    	
        [StringLength(250, ErrorMessage="最多可输入250个字符")]
        public virtual string Remark
        {
            get;
            set;
        }
        public virtual Nullable<System.DateTime> PerformTime
        {
            get;
            set;
        }
        [Required] 
        public virtual System.DateTime PresentTime
        {
            get;
            set;
        }
        [Required] 
        public virtual long Presenter
        {
            get;
            set;
        }
        public virtual Nullable<System.DateTime> AuditTime
        {
            get;
            set;
        }
        public virtual Nullable<long> Auditor
        {
            get;
            set;
        }
    }
}
