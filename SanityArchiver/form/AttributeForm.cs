using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SanityArchiver.data;

namespace SanityArchiver.form
{
    public partial class AttributeForm : Form
    {
        public delegate void AttributeHandler(SettableAttributes attributes);
        private readonly AttributeHandler OnOkClicked;
        public AttributeForm
            (SettableAttributes attributes, AttributeHandler onOkClicked)
        {
            InitializeComponent();
            Show();
            if (attributes.IsReadOnly)
            {
                readOnlyChBox.Checked = true;
            }
            if (attributes.IsHidden)
            {
                hiddenChBox.Checked = true;
            }
            if (attributes.IsArchive)
            {
                archiveChBox.Checked = true;
            }
            OnOkClicked = onOkClicked;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            SettableAttributes att = new SettableAttributes
                (readOnlyChBox.Checked, hiddenChBox.Checked, archiveChBox.Checked);
            OnOkClicked(att);
            Close();
        }
    }
}
