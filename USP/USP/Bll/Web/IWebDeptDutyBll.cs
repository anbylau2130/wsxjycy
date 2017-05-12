using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Bll.Web
{
    public interface IWebDeptDutyBll
    {
        AjaxResult Active(int id, long @operator);
        AjaxResult Add(WebDeptDuty model);
        AjaxResult Cancel(int id, long @operator);
        AjaxResult Audit(int id, long @operator);
        AjaxResult Edit(WebDeptDuty model, long @operator);
        //List<TreeNode> GetTree();
        List<WebDeptDuty> GetAll();
        List<SelectOption> GetWebDeptDutyList(long id);
        WebDeptDuty GetModelById(long id);
        AjaxResult IsExisName(long id, string name);
        DataGrid<UP_ShowWebDeptDuty_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
    }
}
