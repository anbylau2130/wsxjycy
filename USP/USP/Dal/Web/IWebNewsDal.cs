using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Dal.Web
{
    public interface IWebNewsDal
    {
        bool IsExisName(long id, string name);
        List<WebNews> GetAll();
        List<UP_ShowWebNews_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
        WebNews GetModelById(long ID);
        ProcResult Enable(long id, long currentOperator);
        ProcResult Edit(WebNews model, long currentOperator);
        ProcResult Cancel(long id, long currentOperator);
        ProcResult Auditor(WebNews model, long auditor);
        ProcResult Add(WebNews model);
    }
}
