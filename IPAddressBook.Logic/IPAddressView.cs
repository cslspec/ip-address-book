using IPAddressBook.Model;
using System.ComponentModel;
using System.Net;

namespace IPAddressBook.Logic
{
    /// <summary>
    /// IP address model class design to be used in UI.
    /// </summary>
    public class IPAddressView
    {
        /// <summary>
        /// The actual IP address.
        /// </summary>
        [Browsable(false)]
        public required IPAddress Address { get; set; }

        /// <summary>
        /// Entity object from database.
        /// </summary>
        [Browsable(false)]
        public required IPAddressBase AddressEntity { get; set; }

        /// <summary>
        /// A textual representation of the IP address.
        /// </summary>
        public required string AddressDisplay { get; set; }

        /// <summary>
        /// Name of this IP address.
        /// </summary>
        public string? Name
        {
            get { return AddressEntity.Name; }
            set { AddressEntity.Name = value; }
        }

        /// <summary>
        /// Notes for this IP address.
        /// </summary>
        public string? Notes
        {
            get { return AddressEntity.Notes; }
            set { AddressEntity.Notes = value; }
        }
    }
}
