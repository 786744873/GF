using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace BOC_BATCH_TOOL.Entities
{
    [Serializable]
    public class BankInfo
    {
        public string BankName { get; set; }

        public string LinkID { get; set; }
    }
}
