using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using USP.Bll;
using USP.Common;
using USP.Filters;
using USP.Models.Entity;
using USP.Models.POCO;
using USP.Service;
namespace USP.Controllers
{
    public class UserController : Controller
    {
        ISysOperatorBll SysOperatorBll;
        public UserController(ISysOperatorBll SysOperatorBll)
        {
            this.SysOperatorBll = SysOperatorBll;
        }

        public ActionResult Login()
        {
            Session.Abandon();
            Login login = new Login();
            login.Name = "";
            login.Password = "";
            //login.Name = "admin";
            //login.Password = "123456";
            return View();
        }

        public JsonResult IsLog()
        {
            if (((User)HttpContext.Session[Common.Constants.USER_KEY]) == null)
            {
                return Json(new AjaxResult()
                {
                    flag = false,
                    dateTime = DateTime.Now,
                    message = ""
                });
            }
            else
            {
                return Json(new AjaxResult()
                {
                    flag = true,
                    dateTime=DateTime.Now,
                    message = GetLoginHTMLInfo(((User)HttpContext.Session[Common.Constants.USER_KEY]).SysOperator.LoginName)
                });
            }
        }


        [HttpPost]
        public JsonResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                if (!login.Captcha.Equals(HttpContext.Session[Constants.CAPTCHA]))
                {
                    return Json(new AjaxResult()
                    {
                        flag = false,
                        message = "验证码输入错误",
                        dateTime = DateTime.Now,
                        returnUrl = null
                    });
                }

                var result = SysOperatorBll.Login(login, HttpContext);

                if (result.flag == true)
                {
                    result.returnUrl = "/Home/Index";
                    result.message = GetLoginHTMLInfo(((User)HttpContext.Session[Common.Constants.USER_KEY]).SysOperator.LoginName);
                    result.dateTime = DateTime.Now;
                    return Json(result);
                }
                else
                {
                    return Json(result);
                }
            }
            return Json(new AjaxResult()
            {
                flag = false,
                message = "数据校验失败！请检查用户名，密码或者验证码是否正确！",
                dateTime = DateTime.Now,
                returnUrl = null
            });
        }
        //[HttpPost]
        //public ActionResult Login(Login login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (!login.Captcha.Equals(HttpContext.Session[Constants.CAPTCHA]))
        //        {
        //            ModelState.AddModelError("Captcha", "验证码输入错误");
        //            return View("Login", login);
        //        }

        //        var result = SysOperatorBll.Login(login, HttpContext);

        //        if (result.flag == true)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            //ModelState.AddModelError("Name", "用户名或密码错误");
        //            //ModelState.AddModelError("Password", "密码或用户名错误");

        //            ModelState.AddModelError("Password", result.message);

        //            return View("Login", login);
        //        }
        //    }
        //    return View("Login", login);
        //}

        //public ActionResult CheckSso()
        //{
        //    return Json(SysOperatorBll.CheckSso(HttpContext), JsonRequestBehavior.AllowGet);
        //}


        private string GetLoginHTMLInfo(string userName)
        {
            return "<div id='memberInfo' class='pp5' style='height:144px'>" +
                                  "<table width='90%' border='0' align='center' cellpadding='0' cellspacing='0'>" +
                                      "<tbody>" +
                                      "<tr>" +
                                          "<td colspan='3' style='height: 40px;'>" + userName + "，欢迎登录</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                          "<td style='height:47px;'>" +
                                              "<a href='/Home/Index' class='btn_sub' style='width:92px;' target='_blank'>进入会员中心</a>" +
                                          "</td>" +
                                          "<td>&nbsp;</td>" +
                                          "<td><a href='javascript:logout();' class='btn_reg'>退出</a></td>" +
                                      "</tr>" +
                                          "<tr style='height:10px;'>" +
                                              "<td colspan='3'></td>" +
                                          "</tr>" +
                                      "</tbody>" +
                                  "</table>" +
                              "</div>";
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return new HttpUnauthorizedResult();
        }

        public ActionResult Registe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registe(Object obj)
        {
            return View();
        }


        [AuthorizeFilter]
        public ActionResult AuthorizeTest()
        {
            return View();
        }

        [PrivilegeFilter]
        public ActionResult PrivilegeTest()
        {
            return View();
        }
    }
}