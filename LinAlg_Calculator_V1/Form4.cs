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
        public Form4(bool Fraction)
        {
            InitializeComponent();
            F = Fraction;
        }
        public double Scalar = 1;
        public bool Saved = false;
        public bool F;

        private bool VerifyFraction(string s)
        {
            double number;
            if (s.Count(f => f == '/') <= 1)//if there is only one fraction sign
            {
                if (double.TryParse(s.Substring(0, s.IndexOf('/')), out number) && double.TryParse(s.Substring(s.IndexOf('/') + 1), out number)) //both sides are numbers that can be evaluated
                {
                    return true;
                }
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (F && txtScalar.Text.Contains("/")&& VerifyFraction(txtScalar.Text))
            {
                Scalar = Convert.ToDouble(txtScalar.Text.Substring(0, txtScalar.Text.IndexOf('/')))/Convert.ToDouble(txtScalar.Text.Substring(txtScalar.Text.IndexOf('/')+1));
                Saved = true;
                this.Close();
            }
            else if (double.TryParse(txtScalar.Text, out Scalar))
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
            this.Close();
        }
    }
}
