using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace startup_delayer
{
    public partial class OptionsForm : Form
    {
        private string location = "";

        public OptionsForm(string location)
        {
            InitializeComponent();

            this.location = location;
        }

        private void btnShowJson_Click(object sender, EventArgs e)
        {
            Process.Start(location);
        }
    }
}
