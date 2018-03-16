using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ICommonService.OA
{
    /// <summary>
    /// 接口层O_Article_user文章用户中间表
    /// cyj
    /// 2015年7月24日15:47:42
    /// </summary>
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IO_Article_user
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [OperationContract]
        bool Exists(int O_Article_user_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        [OperationContract]
        int Add(CommonService.Model.OA.O_Article_user model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        [OperationContract]
        bool Update(CommonService.Model.OA.O_Article_user model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        [OperationContract]
        bool Delete(int O_Article_user_id);
        [OperationContract]
        bool DeleteList(string O_Article_user_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [OperationContract]
        CommonService.Model.OA.O_Article_user GetModel(int O_Article_user_id);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        [OperationContract]
        DataSet GetList(int Top, string strWhere, string filedOrder);
        [OperationContract]
        int GetRecordCount(string strWhere);
        [OperationContract]
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        /// <summary>
        /// 根据组织机构GUID向表中添加数据
        /// </summary>
        /// <param name="orgList"></param>
        /// <returns></returns>
        [OperationContract]
        bool AddList(string orgList, CommonService.Model.OA.O_Article model);
        /// <summary>
        /// 根据文章guid获得已经读取该文章的用户集合获得数据列表
        /// </summary>
        [OperationContract]

        List<CommonService.Model.OA.O_Article_user> GetListByCode(Guid O_Article_code);
        /// <summary>
        /// 根据文章guid获得未读取该文章的用户集合获得数据列表
        /// </summary>
        [OperationContract]

        List<CommonService.Model.OA.O_Article_user> GetNoreadListByCode(Guid O_Article_code);
        /// <summary>
        /// 根据文章guid和用户guid得到一个对象实体
        /// </summary>
        [OperationContract]

        CommonService.Model.OA.O_Article_user GetModelByAcodeAndCcode(Guid O_Article_code, Guid C_Userinfo_code);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
       
    }
}
