using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Dal.Web
{
    public interface IWebNoticeDal
    {
        bool IsExisName(long id, string name);
        List<WebNotice> GetAll();
        List<UP_ShowNotice_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
        WebNotice GetModelById(long ID);
        ProcResult Enable(long id, long currentOperator);
        ProcResult Edit(WebNotice model, long currentOperator);
        ProcResult Cancel(long id, long currentOperator);

        ProcResult Auditor(WebNotice model, long auditor);
        ProcResult Add(WebNotice model);
    }
}
