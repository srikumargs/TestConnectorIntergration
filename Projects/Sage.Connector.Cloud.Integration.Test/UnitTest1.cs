using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.Connector.Cloud.Integration.Interfaces.DataContracts;
using Sage.Connector.Cloud.Integration.Interfaces.Requests;
using Sage.Connector.Cloud.Integration.Interfaces.Responses;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;
using Sage.Connector.Cloud.Integration.Interfaces.WebAPI;
using Sage.Connector.Cloud.Integration.Proxy.Utils;

namespace Sage.Connector.Cloud.Integration.Test
{
    [TestClass]
    public class UnitTest1
    {
        #region Test Context

        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// Information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void TestConfigurationSerialization()
        {
            var config = new Configuration();
            config.ConfigurationBaseUri = new Uri(@"http://www.sage.com");
            config.ConfigurationResourcePath = @"api/configuration";
            config.RequestBaseUri = new Uri(@"http://www.sage.com");
            config.RequestResourcePath = @"api/messages/requests";
            config.ResponseBaseUri = new Uri(@"http://www.sage.com");
            config.ResponseResourcePath = @"api/messages/responses";
            config.RequestUploadResourcePath = @"api/messages/requests/startuploadrequest";
            config.ResponseUploadResourcePath = @"api/messages/responses/enduploadrequest";
            config.NotificationResourceUri = new Uri(@"http://www.sage.com/api/notification");
            config.MinimumConnectorProductVersion = "1.2.3.4";
            config.UpgradeConnectorProductVersion = "2.3.4.5";
            config.UpgradeConnectorPublicationDate = DateTime.UtcNow.Date;
            config.UpgradeConnectorDescription = "Improved performance.";
            config.UpgradeConnectorLinkUri = new Uri(@"http://www.sage.com/connector_download");
            config.SiteAddressBaseUri = new Uri(@"http://www.sage.com");
            config.TenantPublicUri = new Uri(@"http://www.sage.com/Tenant");
            config.TenantName = "Tenant";
            config.LargeResponseSizeThreshold = 1000;
            config.SuggestedMaxConnectorUptimeDuration = new TimeSpan(7, 0, 0, 0);
            config.MaxBlobSize = 16 * 1024 * 1000;
            config.MinCommunicationFailureRetryInterval = new TimeSpan(1000);
            config.MaxCommunicationFailureRetryInterval = new TimeSpan(10000);
        }

        [TestMethod]
        public void TestCopyConstructor()
        {
            Guid g1 = Guid.NewGuid();
            Guid g3 = Guid.NewGuid();
            Guid g4 = Guid.NewGuid();
            ReportParamValue[] values = new ReportParamValue[]
            {
                new StringReportParamValue("test1", "premiseMetadata", "test1")
            };

            SystemFilterParamValue[] filterValues = new SystemFilterParamValue[] { };

            LoopBackRequest orig = new LoopBackRequest(g1, DateTime.UtcNow, 0, 0, "requestingUser");

            Assert.AreEqual(g1, orig.Id);

            var propertyTuples = new List<PropertyTuple>
            {
                new PropertyTuple(orig.PropertyInfo(x => x.Id), g3),
            };
            LoopBackRequest copy = new LoopBackRequest(orig, propertyTuples);

            Assert.AreNotEqual(orig.Id, copy.Id);
            Assert.AreEqual(g3, copy.Id);
            Assert.AreEqual(orig.CreatedTimestampUtc, copy.CreatedTimestampUtc);
            Assert.AreEqual(orig.GetType().FullName, copy.GetType().FullName);
        }



        [TestMethod]
        public void TestEnuermableCopyAndMutate()
        {
            var orig = new SingleSelectReportParam("name", "displayText", false, "premiseMetadata", "defaultSelectionValue", new KeyName[] { new KeyName("key", "name") }, false);

            var propertyTuples = new List<PropertyTuple>
            {
                new PropertyTuple(orig.PropertyInfo(x => x.AvailableSelectionValues), new KeyName[]{new KeyName("changed key", "changed value")})
            };
            SingleSelectReportParam copy = new SingleSelectReportParam(orig, propertyTuples);

            Assert.AreEqual(orig.DefaultSelectionValue, copy.DefaultSelectionValue);
            Assert.AreEqual(orig.DisplayText, copy.DisplayText);
            Assert.AreEqual(orig.IsCustomValueAllowed, copy.IsCustomValueAllowed);
            Assert.AreEqual(orig.IsRequired, copy.IsRequired);
            Assert.AreEqual(orig.Name, copy.Name);
            Assert.AreEqual(orig.PremiseMetadata, copy.PremiseMetadata);
            Assert.AreNotEqual(orig.AvailableSelectionValues, copy.AvailableSelectionValues);
            Assert.AreEqual(orig.AvailableSelectionValues.Length, copy.AvailableSelectionValues.Length);
            Assert.AreNotEqual(orig.AvailableSelectionValues[0].Key, copy.AvailableSelectionValues[0].Key);
            Assert.AreNotEqual(orig.AvailableSelectionValues[0].Name, copy.AvailableSelectionValues[0].Name);
        }

