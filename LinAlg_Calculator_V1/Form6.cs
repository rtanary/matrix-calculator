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
    public partial class Form6 : Form
    {
        public Form6(double[,] Evalues)
        {
            InitializeComponent();
            int b = Evalues.GetLength(1);
            Output(Evalues);
        }
        public int num; 
        public bool Saved = false;
        private string Subscriptnum(int num)
        {
            string s=string.Empty;
            num++;//changing num to its actual number
            for(int i =0;i<num.ToString().Length;i++)
            {
                s+=Convert.ToChar(Convert.ToInt32(num.ToString().Substring(i, 1))+8320);
            }
            return s;
        }
        private void Output(double[,] Evalues)
        {
            int b = Evalues.GetLength(1);
            Point origin = new Point(3, 5);
            int height = 22, width = 113, i =0;
            for(i=0;i<b;i++)
            {
                RadioButton RBi = new RadioButton();
                RBi.Text = "λ" + Subscriptnum(i) + " (" + Math.Round(Evalues[0, i], 3) + ")";
                RBi.Tag = i;
                RBi.ForeColor = Color.FromArgb(215, 215, 215);
                RBi.Font = new Font("MS Sans Serif", 9, FontStyle.Regular);
                RBi.TabIndex = 1;
                RBi.Size = new Size(width,height);
                pnl.Controls.Add(RBi);
            }
            this.Height += i * (height);
            pnl.Height += i * (height);
            foreach (Control c in Controls)
            {
                if(c is Button)//if the control is a button
                {
                    c.Location = new Point(c.Location.X, c.Location.Y + height * i);
                }
            }
            //use i again here as a total
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectEigenvalue_Click(object sender, EventArgs e)
        {
            Saved = true;
            RadioButton rbSelected = pnl.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            num = Convert.ToInt32(rbSelected.Tag);
            this.Close();
        }
    }
}
