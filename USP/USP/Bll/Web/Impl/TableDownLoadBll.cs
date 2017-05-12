using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USP.Dal.Web;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Bll.Web.Impl
{


    public class TableDownLoadBll : ITableDownLoadBll
    {

        ITableDownLoadDal dal;

        public TableDownLoadBll(ITableDownLoadDal dal)
        {
            this.dal = dal;
        }

        //public List<TreeNode> GetTree()
        //{
        //    List<TreeNode> resultTree = new List<TreeNode>();
        //    List<CommodityType> commodityTypeList = dal.GetAll();

        //    var parentList = commodityTypeList.Where(x => x.Parent == 0 || x.Parent == null).ToList();

        //    foreach (var model in parentList)
        //    {
        //        TreeNode tn = new TreeNode();
        //        tn.id = model.ID;
        //        tn.text = model.Name;
        //        tn.attributes = new
        //        {
        //            Group = model.Group,
        //            Creator = model.Creator,
        //            CreateTime = model.CreateTime,
        //            Auditor = model.Auditor,
        //            AuditTime = model.AuditTime,
        //            Canceler = model.Canceler,
        //            CancelTime = model.CancelTime,
        //            Remark = model.Remark,
        //            Reserve = model.Reserve
        //        };
        //        tn.children.AddRange(GetTree(model.ID, commodityTypeList));
        //        resultTree.Add(tn);
        //    }
        //    return resultTree;
        //}
        //public List<TreeNode> GetTree(long? id, List<CommodityType> allDict)
        //{
        //    List<TreeNode> result = new List<TreeNode>();

        //    var List = allDict.Where(x => x.Parent == id);
        //    foreach (var item in List)
        //    {
        //        TreeNode tn = new TreeNode();
        //        tn.id = item.ID;
        //        if (item.Canceler != null || item.CancelTime != null)
        //        {
        //            tn.text = "(禁用)" + item.Name;
        //        }
        //        else
        //        {
        //            tn.text = item.Name;
        //        }
        //        tn.attributes = new
        //        {
        //            Group = item.Group,
        //            Creator = item.Creator,
        //            CreateTime = item.CreateTime,
        //            Auditor = item.Auditor,
        //            AuditTime = item.AuditTime,
        //            Canceler = item.Canceler,
        //            CancelTime = item.CancelTime,
        //            Remark = item.Remark,
        //            Reserve = item.Reserve
        //        };
        //        var temp = allDict.Where(x => x.Parent == item.ID).ToList();
        //        if (temp.Count() > 0)
        //        {
        //            tn.children.AddRange(GetTree(item.ID, allDict));
        //        }
        //        result.Add(tn);
        //    }
        //    return result;
        //}
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
        public AjaxResult Add(TableDownLoad model)
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

        public AjaxResult Edit(TableDownLoad model, long @operator)
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

        public List<TableDownLoad> GetAll()
        {
            return dal.GetAll();
        }

        public List<SelectOption> GetTableDownLoadList(long id)
        {
            var entity = dal.GetAll();
            List<SelectOption> list = new List<SelectOption>();
            foreach (var v in entity)
            {
                var temp = new SelectOption()
                {
                    id = v.ID.ToString(),
                    text = v.Title,
                    selected = v.ID == id
                };
                list.Add(temp);
            }
            return list;
        }

        public TableDownLoad GetModelById(long id)
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

        public DataGrid<UP_ShowTableDownLoad_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType)
        {
            DataGrid<UP_ShowTableDownLoad_Result> result = new DataGrid<UP_ShowTableDownLoad_Result>();
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