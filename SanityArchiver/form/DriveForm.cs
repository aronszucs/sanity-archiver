using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SanityArchiver.form
{
    public partial class DriveForm : Form
    {
        public delegate void DriveChangeHandler(string driveLetter);
        private DriveChangeHandler OnDriveChanged;
        public DriveForm(ICollection<DriveInfo> drives, DriveChangeHandler onDriveChanged)
        {
            InitializeComponent();
            Show();
            foreach (DriveInfo drive in drives)
            {
                driveListBox.Items.Add(drive.Name);
            }
            OnDriveChanged = onDriveChanged;
        }
        private void ChangeDrive()
        {
            OnDriveChanged(driveListBox.Text);
            Close();
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            ChangeDrive();
        }

        private void DriveListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeDrive();

        }
    }
}
