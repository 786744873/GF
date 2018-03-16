using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.SysManager
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Organization_post_user_region
    {
        [OperationContract]
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int C_Organization_post_user_region_id);


        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.SysManager.C_Organization_post_user_region model);


        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Organization_post_user_region model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_Organization_post_user_region_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.SysManager.C_Organization_post_user_region GetModel(int C_Organization_post_user_region_id);

        /// <summary>
        /// 获取用户关联区域
        /// </summary>
        /// <param name="UserinfoCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization_post_user_region> GetListByUserinfoCode(Guid UserinfoCode);
        /// <summary>
        /// 获取用户区域
        /// </summary>
        /// <param name="orgCode"></param>
        /// <param name="userCode"></param>
        /// <param name="postCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization_post_user_region> GetOrgUserPostRegions(Guid orgCode, Guid userCode, Guid postCode);
    }
}
