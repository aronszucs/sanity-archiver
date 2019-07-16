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

        private RequestSizeDataHandler RequestSizeData;
        private TerminationHandler TerminateCalculation;
        public PropertyForm (string elementName, RequestSizeDataHandler onSizeRequested, 
            TerminationHandler onCalculationTerminated)
        {
            RequestSizeData = onSizeRequested;
            TerminateCalculation = onCalculationTerminated;
            Init(elementName, 0, 0);
            timer1.Start();
        }

        public PropertyForm(string elementName, int elements, long size)
        {
            Init(elementName, elements, size);
        }

        private void Init(string elementName, int elements, long size)
        {
            InitializeComponent();
            nameTextBox.Text = elementName;
            sizeTextBox.Text = size.ToString();
            elementsTextBox.Text = elements.ToString();
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
    }
}
