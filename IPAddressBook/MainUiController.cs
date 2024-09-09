using IPAddressBook.Data;
using IPAddressBook.Logic;

namespace IPAddressBook
{
    /// <summary>
    /// UI controller for <see cref="MainForm"/>.
    /// </summary>
    public class MainUiController
    {
        public MainUiController(
            DataGridView dataGridView,
            Button add,
            Button remove,
            Label info,
            CheckBox iPv4,
            CheckBox iPv6,
            RadioButton acsending
            )
        {
            _dataGridView = dataGridView;
            _add = add;
            _remove = remove;
            _labelInfo = info;
            _iPv4 = iPv4;
            _iPv6 = iPv6;
            _acsending = acsending;

            // Setup database
            var dbcontext = new AddressBookDbContext();
            dbcontext.Database.EnsureCreated();

            _addressService = new IPAddressService(dbcontext);
        }

        private readonly IPAddressService _addressService;

        private readonly DataGridView _dataGridView;

        private readonly Button _add;

        private readonly Button _remove;

        private readonly Label _labelInfo;

        private readonly CheckBox _iPv4;

        private readonly CheckBox _iPv6;

        private readonly RadioButton _acsending;

        private IPAddressFamily GetAddressFamiliesFromUi()
        {
            IPAddressFamily addressFamily = IPAddressFamily.None;
            if (_iPv4.Checked)
            {
                addressFamily |= IPAddressFamily.IPv4;
            }

            if (_iPv6.Checked)
            {
                addressFamily |= IPAddressFamily.IPv6;
            }

            return addressFamily;
        }

        internal void FillGrid()
        {
            var sortDirection = _acsending.Checked
                ? IPAddressSortDirection.Ascending
                : IPAddressSortDirection.Descending;

            var addressFamilies = GetAddressFamiliesFromUi();

            var list = _addressService.GetAllAddresses(addressFamilies, sortDirection);
            _dataGridView.DataSource = list;
        }

        internal void CheckIp(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                _labelInfo.Text = string.Empty;
                _labelInfo.ForeColor = Color.Black;
                _add.Enabled = false;
                _remove.Enabled = false;
                FillGrid();
            }
            else if (IPValidator.ValidateAddress(text))
            {
                PerformIpSearch(text);
            }
            else if (IPValidator.ValidateNetwork(text))
            {
                PerformNetworkSearch(text);
            }
            else
            {
                _labelInfo.Text = "Enter valid IP address or CIDR";
                _labelInfo.ForeColor = Color.Red;
                _add.Enabled = false;
                _remove.Enabled = false;
            }
        }

        private void PerformIpSearch(string text)
        {
            var addressFamilies = GetAddressFamiliesFromUi();
            var list = _addressService.GetAddresses(text, addressFamilies);

            string message;
            if (list.Count == 0)
            {
                message = "Address not found in address book";
                _add.Enabled = true;
                _remove.Enabled = false;
            }
            else
            {
                message = list.Count == 1
                    ? "Found 1 address in address book"
                    : $"Found {list.Count} addresses in address book";
                _add.Enabled = false;
                _remove.Enabled = true;
            }

            _labelInfo.Text = message;
            _labelInfo.ForeColor = Color.Black;

            _dataGridView.DataSource = list;
        }

        private void PerformNetworkSearch(string text)
        {
            var sortDirection = _acsending.Checked
                ? IPAddressSortDirection.Ascending
                : IPAddressSortDirection.Descending;

            var addressFamilies = GetAddressFamiliesFromUi();
            var list = _addressService.GetAddressesFromCidr(text, addressFamilies, sortDirection);

            string message;
            if (list.Count == 0)
            {
                message = "Addresses not found in address book";
            }
            else
            {
                message = list.Count == 1
                    ? "Found 1 address in address book"
                    : $"Found {list.Count} addresses in address book";
            }

            // Update info field and button states
            _labelInfo.Text = message;
            _labelInfo.ForeColor = Color.Black;
            _add.Enabled = false;
            _remove.Enabled = false;

            _dataGridView.DataSource = list;
        }

        internal void AddIp(string text)
        {
            // Add new IP address to database
            _addressService.AddAddress(text);

            // Show the new address in grid
            var addressFamilies = GetAddressFamiliesFromUi();
            var list = _addressService.GetAddresses(text, addressFamilies);
            _dataGridView.DataSource = list;

            // Update info field and button states
            _labelInfo.Text = "Address added to address book";
            _labelInfo.ForeColor = Color.Black;
            _add.Enabled = true;
            _remove.Enabled = true;
        }

        internal void RemoveIp(string text)
        {
            // Remove IP address from database
            _addressService.RemoveAddress(text);

            // Show an empty grid (since the filter still applies)
            var addressFamilies = GetAddressFamiliesFromUi();
            var list = _addressService.GetAddresses(text, addressFamilies);
            _dataGridView.DataSource = list;

            // Update info field and button states
            _labelInfo.Text = "Removed address from address book";
            _labelInfo.ForeColor = Color.Black;
            _add.Enabled = true;
            _remove.Enabled = false;
        }

        internal void SaveChanges()
        {
            _addressService.SaveChanges();
        }
    }
}
