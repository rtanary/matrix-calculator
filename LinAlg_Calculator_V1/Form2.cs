using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinAlg_Calculator_V1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            rbMatrixA.Checked = true;
        }

        public int num;
        public bool Saved = false;

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if(rbMatrixA.Checked)
            {
                num = 0;
            }
            else if(rbMatrixB.Checked)
            {
                num = 1;
            }
            else
            {
                num = 2;
            }
            Saved = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
