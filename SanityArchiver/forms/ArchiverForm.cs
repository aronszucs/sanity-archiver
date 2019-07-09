using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiver.forms
{
    public partial class ArchiverForm : Form
    {
        public delegate void InputHandler(string fileName, string password);

        private InputHandler OnOkClicked;
        public ArchiverForm(InputHandler onOkClicked)
        {
            Init(onOkClicked);
        }
        public ArchiverForm(InputHandler onOkClicked, string defaultName)
        {
            Init(onOkClicked);
            nameTextBox.Text = defaultName;
        }
        private void Init(InputHandler onOkClicked)
        {
            InitializeComponent();
            OnOkClicked = onOkClicked;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            OnOkClicked(nameTextBox.Text, passwordTextBox.Text);
            Close();
        }
    }
}


