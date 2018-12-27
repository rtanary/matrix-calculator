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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public double Scalar = 1;
        public bool Saved = false; 

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(double.TryParse(txtScalar.Text, out Scalar))
            {
                Scalar = Convert.ToDouble(txtScalar.Text);
                Saved = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ensure that input is numeric");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The action was cancelled");
            this.Close();
        }
    }
}
