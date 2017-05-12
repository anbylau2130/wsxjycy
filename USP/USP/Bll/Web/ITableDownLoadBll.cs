using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Bll.Web
{
    public interface ITableDownLoadBll
    {
        AjaxResult Active(int id, long @operator);
        AjaxResult Add(TableDownLoad model);
        AjaxResult Cancel(int id, long @operator);
        AjaxResult Audit(int id, long @operator);
        AjaxResult Edit(TableDownLoad model, long @operator);
        //List<Models.POCO.TreeNode> GetTree();
        List<TableDownLoad> GetAll();
        List<SelectOption> GetTableDownLoadList(long id);
        TableDownLoad GetModelById(long id);
        AjaxResult IsExisName(long id, string name);
        DataGrid<UP_ShowTableDownLoad_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
    }
}
