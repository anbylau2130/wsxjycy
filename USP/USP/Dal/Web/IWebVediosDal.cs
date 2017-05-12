using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Dal.Web
{
    public interface IWebVediosDal
    {
        bool IsExisName(long id, string name);
        List<WebVedios> GetAll();
        List<UP_ShowWebVedios_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
        WebVedios GetModelById(long ID);
        ProcResult Enable(long id, long currentOperator);
        ProcResult Edit(WebVedios model, long currentOperator);
        ProcResult Cancel(long id, long currentOperator);

        ProcResult Auditor(WebVedios model, long auditor);
        ProcResult Add(WebVedios model);
    }
}
