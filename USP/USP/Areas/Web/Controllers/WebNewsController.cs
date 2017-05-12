using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USP.Attributes;
using USP.Bll.Web;
using USP.Common;
using USP.Controllers;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Areas.Web.Controllers
{
    public class WebNewsController : SysPrivilegeController
    {
        // GET: Web/WebNews
        IWebNewsBll webnewsBll;
        public WebNewsController(IWebNewsBll webnews)
        {
            this.webnewsBll = webnews;
        }

        [MenuItem(Parent = "网站管理", Name = "新闻中心", Icon = "glyphicon glyphicon-info-sign")]
        // GET: Supplier/Order
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
                case "indexdatagrid":
                    return IndexGetDataGrid();//列表页数据
                default:
                    return Content("");
            }
        }

        private ActionResult IndexGetDataGrid()
        {
            string wherestr = string.Empty;

            int page;
            if (!int.TryParse(Request["page"], out page))
            {
                page = 1;
            }
            int rows;
            if (!int.TryParse(Request["rows"], out rows))
            {
                rows = 10;
            }
            string type = Request["type"];
            string name = Request["name"];
            if (!string.IsNullOrEmpty(type))
            {
                wherestr += "  and [" + type + "] like '%" + name + "%' ";
            }
            var currentUser = HttpContext.Session[Constants.USER_KEY] as User;
            //if (currentUser != null&&currentUser.SysOperator.ID!=0)
            //    wherestr += " and FSUPPLIERID='" +currentUser.Supplier.FSUPPLIERID + "'";
            var result = webnewsBll.GetAll(page, rows, wherestr, "", "");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Privilege(Menu = "新闻中心", Name = "新增")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(WebNews model)
        {
            var currentUser = HttpContext.Session[Constants.USER_KEY] as USP.Models.POCO.User;
           
            if (ModelState.IsValid)
            {
                model.CreateTime = DateTime.Now;
                model.Creator = currentUser.SysOperator.ID;
                AjaxResult result = webnewsBll.Add(model);
                if (result.flag)
                {
                    TempData["returnMsgType"] = "success";
                    TempData["returnMsg"] = "添加成功";
                    return View("Index");
                }
                else
                {
                    TempData["returnMsgType"] = "error";
                    TempData["returnMsg"] = result.message;
                }
            }
            return View(model);
        }

        [Privilege(Menu = "新闻中心", Name = "修改")]
        public ActionResult Edit(string id)
        {
            long idParse;
            WebNews model = new WebNews();
            if (long.TryParse(id, out idParse))
            {
                model = webnewsBll.GetModelById(idParse);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(WebNews model)
        {
            var currentUser = HttpContext.Session[Constants.USER_KEY] as USP.Models.POCO.User;
            model.Creator = currentUser.SysOperator.ID;
            model.CreateTime = DateTime.Now;
            model.Auditor = null;
            model.AuditTime = null;
            if (ModelState.IsValid)
            {
                var result = webnewsBll.Edit(model, currentUser.SysOperator.ID);
                if (result.flag)
                {
                    TempData["isSuccess"] = "true";
                    TempData["MessageInfo"] = "完善信息成功!";
                    return View("Index");
                }
            }
            TempData["isSuccess"] = "false";
            TempData["MessageInfo"] = "完善信息失败!";
            return View(model);
        }


        [Privilege(Menu = "新闻中心", Name = "注销")]
        [HttpPost]
        public ActionResult Cancel(int id)
        {
            return Json(webnewsBll.Cancel(id, ((User)HttpContext.Session[Common.Constants.USER_KEY]).SysOperator.ID));
        }

        [Privilege(Menu = "新闻中心", Name = "激活")]
        [HttpPost]
        public ActionResult Active(int id)
        {
            return Json(webnewsBll.Active(id, ((User)HttpContext.Session[Common.Constants.USER_KEY]).SysOperator.ID));
        }
        [Privilege(Menu = "新闻中心", Name = "审核")]
        [HttpPost]
        public ActionResult Audit(int id)
        {
            return Json(webnewsBll.Audit(id, ((User)HttpContext.Session[Common.Constants.USER_KEY]).SysOperator.ID));
        }


    }
}