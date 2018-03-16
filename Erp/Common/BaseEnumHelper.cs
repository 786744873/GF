using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Common
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public class BaseEnumHelper
    {
        /// <summary>
        /// 根据机构状态值，获取机构状态名称
        /// </summary>
        /// <param name="organization_state"></param>
       public static string GetOrganizationStateName(int organization_state){
           string name="";

           switch (organization_state)
           {
               case 0:
                   name = "未启用";
                   break;
               case 1:
                   name = "已启用";
                   break;
               case 2:
                   name = "已禁用";
                   break;
               default:
                   name = "未启用";
                   break;
           }

           return name;
       }
       
       /// <summary>
       /// 获取上传附件文件夹
       /// </summary>
       /// <param name="fileBelongTypeEnum">文件归属类型枚举</param>
       /// <returns></returns>
       public static string GetUploadAttachmentFolder(FileBelongTypeEnum fileBelongTypeEnum)
       {
           string folder = String.Empty;
           switch (fileBelongTypeEnum)
           {
               case FileBelongTypeEnum.客户:
                   folder = "customer";
                   break;
               case FileBelongTypeEnum.法院:
                   folder = "court";
                   break;
               case FileBelongTypeEnum.公司:
                   folder = "crival";
                   break;
               case FileBelongTypeEnum.个人:
                   folder = "prival";
                   break;
               case FileBelongTypeEnum.联系人:
                   folder = "contacts";
                   break;
               case FileBelongTypeEnum.法官:
                   folder = "judge";
                   break;
               case FileBelongTypeEnum.委托人:
                   folder = "client";
                   break;
               case FileBelongTypeEnum.配偶:
                   folder = "spouse";
                   break;
               case FileBelongTypeEnum.案件:
                   folder = "case";
                   break;
               case FileBelongTypeEnum.自定义表单:
                   folder = "customerform";
                   break;
           }
           return folder;
       }

    }
}
