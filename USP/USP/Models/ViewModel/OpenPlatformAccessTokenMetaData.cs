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
    
    
    public class OpenPlatformAccessTokenMetaData
    {
        [Required] 
        public virtual long Corp
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
    	
        [StringLength(1024, ErrorMessage="最多可输入1024个字符")]
        [Required] 
        public virtual string AccessToken
        {
            get;
            set;
        }
        [Required] 
        public virtual System.DateTime AccessTime
        {
            get;
            set;
        }
        [Required] 
        public virtual long ExpiresIn
        {
            get;
            set;
        }
        [Required] 
        public virtual long Expires
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
        [Required] 
        public virtual System.DateTime CreateTime
        {
            get;
            set;
        }
    }
}
