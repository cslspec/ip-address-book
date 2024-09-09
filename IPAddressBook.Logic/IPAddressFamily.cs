namespace IPAddressBook.Logic
{
    /// <summary>
    /// IP address family.
    /// </summary>
    [Flags]
    public enum IPAddressFamily
    {
        None = 0,
        IPv4 = 1,
        IPv6 = 2
    }
}
