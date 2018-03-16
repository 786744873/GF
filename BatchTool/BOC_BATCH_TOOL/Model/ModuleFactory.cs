using System;
using System.Collections.Generic;
using System.Text;

namespace BOC_BATCH_TOOL.Model
{
    public class ModuleFactory
    {
        public static object m_lock = new object();
        static ModuleFactory m_instance;
        public static ModuleFactory Instance
        {
            get {
                if (null == m_instance)
                {
                    lock (m_lock)
                    {
                        if (null == m_instance)
                        {
                            lock (m_lock) {
                                m_instance = new ModuleFactory();
                            }
                        }
                    }
                }
                return m_instance; }
        }


    }
}
