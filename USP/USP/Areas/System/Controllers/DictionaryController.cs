using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USP.Attributes;
using USP.Bll;
using USP.Common;
using USP.Controllers;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Areas.System.Controllers
{
    public class DictionaryController : SysPrivilegeController
    {
       
        ISysDictionaryBll sysDictionaryBll;
     
        public DictionaryController(ISysDictionaryBll sysDictionaryBll)
        {
            this.sysDictionaryBll = sysDictionaryBll;
        }
        [MenuItem(Parent = "系统设置", Name = "字典管理", Icon = "icon-sitemap")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string actionName)
        {
            return OtherAction(actionName);
        }

        private ActionResult OtherAction(string ac)
        {
            switch (ac)
            {
                case "DictTree":
                    return GetDicTree();
              
                default:
                    return Content("");
            }
        }

        private ActionResult GetDicTree()
        {
           return  Json(sysDictionaryBll.GetDictTree(), JsonRequestBehavior.AllowGet);
        }

        
        [Privilege(Menu = "字典管理", Name = "注销")]
        [HttpPost]
        public ActionResult Cancel(int id)
        {
            return Json(sysDictionaryBll.Cancel(id, ((User)HttpContext.Session[Common.Constants.USER_KEY]).SysOperator.ID));
        }

        [Privilege(Menu = "字典管理", Name = "激活")]
        [HttpPost]
        public ActionResult Active(int id)
        {
            return Json(sysDictionaryBll.Active(id, ((User)HttpContext.Session[Common.Constants.USER_KEY]).SysOperator.ID));
        }

        [Privilege(Menu = "字典管理", Name = "新增")]
        [HttpPost]
        public ActionResult Add(SysDictionary model)
        {
            var currentUser = HttpContext.Session[Constants.USER_KEY] as USP.Models.POCO.User;
            model.CreateTime = DateTime.Now;
            model.Creator = currentUser.SysOperator.ID;
            AjaxResult result = new AjaxResult();
            if (ModelState.IsValid)
            {
                 result = sysDictionaryBll.Add(model);
            }
            return Json(result);
        }
        [Privilege(Menu = "字典管理", Name = "修改")]
        [HttpPost]
        public ActionResult Edit(SysDictionary model)
        {
            var currentUser = HttpContext.Session[Constants.USER_KEY] as USP.Models.POCO.User;
            model.Creator = currentUser.SysOperator.ID;
            model.CreateTime = DateTime.Now;
            model.Auditor = null;
            model.AuditTime = null;
            var result = new AjaxResult();
            if (ModelState.IsValid)
            {
                result=sysDictionaryBll.Edit(model, currentUser.SysOperator.ID);
            }
            return Json(result);
        }



        [Privilege(Menu = "字典管理", Name = "删除")]
        [HttpPost]
        public ActionResult Del(SysDictionary model)
        {
            var currentUser = HttpContext.Session[Constants.USER_KEY] as USP.Models.POCO.User;
            var result = sysDictionaryBll.Delete(model.ID);
            return Json(result);
        }
    }
}