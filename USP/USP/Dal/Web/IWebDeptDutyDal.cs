using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Dal.Web
{
    public interface IWebDeptDutyDal
    {
        bool IsExisName(long id, string name);
        List<WebDeptDuty> GetAll();
        List<UP_ShowWebDeptDuty_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
        WebDeptDuty GetModelById(long ID);
        ProcResult Enable(long id, long currentOperator);
        ProcResult Edit(WebDeptDuty model, long currentOperator);
        ProcResult Cancel(long id, long currentOperator);
        ProcResult Auditor(WebDeptDuty model, long auditor);
        ProcResult Add(WebDeptDuty model);
    }
}
