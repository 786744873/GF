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
    public interface IC_Organization_post_user_role
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
        bool Exists(int C_Organization_post_user_role_id);


        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        bool Add(CommonService.Model.SysManager.C_Organization_post_user_role model);


        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.SysManager.C_Organization_post_user_role model);


        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_Organization_post_user_role_id);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool DeleteList(string C_Organization_post_user_role_idlist);


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.SysManager.C_Organization_post_user_role GetModel(int C_Organization_post_user_role_id);



        /// <summary>
        /// 根据组织机构Guid，用户Guid，岗位Guid,获取关联角色关系数据集合
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <param name="postCode">岗位Guid</param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization_post_user_role> GetOrgUserPostRoles(Guid orgCode, Guid userCode, Guid postCode);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization_post_user_role> GetModelList(string strWhere);

        /// <summary>
        /// 根据用户code获得集合
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.SysManager.C_Organization_post_user_role> GetListByUserCode(Guid userCode);


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return bll.GetList(PageSize,PageIndex,strWhere);
        //}


    }
}
