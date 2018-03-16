using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.KMS
{
    /// <summary>
    /// 问题/文档/视频 关联业务流程表单表
    /// cyj
    /// 2016年1月13日10:29:55
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IK_PorblemAndResources_LinkCase
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int K_ProblemAndResources_LinkCase_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int K_ProblemAndResources_LinkCase_id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.KMS.K_PorblemAndResources_LinkCase GetModel(int K_ProblemAndResources_LinkCase_id);
        /// <summary>
        /// 根据实体得到数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.KMS.K_PorblemAndResources_LinkCase> GetListByModel(CommonService.Model.KMS.K_PorblemAndResources_LinkCase modelL);
        /// <summary>
        /// 根据实体得到对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        CommonService.Model.KMS.K_PorblemAndResources_LinkCase GetModelByModel(CommonService.Model.KMS.K_PorblemAndResources_LinkCase modelL);
        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        [OperationContract]
        bool MutilyAdd(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model);
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        [OperationContract]
        bool MutilyUpdate(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        [OperationContract]
        bool MutilyDelete(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model);


        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
