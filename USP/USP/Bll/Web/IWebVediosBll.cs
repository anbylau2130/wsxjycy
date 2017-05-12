using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Bll.Web
{
    public interface IWebVediosBll
    {
        AjaxResult Active(int id, long @operator);
        AjaxResult Add(WebVedios model);
        AjaxResult Cancel(int id, long @operator);
        AjaxResult Audit(int id, long @operator);
        AjaxResult Edit(WebVedios model, long @operator);
        List<WebVedios> GetAll();
        List<SelectOption> GetWebVediosList(long id);
        WebVedios GetModelById(long id);
        AjaxResult IsExisName(long id, string name);
        DataGrid<UP_ShowWebVedios_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
    }
}
