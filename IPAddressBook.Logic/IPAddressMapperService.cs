using IPAddressBook.Model;

namespace IPAddressBook.Logic
{
    /// <summary>
    /// Map from EF classes to view classes.
    /// NOTE: Consider using extension methods instead.
    /// </summary>
    public static class IPAddressMapperService
    {
        private static IPAddressView MapFromBytes(IPAddressBase entity, byte[] bytes)
        {
            var ipAddress = new System.Net.IPAddress(bytes);

            return new IPAddressView
            {
                Address = ipAddress,
                AddressEntity = entity,
                AddressDisplay = ipAddress.ToString()
            };
        }

        public static IPAddressView Map(IPv4Address address)
        {
            // Convert from format used in pesistent storage to byte array
            var addressbytes = new byte[] {
                address.Octet1,
                address.Octet2,
                address.Octet3,
                address.Octet4
            };

            var viewAddress = MapFromBytes(address, addressbytes);
            return viewAddress;
        }

        public static IPAddressView Map(IPv6Address address)
        {
            // Convert from format used in pesistent storage to byte array
            var addressbytes = new byte[] {
                (byte)(address.Group1 >> 8),
                (byte)(address.Group1 & 0xff),
                (byte)(address.Group2 >> 8),
                (byte)(address.Group2 & 0xff),
                (byte)(address.Group3 >> 8),
                (byte)(address.Group3 & 0xff),
                (byte)(address.Group4 >> 8),
                (byte)(address.Group4 & 0xff),
                (byte)(address.Group5 >> 8),
                (byte)(address.Group5 & 0xff),
                (byte)(address.Group6 >> 8),
                (byte)(address.Group6 & 0xff),
                (byte)(address.Group7 >> 8),
                (byte)(address.Group7 & 0xff),
                (byte)(address.Group8 >> 8),
                (byte)(address.Group8 & 0xff)
            };

            var viewAddress = MapFromBytes(address, addressbytes);
            return viewAddress;
        }
    }
}
