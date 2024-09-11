using IPAddressBook.Logic;

namespace IPAddressBook
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Create UI controller
            _controller = new MainUiController(
                dataGridView1, buttonAdd, buttonRemove, labelInfo,
                checkBoxIPv4, checkBoxIPv6, radioButtonAscendingOrder);

            // Setup event handlers
            textBoxIPAddress.TextChanged += (_, _) => _controller.CheckIp(textBoxIPAddress.Text);
            checkBoxIPv4.CheckedChanged += (_, _) => _controller.CheckIp(textBoxIPAddress.Text);
            checkBoxIPv6.CheckedChanged += (_, _) => _controller.CheckIp(textBoxIPAddress.Text);
            radioButtonAscendingOrder.CheckedChanged += (_, _) => _controller.CheckIp(textBoxIPAddress.Text);

            buttonClear.Click += (_, _) => textBoxIPAddress.Text = string.Empty;
            buttonAdd.Click += (_, _) => _controller.AddIp(textBoxIPAddress.Text);
            buttonRemove.Click += (_, _) => _controller.RemoveIp(textBoxIPAddress.Text);

            dataGridView1.CellValueChanged += (_, _) => _controller.SaveChanges();

            // Setup and fill grid
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "address",
                HeaderText = "IP Address",
                DataPropertyName = nameof(IPAddressView.AddressDisplay),
                ReadOnly = true,
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "name",
                HeaderText = "Name",
                DataPropertyName = nameof(IPAddressView.Name),
                ReadOnly = false
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "notes",
                HeaderText = "Notes",
                DataPropertyName = nameof(IPAddressView.Notes),
                ReadOnly = false
            });
            _controller.FillGrid();
        }

        private readonly MainUiController _controller;
    }
}
