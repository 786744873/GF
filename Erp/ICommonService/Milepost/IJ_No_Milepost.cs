
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
namespace ICommonService.Milepost
{
    /// <summary>
    /// 接口层J_No_Milepost
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IJ_No_Milepost
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        [OperationContract]
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int J_No_Milepost_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.Milepost.J_No_Milepost model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.Milepost.J_No_Milepost model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int J_No_Milepost_id);
        [OperationContract]
        bool DeleteList(string J_No_Milepost_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.Milepost.J_No_Milepost GetModel(int J_No_Milepost_id);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.Milepost.J_No_Milepost model, bool IsPreSetManager, Guid? userCode, List<Guid?> depts);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.Milepost.J_No_Milepost> GetListByPage(CommonService.Model.Milepost.J_No_Milepost model, string orderby, int startIndex, int endIndex, bool IsPreSetManager, Guid? userCode, List<Guid?> depts);

        #endregion  MethodEx
    }
}
