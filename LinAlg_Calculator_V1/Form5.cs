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
    public partial class Form5 : Form
    {
        public Form5(double[,] Matrix, string Identifier, bool Fraction)
        {
            InitializeComponent();
            Output(Matrix, Identifier, Fraction);
        }
        public bool Saved = false;

        private void Output(double[,] Matrix, string Identifier, bool Fraction)
        {
            int row = Matrix.GetLength(0);
            int col = Matrix.GetLength(1);
            int width = 22;
            int space = 10;
            int length = 3*width;
            int margin = (3/2)*space;
            Point origin = new Point(12, 29);

            TextBox[,] TextOutput = new TextBox[row, col];
            this.Size = new Size(margin*(col+2) + col*length + space, margin*(row+7)+row*width+lblOutput.Height +btnOk.Height +btnSave.Height);

            lblOutput.Text = Identifier;

            for(int i=0;i<row;i++)
            {
                for(int j=0;j<col;j++)
                {
                    TextOutput[i, j] = new TextBox();
                    TextOutput[i, j].TabIndex = 1;
                    TextOutput[i, j].ReadOnly = true;
                    TextOutput[i, j].Name = "TextBox" + i.ToString() + j.ToString();
                    TextOutput[i, j].Location = new Point(origin.X + (length + space) * j, origin.Y + (width + space) * i);
                    TextOutput[i, j].Size = new Size(length, width);
                    TextOutput[i, j].TextAlign = HorizontalAlignment.Center;

                    if (Matrix[i, j].ToString().Length >= 3 && Fraction)//smallest amount for a fraction to be interpreted (0.5)
                    {
                        int max = 1000;//max amount to divide by 
                        for (int k = 2; k < max; k++)
                        {
                            if (k * Matrix[i, j] % 1 == 0 && Matrix[i, j] % 1 != 0)//if it wasn't a whole number to begin with
                            {
                                TextOutput[i, j].Text = (k * Matrix[i, j]).ToString() + "/" + k.ToString();
                                break;
                            }
                            if (k == max - 1)//if there is no way to interpret fraction with max
                            {
                                TextOutput[i, j].Text = Matrix[i, j].ToString();
                            }
                        }
                    }
                    else
                    {
                        TextOutput[i, j].Text = Matrix[i, j].ToString();
                    }

                    this.Controls.Add(TextOutput[i, j]);
                }
            }
            btnOk.Location = new Point(origin.X, origin.Y + (width + space) * row +btnSave.Height+space);
            btnSave.Location = new Point(origin.X, origin.Y + (width + space) * row);

        }
        public int SelectMatrix()
        {
            Form2 Form_2 = new Form2();
            Form_2.ShowDialog();
            if (Form_2.Saved)
            {
                return Form_2.num;
            }
            return -1;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Saved = true;
            this.Close();
        }
    }
}
