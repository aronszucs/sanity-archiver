using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiver.form
{
    public partial class MessageForm : Form
    {
        public MessageForm(string label, string message)
        {
            InitializeComponent();
            Text = label;
            messageLabel.Text = message;
            Show();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
