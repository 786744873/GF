using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BOC_BATCH_TOOL.Utilities
{
    public class LanKeyElement : ConfigurationElement
    {
        [ConfigurationProperty("LanKey", IsRequired = true)]
        public string LanKey
        {
            get { return (string)this["LanKey"]; }
            set { this["LanKey"] = value; }
        }

        [ConfigurationProperty("ReservedIndex1", IsRequired = true, DefaultValue = 80)]
        [IntegerValidator(MinValue = 1, MaxValue = 999)]
        public int ReservedIndex1
        {
            get { return (int)this["ReservedIndex1"]; }
            set { this["ReservedIndex1"] = value; }
        }

        [ConfigurationProperty("ZH_CN")]
        public string ZH_CN
        {
            get { return (string)this["ZH_CN"]; }
            set { this["ZH_CN"] = value; }
        }

        [ConfigurationProperty("EN_US")]
        public string EN_US
        {
            get { return (string)this["EN_US"]; }
            set { this["EN_US"] = value; }
        }

        public string GetLanString(string lan)
        {
            return (string)this[lan];
        }
    }

    public class LanKeyCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new LanKeyElement();
        }

        [ConfigurationProperty("ReservedIndex2", IsRequired = true, DefaultValue = 80)]
        [IntegerValidator(MinValue = 1, MaxValue = 65535)]
        public int ReservedIndex2
        {
            get { return (int)this["ReservedIndex2"]; }
            set { this["ReservedIndex2"] = value; }
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var lastRegex = (LanKeyElement)element;
            return getKey(lastRegex);
        }

        public LanKeyElement this[int index] //  
        {
            get { return (LanKeyElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemove(index);
                BaseAdd(index, value);
            }
        }

        public void Add(LanKeyElement item)
        {
            BaseAdd(item);
        }

        private string getKey(LanKeyElement item)
        {
            return item.LanKey;
        }

        /*
        public new int Count
        {
            get { return base.Count; }
        }

        public int IndexOf(LanKeyElement endPoint)
        {
            return BaseIndexOf(endPoint);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Clear()
        {
            BaseClear();
        }

        public bool Contains(LanKeyElement item)
        {
            return BaseIndexOf(item) >= 0;
        }

        public void CopyTo(LanKeyElement[] array, int arrayIndex)
        {
            base.CopyTo(array, arrayIndex);
        }

        public new bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(LanKeyElement item)
        {
            if (BaseIndexOf(item) >= 0)
            {
                BaseRemove(item);
                return true;
            }
            return false;
        }

        public LanKeyElement[] ToLastRegexArray()
        {
            var result = new List<LanKeyElement>();
            for (int i = 0; i < this.Count; i++)
            {
                result.Add((this[i]));
            }

            return result.ToArray();
        }

         */
    }


    public class ClientConfigurationSection : ConfigurationSection
    {
        public static string SectionsName { get; set; }
        public static void AddToConfigFile()
        {
            if (Current.Sections[SectionsName] == null)
                Current.Sections.Add(SectionsName, new ClientConfigurationSection());
        }

        private static Configuration _current;
        public static Configuration Current { get { return _current; } private set { _current = value; } }

        [ConfigurationProperty("LanguageCollection", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(LanKeyElement), AddItemName = "LanItem1", ClearItemsName = "LanItem2", RemoveItemName = "LanItem3")]
        public LanKeyCollection LanguageCollection
        {
            get { return (LanKeyCollection)this["LanguageCollection"]; }
            set { this["LanguageCollection"] = value; }
        }
    }


    public class Config_Tester
    {
        public static void ReadBtn_Click()
        {
            ClientConfigurationSection.SectionsName = "Dict";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ClientConfigurationSection section = config.Sections[ClientConfigurationSection.SectionsName] as ClientConfigurationSection;
            if (section == null)
                return;

            if (section.LanguageCollection.Count >= 1)
            {
                var Service1IPBox = section.LanguageCollection[0].LanKey.ToString();
                var Service1ReservedIndex1Box = section.LanguageCollection[0].ReservedIndex1;
                var Service2IPBox = section.LanguageCollection[1].LanKey.ToString();
                var Service2ReservedIndex1Box = section.LanguageCollection[1].ReservedIndex1;
                var Service3IPBox = section.LanguageCollection[2].LanKey.ToString();
                var Service3ReservedIndex1Box = section.LanguageCollection[2].ReservedIndex1;
                MessageBox.Show(string.Format("Service1IPBox: {0}; Service1ReservedIndex1Box: {1}; Service2IPBox: {2}; " +
                                              "Service2ReservedIndex1Box: {3} Service3IPBox: {4}; Service3ReservedIndex1Box: {5}", Service1IPBox, Service1ReservedIndex1Box,
                                              Service2IPBox, Service2ReservedIndex1Box, Service3IPBox, Service3ReservedIndex1Box));
            }
        }

        public static void SaveBtn_Click()
        {
            ClientConfigurationSection.SectionsName = "Dict";
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var section = config.Sections[ClientConfigurationSection.SectionsName] as ClientConfigurationSection;
            if (section == null)
            {
                section = new ClientConfigurationSection();
                var ipElement1 = new LanKeyElement { LanKey = "Key1021", ZH_CN = "中行行内1", EN_US = "境内他行a" };
                section.LanguageCollection.Add(ipElement1);

                var ipElement2 = new LanKeyElement { LanKey = "Key1022", ZH_CN = "中行行内2", EN_US = "境内他行b" };
                section.LanguageCollection.Add(ipElement2);

                var ipElement3 = new LanKeyElement { LanKey = "Key1023", ZH_CN = "中行行内3", EN_US = "境内他行c" };
                section.LanguageCollection.Add(ipElement3);

                config.Sections.Add(ClientConfigurationSection.SectionsName, section);
            }
            config.Save(ConfigurationSaveMode.Full);
        }
    }
}
