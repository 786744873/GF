using System;
using System.Collections;
using System.ServiceModel;
namespace Maticsoft.Common
{
    internal static class ChannelFactoryCreator
    {
        private static Hashtable channelFactories = new Hashtable();

        public static ChannelFactory<T> Create<T>(string endpointName)
        {
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }

            ChannelFactory<T> channelFactory = null;

            if(channelFactories.ContainsKey(endpointName))
            {
                channelFactory = channelFactories[endpointName] as ChannelFactory<T>;
            }

            if (channelFactory == null)
            {
                channelFactory = new ChannelFactory<T>(endpointName);
                lock (channelFactories.SyncRoot)
                {
                    channelFactories[endpointName] = channelFactory;
                }
            }

            return channelFactory;
        }
    }
}