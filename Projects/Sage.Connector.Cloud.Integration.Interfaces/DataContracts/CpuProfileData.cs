using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Sage.Connector.Cloud.Integration.Interfaces.Utils;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    [DataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "CpuProfileDataContract")]
    public class CpuProfileData : IExtensibleDataObject
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the CpuProfileData class
        /// </summary>
        public CpuProfileData(
            Int16 addressWidth,
            Int16 architecture,
            String caption,
            Int16 dataWidth,
            Int32 extClock,
            Int16 family,
            Int16 level,
            String manufacturer,
            Int32 maxClockSpeed,
            String name,
            Int32 numberOfCores,
            Int32 numberOfLogicalProcessors)
        {
            AddressWidth = addressWidth;
            Architecture = architecture;
            Caption = caption;
            DataWidth = dataWidth;
            ExtClock = extClock;
            Family = family;
            Level = level;
            Manufacturer = manufacturer;
            MaxClockSpeed = maxClockSpeed;
            Name = name;
            NumberOfCores = numberOfCores;
            NumberOfLogicalProcessors = numberOfLogicalProcessors;
        }

        /// <summary>
        /// Initializes a new instance of the CpuProfileData class from an existing instance and a collection of propertyTuples
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyTuples"></param>
        public CpuProfileData(CpuProfileData source, IEnumerable<PropertyTuple> propertyTuples)
        {
            AddressWidth = source.AddressWidth;
            Architecture = source.Architecture;
            Caption = source.Caption;
            DataWidth = source.DataWidth;
            ExtClock = source.ExtClock;
            Family = source.Family;
            Level = source.Level;
            Manufacturer = source.Manufacturer;
            MaxClockSpeed = source.MaxClockSpeed;
            Name = source.Name;
            NumberOfCores = source.NumberOfCores;
            NumberOfLogicalProcessors = source.NumberOfLogicalProcessors;
            ExtensionData = source.ExtensionData;

            var myPropertyTuples = propertyTuples.Where(x => x.Item1.DeclaringType == typeof(CpuProfileData));
            foreach (var tuple in myPropertyTuples)
            {
                tuple.Item1.SetValue(this, tuple.Item2, null);
            }
        }
        #endregion


        #region Public properties
        [DataMember(Name = "AddressWidth", IsRequired = true, Order = 0)]
        public Int16 AddressWidth
        { get; protected set; }

        [DataMember(Name = "Architecture", IsRequired = true, Order = 1)]
        public Int16 Architecture
        { get; protected set; }

        [DataMember(Name = "Caption", IsRequired = true, Order = 2)]
        public String Caption
        { get; protected set; }

        [DataMember(Name = "DataWidth", IsRequired = true, Order = 3)]
        public Int16 DataWidth
        { get; protected set; }

        [DataMember(Name = "ExtClock", IsRequired = true, Order = 4)]
        public Int32 ExtClock
        { get; protected set; }

        [DataMember(Name = "Family", IsRequired = true, Order = 5)]
        public Int16 Family
        { get; protected set; }

        [DataMember(Name = "Level", IsRequired = true, Order = 6)]
        public Int16 Level
        { get; protected set; }

        [DataMember(Name = "Manufacturer", IsRequired = true, Order = 7)]
        public String Manufacturer
        { get; protected set; }

        [DataMember(Name = "MaxClockSpeed", IsRequired = true, Order = 8)]
        public Int32 MaxClockSpeed
        { get; protected set; }

        [DataMember(Name = "Name", IsRequired = true, Order = 9)]
        public String Name
        { get; protected set; }

        [DataMember(Name = "NumberOfCores", IsRequired = true, Order = 10)]
        public Int32 NumberOfCores
        { get; protected set; }

        [DataMember(Name = "NumberOfLogicalProcessors", IsRequired = true, Order = 11)]
        public Int32 NumberOfLogicalProcessors
        { get; protected set; }


        // To support forward-compatible data contracts
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }
}
