using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using BOC_BATCH_TOOL.Controls;
using BOC_BATCH_TOOL.EnumTypes;

namespace BOC_BATCH_TOOL.Types
{
    public static class ConsistDefine
    {
        private static readonly List<RegexValidationItem> _preDefinedValidationItems = new List<RegexValidationItem>();
        public static List<RegexValidationItem> PreDefinedValidationItems()
        {
            var item1 = new RegexValidationItem { RegexValue = "^[0-9]*$", MessageEnus = "Only number are allowed", MessageZhcn = "Only number are allowed" };
            var item2 = new RegexValidationItem { RegexValue = "^[a-zA-Z0-9]*$", MessageEnus = "Only English char and number are allowed", MessageZhcn = "Only English char and number are allowed" };
            _preDefinedValidationItems.Add(item1);
            _preDefinedValidationItems.Add(item2);
            return _preDefinedValidationItems;
        }

        public static UILang Language { get; set; }
    }

    [Serializable]
    public class TranslatingKeyAttribute : Attribute
    {
        public TranslatingKeyAttribute(string lanKey, string chs, string eng, string cht)
        {
            LanKey = lanKey;
            Chs = chs;
            Eng = eng;
            Cht = cht;
        }

        public string LanKey { get; private set; }
        public string Chs { get; private set; }
        public string Eng { get; private set; }
        public string Cht { get; private set; }
    }

    [Serializable]
    public class LanDescriptor
    {
        public string Key { get; set; }
        public string Lang { get; set; }
    }

    [Serializable]
    public class EditorValidateRule
    {
        public event MethodInvoker OnRequiredChanged;
        public string RegexValue { get; set; }
        //public LanDescriptor LanDescriptorZhcn { get; set; }
        //public LanDescriptor LanDescriptorEnus { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        private bool _required;
        public bool Required
        {
            get { return _required; }
            set
            {
                if (_required != value)
                {
                    _required = value;
                    if (OnRequiredChanged != null)
                        OnRequiredChanged();
                }
            }
        }

        public new string ToString()
        {
            return RegexValue;
        }
    }


    [Serializable]
    public class InfrastructureTypes
    {
        public bool ShowCoprateTransferTab { get; set; }
        public bool ShowIndividualTransferTab { get; set; }
        public bool ShowFastAgentOutTab { get; set; }
        public bool ShowFastAgentInTab { get; set; }
        public bool ShowNormalAgentOutTab { get; set; }
        public bool ShowNormalAgentInTab { get; set; }
    }

    [Serializable]
    public class CNAP
    {
        [XmlElement("CODE")]
        public string Code { get; set; }
        [XmlElement("NAME")]
        public string Name { get; set; }
        [XmlElement("ADDR")]
        public string Addr { get; set; }
        [XmlElement("GROUP")]
        public string Group { get; set; }
        [XmlElement("Usage")]
        public string Usage { get; set; }
    }

    [Serializable]
    public class CNAPS
    {
        [XmlElement("CNAP")]
        public List<CNAP> Items { get; set; }
    }
}
