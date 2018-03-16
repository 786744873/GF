using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppService
{
    public class BaseInfoDoc:IBaseInfoDoc
    {
        /// <summary>
        /// 区域业务逻辑层
        /// </summary>
        CommonService.BLL.C_Region regionBLL = new CommonService.BLL.C_Region();
        CommonService.BLL.SysManager.C_Organization oBLL = new CommonService.BLL.SysManager.C_Organization();
        CommonService.C_Parameters paraBLL = new CommonService.C_Parameters();

        #region App专用
        /// <summary>
        /// 根据父级ID获取子集参数
        /// </summary>
        /// <param name="id">父级ID</param>
        /// <returns>参数列表</returns>
        public List<CommonService.Model.C_Parameters> GetParametersByParentID(string id)
        {
            return paraBLL.AppGetParametersByParentID(Convert.ToInt32(id));
        }

        /// <summary>
        /// 获取所有特殊区域集合
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.C_Region> GetAllSpecialRegions()
        {
            return regionBLL.GetAllSpecialList();
        }


        #endregion

        
    }
}