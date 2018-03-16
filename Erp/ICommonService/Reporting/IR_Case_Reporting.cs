using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.Reporting
{
    /// <summary>
    /// 接口层R_Case_Reporting
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IR_Case_Reporting
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.Reporting.R_Case_Reporting model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.Reporting.R_Case_Reporting model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int ID);
        [OperationContract]
        bool DeleteAll();
        [OperationContract]
        bool DeleteList(string IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.Reporting.R_Case_Reporting GetModel(int ID);


        [OperationContract]
        int GetRecordCount(CommonService.Model.Reporting.V_Case_Reporting model);
        [OperationContract]
        List<CommonService.Model.Reporting.V_Case_Reporting> GetListByPage(CommonService.Model.Reporting.V_Case_Reporting model, string orderby, int startIndex, int endIndex);


        [OperationContract]
        List<CommonService.Model.Reporting.V_Case_Reporting> GetModelList(string strWhere);

        [OperationContract]
        void Statistics();
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
