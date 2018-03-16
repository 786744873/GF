using ICommonService.SysManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.SysManager
{
    public class C_Organization_post_user_region : IC_Organization_post_user_region
    {
        private readonly CommonService.BLL.SysManager.C_Organization_post_user_region bll = new CommonService.BLL.SysManager.C_Organization_post_user_region();
        /// <summary>
        /// 得到最大Id
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }
        /// <summary>
        /// 是否存在该条记录
        /// </summary>
        /// <param name="C_Organization_post_user_region_id"></param>
        /// <returns></returns>
        public bool Exists(int C_Organization_post_user_region_id)
        {
            return bll.Exists(C_Organization_post_user_region_id);
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Model.SysManager.C_Organization_post_user_region model)
        {
            if (bll.Add(model)==1)
            {
                return true;
            }else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.SysManager.C_Organization_post_user_region model)
        {
            return bll.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="C_Organization_post_user_region_id"></param>
        /// <returns></returns>
        public bool Delete(int C_Organization_post_user_region_id)
        {
            return bll.Delete(C_Organization_post_user_region_id);
        }
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="C_Organization_post_user_region_id"></param>
        /// <returns></returns>
        public Model.SysManager.C_Organization_post_user_region GetModel(int C_Organization_post_user_region_id)
        {
            return bll.GetModel(C_Organization_post_user_region_id);
        }
        public List<CommonService.Model.SysManager.C_Organization_post_user_region> GetOrgUserPostRegions(Guid orgCode, Guid userCode, Guid postCode)
        {
            return bll.GetOrgUserPostRegions(orgCode,userCode,postCode);
        }
        /// <summary>
        /// 获取用户关联区域
        /// </summary>
        /// <param name="UserinfoCode"></param>
        /// <returns></returns>
        public List<Model.SysManager.C_Organization_post_user_region> GetListByUserinfoCode(Guid UserinfoCode)
        {
            return bll.GetListByUserinfoCode(UserinfoCode);
        }
    }
}
