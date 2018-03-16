using CommonService.Model.CaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.CaseManager
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IB_Case_Typicalcase
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int B_Case_Typicalcase_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.CaseManager.B_Case_Typicalcase model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.CaseManager.B_Case_Typicalcase model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int B_Case_Typicalcase_id);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="typicalcodes"></param>
        /// <returns></returns>
        [OperationContract]
        bool MutilyDelete(string typicalcodes);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_Typicalcase GetModel(int B_Case_Typicalcase_id);
        /// <summary>
        /// 根据code得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.CaseManager.B_Case_Typicalcase GetModelByCode(Guid B_Case_Typicalcase_code);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case_Typicalcase> GetList(string strWhere);
        [OperationContract]
        int GetRecordCount(CommonService.Model.CaseManager.B_Case_Typicalcase model);
        [OperationContract]
        List<CommonService.Model.CaseManager.B_Case_Typicalcase> GetListByPage(CommonService.Model.CaseManager.B_Case_Typicalcase model, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
