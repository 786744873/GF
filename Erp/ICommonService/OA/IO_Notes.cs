﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.OA
{
    /// <summary>
    /// 接口层O_Notes3.	便签表
    /// cyj
    /// 2015年7月14日15:45:02
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Notes
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]

        bool Exists(int O_Notes_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]

        int Add(CommonService.Model.OA.O_Notes model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]

        bool Update(CommonService.Model.OA.O_Notes model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]

        bool Delete(int O_Notes_id);
        [OperationContract]

        bool DeleteList(string O_Notes_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]

        CommonService.Model.OA.O_Notes GetModel(int O_Notes_id);
        /// <summary>
        /// 根据code得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.OA.O_Notes GetModelByCode(Guid O_Notes_code);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.OA.O_Notes> GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        [OperationContract]

        int GetRecordCount(string strWhere);
        [OperationContract]

        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}