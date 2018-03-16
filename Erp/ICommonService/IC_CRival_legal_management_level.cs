﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICRival_legal_management_level”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_CRival_legal_management_level
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
        bool Exists(int C_CRival_legal_management_level_id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_CRival_legal_management_level model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_CRival_legal_management_level model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int C_CRival_legal_management_level_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_CRival_legal_management_level GetModel(int C_CRival_legal_management_level_id);

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_CRival_legal_management_level model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_CRival_legal_management_level> GetListByPage(CommonService.Model.C_CRival_legal_management_level model, string orderby, int startIndex, int endIndex);
    }
}