using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.OA
{
    /// <summary>
    /// 流程预设表业务逻辑
    /// 作者：贺太玉
    /// 日期：2015/08/01
    /// </summary>
    public partial class O_FlowSet
    {
        private readonly CommonService.DAL.OA.O_FlowSet dal = new DAL.OA.O_FlowSet();
        private readonly CommonService.DAL.OA.O_FlowSet_AuditPerson APdal = new DAL.OA.O_FlowSet_AuditPerson();
        private readonly CommonService.BLL.OA.O_FlowSet_AuditPerson APbll = new BLL.OA.O_FlowSet_AuditPerson();
        public O_FlowSet()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int O_FlowSet_id)
        {
            return dal.Exists(O_FlowSet_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.OA.O_FlowSet model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.OA.O_FlowSet model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid O_FlowSet_code)
        {

            return dal.Delete(O_FlowSet_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string O_FlowSet_idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(O_FlowSet_idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.OA.O_FlowSet GetModel(Guid O_FlowSet_code)
        {

            return dal.GetModel(O_FlowSet_code);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.OA.O_FlowSet> modelList = new List<CommonService.Model.OA.O_FlowSet>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.OA.O_FlowSet model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 根据所属流程guid获得数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet> GetListByFlowCode(Guid? flowCode)
        {
            return DataTableToList(dal.GetListByFlowCode(flowCode).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.OA.O_FlowSet model)
        {
            return dal.GetRecordCount(model);
            //   return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.OA.O_FlowSet> GetListByPage(CommonService.Model.OA.O_FlowSet model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
            //  return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 修改或者添加流程预设和预审审批人信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateFlowSetAndAuditPerson(CommonService.Model.OA.O_FlowSet model, string userlists, int type)
        {
            bool flag = true;
            if (type == 1)
            {//新增
                if (!(Add(model) > 0))
                {
                    flag = false;
                }
                else
                {//向预设审核人表中增加数据
                    string[] list = userlists.Split(',');
                    foreach (var item in list)
                    {
                        CommonService.Model.OA.O_FlowSet_AuditPerson per = new Model.OA.O_FlowSet_AuditPerson();
                        per.O_FlowSet_auditPerson_code = Guid.NewGuid();
                        per.O_FlowSet_auditPerson_flowSet = model.O_FlowSet_code;
                        per.O_FlowSet_auditPerson_auditPerson = new Guid(item.ToString());
                        per.O_FlowSet_auditPerson_isDelete = false;
                        per.O_FlowSet_auditPerson_creator = model.O_FlowSet_creator;
                        per.O_FlowSet_auditPerson_createTime = DateTime.Now;
                        if (!(APdal.Add(per) > 0))
                        {
                            flag = false;
                        }
                    }
                }
            }
            else if (type == 2)
            { //修改预设
                if (!Update(model))
                {
                    flag = false;
                }
                else
                {
                    //先删除之前此流程的预设审核人
                    if (!APdal.UpdateList(model.O_FlowSet_code))
                    {
                        flag = false;
                    }
                    else
                    {
                        //再向预设审核人表中增加数据
                        string[] list = userlists.Split(',');
                        foreach (var item in list)
                        {
                            CommonService.Model.OA.O_FlowSet_AuditPerson per = new Model.OA.O_FlowSet_AuditPerson();
                            per.O_FlowSet_auditPerson_code = Guid.NewGuid();
                            per.O_FlowSet_auditPerson_flowSet = model.O_FlowSet_code;
                            per.O_FlowSet_auditPerson_auditPerson = new Guid(item.ToString());
                            per.O_FlowSet_auditPerson_isDelete = false;
                            per.O_FlowSet_auditPerson_creator = model.O_FlowSet_creator;
                            per.O_FlowSet_auditPerson_createTime = DateTime.Now;
                            if (!(APdal.Add(per) > 0))
                            {
                                flag = false;
                            }
                        }
                    }
                }
            }
            else
            { //删除预设信息和预设审批人信息
                model.O_FlowSet_isDelete = true;
                if (!Update(model))
                {
                    flag = false;
                }
                else
                {
                    List<CommonService.Model.OA.O_FlowSet_AuditPerson> FAlist = APbll.GetListByflowSetCode(new Guid(model.O_FlowSet_code.ToString()));
                    if (FAlist.Count() > 0)
                    {
                        if (!APdal.UpdateList(model.O_FlowSet_code))
                        {
                            flag = false;
                        }
                    }

                }
            }
            return flag;
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
