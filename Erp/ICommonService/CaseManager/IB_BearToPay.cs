﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    /// <summary>
    /// 案件--费用承担契约接口
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_BearToPay
    {
        /// <summary>
        /// 得到最大ID
        /// </summary>
        [OperationContract]
        int GetMaxId();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int B_BearToPay_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_BearToPay model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_BearToPay model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int B_BearToPay_id);

        /// <summary>
        /// 根据案件GUID得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.CaseManager.B_BearToPay GetModel(Guid B_Case_code, int B_BearToPay_ctypes);
        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.CaseManager.B_BearToPay model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_BearToPay> GetListByPage(CommonService.Model.CaseManager.B_BearToPay model, string orderby, int startIndex, int endIndex);
    }
}
