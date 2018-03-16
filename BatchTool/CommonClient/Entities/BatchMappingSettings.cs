using System;
using System.Collections.Generic;
using System.Text;
using CommonClient.Controls;

namespace CommonClient.Entities
{
    /// <summary>
    /// 批量转换映射关系类
    /// </summary>
    [Serializable]
    public class MappingsRelationSettings : EntityBase, ICloneable
    {
        public MappingsRelationSettings()
        {
            StartRowIndex = 1;
            SeperateChar = string.Empty;
            MaxCountPerOperation = 0;
            FieldsMappings = new Dictionary<string, string>();
            BatchFieldsMappings = new Dictionary<string, string>();
        }

        /// <summary>
        /// 每批次最大笔数
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public int MaxCountPerOperation { get; set; }

        /// <summary>
        /// 源文件文本数据分隔符
        /// </summary>
        [DvValidatRule(CaseDescription = "FileConvert", MinLength = 0, MaxLength = 0, RegCode = "reg", Required = false)]
        public string SeperateChar { get; set; }

        /// <summary>
        /// 批信息映射关系
        /// </summary>
        public Dictionary<string, string> BatchFieldsMappings { get; set; }

        /// <summary>
        /// 字段映射关系
        /// </summary>
        public Dictionary<string, string> FieldsMappings { get; set; }

        /// <summary>
        /// 是否设置了字段信息
        /// </summary>
        public bool IsSetFields
        {
            get
            {
                if (MaxCountPerOperation <= 0) return false;
                //if (string.IsNullOrEmpty(SeperateChar.ToString())) return false;
                if (FieldsMappings.Count > 0)
                {
                    foreach (string map in FieldsMappings.Values)
                    {
                        if (!string.IsNullOrEmpty(map))
                            return true;
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// 是否设置了批信息
        /// </summary>
        public bool IsSetBatchFields
        {
            get
            {
                //if (MaxCountPerOperation <= 0) return false;
                //if (string.IsNullOrEmpty(SeperateChar.ToString())) return false;
                //if (BatchFieldsMappings.Count > 0)
                //{
                //    foreach (string map in BatchFieldsMappings.Values)
                //    {
                //        if (!string.IsNullOrEmpty(map)) return true;
                //    }
                //}
                //return false;
                return true;
            }
        }

        /// <summary>
        /// 数据起始行数
        /// </summary>
        public int StartRowIndex { get; set; }

        /// <summary>
        /// 数据截止行
        /// </summary>
        public int? EndRowIndex { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
