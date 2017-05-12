using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Dal.Web
{
    public interface ITableDownLoadDal
    {
        bool IsExisName(long id, string name);
        List<TableDownLoad> GetAll();
        List<UP_ShowTableDownLoad_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
        TableDownLoad GetModelById(long ID);
        ProcResult Enable(long id, long currentOperator);
        ProcResult Edit(TableDownLoad model, long currentOperator);
        ProcResult Cancel(long id, long currentOperator);

        ProcResult Auditor(TableDownLoad model, long auditor);
        ProcResult Add(TableDownLoad model);
    }
}
