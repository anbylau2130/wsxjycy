﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USP.Dal.Web;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Bll.Web.Impl
{
    public class WebDeptDutyBll : IWebDeptDutyBll
    {

        IWebDeptDutyDal dal;

        public WebDeptDutyBll(IWebDeptDutyDal dal)
        {
            this.dal = dal;
        }

        public AjaxResult Active(int id, long @operator)
        {
            AjaxResult result = new AjaxResult();
            var procResult = dal.Enable(id, @operator);
            result.flag = procResult.IsSuccess;
            if (procResult.IsSuccess)
            {
                result.message = "激活成功！";
            }
            else
            {
                result.message = procResult.ProcMsg;
            }

            return result;
        }
        public AjaxResult Audit(int id, long @operator)
        {
            AjaxResult result = new AjaxResult();
            var model = dal.GetModelById(id);
            var procResult = dal.Auditor(model, @operator);
            result.flag = procResult.IsSuccess;
            if (result.flag)
            {
                result.message = "审核成功！";
            }
            else
            {
                result.message = procResult.ProcMsg;
            }
            return result;
        }
        public AjaxResult Add(WebDeptDuty model)
        {
            AjaxResult result = new AjaxResult();
            var procResult = dal.Add(model);
            result.flag = procResult.IsSuccess;
            if (result.flag)
            {
                result.message = "新增成功！";
            }
            else
            {
                result.message = procResult.ProcMsg;
            }
            return result;

        }

        public AjaxResult Cancel(int id, long @operator)
        {
            AjaxResult result = new AjaxResult();
            var procResult = dal.Cancel(id, @operator);
            result.flag = procResult.IsSuccess;
            if (result.flag)
            {
                result.message = "注销成功！";
            }
            else
            {
                result.message = procResult.ProcMsg;
            }
            return result;
        }

        public AjaxResult Edit(WebDeptDuty model, long @operator)
        {
            AjaxResult result = new AjaxResult();
            var procResult = dal.Edit(model, @operator);
            result.flag = procResult.IsSuccess;
            if (result.flag)
            {
                result.message = "修改成功！";
            }
            else
            {
                result.message = procResult.ProcMsg;
            }
            return result;
        }

        public List<WebDeptDuty> GetAll()
        {
            return dal.GetAll();
        }

        public List<SelectOption> GetWebDeptDutyList(long id)
        {
            var entity = dal.GetAll();
            List<SelectOption> list = new List<SelectOption>();
            foreach (var v in entity)
            {
                var temp = new SelectOption()
                {
                    id = v.ID.ToString(),
                    text = v.DeptName,
                    selected = v.ID == id
                };
                list.Add(temp);
            }
            return list;
        }

        public WebDeptDuty GetModelById(long id)
        {
            return dal.GetModelById(id);
        }

        public AjaxResult IsExisName(long id, string name)
        {
            AjaxResult result = new AjaxResult();
            if (dal.IsExisName(id, name))
            {
                result.flag = true;
                result.message = "已经存在该名称！";
            }
            else
            {
                result.flag = false;
                result.message = "";
            }
            return result;
        }

        public DataGrid<UP_ShowWebDeptDuty_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType)
        {
            DataGrid<UP_ShowWebDeptDuty_Result> result = new DataGrid<UP_ShowWebDeptDuty_Result>();
            result.rows = dal.GetAll(pageIndex, pageSize, whereStr, strOrder, strOrderType);
            if (result.rows.Count > 0)
            {
                result.total = (long)result.rows[0].RowCnt;
            }
            return result;
            // return dal.GetAll(pageIndex, pageSize, whereStr, strOrder, strOrderType);
        }
    }
}