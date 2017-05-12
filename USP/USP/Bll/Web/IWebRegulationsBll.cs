using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Bll.Web
{
    public interface IWebRegulationsBll
    {
        AjaxResult Active(int id, long @operator);
        AjaxResult Add(WebRegulations model);
        AjaxResult Cancel(int id, long @operator);
        AjaxResult Audit(int id, long @operator);
        AjaxResult Edit(WebRegulations model, long @operator);
        //List<TreeNode> GetTree();
        List<WebRegulations> GetAll();
        List<SelectOption> GetWebRegulationsList(long id);
        WebRegulations GetModelById(long id);
        AjaxResult IsExisName(long id, string name);
        DataGrid<UP_ShowWebRegulations_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
    }
}
