using System.ComponentModel.DataAnnotations;

namespace IPAddressBook.Model
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Minor Code Smell", "S101:Types should be named in PascalCase",
        Justification = "Spurious warning.")]
    public abstract class IPAddressBase
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Notes { get; set; }
    }
}
