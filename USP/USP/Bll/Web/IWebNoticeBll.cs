using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Bll.Web
{
    public interface IWebNoticeBll
    {
        AjaxResult Active(int id, long @operator);
        AjaxResult Add(WebNotice model);
        AjaxResult Cancel(int id, long @operator);
        AjaxResult Audit(int id, long @operator); 
        AjaxResult Edit(WebNotice model, long @operator);
        //List<TreeNode> GetTree();
        List<WebNotice> GetAll();
        List<SelectOption> GetWebNoticeList(long id);
        WebNotice GetModelById(long id);
        AjaxResult IsExisName(long id, string name);
        DataGrid<UP_ShowNotice_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
    }
}
