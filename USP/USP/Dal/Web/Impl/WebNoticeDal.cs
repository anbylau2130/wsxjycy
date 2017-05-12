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
    public class WebNoticeDal : IWebNoticeDal
    {
        USPEntities db = new USPEntities();
        public ProcResult Add(WebNotice model)
        {
            ProcResult result = new ProcResult();
            try
            {
                db.WebNotice.Add(model);
                result.IsSuccess = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                result.ProcMsg = ex.InnerException.Message;
                LogUtil.Exception("ExceptionLogger", ex);
            }
            return result;
        }

        public ProcResult Auditor(WebNotice model, long auditor)
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
                db.Entry<WebNotice>((WebNotice)entity).State = System.Data.Entity.EntityState.Modified;
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
                db.Entry<WebNotice>((WebNotice)entity).State = System.Data.Entity.EntityState.Modified;
                result.IsSuccess = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                result.ProcMsg = ex.InnerException.Message;
                LogUtil.Exception("ExceptionLogger", ex);

            }
            return result;
        }
      
        public ProcResult Edit(WebNotice model, long currentOperator)
        {
            ProcResult result = new ProcResult();
            try
            {
                model.Creator = currentOperator;
                model.CreateTime = DateTime.Now;
                db.Set<WebNotice>().Attach(model);
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
                db.Entry<WebNotice>((WebNotice)entity).State = System.Data.Entity.EntityState.Modified;
                result.IsSuccess = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                result.ProcMsg = ex.InnerException.Message;
                LogUtil.Exception("ExceptionLogger", ex);
            }
            return result;
        }

        public WebNotice GetModelById(long ID)
        {
            return db.WebNotice.FirstOrDefault(x => x.ID == ID);
        }

        public List<UP_ShowNotice_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType)
        {
            try
            {
                return (from i in db.UP_ShowNotice(pageIndex, pageSize, whereStr, strOrder, strOrderType).ToList()
                        select i).ToList();
            }
            catch (Exception ex)
            {
                LogUtil.Exception("ExceptionLogger", ex);
                return new List<UP_ShowNotice_Result>();
            }
        }
        public List<WebNotice> GetAll()
        {
            return db.WebNotice.ToList();
            //return db.WebNotice.Where(x => x.Canceler == null).ToList();
        }

        public bool IsExisName(long id, string title)
        {
            return db.WebNotice.Where(x => x.ID != id && x.Title == title).Count() > 0 ? true : false;
        }

    }



}