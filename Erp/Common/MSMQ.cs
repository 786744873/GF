using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace CommonService.Common
{
    /// <summary>
    /// 消息队列关联类
    /// </summary>
    public class MSMQ
    {
        /// <summary>
        /// 发送计算条目统计时间消息
        /// </summary>
        public static void SendMessage()
        {
            Message msg = new Message("clacEntryStatisticsTime");
            try
            {
                string queueName = @".\Private$\SampleQueue";
                MessageQueue mq = null;
                if (!MessageQueue.Exists(queueName))
                    mq = MessageQueue.Create(queueName);
                else
                    mq = new MessageQueue(queueName);
                mq.Formatter = new XmlMessageFormatter(new[] { "System.String" });
                mq.Send(msg, "说明:计算条目统计时间");
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter("E:\\ServiceException.txt", true))
                {
                    sw.WriteLine("异常时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "     异常：" + "" + ex.ToString() + "" + "     异常地点：ReadMessage");
                }
            }
            
        }

        /// <summary>
        /// 发送日程消息
        /// </summary>
        public static void SendScheduleMessage()
        {
            Message msg = new Message("clacScheduleMessage");

            string queueName = @".\Private$\SampleQueue";
            MessageQueue mq = null;
            if (!MessageQueue.Exists(queueName))
                mq = MessageQueue.Create(queueName);
            else
                mq = new MessageQueue(queueName);
            mq.Formatter = new XmlMessageFormatter(new[] { "System.String" });
            mq.Send(msg, "说明:日程消息处理");
        }

    }
}
