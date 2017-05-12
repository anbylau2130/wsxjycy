using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USP.Context;
using USP.Models.Entity;
using USP.Models.POCO;
using USP.Utility;

namespace USP.Dal.Web.Impl
{
    public class WebServiceGuideDal : IWebServiceGuideDal
    {
        USPEntities db = new USPEntities();
        public ProcResult Add(WebServiceGuide model)
        {
            ProcResult result = new ProcResult();
            try
            {
                db.WebServiceGuide.Add(model);
                result.IsSuccess = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                result.ProcMsg = ex.InnerException.Message;
                LogUtil.Exception("ExceptionLogger", ex);
            }
            return result;
        }

        public ProcResult Auditor(WebServiceGuide model, long auditor)
        {
            ProcResult result = new ProcResult();

            try
            {
                var entity = GetModelById(model.ID);
                if (entity != null)
                {
                    entity.Auditor = auditor;
                    entity.AuditTime = DateTime.Now;
                }
                db.Entry<WebServiceGuide>((WebServiceGuide)entity).State = System.Data.Entity.EntityState.Modified;
                result.IsSuccess = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                result.ProcMsg = ex.InnerException.Message;
                LogUtil.Exception("ExceptionLogger", ex);
            }
            return result;
        }


        public ProcResult Cancel(long id, long currentOperator)
        {
            ProcResult result = new ProcResult();
            try
            {
                var entity = GetModelById(id);
                if (entity != null)
                {
                    entity.Canceler = currentOperator;
                    entity.CancelTime = DateTime.Now;
                    entity.Auditor = null;
                    entity.AuditTime = null;
                }
                db.Entry<WebServiceGuide>((WebServiceGuide)entity).State = System.Data.Entity.EntityState.Modified;
                result.IsSuccess = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                result.ProcMsg = ex.InnerException.Message;
                LogUtil.Exception("ExceptionLogger", ex);

            }
            return result;
        }

        public ProcResult Edit(WebServiceGuide model, long currentOperator)
        {
            ProcResult result = new ProcResult();
            try
            {
                model.Creator = currentOperator;
                model.CreateTime = DateTime.Now;
                db.WebServiceGuide.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                result.IsSuccess = db.SaveChanges() > 0;
                return result;
            }
            catch (Exception ex)
            {
                result.ProcMsg = ex.InnerException.Message;
                LogUtil.Exception("ExceptionLogger", ex);
            }
            return result;
        }

        public ProcResult Enable(long id, long currentOperator)
        {
            ProcResult result = new ProcResult();
            try
            {
                var entity = GetModelById(id);
                if (entity != null)
                {
                    entity.Canceler = null;
                    entity.CancelTime = null;
                    entity.Auditor = currentOperator;
                    entity.AuditTime = DateTime.Now;
                }
                db.Entry<WebServiceGuide>((WebServiceGuide)entity).State = System.Data.Entity.EntityState.Modified;
                result.IsSuccess = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                result.ProcMsg = ex.InnerException.Message;
                LogUtil.Exception("ExceptionLogger", ex);
            }
            return result;
        }

        public WebServiceGuide GetModelById(long ID)
        {
            return db.WebServiceGuide.FirstOrDefault(x => x.ID == ID);
        }

        public List<UP_ShowWebServiceGuide_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType)
        {
            try
            {
                return (from i in db.UP_ShowWebServiceGuide(pageIndex, pageSize, whereStr, strOrder, strOrderType).ToList()
                        select i).ToList();
            }
            catch (Exception ex)
            {
                LogUtil.Exception("ExceptionLogger", ex);
                return new List<UP_ShowWebServiceGuide_Result>();
            }
        }
        public List<WebServiceGuide> GetAll()
        {
            return db.WebServiceGuide.ToList();
            //return db.WebServiceGuide.Where(x => x.Canceler == null).ToList();
        }

        public bool IsExisName(long id, string name)
        {
            return db.WebServiceGuide.Where(x => x.ID != id && x.Title == name).Count() > 0 ? true : false;
        }

    }


}