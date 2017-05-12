using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USP.Models.Entity;
using USP.Models.POCO;

namespace USP.Bll.Web
{
        public interface IWebServiceGuideBll
        {
            AjaxResult Active(int id, long @operator);
            AjaxResult Add(WebServiceGuide model);
            AjaxResult Cancel(int id, long @operator);
            AjaxResult Audit(int id, long @operator);
            AjaxResult Edit(WebServiceGuide model, long @operator);
            //List<TreeNode> GetTree();
            List<WebServiceGuide> GetAll();
            List<SelectOption> GetWebServiceGuideList(long id);
            WebServiceGuide GetModelById(long id);
            AjaxResult IsExisName(long id, string name);
            DataGrid<UP_ShowWebServiceGuide_Result> GetAll(int? pageIndex, int? pageSize, string whereStr, string strOrder, string strOrderType);
        }
   
}
