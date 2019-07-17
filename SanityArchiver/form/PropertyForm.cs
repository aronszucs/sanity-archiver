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
    public partial class PropertyForm : Form
    {
        public delegate DirSizeCalculationData RequestSizeDataHandler();
        public delegate void TerminationHandler();

        public delegate void AttributeHandler(SettableAttributes attributes);
        private AttributeHandler OnOkClicked;

        private RequestSizeDataHandler RequestSizeData;
        private TerminationHandler TerminateCalculation;
        public PropertyForm (string elementName, RequestSizeDataHandler onSizeRequested, 
            TerminationHandler onCalculationTerminated, SettableAttributes attributes, AttributeHandler onOkClicked)
        {
            RequestSizeData = onSizeRequested;
            TerminateCalculation = onCalculationTerminated;
            Init(elementName, 0, 0, attributes, onOkClicked);
            timer1.Start();
        }

        public PropertyForm(string elementName, int elements, long size,
                            SettableAttributes attributes, AttributeHandler onOkClicked)
        {
            Init(elementName, elements, size, attributes, onOkClicked);
        }

        private void Init(string elementName, int elements, long size, SettableAttributes attributes, AttributeHandler onOkClicked)
        {
            InitializeComponent();
            nameTextBox.Text = elementName;
            sizeTextBox.Text = size.ToString();
            elementsTextBox.Text = elements.ToString();

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
            Show();

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DirSizeCalculationData data = RequestSizeData();
            sizeTextBox.Text = data.Size.ToString();
            elementsTextBox.Text = data.Elements.ToString();
        }

        private void PropertyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TerminateCalculation?.Invoke();
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
