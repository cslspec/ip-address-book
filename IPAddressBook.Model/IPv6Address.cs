namespace IPAddressBook.Model
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Minor Code Smell", "S101:Types should be named in PascalCase",
        Justification = "Spurious warning.")]
    public class IPv6Address : IPAddressBase
    {
        public required ushort Group1 { get; set; }

        public required ushort Group2 { get; set; }

        public required ushort Group3 { get; set; }

        public required ushort Group4 { get; set; }

        public required ushort Group5 { get; set; }

        public required ushort Group6 { get; set; }

        public required ushort Group7 { get; set; }

        public required ushort Group8 { get; set; }
    }
}
