using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Dal.Web
{
    public interface IWebRegulationsDal
    {
        bool IsExisName(long id, string name);
        List<WebRegulations> GetAll();
        List<UP_ShowWebRegulations_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
        WebRegulations GetModelById(long ID);
        ProcResult Enable(long id, long currentOperator);
        ProcResult Edit(WebRegulations model, long currentOperator);
        ProcResult Cancel(long id, long currentOperator);
        ProcResult Auditor(WebRegulations model, long auditor);
        ProcResult Add(WebRegulations model);
    }
}
