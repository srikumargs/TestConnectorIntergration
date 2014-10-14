using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sage.Connector.Cloud.Integration.Interfaces.DataContracts
{
    /// <summary>
    /// An alternate collection contract, used instead of raw String[], in order to get reliable serialization behavior
    /// </summary>
    /// <remarks>
    /// If you use a raw String[] as a DataMember of a DataContract, then the namespace the serializer uses is not
    /// reliable (i.e., the generated namespace on the client side may be different than the server side).  This is a problem
    /// because it breaks the ability to compute a message body hash.
    /// </remarks>
    [CollectionDataContract(Namespace = ServiceConstants.V1_SERVICE_NAMESPACE, Name = "StringListContract", ItemName = "String")]
    public class StringList : List<String>
    {
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.List<T> class
        //     that is empty and has the default initial capacity.
        public StringList()
            : base()
        { }

        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.List<T> class
        //     that contains elements copied from the specified collection and has sufficient
        //     capacity to accommodate the number of elements copied.
        //
        // Parameters:
        //   collection:
        //     The collection whose elements are copied to the new list.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     collection is null.
        public StringList(IEnumerable<String> collection)
            : base(collection)
        { }

        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.List<T> class
        //     that is empty and has the specified initial capacity.
        //
        // Parameters:
        //   capacity:
        //     The number of elements that the new list can initially store.
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     capacity is less than 0.
        public StringList(int capacity)
            : base(capacity)
        { }
    }
}
