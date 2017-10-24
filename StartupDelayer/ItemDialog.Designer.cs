namespace startup_delayer
{
  partial class ItemDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblItem = new System.Windows.Forms.Label();
            this.txbItem = new System.Windows.Forms.TextBox();
            this.lblOffset = new System.Windows.Forms.Label();
            this.numOffset = new System.Windows.Forms.NumericUpDown();
            this.ttipOffset = new System.Windows.Forms.ToolTip(this.components);
            this.lblWorkingDirectory = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txbWorkingDirectory = new System.Windows.Forms.TextBox();
            this.btnChooseWorkingDir = new System.Windows.Forms.Button();
            this.grpAdvanced = new System.Windows.Forms.GroupBox();
            this.ckbParentDir = new System.Windows.Forms.CheckBox();
            this.lblArguments = new System.Windows.Forms.Label();
            this.txbArguments = new System.Windows.Forms.TextBox();
            this.ckbAdvancedOptions = new System.Windows.Forms.CheckBox();
            this.lblState = new System.Windows.Forms.Label();
            this.cmbState = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).BeginInit();
            this.grpAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(168, 217);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(249, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(9, 15);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(67, 13);
            this.lblItem.TabIndex = 2;
            this.lblItem.Text = "Startup Item:";
            // 
            // txbItem
            // 
            this.txbItem.Location = new System.Drawing.Point(82, 12);
            this.txbItem.Name = "txbItem";
            this.txbItem.Size = new System.Drawing.Size(242, 20);
            this.txbItem.TabIndex = 3;
            this.txbItem.TextChanged += new System.EventHandler(this.txbItem_TextChanged);
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(9, 40);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(38, 13);
            this.lblOffset.TabIndex = 4;
            this.lblOffset.Text = "Offset:";
            // 
            // numOffset
            // 
            this.numOffset.Location = new System.Drawing.Point(82, 38);
            this.numOffset.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numOffset.Name = "numOffset";
            this.numOffset.Size = new System.Drawing.Size(75, 20);
            this.numOffset.TabIndex = 5;
            this.ttipOffset.SetToolTip(this.numOffset, "Enter value between 0 and 65535");
            // 
            // lblWorkingDirectory
            // 
            this.lblWorkingDirectory.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkingDirectory.Location = new System.Drawing.Point(6, 16);
            this.lblWorkingDirectory.Name = "lblWorkingDirectory";
            this.lblWorkingDirectory.Size = new System.Drawing.Size(58, 32);
            this.lblWorkingDirectory.TabIndex = 6;
            this.lblWorkingDirectory.Text = "Working Directory:";
            // 
            // txbWorkingDirectory
            // 
            this.txbWorkingDirectory.Enabled = false;
            this.txbWorkingDirectory.Location = new System.Drawing.Point(70, 19);
            this.txbWorkingDirectory.Name = "txbWorkingDirectory";
            this.txbWorkingDirectory.Size = new System.Drawing.Size(236, 20);
            this.txbWorkingDirectory.TabIndex = 7;
            // 
            // btnChooseWorkingDir
            // 
            this.btnChooseWorkingDir.Location = new System.Drawing.Point(70, 45);
            this.btnChooseWorkingDir.Name = "btnChooseWorkingDir";
            this.btnChooseWorkingDir.Size = new System.Drawing.Size(75, 23);
            this.btnChooseWorkingDir.TabIndex = 8;
            this.btnChooseWorkingDir.Text = "Choose...";
            this.btnChooseWorkingDir.UseVisualStyleBackColor = true;
            this.btnChooseWorkingDir.Click += new System.EventHandler(this.btnChooseWorkingDir_Click);
            // 
            // grpAdvanced
            // 
            this.grpAdvanced.Controls.Add(this.cmbState);
            this.grpAdvanced.Controls.Add(this.lblState);
            this.grpAdvanced.Controls.Add(this.ckbParentDir);
            this.grpAdvanced.Controls.Add(this.lblArguments);
            this.grpAdvanced.Controls.Add(this.txbArguments);
            this.grpAdvanced.Controls.Add(this.lblWorkingDirectory);
            this.grpAdvanced.Controls.Add(this.txbWorkingDirectory);
            this.grpAdvanced.Controls.Add(this.btnChooseWorkingDir);
            this.grpAdvanced.Location = new System.Drawing.Point(12, 64);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Size = new System.Drawing.Size(312, 130);
            this.grpAdvanced.TabIndex = 9;
            this.grpAdvanced.TabStop = false;
            this.grpAdvanced.Text = "Advanced Options";
            // 
            // ckbParentDir
            // 
            this.ckbParentDir.AutoSize = true;
            this.ckbParentDir.Location = new System.Drawing.Point(156, 49);
            this.ckbParentDir.Name = "ckbParentDir";
            this.ckbParentDir.Size = new System.Drawing.Size(124, 17);
            this.ckbParentDir.TabIndex = 11;
            this.ckbParentDir.Text = "Use Parent Directory";
            this.ckbParentDir.UseVisualStyleBackColor = true;
            this.ckbParentDir.CheckedChanged += new System.EventHandler(this.ckbParentDir_CheckedChanged);
            // 
            // lblArguments
            // 
            this.lblArguments.AutoSize = true;
            this.lblArguments.BackColor = System.Drawing.Color.Transparent;
            this.lblArguments.Location = new System.Drawing.Point(6, 77);
            this.lblArguments.Name = "lblArguments";
            this.lblArguments.Size = new System.Drawing.Size(60, 13);
            this.lblArguments.TabIndex = 9;
            this.lblArguments.Text = "Arguments:";
            // 
            // txbArguments
            // 
            this.txbArguments.Location = new System.Drawing.Point(70, 74);
            this.txbArguments.Name = "txbArguments";
            this.txbArguments.Size = new System.Drawing.Size(236, 20);
            this.txbArguments.TabIndex = 10;
            // 
            // ckbAdvancedOptions
            // 
            this.ckbAdvancedOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbAdvancedOptions.AutoSize = true;
            this.ckbAdvancedOptions.Location = new System.Drawing.Point(12, 221);
            this.ckbAdvancedOptions.Name = "ckbAdvancedOptions";
            this.ckbAdvancedOptions.Size = new System.Drawing.Size(144, 17);
            this.ckbAdvancedOptions.TabIndex = 0;
            this.ckbAdvancedOptions.Text = "Show Advanced Options";
            this.ckbAdvancedOptions.UseVisualStyleBackColor = true;
            this.ckbAdvancedOptions.CheckedChanged += new System.EventHandler(this.ckbAdvancedOptions_CheckedChanged);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Location = new System.Drawing.Point(6, 104);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 12;
            this.lblState.Text = "State:";
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(70, 101);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(121, 21);
            this.cmbState.TabIndex = 13;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.cmbState_SelectedIndexChanged);
            // 
            // ItemDialog
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(336, 252);
            this.Controls.Add(this.ckbAdvancedOptions);
            this.Controls.Add(this.grpAdvanced);
            this.Controls.Add(this.numOffset);
            this.Controls.Add(this.lblOffset);
            this.Controls.Add(this.txbItem);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ItemDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Startup Item";
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).EndInit();
            this.grpAdvanced.ResumeLayout(false);
            this.grpAdvanced.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblItem;
    private System.Windows.Forms.TextBox txbItem;
    private System.Windows.Forms.Label lblOffset;
    private System.Windows.Forms.NumericUpDown numOffset;
    private System.Windows.Forms.ToolTip ttipOffset;
        private System.Windows.Forms.Label lblWorkingDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txbWorkingDirectory;
        private System.Windows.Forms.Button btnChooseWorkingDir;
        private System.Windows.Forms.GroupBox grpAdvanced;
        private System.Windows.Forms.CheckBox ckbAdvancedOptions;
        private System.Windows.Forms.Label lblArguments;
        private System.Windows.Forms.TextBox txbArguments;
        private System.Windows.Forms.CheckBox ckbParentDir;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label lblState;
    }
}