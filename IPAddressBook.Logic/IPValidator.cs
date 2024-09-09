using System.Net;

namespace IPAddressBook.Logic
{
    public static class IPValidator
    {
        public static bool ValidateAddress(string ipstring)
        {
            if (!IPAddress.TryParse(ipstring, out var address))
            {
                return false;
            }

            var valid =
                address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ||
                address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6;

            return valid;
        }

        public static bool ValidateNetwork(string text)
        {
            return IPNetwork.TryParse(text, out _);
        }

        internal static bool CheckNetworkContains(IPNetwork network, IPAddressView addressview)
        {
            return network.Contains(addressview.Address);
        }
    }
}
