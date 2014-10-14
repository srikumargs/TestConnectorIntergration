using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Sage.Connector.Cloud.Integration.Interfaces;

namespace Sage.Connector.Cloud.Integration.MockServiceLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class MockAdminServiceHost
    {
        /// <summary>
        /// 
        /// </summary>
        public static void StartService()
        {
            WSHttpBinding binding = new WSHttpBinding(SecurityMode.None);
            //binding.MaxReceivedMessageSize = 5000000;
            //binding.MaxBufferPoolSize = 5000000;
            //binding.MaxBufferSize = 5000000;
            //binding.ReaderQuotas.MaxStringContentLength = 5000000;
            //binding.ReaderQuotas.MaxArrayLength = 5000000;
            //binding.ReaderQuotas.MaxBytesPerRead = 5000000;
            //binding.ReaderQuotas.MaxDepth = 5000000;
            //binding.ReaderQuotas.MaxNameTableCharCount = 5000000;
            _serviceHost = new ServiceHost(typeof(AdminService), new[] { new Uri(String.Format("http://{0}:8732", Environment.MachineName)) });
            ServiceEndpoint serviceEndpoint =
                _serviceHost.AddServiceEndpoint(typeof(IAdminService), binding, "/AdminService/AdminService.svc");
            //ServiceEndpoint msiEndpoint =
            //    Instance.AddServiceEndpoint(typeof(ICREMessageServiceInjection), binding, "MockCloudServiceInjection.svc");
            _serviceHost.Open();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void StopService()
        {
            if (_serviceHost.State != CommunicationState.Closed)
            { _serviceHost.Close(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static String EndpointAddress
        {
            get { return _serviceHost.Description.Endpoints[0].Address.Uri.ToString(); }
        }

        private static ServiceHost _serviceHost = null;
    }
}
