using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace startup_delayer
{
    public partial class MainForm : Form
    {
        private string title = "";
        private StartupManager manager;


        public MainForm(StartupManager manager)
        {
            this.manager = manager;

            InitializeComponent();

            title = ConfigurationManager.AppSettings["Title"];
            Text = title;

            // Customise the ListView
            listViewItems.Columns.Add("Program", -2);
            listViewItems.Columns.Add("Offset");
            listViewItems.Columns.Add("Working Directory");
            listViewItems.Columns.Add("Arguments");
            listViewItems.Columns.Add("State");

            UpdateUI();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!manager.IsSaveRequired) return;

            MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
            DialogResult confirmation = MessageBox.Show(this, "Do you wish to commit your changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
            if (confirmation == DialogResult.Yes)
            {
                manager.Save();
                e.Cancel = false;
            }
            else if (confirmation == DialogResult.No)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #region Toolstrip Items
        private void tsbCommit_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            using (OptionsForm options = new OptionsForm(manager.FileLocation))
            {
                options.ShowDialog();
            }
        }
        #endregion

        #region ListView

        #region Behaviours
        private void listViewItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listViewItems.SelectedItems.Count > 0 && listViewItems.FocusedItem.Bounds.Contains(e.Location))
                {
                    ctxtSpecificItem.Show(listViewItems, e.Location);
                }
            }
        }

        private void listViewItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listViewItems.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                MessageBox.Show(info.Item.Text);
            }
        }

        private void listViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
        #endregion

        #region ListView Item Context Menu
        private void tsmEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void tsmRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }
        #endregion
        
        #endregion

        private void Save()
        {
            manager.Save();
            UpdateUI();
        }

        private void Add()
        {
            using (ItemDialog dialog = new ItemDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    manager.AddStartupItem(dialog.Item);
                    PopulateListView(new List<StartupItem>(manager.GetItems()));
                    UpdateUI();
                }
            }
        }

        private void Edit()
        {
            if (listViewItems.SelectedIndices.Count == 0) return;

            // Get the selected index - first is fine as multi-select is off
            int index = listViewItems.SelectedIndices[0];

            StartupItem item = manager.GetItems().ElementAt(index);

            using (ItemDialog dialog = new ItemDialog(item))
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    manager.EditStartupItem(item, dialog.Item);
                    PopulateListView(new List<StartupItem>(manager.GetItems()));
                    UpdateUI();
                }
            }
        }

        private void Remove()
        {
            if (listViewItems.SelectedIndices.Count == 0) return;

            // Get the selected index - first is fine as multi-select is off
            int index = listViewItems.SelectedIndices[0];

            StartupItem item = manager.GetItems().ElementAt(index);
            manager.RemoveStartupItem(item);

            PopulateListView(new List<StartupItem>(manager.GetItems()));
            UpdateUI();
        }


        #region Helper Methods
        public void PopulateListView(List<StartupItem> items)
        {
            listViewItems.Items.Clear();
            foreach (StartupItem item in items)
            {
                string itemName = item.Item;
                int index = itemName.LastIndexOf('\\');
                if (index != -1)
                {
                    itemName = itemName.Substring(index + 1, itemName.Length - (index + 1));
                }

                string[] data = new string[]
                {
                    itemName,
                    item.Offset.ToString(),
                    item.WorkingDirectory,
                    item.Arguments,
                    item.WindowState.ToString()
                };

                listViewItems.Items.Add(new ListViewItem(data)
                {
                    ToolTipText = item.Item
                });
            }
        }

        private void UpdateUI()
        {
            if (manager.IsSaveRequired)
            {
                Text = title + " [Save Required]";
                tsbCommit.Enabled = true;
            }
            else
            {
                Text = title;
                tsbCommit.Enabled = false;
            }

            bool anyItemSelected = listViewItems.SelectedIndices.Count > 0;
            tsbEdit.Enabled = anyItemSelected;
            tsbRemove.Enabled = anyItemSelected;
        }
        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
                e.SuppressKeyPress = true;
            }
        }
    }
}
