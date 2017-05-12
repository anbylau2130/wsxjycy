using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebSockets;
using USP.Bll;
using USP.Attributes;
using USP.Models.Entity;
using USP.Models.POCO;
using USP.Utility;
using System.Transactions;

namespace USP.Areas.System.Controllers
{
    [Menu(Name = "系统设置", Icon = "panel-icon  icon-cogs")]
    public class SystemController : Controller
    {
        ISystemBll systemBll;
        //ISupplierBll supplierBll;
        ISysOperatorBll operatorBll;
        //ISupplierGroupBll supplierGroupBll;
        //ISysOperaterSupplierBll operaterSupplierBll;

        public SystemController(ISystemBll systemBll,/* ISupplierBll supplierBll, ISupplierGroupBll supplierGroupBll,
            ISysOperaterSupplierBll operaterSupplierBll,*/ ISysOperatorBll operatorBll)
        {
            this.systemBll = systemBll;
            //this.supplierBll = supplierBll;
            //this.supplierGroupBll = supplierGroupBll;
            //this.operaterSupplierBll = operaterSupplierBll;
            this.operatorBll = operatorBll;
        }


        // GET: System/System
        public ActionResult Index()
        {
            return View();
        }



        //[MenuItem(Parent = "系统数据", Name = "控制器数据", Icon = "glyphicon glyphicon-info-sign")]
        public ActionResult Controller()
        {
            return View();
        }


        public ActionResult Controllers()
        {
            return Json(systemBll.getControllerGrid(), JsonRequestBehavior.AllowGet);
        }

        //[MenuItem(Parent = "系统数据", Name = "菜单数据", Icon = "glyphicon glyphicon-list")]
        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Menus()
        {
            return Json(systemBll.getMenuGrid(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Privileges()
        {
            return Json(systemBll.getPrivilegeGrid(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AssignMenu()
        {
            return Json(new
            {
                Count = systemBll.AssignMenu(),
                Msg = "菜单已分配给超级管理员"
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AssignPrivilege()
        {
            return Json(new
            {
                Count = systemBll.AssignPrivilege(),
                Msg = "权限已分配给超级管理员"
            }
                , JsonRequestBehavior.AllowGet);
        }


    }
}
