namespace IPAddressBook.Model
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Minor Code Smell", "S101:Types should be named in PascalCase",
        Justification = "Spurious warning.")]
    public class IPv4Address : IPAddressBase
    {
        public required byte Octet1 { get; set; }

        public required byte Octet2 { get; set; }

        public required byte Octet3 { get; set; }

        public required byte Octet4 { get; set; }
    }
}
