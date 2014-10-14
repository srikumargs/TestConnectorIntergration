using System;
using System.Security.Cryptography;
using System.Text;

namespace Sage.Connector.Cloud.Integration.Interfaces.Utils
{
    public class MessageHashManager
    {
        #region Constructors

        /// <summary>
        /// Do not allow construction without the required params
        /// </summary>
        private MessageHashManager() {}

        /// <summary>
        /// Constructor taking the necessary symmetric key parts
        /// </summary>
        /// <param name="key"></param>
        public MessageHashManager(string key)
        {
            Key = Convert.FromBase64String(key);
        }

        #endregion


        #region Private Members

        private readonly byte[] Key;

        #endregion


        #region Public Methods

        /// <summary>
        /// Create a hash of a message using our key data
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string ComputeMessageHash(string plainText)
        {
            // Check arguments
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");

            // Create the hashing algorithm using our key
            using (HMACSHA256 hashAlgorithm = new HMACSHA256(Key))
            {
                // Get the byte array for the text using a default encoding
                // Then compute the hashed value.  HMACSHA256 will result in an
                // Output hash that is 256 bits in length regardless of input size
                return Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(plainText)));
            }
        }

        #endregion
    }
}
