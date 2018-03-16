using System;
using System.Collections.Generic;
using System.Text;

namespace BOC_BATCH_TOOL.Entities
{
    /// <summary>
    /// 批量转换映射关系类
    /// </summary>
    [Serializable]
    public class MappingsRelationSettings : Object, ICloneable
    {
        public MappingsRelationSettings()
        {
            m_SeperateChar = string.Empty;
            m_MaxCountPerOperation = 0;
            m_FieldsMappings = new Dictionary<string, string>();
            m_BatchFieldsMappings = new Dictionary<string, string>();
        }

        private int m_MaxCountPerOperation;
        /// <summary>
        /// 每批次最大笔数
        /// </summary>
        public int MaxCountPerOperation
        {
            get { return m_MaxCountPerOperation; }
            set { m_MaxCountPerOperation = value; }
        }

        private string m_SeperateChar;
        /// <summary>
        /// 源文件文本数据分隔符
        /// </summary>
        public string SeperateChar
        {
            get { return m_SeperateChar; }
            set { m_SeperateChar = value; }
        }

        private Dictionary<string, string> m_BatchFieldsMappings;
        /// <summary>
        /// 批信息映射关系
        /// </summary>
        public Dictionary<string, string> BatchFieldsMappings
        {
            get { return m_BatchFieldsMappings; }
            set { m_BatchFieldsMappings = value; }
        }

        private Dictionary<string, string> m_FieldsMappings;
        /// <summary>
        /// 字段映射关系
        /// </summary>
        public Dictionary<string, string> FieldsMappings
        {
            get { return m_FieldsMappings; }
            set { m_FieldsMappings = value; }
        }
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
                        if (!string.IsNullOrEmpty(map)) return true;
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

        private int m_Index = 1;
        /// <summary>
        /// 数据起始行数
        /// </summary>
        public int StartRowIndex
        {
            get { return m_Index; }
            set { m_Index = value; }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
