using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace CommonService.BLL.FinanceManager
{
    /// <summary>
    /// 凭证信息表业务逻辑
    /// 作者：崔慧栋
    /// 日期：2015/08/25
    /// </summary>
	public partial class C_Voucher_Form
	{
        private readonly CommonService.DAL.FinanceManager.C_Voucher_Form dal = new CommonService.DAL.FinanceManager.C_Voucher_Form();
		public C_Voucher_Form()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CommonService.Model.FinanceManager.C_Voucher_Form model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Guid F_Form_code, Guid C_Voucher_code)
		{
            return dal.Delete(F_Form_code,C_Voucher_code);
		}

         /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="B_Case_links"></param>
        /// <returns></returns>
        public bool OperateList(List<CommonService.Model.FinanceManager.C_Voucher_Form> C_Voucher_Forms)
        {
            foreach (CommonService.Model.FinanceManager.C_Voucher_Form C_Voucher_Form in C_Voucher_Forms)
            {
                bool flag = dal.Exists(C_Voucher_Form.F_Form_code.Value, C_Voucher_Form.C_Voucher_code.Value);
                if (!flag)
                {
                    dal.Add(C_Voucher_Form);
                }
            }
            return true;
        }

         /// <summary>
        /// 根据凭证信息Code获得数据列表
        /// </summary>
        public List<CommonService.Model.FinanceManager.C_Voucher_Form> GetListByVoucherCode(Guid C_Voucher_code)
        {
            return DataTableToList(dal.GetListByVoucherCode(C_Voucher_code).Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.FinanceManager.C_Voucher_Form> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.FinanceManager.C_Voucher_Form> modelList = new List<CommonService.Model.FinanceManager.C_Voucher_Form>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.FinanceManager.C_Voucher_Form model;
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

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

