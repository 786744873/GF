using ICommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    public class C_Court : IC_Court
    {
        CommonService.BLL.C_Court coBLL = new CommonService.BLL.C_Court();

        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            return coBLL.GetMaxId();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <returns></returns>
        public bool Exists(int C_Court_id)
        {
            return coBLL.Exists(C_Court_id);
        }
        /// <summary>
        /// 是否存在该记录(根据名称)
        /// </summary>
        public bool ExistsByName(CommonService.Model.C_Court model)
        {
            return coBLL.ExistsByName(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.C_Court model)
        {
            return coBLL.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.C_Court model)
        {
            return coBLL.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <returns></returns>
        public bool Delete(Guid C_Court_code)
        {
            return coBLL.Delete(C_Court_code);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <returns></returns>
        public Model.C_Court GetModel(int C_Court_id)
        {
            return coBLL.GetModel(C_Court_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <returns></returns>
        public Model.C_Court Get(Guid C_Court_code)
        {
            return coBLL.GetModel(C_Court_code);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<Model.C_Court> GetAllList()
        {
            return coBLL.GetAllList();
        }
          /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<Model.C_Court> GetAllListByUserRegioncode(Guid userregioncode)
        {
            return coBLL.GetAllListByUserRegioncode(userregioncode);
        }
        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(Model.C_Court model)
        {
            return coBLL.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<Model.C_Court> GetListByPage(Model.C_Court model, string orderby, int startIndex, int endIndex)
        {
            return coBLL.GetListByPage(model,orderby,startIndex,endIndex);
        }

        /// <summary>
        /// 根据律师获得数据列表
        /// </summary>
        /// <param name="Lawyer"></param>
        /// <returns></returns>
        public List<Model.C_Court> GetAllListByLawyer(Guid Lawyer)
        {
            return coBLL.GetAllListByLawyer(Lawyer);
        }

        /// <summary>
        /// 获取法院信息
        /// </summary>,IsPreSetManager,RoleId
        /// <param name="lawyerCode"></param>
        /// <returns></returns>
        public List<Model.C_Court> GetListBylawyer(Guid lawyerCode)
        {
            return coBLL.GetListBylawyer(lawyerCode);
        }
    }
}
