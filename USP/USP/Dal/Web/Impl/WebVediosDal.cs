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
    public class WebVediosDal : IWebVediosDal
    {
        USPEntities db = new USPEntities();
        public ProcResult Add(WebVedios model)
        {
            ProcResult result = new ProcResult();
            try
            {
                db.WebVedios.Add(model);
                result.IsSuccess = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                result.ProcMsg = ex.InnerException.Message;
                LogUtil.Exception("ExceptionLogger", ex);
            }
            return result;
        }

        public ProcResult Auditor(WebVedios model, long auditor)
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
                db.Entry<WebVedios>((WebVedios)entity).State = System.Data.Entity.EntityState.Modified;
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
                db.Entry<WebVedios>((WebVedios)entity).State = System.Data.Entity.EntityState.Modified;
                result.IsSuccess = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                result.ProcMsg = ex.InnerException.Message;
                LogUtil.Exception("ExceptionLogger", ex);

            }
            return result;
        }

        public ProcResult Edit(WebVedios model, long currentOperator)
        {
            ProcResult result = new ProcResult();
            try
            {
                model.Creator = currentOperator;
                model.CreateTime = DateTime.Now;
                db.WebVedios.Attach(model);
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
                db.Entry<WebVedios>((WebVedios)entity).State = System.Data.Entity.EntityState.Modified;
                result.IsSuccess = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                result.ProcMsg = ex.InnerException.Message;
                LogUtil.Exception("ExceptionLogger", ex);
            }
            return result;
        }

        public WebVedios GetModelById(long ID)
        {
            return db.WebVedios.FirstOrDefault(x => x.ID == ID);
        }

        public List<UP_ShowWebVedios_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType)
        {
            try
            {
                return (from i in db.UP_ShowWebVedios(pageIndex, pageSize, whereStr, strOrder, strOrderType).ToList()
                        select i).ToList();
            }
            catch (Exception ex)
            {
                LogUtil.Exception("ExceptionLogger", ex);
                return new List<UP_ShowWebVedios_Result>();
            }
        }
        public List<WebVedios> GetAll()
        {
            return db.WebVedios.ToList();
            //return db.WebVedios.Where(x => x.Canceler == null).ToList();
        }

        public bool IsExisName(long id, string name)
        {
            return db.WebVedios.Where(x => x.ID != id && x.Title == name).Count() > 0 ? true : false;
        }
    }
}