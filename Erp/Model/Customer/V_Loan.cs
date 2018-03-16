using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Model.Customer
{
    //OA借款报销表单虚拟类
    public class V_Loan
    {
        private string costtype;
        /// <summary>
        /// 费用种类
        /// </summary>
        public string Consttype
        {
            set { costtype = value; }
            get { return costtype; }
        }
        private string invoicetype;
        /// <summary>
        /// 发票种类
        /// </summary>
        public string Invoicetype
        {
            set { invoicetype = value; }
            get { return invoicetype; }
        }
        private string invoicevalue;
        /// <summary>
        /// 发票金额
        /// </summary>
        public string Invoicevalue
        {
            set { invoicevalue = value; }
            get { return invoicevalue; }
        }
        private string paymentstatus;
        /// <summary>
        /// 付款状态
        /// </summary>
        public string Paymentstatus
        {
            set { paymentstatus = value; }
            get { return paymentstatus; }
        }
        private string abstracts;
        /// <summary>
        /// 摘要
        /// </summary>
        public string Abstracts
        {
            set { abstracts = value; }
            get { return abstracts; }
        }
        private string dateofcost;
        /// <summary>
        ///费用产生日期
        /// </summary>
        public string Dateofcost
        {
            set { dateofcost = value; }
            get { return dateofcost; }
        }
        private string applydate;
        /// <summary>
        ///申请日期
        /// </summary>
        public string Applydate
        {
            set { applydate = value; }
            get { return applydate; }
        }
        private string formstatus;
        /// <summary>
        ///表单状态
        /// </summary>
        public string Formstatus
        {
            set { formstatus = value; }
            get { return formstatus; }
        }
        private string formcode;
        /// <summary>
        ///表单guid
        /// </summary>
        public string Formcode
        {
            set { formcode = value; }
            get { return formcode; }
        }
        private string formname;
        /// <summary>
        ///表单名称
        /// </summary>
        public string Formname
        {
            set { formname = value; }
            get { return formname; }
        }
        private string formapplyPerson_name;
        /// <summary>
        ///表单申请人名称
        /// </summary>
        public string FormapplyPerson_name
        {
            set { formapplyPerson_name = value; }
            get { return formapplyPerson_name; }
        }
        private string formPropertyValueGroup;
        /// <summary>
        ///行专列标示
        /// </summary>
        public string FormPropertyValueGroup
        {
            set { formPropertyValueGroup = value; }
            get { return formPropertyValueGroup; }
        }
    }
}
