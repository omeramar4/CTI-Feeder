using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    public partial class CrevisConfForm : Form
    {
        public static double timeout = Convert.ToDouble(MyForm._crevisTimeout);

        public CrevisConfForm()
        {
            InitializeComponent();
            TimeoutTextBox.Text = timeout.ToString();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(TimeoutTextBox.Text);
            }
            catch
            {
                DialogResult result = MessageBox.Show("Invalid timeout value", "Error", MessageBoxButtons.OK);
            }

            if (string.IsNullOrWhiteSpace(TimeoutTextBox.Text))
            {
                timeout = 1500;
                DialogResult result = MessageBox.Show("No input - timeout is back to default (2 seconds)", "Error", MessageBoxButtons.OK);
            }
            else if (Convert.ToDouble(TimeoutTextBox.Text) < 1000)
            {
                DialogResult result = MessageBox.Show("Invalid timeout value", "Error", MessageBoxButtons.OK);
            }
            else
            {
                timeout = Convert.ToDouble(TimeoutTextBox.Text) ;
                TimeoutIsSetImg.Visible = true;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