        /// <summary>
        /// Serialize/deserialize request using some upper end unicode characters
        /// </summary>
        [TestMethod]
        public void TestSerializerWithRequest()
        {
            Guid g1 = Guid.NewGuid();
            Guid g2 = Guid.NewGuid();
            ReportParamValue[] values = new ReportParamValue[] 
            {
                new StringReportParamValue("test1-åè", "premiseMetadata+ì", "test1?æìñ")
            };
            SystemFilterParamValue[] filterValues = new SystemFilterParamValue[] { };
            LoopBackRequest orig = new LoopBackRequest(g1, DateTime.UtcNow, 0, 0, "requestingUser..å");

            String requestAsString = SerializationHelper.Serialize<Request>(orig);

            Request deserializedRequest = SerializationHelper.Deserialize<Request>(requestAsString);

            Assert.AreEqual(orig.Id, deserializedRequest.Id);
            Assert.AreEqual(orig.GetType().FullName, deserializedRequest.GetType().FullName);
            Assert.IsInstanceOfType(deserializedRequest, orig.GetType());
        }

        /// <summary>
        /// Serialize/deserialize response using some upper end unicode characters
        /// </summary>
        [TestMethod]
        public void TestSerializerWithResponse()
        {
            var parameter = new
                StringReportParam(
                "name[Ă]",
                "",
                false,
                "premiseMetadata",
                "value",
                10);

            var report = new
                ReportDescriptor(
                    "uniqueIdentifier/Ó", "name:Ĉ", "description-ß",
                    "category", "applicationName", "menuPath",
                    "path", new ReportParam[] { parameter }, new SystemFilterParam[] { });

            Response orig = new
                LoopBackRequestResponse(
                Guid.NewGuid(),
                Guid.NewGuid(),
                DateTime.UtcNow);

            String responseAsString = SerializationHelper.Serialize<Response>(orig);

            Response deserializedResponse = SerializationHelper.Deserialize<Response>(responseAsString);

            Assert.AreEqual(orig.Id, deserializedResponse.Id);
            Assert.AreEqual(orig.GetType().FullName, deserializedResponse.GetType().FullName);
            Assert.IsInstanceOfType(deserializedResponse, orig.GetType());
        }

        [TestMethod]
        public void TestResponseHelper()
        {
            // Create a new report list request response
            var reportDescriptors = new ReportDescriptor[]
            {
                new ReportDescriptor("uniqueIdentifier", "name", "description", "category", "applicationName", "menuPath", "path", new ReportParam[]{}, new SystemFilterParam[]{})
            };
            LoopBackRequestResponse initial =
                new LoopBackRequestResponse(Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow);

            // Set the IndirectPayloadUploadId property to a large value so that when we replace that
            // Value below, the resulting message will be smaller
            List<PropertyTuple> propertyTuples = new List<PropertyTuple>();
            propertyTuples.Add(new PropertyTuple(initial.PropertyInfo(x => x.IndirectPayloadUploadId), "somelongpayloaduploadid"));
            Response orig = new LoopBackRequestResponse(initial, propertyTuples);

            // Prepare a response with a zero size threshold, so it cannot be accommodated
            Response finalResponse;
            bool isWithinThreshold = ResponseHelper.PrepareResponse(orig, 0, GetPayloadId, out finalResponse);
            Assert.IsFalse(isWithinThreshold, "Zero threshold for message size should not have been accommodated");

            // Now prepare a response with a reasonable message size threshold
            UInt32 threshold = (UInt32)ResponseHelper.GetResponseAsString(orig).Length - 1;
            isWithinThreshold = ResponseHelper.PrepareResponse(orig, threshold, GetPayloadId, out finalResponse);
            Assert.IsTrue(isWithinThreshold, "Large threshold for message size should have been accommodated");
            LoopBackRequestResponse origCast = (orig as LoopBackRequestResponse);
            LoopBackRequestResponse prepareResponseCast = (finalResponse as LoopBackRequestResponse);
            Assert.AreEqual(origCast.Id, prepareResponseCast.Id);
            Assert.AreNotEqual(origCast.IndirectPayloadUploadId, prepareResponseCast.IndirectPayloadUploadId);
        }

        private static String GetPayloadId(Response response)
        {
            return "somepayloaduploadid";
        }        
        #endregion
    }
}
