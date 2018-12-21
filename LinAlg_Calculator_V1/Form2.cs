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

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if(rbMatrixA.Checked)
            {
                num = 1;
            }
            else if(rbMatrixB.Checked)
            {
                num = 2;
            }
            else
            {
                num = 3;
            }
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
