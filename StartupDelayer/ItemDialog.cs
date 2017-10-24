using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace startup_delayer
{
    public partial class ItemDialog : Form
    {
        private const int DefaultUpperTimeLimit = 3600;
        private const string UrlRegex = @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";

        private List<ProcessWindowStyle> stateChoices = new List<ProcessWindowStyle>()
        {
            ProcessWindowStyle.Normal,
            ProcessWindowStyle.Minimized,
            ProcessWindowStyle.Maximized
        };


        public StartupItem Item { get; private set; }


        public ItemDialog(StartupItem item = null)
        {
            InitializeComponent();
            Item = item == null ? new StartupItem(0, "", 0, "", "") : item;
            SetupDialog(Item);
        }


        private void SetupDialog(StartupItem item)
        {
            try
            {
                numOffset.Maximum = Convert.ToInt32(ConfigurationManager.AppSettings["UpperTimeLimit"]);
            }
            catch (FormatException)
            {
                numOffset.Maximum = DefaultUpperTimeLimit;
            }

            foreach (ProcessWindowStyle style in stateChoices)
            {
                cmbState.Items.Add(style.ToString());
            }

            // Populate Fields
            txbItem.Text = item.Item;
            numOffset.Value = item.Offset;
            txbWorkingDirectory.Text = item.WorkingDirectory;
            txbArguments.Text = item.Arguments;
            cmbState.SelectedIndex = stateChoices.IndexOf(item.WindowState);

            // Validate input and update UI appropriately
            bool isURL = IsURL(txbItem.Text);
            btnChooseWorkingDir.Enabled = !isURL;
            ckbParentDir.Enabled = !isURL;
            txbArguments.Enabled = !isURL;

            Height -= grpAdvanced.Height;
            grpAdvanced.Visible = false;

            if (txbItem.Text == "")
            {
                ckbParentDir.Enabled = false;
            }
            
            txbItem.Focus();
        }

        private void btnChooseWorkingDir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                txbWorkingDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isURL = IsURL(txbItem.Text);

            Item = new StartupItem(0, txbItem.Text, (int)numOffset.Value,
                isURL ? "" : txbWorkingDirectory.Text,
                isURL ? "" : txbArguments.Text,
                stateChoices[cmbState.SelectedIndex]);
        }

        private void ckbAdvancedOptions_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAdvancedOptions.Checked)
            {
                Height += grpAdvanced.Height;
                grpAdvanced.Visible = true;
                Location = new System.Drawing.Point(Location.X, Location.Y - (grpAdvanced.Height / 2));
            }
            else
            {
                Height -= grpAdvanced.Height;
                grpAdvanced.Visible = false;
                Location = new System.Drawing.Point(Location.X, Location.Y + (grpAdvanced.Height / 2));
            }
        }

        private void ckbParentDir_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbParentDir.Checked)
            {
                if (txbItem.Text != "")
                {
                    txbWorkingDirectory.Text = Path.GetDirectoryName(txbItem.Text);
                    btnChooseWorkingDir.Enabled = false;
                }
            }
            else
            {
                txbWorkingDirectory.Clear();
                btnChooseWorkingDir.Enabled = true;
            }
        }

        private void txbItem_TextChanged(object sender, EventArgs e)
        {
            bool isURL = IsURL(txbItem.Text);
            btnChooseWorkingDir.Enabled = !isURL;
            ckbParentDir.Enabled = !isURL;
            txbArguments.Enabled = !isURL;

            if (txbItem.Text == "")
            {
                txbWorkingDirectory.Clear();
                btnChooseWorkingDir.Enabled = false;
                ckbParentDir.Enabled = false;
            }
            else
            {
                btnChooseWorkingDir.Enabled = true;
                ckbParentDir.Enabled = true;
            }
        }

        private bool IsURL(string input)
        {
            Match urlMatch = Regex.Match(input, UrlRegex);
            return urlMatch.Success;
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text = cmbState.SelectedIndex.ToString();
        }
    }
}
