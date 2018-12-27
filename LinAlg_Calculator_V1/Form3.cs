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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            rbMatrixA1.Checked = true;
            rbMatrixA2.Checked = true;
        }

        public int[] num = new int[2];
        public bool Saved = false;

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if(rbMatrixA1.Checked)
            {
                num[0] = 0;
            }
            else if(rbMatrixB1.Checked)
            {
                num[0] = 1;
            }
            else
            {
                num[0] = 2;
            }
            
            if(rbMatrixA2.Checked)
            {
                num[1] = 0;
            }
            else if(rbMatrixB2.Checked)
            {
                num[1] = 1;
            }
            else
            {
                num[1] = 2;
            }
            Saved = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The action was cancelled");
            this.Close();
        }
    }
}
