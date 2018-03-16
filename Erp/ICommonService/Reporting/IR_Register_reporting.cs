using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.Reporting
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IR_Register_reporting
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
        int Add(CommonService.Model.Reporting.R_Register_reporting model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.Reporting.R_Register_reporting model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int ID);
        [OperationContract]
        bool DeleteList(string IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.Reporting.R_Register_reporting GetModel(int ID);


        [OperationContract]
        int GetRecordCount(CommonService.Model.Reporting.V_Register_reporting model);
        [OperationContract]
        List<CommonService.Model.Reporting.R_Register_reporting> GetListByPage(CommonService.Model.Reporting.V_Register_reporting model, string orderby, int startIndex, int endIndex);


        [OperationContract]
        List<CommonService.Model.Reporting.V_Register_reporting> GetModelList(string strWhere);

        [OperationContract]
        void Statistics();

        /// <summary>
        /// 统计虚拟表数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [OperationContract]
        int GetDataListCount(CommonService.Model.Reporting.V_Register_reporting model, int type);

        /// <summary>
        /// 分页获取虚拟表的值
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        [OperationContract]
        List<CommonService.Model.Reporting.V_Register_statistics> GetDataList(CommonService.Model.Reporting.V_Register_reporting model, int type, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}
