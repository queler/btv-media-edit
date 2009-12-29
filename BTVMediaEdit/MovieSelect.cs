using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTVMediaEdit
{
    public partial class MovieSelect : Form
    {
        public MovieSelect(List<string> fullNames)
        {
            InitializeComponent();

            foreach (string name in fullNames)
            {
                clbSelect.Items.Add(name);
            }
        }

        public List<string> GetSelected()
        {
            List<string> ls = new List<string>();
            foreach (object o in clbSelect.CheckedItems)
            {
                ls.Add(o.ToString());
            }
            return ls;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
