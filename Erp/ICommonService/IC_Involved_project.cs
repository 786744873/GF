﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IC_Involved_project”。
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IC_Involved_project
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
        bool Exists(int C_Involved_project_id);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool ExistsByName(CommonService.Model.C_Involved_project model);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.C_Involved_project model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.C_Involved_project model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(Guid C_Involved_project_code);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Involved_project GetModelByCode(Guid C_Involved_project_code);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.C_Involved_project GetModel(int C_Involved_project_id);
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
         [OperationContract]
        List<CommonService.Model.C_Involved_project> GetAllList();
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        int GetRecordCount(CommonService.Model.C_Involved_project model);
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.C_Involved_project> GetListByPage(CommonService.Model.C_Involved_project model, string orderby, int startIndex, int endIndex);
    }
}