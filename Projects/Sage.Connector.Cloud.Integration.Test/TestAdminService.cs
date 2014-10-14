using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.Connector.Cloud.Integration.Interfaces;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.MockServiceLibrary;

namespace Sage.Connector.Cloud.Integration.Test
{
    [TestClass]
    public class TestAdminService
    {
        [TestInitialize]
        public void TestInitialize()
        { MockAdminServiceHost.StartService(); }

        [TestCleanup]
        public void TestCleanup()
        { MockAdminServiceHost.StopService(); }

        [TestMethod]
        public void TestGetTenant()
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



            ChannelFactory<IAdminService> channelFactory = new ChannelFactory<IAdminService>(
                binding, 
                MockAdminServiceHost.EndpointAddress);
            try
            {
                IAdminService service = channelFactory.CreateChannel();

                TenantInfo tenantInfo = service.GetTenantInfo();
                channelFactory.Close();
                channelFactory = null;
            }
            finally
            {
                if (channelFactory != null)
                {
                    channelFactory.Abort();
                    channelFactory = null;
                }
            }
        }
    }
}
