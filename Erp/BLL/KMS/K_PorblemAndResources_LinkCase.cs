using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.BLL.KMS
{
    /// <summary>
    /// 问题/文档/视频 关联业务流程表单表
    /// cyj
    /// 2016年1月13日10:23:33
    /// </summary>
    public class K_PorblemAndResources_LinkCase
    {
        private readonly CommonService.DAL.KMS.K_PorblemAndResources_LinkCase dal = new CommonService.DAL.KMS.K_PorblemAndResources_LinkCase();
        private readonly CommonService.BLL.C_Court bllCourt = new BLL.C_Court();
        public K_PorblemAndResources_LinkCase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_ProblemAndResources_LinkCase_id)
        {
            return dal.Exists(K_ProblemAndResources_LinkCase_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int K_ProblemAndResources_LinkCase_id)
        {

            return dal.Delete(K_ProblemAndResources_LinkCase_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_PorblemAndResources_LinkCase GetModel(int K_ProblemAndResources_LinkCase_id)
        {

            return dal.GetModel(K_ProblemAndResources_LinkCase_id);
        }
        /// <summary>
        /// 根据实体得到对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_PorblemAndResources_LinkCase GetModelByModel(CommonService.Model.KMS.K_PorblemAndResources_LinkCase modelL)
        {
            return dal.GetModelByModel(modelL);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.KMS.K_PorblemAndResources_LinkCase GetModelByCache(int K_ProblemAndResources_LinkCase_id)
        {

            string CacheKey = "K_PorblemAndResources_LinkCaseModel-" + K_ProblemAndResources_LinkCase_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(K_ProblemAndResources_LinkCase_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.KMS.K_PorblemAndResources_LinkCase)objModel;
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
        /// 根据实体得到数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_PorblemAndResources_LinkCase> GetListByModel(CommonService.Model.KMS.K_PorblemAndResources_LinkCase modelL)
        {
            return DataTableToList(dal.GetListByModel(modelL).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_PorblemAndResources_LinkCase> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_PorblemAndResources_LinkCase> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.KMS.K_PorblemAndResources_LinkCase> modelList = new List<CommonService.Model.KMS.K_PorblemAndResources_LinkCase>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.KMS.K_PorblemAndResources_LinkCase model = new Model.KMS.K_PorblemAndResources_LinkCase();
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        public bool MutilyAdd(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            /***
             * 根据实体来向表中增加数据
             * 1.如果区域为空的话，说明是所有区域
             * 2.如果法院集合为all的话，说明选中了所有法院
             * 
             * **/
            if (model != null)
            {
                if (model.K_ProblemAndResources_LinkCase_region == null)
                {
                    if (model.K_ProblemAndResources_LinkCase_CourtListcode.Contains("all"))
                    {
                        List<CommonService.Model.C_Court> courtItem = bllCourt.GetAllList();
                        foreach (var item in courtItem)
                        {
                            CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = new Model.KMS.K_PorblemAndResources_LinkCase();
                            linkModel = model;
                            linkModel.K_ProblemAndResources_LinkCase_Courtcode = item.C_Court_code;
                            if (dal.Add(linkModel)==0)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        string[] courtCodes = model.K_ProblemAndResources_LinkCase_CourtListcode.Split(',');
                        for (int i = 0; i < courtCodes.Count(); i++)
                        {
                            CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = new Model.KMS.K_PorblemAndResources_LinkCase();
                            linkModel = model;
                            linkModel.K_ProblemAndResources_LinkCase_Courtcode = new Guid(courtCodes[i]);
                            if (dal.Add(linkModel) == 0)
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {                   
                    if (model.K_ProblemAndResources_LinkCase_CourtListcode.Contains("all"))
                    {
                        List<CommonService.Model.C_Court> courtItem = bllCourt.GetAllListByUserRegioncode(model.K_ProblemAndResources_LinkCase_region.Value);
                        foreach (var item in courtItem)
                        {
                            CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = new Model.KMS.K_PorblemAndResources_LinkCase();
                            linkModel = model;
                            linkModel.K_ProblemAndResources_LinkCase_Courtcode = item.C_Court_code;
                            if (dal.Add(linkModel) == 0)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        string[] courtCodes = model.K_ProblemAndResources_LinkCase_CourtListcode.Split(',');
                        for (int i = 0; i < courtCodes.Count(); i++)
                        {
                            CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = new Model.KMS.K_PorblemAndResources_LinkCase();
                            linkModel = model;
                            linkModel.K_ProblemAndResources_LinkCase_Courtcode = new Guid(courtCodes[i]);
                            if (dal.Add(linkModel) == 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        public bool MutilyUpdate(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            if (dal.DeleteByFK_code(model.C_FK_code.Value))
            {
                if (!MutilyAdd(model))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        public bool MutilyDelete(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            if (!dal.DeleteByFK_code(model.C_FK_code.Value))
                return false;
            return true;
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
