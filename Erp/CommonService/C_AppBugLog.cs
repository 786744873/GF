using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    public class C_AppBugLog : IC_AppBugLog
    {
        CommonService.BLL.C_AppBugLog oBLL = new BLL.C_AppBugLog();


        public int AddAppBugLog(Model.C_AppBugLog model)
        {
           return oBLL.Add(model);
        }
    }
}
