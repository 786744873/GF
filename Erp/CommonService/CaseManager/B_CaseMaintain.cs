﻿using ICommonService.CaseManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.CaseManager
{
    public class B_CaseMaintain : IB_CaseMaintain
    {
        private CommonService.BLL.CaseManager.B_CaseMaintain bll = new CommonService.BLL.CaseManager.B_CaseMaintain();
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return bll.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int B_CaseMaintain_id)
        {
            return bll.Exists(B_CaseMaintain_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.CaseManager.B_CaseMaintain model)
        {
            return bll.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.CaseManager.B_CaseMaintain model)
        {
            return bll.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int B_CaseMaintain_id)
        {

            return bll.Delete(B_CaseMaintain_id);
        }
        public bool DeleteCase(string  B_CaseMaintain_id)
        {

            return bll.DeleteCase(B_CaseMaintain_id);
        }
      
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string B_CaseMaintain_idlist)
        {
            return bll.DeleteList(B_CaseMaintain_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.CaseManager.B_CaseMaintain GetModel(int B_CaseMaintain_id)
        {

            return bll.GetModel(B_CaseMaintain_id);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return bll.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_CaseMaintain> GetModelList(string strWhere)
        {
            DataSet ds = bll.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_CaseMaintain> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.CaseManager.B_CaseMaintain> modelList = new List<CommonService.Model.CaseManager.B_CaseMaintain>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.CaseManager.B_CaseMaintain model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = bll.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
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
        public int GetRecordCount(CommonService.Model.CaseManager.B_CaseMaintain strWhere)
        {
            return bll.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.CaseManager.B_CaseMaintain> GetListByPage(CommonService.Model.CaseManager.B_CaseMaintain strWhere, string orderby, int startIndex, int endIndex)
        {

            return bll.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return bll.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

    }
}