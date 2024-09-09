namespace IPAddressBook
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            splitContainer1 = new SplitContainer();
            groupBoxSortDirection = new GroupBox();
            radioButtonDescendingOrder = new RadioButton();
            radioButtonAscendingOrder = new RadioButton();
            groupBoxAddressFamily = new GroupBox();
            checkBoxIPv6 = new CheckBox();
            checkBoxIPv4 = new CheckBox();
            buttonClear = new Button();
            labelInfo = new Label();
            labelStatic = new Label();
            textBoxIPAddress = new TextBox();
            buttonRemove = new Button();
            buttonAdd = new Button();
            labelIPAddress = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxSortDirection.SuspendLayout();
            groupBoxAddressFamily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBoxSortDirection);
            splitContainer1.Panel1.Controls.Add(groupBoxAddressFamily);
            splitContainer1.Panel1.Controls.Add(buttonClear);
            splitContainer1.Panel1.Controls.Add(labelInfo);
            splitContainer1.Panel1.Controls.Add(labelStatic);
            splitContainer1.Panel1.Controls.Add(textBoxIPAddress);
            splitContainer1.Panel1.Controls.Add(buttonRemove);
            splitContainer1.Panel1.Controls.Add(buttonAdd);
            splitContainer1.Panel1.Controls.Add(labelIPAddress);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Size = new Size(1113, 504);
            splitContainer1.SplitterDistance = 100;
            splitContainer1.TabIndex = 0;
            // 
            // groupBoxSortDirection
            // 
            groupBoxSortDirection.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxSortDirection.Controls.Add(radioButtonDescendingOrder);
            groupBoxSortDirection.Controls.Add(radioButtonAscendingOrder);
            groupBoxSortDirection.Location = new Point(888, 12);
            groupBoxSortDirection.Name = "groupBoxSortDirection";
            groupBoxSortDirection.Size = new Size(203, 74);
            groupBoxSortDirection.TabIndex = 11;
            groupBoxSortDirection.TabStop = false;
            groupBoxSortDirection.Text = "Sort Direction";
            // 
            // radioButtonDescendingOrder
            // 
            radioButtonDescendingOrder.AutoSize = true;
            radioButtonDescendingOrder.Location = new Point(6, 46);
            radioButtonDescendingOrder.Name = "radioButtonDescendingOrder";
            radioButtonDescendingOrder.Size = new Size(154, 19);
            radioButtonDescendingOrder.TabIndex = 2;
            radioButtonDescendingOrder.Text = "Sort in descending order";
            radioButtonDescendingOrder.UseVisualStyleBackColor = true;
            // 
            // radioButtonAscendingOrder
            // 
            radioButtonAscendingOrder.AutoSize = true;
            radioButtonAscendingOrder.Checked = true;
            radioButtonAscendingOrder.Location = new Point(6, 20);
            radioButtonAscendingOrder.Name = "radioButtonAscendingOrder";
            radioButtonAscendingOrder.Size = new Size(147, 19);
            radioButtonAscendingOrder.TabIndex = 1;
            radioButtonAscendingOrder.TabStop = true;
            radioButtonAscendingOrder.Text = "Sort in ascending order";
            radioButtonAscendingOrder.UseVisualStyleBackColor = true;
            // 
            // groupBoxAddressFamily
            // 
            groupBoxAddressFamily.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxAddressFamily.Controls.Add(checkBoxIPv6);
            groupBoxAddressFamily.Controls.Add(checkBoxIPv4);
            groupBoxAddressFamily.Location = new Point(667, 12);
            groupBoxAddressFamily.Name = "groupBoxAddressFamily";
            groupBoxAddressFamily.Size = new Size(203, 74);
            groupBoxAddressFamily.TabIndex = 10;
            groupBoxAddressFamily.TabStop = false;
            groupBoxAddressFamily.Text = "Address Family";
            // 
            // checkBoxIPv6
            // 
            checkBoxIPv6.AutoSize = true;
            checkBoxIPv6.Checked = true;
            checkBoxIPv6.CheckState = CheckState.Checked;
            checkBoxIPv6.Location = new Point(8, 45);
            checkBoxIPv6.Name = "checkBoxIPv6";
            checkBoxIPv6.Size = new Size(136, 19);
            checkBoxIPv6.TabIndex = 2;
            checkBoxIPv6.Text = "Show IPv6 Addresses";
            checkBoxIPv6.UseVisualStyleBackColor = true;
            // 
            // checkBoxIPv4
            // 
            checkBoxIPv4.AutoSize = true;
            checkBoxIPv4.Checked = true;
            checkBoxIPv4.CheckState = CheckState.Checked;
            checkBoxIPv4.Location = new Point(8, 21);
            checkBoxIPv4.Name = "checkBoxIPv4";
            checkBoxIPv4.Size = new Size(134, 19);
            checkBoxIPv4.TabIndex = 1;
            checkBoxIPv4.Text = "Show IPv4 addresses";
            checkBoxIPv4.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            buttonClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonClear.ForeColor = Color.Maroon;
            buttonClear.Location = new Point(292, 13);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(23, 23);
            buttonClear.TabIndex = 4;
            buttonClear.Text = "X";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.ForeColor = Color.Black;
            labelInfo.Location = new Point(90, 73);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(0, 15);
            labelInfo.TabIndex = 8;
            // 
            // labelStatic
            // 
            labelStatic.AutoSize = true;
            labelStatic.Location = new Point(331, 13);
            labelStatic.Name = "labelStatic";
            labelStatic.Size = new Size(306, 75);
            labelStatic.TabIndex = 7;
            labelStatic.Text = resources.GetString("labelStatic.Text");
            // 
            // textBoxIPAddress
            // 
            textBoxIPAddress.Location = new Point(90, 13);
            textBoxIPAddress.Name = "textBoxIPAddress";
            textBoxIPAddress.Size = new Size(225, 23);
            textBoxIPAddress.TabIndex = 1;
            // 
            // buttonRemove
            // 
            buttonRemove.Enabled = false;
            buttonRemove.Location = new Point(210, 42);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(105, 23);
            buttonRemove.TabIndex = 3;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            buttonAdd.Enabled = false;
            buttonAdd.Location = new Point(90, 42);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(105, 23);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // labelIPAddress
            // 
            labelIPAddress.AutoSize = true;
            labelIPAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelIPAddress.Location = new Point(12, 16);
            labelIPAddress.Name = "labelIPAddress";
            labelIPAddress.Size = new Size(66, 15);
            labelIPAddress.TabIndex = 0;
            labelIPAddress.Text = "IP address:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1113, 400);
            dataGridView1.TabIndex = 20;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 504);
            Controls.Add(splitContainer1);
            Name = "MainForm";
            ShowIcon = false;
            Text = "IP Address Book";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxSortDirection.ResumeLayout(false);
            groupBoxSortDirection.PerformLayout();
            groupBoxAddressFamily.ResumeLayout(false);
            groupBoxAddressFamily.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox textBoxIPAddress;
        private Button buttonRemove;
        private Button buttonAdd;
        private Label labelIPAddress;
        private DataGridView dataGridView1;
        private GroupBox groupBoxAddressFamily;
        private CheckBox checkBoxIPv6;
        private CheckBox checkBoxIPv4;
        private GroupBox groupBoxSortDirection;
        private RadioButton radioButtonDescendingOrder;
        private RadioButton radioButtonAscendingOrder;
        private Label labelStatic;
        private Label labelInfo;
        private Button buttonClear;
    }
}
