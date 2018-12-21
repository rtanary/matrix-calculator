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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnSave.Enabled = false;
        }

        MatrixInput Input = new MatrixInput(0,0);//Default matrix (for generation)

        MatrixOutput MatrixA = new MatrixOutput(0, 0);
        MatrixOutput MatrixB = new MatrixOutput(0, 0);
        MatrixOutput MatrixC = new MatrixOutput(0, 0);

        public class MatrixInput
        {
            public TextBox[,] Text = new TextBox[0, 0];
            public int Mrow, Mcol;

            public MatrixInput(int row, int col)
            {
                Text = new TextBox[row, col];
                Mrow = row;
                Mcol = col;
            }

        }
        public class MatrixOutput
        {
            public double[,] MatrixNum;
            public int Mrow, Mcol;
            //default instances of variables

            //initalizing variables
            public MatrixOutput(int row, int col)
            {
                MatrixNum = new double[row, col];
                Mrow = row;
                Mcol = col;
            }

            public bool VerifySave(double[,] Matrix, TextBox[,] Text, int row, int col)
            {
                double number;
                for(int i=0; i<row;i++)
                {
                    for (int j=0;j<col;j++)
                    {
                        if (!double.TryParse(Text[i, j].Text, out number))
                        {
                            MessageBox.Show("Ensure that your inputs are all numeric");
                            return false;
                        }
                    }
                }
                return true;
            }
            public double[,] Save(double[,] Matrix, TextBox[,] Text, int row, int col)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Matrix[i, j] = Convert.ToDouble(Text[i, j].Text);
                    }
                }
                return Matrix;
            }
            
            private bool VerifyAdd (MatrixOutput Matrix1, MatrixOutput Matrix2)
            {
                if(Matrix1.Mrow == Matrix2.Mrow && Matrix1.Mcol ==Matrix2.Mcol)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Addition is not possible, check dimensions");
                    return false;
                }
            }
            private double[,] Addition (double[,] Matrix1, double[,] Matrix2, int row, int col)
            {
                double[,] Matrix3 = new double[row, col];
                for (int i =0;i<row;i++)
                {
                    for(int j= 0;j<col;j++)
                    {
                        Matrix3[i, j] = Matrix1[i, j] + Matrix2[i, j];
                    }
                }
                return Matrix3;
            }

            private double[,] ScalarMultiplication (int scalar, MatrixOutput Matrix)
            {
                for(int i = 0;i<Matrix.Mrow; i++)
                {
                    for(int j=0;j<Matrix.Mcol;j++)
                    {
                        Matrix.MatrixNum[i, j] *= scalar;
                    }
                }
                return Matrix.MatrixNum;
            }

            private bool VerifyMultiplication(MatrixOutput Matrix1, MatrixOutput Matrix2)
            {
                if(Matrix1.Mcol==Matrix2.Mrow)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Incorrect dimensions. Ensure that the first matrix's columns are equal to the second matrix's rows");
                    return false;
                }
            }
        }
            private void btnGenerate_Click(object sender, EventArgs e)
            {
                int row = Convert.ToInt32(nudRow.Value);
                int col = Convert.ToInt32(nudCol.Value);

                Input = new MatrixInput(row, col);

                int width = 22;
                int space = 10;
                int length = 44;

                Point origin = new Point(215, 23);

                    for (int i = 0; i < row; i++)
                         {
                             for (int j = 0; j < col; j++)
                                {
                                    Input.Text[i, j] = new TextBox();
                                    Input.Text[i, j].Name = "TextBox" + i.ToString() + j.ToString();
                                    Input.Text[i, j].Location = new Point(origin.X + (length + space) * i, origin.Y + (width + space) * j);
                                    Input.Text[i, j].Size = new Size(length, width);
                                    this.Controls.Add(Input.Text[i, j]);
                                 }
                        }
                btnSave.Enabled = true;
            }

            private void btnSave_Click(object sender, EventArgs e)
        {
            Form2 Form_2 = new Form2();
            Form_2.ShowDialog();
            
            switch(Form_2.num)
            {
                case 1:
                    if(MatrixA.VerifySave(MatrixA.MatrixNum,Input.Text,Input.Mrow, Input.Mcol))
                    {
                        MatrixA.MatrixNum = MatrixA.Save(MatrixA.MatrixNum, Input.Text, Input.Mrow, Input.Mcol);
                    }
                    break;
                case 2:
                    if (MatrixB.VerifySave(MatrixB.MatrixNum, Input.Text, Input.Mrow, Input.Mcol))
                    {
                        MatrixB.MatrixNum = MatrixB.Save(MatrixB.MatrixNum, Input.Text, Input.Mrow, Input.Mcol);
                    }
                    break;
                case 3:
                    if (MatrixC.VerifySave(MatrixC.MatrixNum, Input.Text, Input.Mrow, Input.Mcol))
                    {
                        MatrixC.MatrixNum = MatrixC.Save(MatrixA.MatrixNum, Input.Text, Input.Mrow, Input.Mcol);
                    }
                    break;
            }
        }
    }
}
