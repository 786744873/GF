using System;
namespace Maticsoft.Common
{
    public static class ServiceProxyFactory
    {
        public static T Create<T>(string endpointName)
        {
            if (string.IsNullOrEmpty(endpointName))
            {
                throw new ArgumentNullException("endpointName");
            }
            return (T)(new ServiceRealProxy<T>(endpointName).GetTransparentProxy());
        }      
    }
}
