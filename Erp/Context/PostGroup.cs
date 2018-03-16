using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    /// <summary>
    /// 岗位组(静态帮组类)
    /// </summary>
    public class PostGroup
    {

        /// <summary>
        /// 指挥中心组标识
        /// </summary>
        public static Guid? CommandCentre
        {
            get
            {
                return new Guid("C2EF7038-EA0A-4EDF-B762-E5FE62C9FD7D");
            }
        }

        /// <summary>
        /// 主办律师组标识
        /// </summary>
        public static Guid? HostLawyer
        {
            get
            {
                return new Guid("84CC166E-0C4B-4025-8432-61AC281AB510");
            }
        }

        /// <summary>
        /// 协办律师组标识
        /// </summary>
        public static Guid? CoLawyer
        {
            get
            {
                return new Guid("3F0863E1-6528-4292-AC9E-E27FA07C89D4");
            }
        }

        /// <summary>
        /// 部长组标识
        /// </summary>
        public static Guid? Minister
        {
            get
            {
                return new Guid("A33B44C7-93A0-4520-94D5-C50C8C7AC99F");
            }
        }

        /// <summary>
        /// 首席专家组标识
        /// </summary>
        public static Guid? ChiefExpert
        {
            get
            {
                return new Guid("DA275F5A-4809-4F9D-832E-B213A65A78F5");
            }
        }

        /// <summary>
        /// 专业顾问组标识
        /// </summary>
        public static Guid? ProfessionalConsultant
        {
            get
            {
                return new Guid("6645A6C7-B5C8-4F78-9440-0C12D4B7195C");
            }
        }

        /// <summary>
        /// 分公司总经理组标识
        /// </summary>
        public static Guid? BranchGeneralManager
        {
            get
            {
                return new Guid("A7AD8ACF-2462-4187-A4EE-D2E4573C765A");
            }
        }

        /// <summary>
        /// 财务组标识
        /// </summary>
        public static Guid? Finance
        {
            get
            {
                return new Guid("94EDA41E-F330-46F6-AF8C-1A3C93402DEE");
            }
        }

        /// <summary>
        /// 销售内勤组标识
        /// </summary>
        public static Guid? Sales
        {
            get
            {
                return new Guid("20EF134D-0262-48BB-BD22-53333C6A0641");
            }
        }

        /// <summary>
        /// 人力资源组标识
        /// </summary>
        public static Guid? HumanResources
        {
            get
            {
                return new Guid("750C5D0B-2A20-4034-9D46-B3D392C46BDF");
            }
        }

        /// <summary>
        /// 运营管理组标识
        /// </summary>
        public static Guid? OperationManagement
        {
            get
            {
                return new Guid("0ABEF5B0-65A9-4AE5-83E5-540AC5C6B109");
            }
        }

        /// <summary>
        /// 总经理组标识
        /// </summary>
        public static Guid? GeneralManager
        {
            get
            {
                return new Guid("0C2B0A7C-EC75-405C-9631-CBE0BC51F8AD");
            }
        }

        /// <summary>
        /// 市场组标识
        /// </summary>
        public static Guid? Market
        {
            get
            {
                return new Guid("7B8157D0-1C39-4582-87F6-569104CB3136");
            }
        }

        /// <summary>
        /// 客户组标识
        /// </summary>
        public static Guid? CustomerService
        {
            get
            {
                return new Guid("038D581C-7D76-4511-94D6-2855098A04DC");
            }
        }

        /// <summary>
        /// 查控律师组标识
        /// </summary>
        public static Guid? ControlLawyer
        {
            get
            {
                return new Guid("B6057F9F-1880-4966-A062-05392AA7E9BF");
            }
        }

        /// <summary>
        /// 培训主管组
        /// </summary>
        public static Guid? TrainingSupervisor
        {
            get
            {
                return new Guid("C222E524-B2B1-43D6-BDC2-7DF0E74D3DF7");
            }
        }

        /// <summary>
        /// 研究院院长
        /// </summary>
        public static Guid? ResearchPresident
        {
            get
            {
                return new Guid("2DBCB751-3365-4B9F-94C0-E004224FB567");
            }
        }

    }
}
