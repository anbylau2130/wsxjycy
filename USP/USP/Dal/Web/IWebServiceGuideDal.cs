using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Dal.Web
{
    public interface IWebServiceGuideDal
    {
        bool IsExisName(long id, string name);
        List<WebServiceGuide> GetAll();
        List<UP_ShowWebServiceGuide_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
        WebServiceGuide GetModelById(long ID);
        ProcResult Enable(long id, long currentOperator);
        ProcResult Edit(WebServiceGuide model, long currentOperator);
        ProcResult Cancel(long id, long currentOperator);

        ProcResult Auditor(WebServiceGuide model, long auditor);
        ProcResult Add(WebServiceGuide model);
    }
}
