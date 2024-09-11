using IPAddressBook.Data;
using IPAddressBook.Model;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace IPAddressBook.Logic
{
    /// <summary>
    /// IP address book service class. Supports search, update, add and removal.
    /// </summary>
    /// <param name="dbContext"></param>
    public class IPAddressService(AddressBookDbContext dbContext)
    {
        private readonly AddressBookDbContext _dbContext = dbContext;

        /// <summary>
        /// Add a new address to the database.
        /// </summary>
        /// <param name="ipText">IP address as text</param>
        public void AddAddress(string ipText)
        {
            if (!IPAddress.TryParse(ipText, out var address))
            {
                Debug.WriteLine($"{nameof(AddAddress)} got invalid IP address !");
                return;
            }

            if (address.AddressFamily == AddressFamily.InterNetwork)
            {
                // New IPv4 address
                var bytes = address.GetAddressBytes();
                var newAddress = new IPv4Address
                {
                    Octet1 = bytes[0],
                    Octet2 = bytes[1],
                    Octet3 = bytes[2],
                    Octet4 = bytes[3]
                };

                _dbContext.IPv4Addresses.Add(newAddress);
                _dbContext.SaveChanges();
            }
            else if (address.AddressFamily == AddressFamily.InterNetworkV6)
            {
                // New IPv6 address
                var bytes = address.GetAddressBytes();
                var newAddress = new IPv6Address
                {
                    Group1 = (ushort)((bytes[0] << 8) + bytes[1]),
                    Group2 = (ushort)((bytes[2] << 8) + bytes[3]),
                    Group3 = (ushort)((bytes[4] << 8) + bytes[5]),
                    Group4 = (ushort)((bytes[6] << 8) + bytes[7]),
                    Group5 = (ushort)((bytes[8] << 8) + bytes[9]),
                    Group6 = (ushort)((bytes[10] << 8) + bytes[11]),
                    Group7 = (ushort)((bytes[12] << 8) + bytes[13]),
                    Group8 = (ushort)((bytes[14] << 8) + bytes[15])
                };

                _dbContext.IPv6Addresses.Add(newAddress);
                _dbContext.SaveChanges();
            }
            else
            {
                Debug.WriteLine("Unknown address family");
            }
        }

        /// <summary>
        /// Remove a specific address from the database.
        /// </summary>
        /// <param name="text"></param>
        /// <exception cref="NotImplementedException"></exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Minor Code Smell",
            "S3267:Loops should be simplified with \"LINQ\" expressions",
            Justification = "Use a simpler code construct instead of .ForEach()")]
        public void RemoveAddress(string ipText)
        {
            var list = GetAddresses(ipText, IPAddressFamily.IPv4 | IPAddressFamily.IPv6);

            foreach (var address in list)
            {
                if (address.AddressEntity is IPv4Address ipv4)
                {
                    _dbContext.IPv4Addresses.Remove(ipv4);
                    Debug.WriteLine($"Removed IPv4 ID: {ipv4.Id}");
                }
                else if (address.AddressEntity is IPv6Address ipv6)
                {
                    _dbContext.IPv6Addresses.Remove(ipv6);
                    Debug.WriteLine($"Removed ID: {ipv6.Id}");
                }
            }

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Get a specific IP address from the database.
        /// </summary>
        /// <param name="ipText"></param>
        /// <param name="addressFamilies"></param>
        /// <returns></returns>
        public IList<IPAddressView> GetAddresses(string ipText, IPAddressFamily addressFamilies)
        {
            var list = new List<IPAddressView>();

            if (!IPAddress.TryParse(ipText, out var address))
            {
                Debug.WriteLine($"{nameof(GetAddresses)} got invalid IP address !");
                return list;
            }

            var ipv4Search =
                addressFamilies.HasFlag(IPAddressFamily.IPv4) &&
                address.AddressFamily == AddressFamily.InterNetwork;

            if (ipv4Search)
            {
                // Search for IPv4 address
                var bytes = address.GetAddressBytes();
                var ipv4 = _dbContext.IPv4Addresses
                    .Where(x =>
                        x.Octet1 == bytes[0] &&
                        x.Octet2 == bytes[1] &&
                        x.Octet3 == bytes[2] &&
                        x.Octet4 == bytes[3])
                    .Select(x => IPAddressMapperService.Map(x));
                list.AddRange(ipv4);
            }

            var ipv6Search =
                addressFamilies.HasFlag(IPAddressFamily.IPv6) &&
                address.AddressFamily == AddressFamily.InterNetworkV6;

            if (ipv6Search)
            {
                // Search for IPv6 address
                var bytes = address.GetAddressBytes();
                var ipv6 = _dbContext.IPv6Addresses
                    .Where(x =>
                        x.Group1 == ((bytes[0] << 8) + bytes[1]) &&
                        x.Group2 == ((bytes[2] << 8) + bytes[3]) &&
                        x.Group3 == ((bytes[4] << 8) + bytes[5]) &&
                        x.Group4 == ((bytes[6] << 8) + bytes[7]) &&
                        x.Group5 == ((bytes[8] << 8) + bytes[9]) &&
                        x.Group6 == ((bytes[10] << 8) + bytes[11]) &&
                        x.Group7 == ((bytes[12] << 8) + bytes[13]) &&
                        x.Group8 == ((bytes[14] << 8) + bytes[15]))
                    .Select(x => IPAddressMapperService.Map(x));
                list.AddRange(ipv6);
            }

            return list;
        }

        /// <summary>
        /// Get all IP addresses from the database. Apply IP address family filter and sort direction.
        /// </summary>
        /// <param name="addressFamily">IPv4 or IPv6 or both.</param>
        /// <param name="sortDirection">Ascending, descending or none.</param>
        /// <returns>List of IP addresses.</returns>
        public IList<IPAddressView> GetAllAddresses(
            IPAddressFamily addressFamilies,
            IPAddressSortDirection sortDirection)
        {
            var list = new List<IPAddressView>();

            if (addressFamilies.HasFlag(IPAddressFamily.IPv4))
            {
                if (sortDirection == IPAddressSortDirection.Ascending)
                {
                    // Fetch IPv4 addresses in ascending order.
                    var ipv4 = _dbContext.IPv4Addresses
                        .OrderBy(x => x.Octet1)
                        .ThenBy(x => x.Octet2)
                        .ThenBy(x => x.Octet3)
                        .ThenBy(x => x.Octet4)
                        .Select(x => IPAddressMapperService.Map(x));
                    list.AddRange(ipv4);
                }
                else if (sortDirection == IPAddressSortDirection.Descending)
                {
                    // Fetch IPv4 addresses in descending order.
                    var ipv4 = _dbContext.IPv4Addresses
                        .OrderByDescending(x => x.Octet1)
                        .ThenByDescending(x => x.Octet2)
                        .ThenByDescending(x => x.Octet3)
                        .ThenByDescending(x => x.Octet4)
                        .Select(x => IPAddressMapperService.Map(x));
                    list.AddRange(ipv4);
                }
                else
                {
                    // Fetch IPv4 addresses in arbitrary order.
                    var ipv4 = _dbContext.IPv4Addresses
                        .Select(x => IPAddressMapperService.Map(x));
                    list.AddRange(ipv4);
                }
            }

            if (addressFamilies.HasFlag(IPAddressFamily.IPv6))
            {
                if (sortDirection == IPAddressSortDirection.Ascending)
                {
                    // Fetch IPv6 addresses in ascending order.
                    var ipv6 = _dbContext.IPv6Addresses
                        .OrderBy(x => x.Group1)
                        .ThenBy(x => x.Group2)
                        .ThenBy(x => x.Group3)
                        .ThenBy(x => x.Group4)
                        .ThenBy(x => x.Group5)
                        .ThenBy(x => x.Group6)
                        .ThenBy(x => x.Group7)
                        .ThenBy(x => x.Group8)
                        .Select(x => IPAddressMapperService.Map(x));
                    list.AddRange(ipv6);
                }
                else if (sortDirection == IPAddressSortDirection.Descending)
                {
                    // Fetch IPv6 addresses in descending order.
                    var ipv6 = _dbContext.IPv6Addresses
                        .OrderByDescending(x => x.Group1)
                        .ThenByDescending(x => x.Group2)
                        .ThenByDescending(x => x.Group3)
                        .ThenByDescending(x => x.Group4)
                        .ThenByDescending(x => x.Group5)
                        .ThenByDescending(x => x.Group6)
                        .ThenByDescending(x => x.Group7)
                        .ThenByDescending(x => x.Group8)
                        .Select(x => IPAddressMapperService.Map(x));
                    list.AddRange(ipv6);
                }
                else
                {
                    // Fetch IPv6 addresses in arbitrary order.
                    var ipv6 = _dbContext.IPv6Addresses
                        .Select(x => IPAddressMapperService.Map(x));
                    list.AddRange(ipv6);
                }
            }

            return list;
        }

        public IList<IPAddressView> GetAddressesFromCidr(
            string networkText,
            IPAddressFamily addressFamilies,
            IPAddressSortDirection sortDirection)
        {
            if (!IPNetwork.TryParse(networkText, out var network))
            {
                Debug.WriteLine($"{nameof(GetAddressesFromCidr)} got invalid IP network address !");
                return [];
            }

            var all = GetAllAddresses(addressFamilies, sortDirection);
            var list = all
                .Where(x => IPValidator.CheckNetworkContains(network, x))
                .ToList();

            return list;
        }

        /// <summary>
        /// Save changes to IP Address entity.
        /// </summary>
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
