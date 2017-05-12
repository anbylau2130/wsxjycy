using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Bll.Web
{
    public interface IWebNewsBll
    {
        AjaxResult Active(int id, long @operator);
        AjaxResult Add(WebNews model);
        AjaxResult Cancel(int id, long @operator);
        AjaxResult Audit(int id, long @operator);
        AjaxResult Edit(WebNews model, long @operator);
        //List<TreeNode> GetTree();
        List<WebNews> GetAll();
        List<SelectOption> GetWebNewsList(long id);
        WebNews GetModelById(long id);
        AjaxResult IsExisName(long id, string name);
        DataGrid<UP_ShowWebNews_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
    }
}
