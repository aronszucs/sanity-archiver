using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SanityArchiver.prompter;

namespace SanityArchiver.form
{
    public partial class InputPromptForm : Form
    {
        private Prompter.InputHandler OnOkButtonClicked;
        public InputPromptForm(string message, string defaultValue, Prompter.InputHandler okButtonClick)
        {
            InitializeComponent();
            Text = message;
            inputTextBox.Text = defaultValue;
            OnOkButtonClicked = okButtonClick;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            OnOkButtonClicked(inputTextBox.Text);
            Close();
        }
    }
}
