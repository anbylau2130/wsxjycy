using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USP.Bll.Web;

namespace USP.Controllers
{
    public class DefaultController : Controller
    {
        IWebNoticeBll webNoticeBll;
        IWebNewsBll webNewsBll;
        IWebVediosBll webVedioBll;
        IWebServiceGuideBll webServiceGuideBll;
        public DefaultController(IWebNoticeBll webNoticeBll, IWebNewsBll webNewsBll, IWebVediosBll webVedioBll, IWebServiceGuideBll webServiceGuideBll)
        {
            this.webNoticeBll = webNoticeBll;
            this.webNewsBll = webNewsBll;
            this.webVedioBll = webVedioBll;
            this.webServiceGuideBll = webServiceGuideBll;
        }
        // GET: Default
        public ActionResult Index()
        {
            ViewBag.WebNotice = webNoticeBll.GetAll(1, 6, " And Auditor is not null  And AuditTime is not null", " a.CreateTime ", " Desc ").rows.ToList();
            ViewBag.WebNews = webNewsBll.GetAll(1, 10, " And Auditor is not null  And AuditTime is not null ", " CreateTime ", "Desc").rows.ToList();
            ViewBag.WebVedios = webVedioBll.GetAll(1, 1, " And Auditor is not null  And AuditTime is not null ", " CreateTime ", "Desc").rows.ToList();
            ViewBag.WebNesThumbnail = webNewsBll.GetAll().Where(x => x.Reserve != null).OrderByDescending(x=>x.CreateTime).ToList();
            ViewBag.WebServiceGuide = webServiceGuideBll.GetAll(1, 8, " And Auditor is not null  And AuditTime is not null ", " CreateTime ", "Desc").rows.ToList();
            return View();
        }
        //政务公开
        public ActionResult OpenGovernment()
        {
            return View();
        }
        //政策法规
        public ActionResult Regulations()
        {
            return View();
        }

        //表格下载
        public ActionResult TableDownLoad()
        {
            return View();
        }

        //交流沟通
        public ActionResult Communication()
        {
            return View();
        }

        public ActionResult Jobs()
        {
            return View();
        }

        public ActionResult Organizations()
        {
            return View();
        }

        public ActionResult ServiceGuide()
        {
            return View();
        }

        public ActionResult Vedios()
        {
            return View();
        }

    }
}