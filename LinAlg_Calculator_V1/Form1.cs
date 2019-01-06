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
        //Attempt LU Decomposition Worse comes to worse, RREF Matrix * Diagonal 
        //Need elementary row operations for upper and lower triangular matrices (can make methods/buttons for that)
        //need a counter for the number of row exchanges in order to create such a matrix
        //cholesky decomposition?
        //Fix gui 
        //update all forms to fit color scheme
        public Form1()
        {
            InitializeComponent();
            pnlCalculations.Height = this.Height;
            pnlInput.Width = this.Width - pnlCalculations.Width;
            tCOperations.Height = pnlCalculations.Height - lblMatrixOperations.Height;
        }
        TextBox[,] TextData = new TextBox[0, 0];
        Matrix[] Memory = new Matrix[3];

        private double SelectScalar()
        {
            Form4 Form_4 = new Form4(cbFraction.Checked);
            Form_4.ShowDialog();
            if (Form_4.Saved)
            {
                return Form_4.Scalar;
            }
            return double.NaN;
        }
        private int SelectMatrix_1()
        {
            Form2 Form_2 = new Form2();
            Form_2.ShowDialog();
            if (Form_2.Saved)
            {
                return Form_2.num;
            }
            return -1;
        }
        private int[] SelectMatrix_2()
        {
            Form3 Form_3 = new Form3();
            Form_3.ShowDialog();
            if (Form_3.Saved)
            {
                return Form_3.num;
            }
            return new int[] { -1, -1 };
        }
        private int SelectEigenvalue(double[,] Eigenvalues)
        {
            Form6 Form_6 = new Form6(Eigenvalues);
            Form_6.ShowDialog();
            if(Form_6.Saved)
            {
                return Form_6.num;
            }
            return -1;
        }
        private double[,] Save(double[,] Matrix, TextBox[,] Text)
        {
            int row = Text.GetLength(0);
            int col = Text.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Text[i, j].Text = Text[i, j].Text.Trim();
                    if (Text[i, j].Text.Contains("/"))//if fraction
                    {
                        Matrix[i, j] = Convert.ToDouble(Text[i, j].Text.Substring(0, Text[i, j].Text.IndexOf('/'))) / Convert.ToDouble(Text[i, j].Text.Substring(Text[i, j].Text.IndexOf('/') + 1));
                    }
                    else//directly converting matrix to numbers
                    {
                        Matrix[i, j] = Convert.ToDouble(Text[i, j].Text);
                    }
                }
            }
            return Matrix;//want to be passed by reference, overwriting values
        }
        private void Save(double[,] newMatrix, int a)//used to overwrite a previous matrix with current output
        {
            Memory[a] = new Matrix(newMatrix.GetLength(0), newMatrix.GetLength(1));
            for (int i = 0; i < Memory[a].row; i++)
            {
                for (int j = 0; j < Memory[a].col; j++)
                {
                    Memory[a].MatrixNum[i, j] = newMatrix[i, j];
                }
            }
        }
        private void SetUpTextBox(int row, int col)
        {
            int width = 55;
            int space = 5;
            int length = 41;

            Point origin = new Point(145, 85);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    TextData[i, j] = new TextBox();
                    TextData[i, j].TabIndex = 10;
                    TextData[i, j].Name = "TextBox" + i.ToString() + j.ToString();
                    TextData[i, j].Location = new Point(origin.X + (length + space) * j, origin.Y + (length / 2 + space) * i);
                    TextData[i, j].Size = new Size(length, width);
                    TextData[i, j].TextAlign = HorizontalAlignment.Center;
                    this.Controls.Add(TextData[i, j]);//setting up each textbox for form
                }
            }
        }
        private void ClearTextBoxes(Control m)
        {
            for (int x = m.Controls.Count - 1; x >= 0; x--)
            {
                TextBox c = m.Controls[x] as TextBox;
                if (c != null)
                {
                    c.Dispose();
                }
            }
        }
        private string SuperscriptNum(string s)
        {
            string SupScript = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s.Substring(i, 1))
                {
                    case "-"://negative sign
                        SupScript += Convert.ToChar(8315);
                        break;
                    case "."://decimal
                        SupScript += Convert.ToChar(183);
                        break;
                    default://numbers
                        switch (Convert.ToInt32(s.Substring(i, 1)))
                        {
                            case 1:
                                SupScript += "\x00B9";
                                break;
                            case 2:
                                SupScript += "\x00B2";
                                break;
                            case 3:
                                SupScript += "\x00B3";
                                break;
                            default:
                                SupScript += Convert.ToChar(8304 + Convert.ToInt32(s.Substring(i, 1)));
                                break;
                        }
                        break;
                }
            }
            return SupScript;
        }
        private string Subscriptnum(int num)
        {
            string s = string.Empty;
            num++;//changing num to its actual number
            for (int i = 0; i < num.ToString().Length; i++)
            {
                s += Convert.ToChar(Convert.ToInt32(num.ToString().Substring(i, 1)) + 8320);
            }
            return s;
        }
        private void OutputResult(double[,] Matrix, string ID)
        {
            Form5 Form_5 = new Form5(Matrix, ID, cbFraction.Checked);
            Form_5.ShowDialog();
            if (Form_5.Saved)
            {
                int a = Form_5.SelectMatrix();
                if(a!=-1)
                {
                    Save(Matrix, a);
                    MessageBox.Show("Matrix Saved as Matrix " + Convert.ToChar(a + 65));
                }
            }
        }
        private string Fraction(double d)
        {
            int max = 1000;
            for (int i = 2; i < max; i++)
            {
                if (i * d % 1 == 0 && d % 1 != 0)
                {
                    return ((i * d).ToString() + "/" + i);
                }
            }
            return d.ToString();
        }
        private bool VerifySave(TextBox[,] Text, int row, int col)//textboxes can be saved as double
        {
            double number;
            if (row == 0 || col == 0)
            {
                MessageBox.Show("Please generate Matrix Dimensions");//if not generated 
                return false;
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (!double.TryParse(Text[i, j].Text, out number))//testing if textbox can be converted to double
                    {
                        if (Text[i, j].Text.Contains("/") && cbFraction.Checked)
                        {
                            if (VerifyFraction(Text[i, j].Text))
                            {
                                return true;
                            }
                        }
                        MessageBox.Show("Ensure that all inputs are filled in and numeric");
                        return false;
                    }
                }
            }
            return true;
        }
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
        private bool Verify(int a)
        {
            if (a != -1)
            {
                if (Memory[a].MatrixNum == null)
                {
                    MessageBox.Show("Selected memory is empty, action cannot be performed");
                }
                return Memory[a].MatrixNum != null;
            }
            return false;
        }
        private bool Verify(int[] a)//multi matrix verification
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == -1)
                {
                    return false;
                }
                if (Memory[a[i]].MatrixNum == null)
                {
                    return false;
                }
            }
            return true;
        }
        private bool VerifyAdd(double[,] Matrix1, double[,] Matrix2)
        {
            if (!(Matrix1.GetLength(0) == Matrix2.GetLength(0) && Matrix1.GetLength(1) == Matrix2.GetLength(1)))
            {
                MessageBox.Show("Addition is not possible, check dimensions of matrices");//testing if matrices can be added
            }
            return (Matrix1.GetLength(0) == Matrix2.GetLength(0) && Matrix1.GetLength(1) == Matrix2.GetLength(1));
        }
        private bool VerifyMultiplication(double[,] Matrix1, double[,] Matrix2)
        {
            if (Matrix1.GetLength(1) == Matrix2.GetLength(0))//checking if matrices can be multiplied
            {
                return true;
            }
            else
            {
                MessageBox.Show("Incorrect dimensions. Ensure that the first matrix's columns are equal to the second matrix's rows");
                return false;
            }
        }
        private bool VerifySquare(double[,] Matrix)
        {
            if (!(Matrix.GetLength(0) == Matrix.GetLength(1)))//verifying if square 
            {
                MessageBox.Show("Matrix is not square, operation cannot be performed");
            }
            return (Matrix.GetLength(0) == Matrix.GetLength(1));
        }
        private bool VerifyInvertible(Matrix Matrix)//seeing if matrix can be inverted 
        {
            if (VerifySquare(Matrix.MatrixNum))
            {
                if (Matrix.Determinant(Matrix.MatrixNum) == 0)
                {
                    MessageBox.Show("Matrix cannot be inverted");
                }
                return (Matrix.Determinant(Matrix.MatrixNum) != 0);

            }
            return false;
        }
        private bool VerifySymmetric (Matrix Matrix)
        {
            int row = Matrix.row;
            int col = Matrix.col;
            if(VerifySquare(Matrix.MatrixNum))
            {
                for(int i=0;i<row;i++)
                {
                    for(int j=i;j<col;j++)
                    {
                        if(Matrix.MatrixNum[i,j]!=Matrix.MatrixNum[j,i])
                        {
                            MessageBox.Show("Matrix is not symmetric, action cannot be performed");
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this);//disposing of prior textboxes

            int row = Convert.ToInt32(nudRow.Value);
            int col = Convert.ToInt32(nudCol.Value);//converting data from inputs
            TextData = new TextBox[row, col];
            SetUpTextBox(row, col);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (VerifySave(TextData, TextData.GetLength(0), TextData.GetLength(1)))
            {
                int a = SelectMatrix_1();
                if (a != -1)//if actually selected
                {
                    Memory[a] = new Matrix(TextData.GetLength(0), TextData.GetLength(1));
                    Memory[a].MatrixNum = Save(Memory[a].MatrixNum, TextData);
                    MessageBox.Show("Matrix Saved as Matrix " + Convert.ToChar(a + 65));

                }
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                OutputResult(Memory[a].MatrixNum, "Matrix " + Convert.ToChar(a + 65));
            }

        }
        private void btnAddition_Click(object sender, EventArgs e)
        {
            int[] a = SelectMatrix_2();
            if (Verify(a))
            {
                if (VerifyAdd(Memory[a[0]].MatrixNum, Memory[a[1]].MatrixNum))
                {
                    OutputResult(Memory[a[0]].Addition(Memory[a[0]].MatrixNum, Memory[a[1]].MatrixNum), "Matrix " + Convert.ToChar(a[0] + 65) + "+" + Convert.ToChar(a[1] + 65));
                }
            }
        }
        private void btnScalarMultiplication_Click(object sender, EventArgs e)
        {

            int a = SelectMatrix_1();
            if (Verify(a))
            {
                double c = SelectScalar();
                if (!(double.IsNaN(c)))
                {
                    if (cbFraction.Checked)
                    {
                        OutputResult(Memory[a].ScalarMultiplication(c, Memory[a].MatrixNum), "Matrix " + Fraction(c) + Convert.ToChar(a + 65));
                    }
                    else
                    {
                        OutputResult(Memory[a].ScalarMultiplication(c, Memory[a].MatrixNum), "Matrix " + Math.Round(c,3).ToString() + Convert.ToChar(a + 65));
                    }
                }
            }
        }
        private void btnTranspose_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                OutputResult(Memory[a].Transpose(Memory[a].MatrixNum), "Matrix " + Convert.ToChar(a + 65) + Convert.ToChar(7488));
            }
        }
        private void btnMatrixMultiplication_Click(object sender, EventArgs e)
        {
            int[] a = SelectMatrix_2();
            if (Verify(a))
            {
                if (VerifyMultiplication(Memory[a[0]].MatrixNum, Memory[a[1]].MatrixNum))
                {
                    OutputResult(Memory[a[0]].MMultiplication(Memory[a[0]].MatrixNum, Memory[a[1]].MatrixNum), "Matrix " + Convert.ToChar(a[0] + 65) + Convert.ToChar(a[1] + 65));
                }
            }
        }
        private void btnPower_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                if (VerifySquare(Memory[a].MatrixNum))
                {
                    double k = SelectScalar();
                    if (!(double.IsNaN(k)))
                    {
                        if(Memory[a].VerifyDiagonalizable(Memory[a].MatrixNum)&&Memory[a].VerifyPositiveDefinite(Memory[a].MatrixNum))
                        {
                            double[,] D = Memory[a].Power(k,Memory[a].Diagonal(Memory[a].MatrixNum));
                            double[,] P = Memory[a].Eigenspace(Memory[a].MatrixNum);
                            double[,] Pinv = Memory[a].Inverse(P);
                            double[,] Product = Memory[a].MMultiplication(Memory[a].MMultiplication(P, D), Pinv);
                            OutputResult(Product, "Matrix " + Convert.ToChar(a + 65) + SuperscriptNum(k.ToString()));
                        }
                        else//use basic power
                        {
                            if (k % 1 == 0)
                            {
                                int c = Convert.ToInt32(k);
                                if (c < 0 && VerifyInvertible(Memory[a]))
                                {
                                    OutputResult(Memory[a].Power(c, Memory[a].Inverse(Memory[a].MatrixNum)), "Matrix " + Convert.ToChar(a + 65) + SuperscriptNum(c.ToString()));
                                }
                                else if (c >= 0)
                                {
                                    OutputResult(Memory[a].Power(c, Memory[a].MatrixNum), "Matrix " + Convert.ToChar(a + 65) + SuperscriptNum(c.ToString()));
                                }
                                else
                                {
                                    MessageBox.Show("Matrix is not invertible, meaning there cannot exist a negative power of Matrix " + Convert.ToChar(a + 65));
                                }
                            }
                            else
                            {
                                MessageBox.Show("Since matrix is not diagonalizable or is not positive definite, it cannot evaluate for non-integer matrix powers");
                            }
                        }
                    }
                }
            }
        }
        private void btnDeterminant_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                if (VerifySquare(Memory[a].MatrixNum))
                {
                    MessageBox.Show("Determinant of Matrix " + Convert.ToChar(a + 65) + ":" + "\n" + Memory[a].Determinant(Memory[a].MatrixNum));
                }
            }
        }
        private void btnCofactor_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                if (VerifySquare(Memory[a].MatrixNum))
                {
                    OutputResult(Memory[a].Cofactor(Memory[a].MatrixNum), "Matrix C(" + Convert.ToChar(a + 65) + ")");
                }
            }
        }
        private void btnMinor_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                if (VerifySquare(Memory[a].MatrixNum))
                {
                    OutputResult(Memory[a].Minor(Memory[a].MatrixNum), "Matrix M(" + Convert.ToChar(a + 65) + ")");
                }
            }
        }
        private void btnAdjugate_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                if (VerifySquare(Memory[a].MatrixNum))
                {
                    OutputResult(Memory[a].Adjugate(Memory[a].MatrixNum), "Matrix Adj(" + Convert.ToChar(a + 65));
                }
            }
        }
        private void btnInverse_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                if (VerifySquare(Memory[a].MatrixNum))
                {
                    if (VerifyInvertible(Memory[a]))
                    {
                        OutputResult(Memory[a].Inverse(Memory[a].MatrixNum), "Matrix " + Convert.ToChar(a + 65) + Convert.ToChar(8315) + Convert.ToChar(185));
                    }
                }
            }
        }
        private void btnRREF_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                OutputResult(Memory[a].RREF(Memory[a].MatrixNum), "Matrix RREF(" + Convert.ToChar(a + 65) + ")");
            }
        }
        private void btnRowspace_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                OutputResult(Memory[a].Rowspace(Memory[a].MatrixNum), "Matrix Row(" + Convert.ToChar(a + 65) + ")");
            }
        }
        private void btnColSpace_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                OutputResult(Memory[a].Columnspace(Memory[a].MatrixNum), "Matrix Col(" + Convert.ToChar(a + 65) + ")");
            }
        }
        private void btnNullspace_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                OutputResult(Memory[a].Nullspace(Memory[a].MatrixNum), "Matrix Null(" + Convert.ToChar(a + 65) + ")");
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if(TextData.GetLength(0)==0)
            {
                MessageBox.Show("Please generate matrix dimensions");
            }
            else
            {
                for (int i = 0; i < TextData.GetLength(0); i++)
                {
                    for (int j = 0; j < TextData.GetLength(1); j++)
                    {
                        TextData[i, j].Text = string.Empty;//clear all current textbox inputs
                    }
                }
            }
        }
        private void btnFill_Click(object sender, EventArgs e)
        {
            if (TextData.GetLength(0) == 0)
            {
                MessageBox.Show("Please generate matrix dimensions");
            }
            else
            {
                for(int k=0;k<TextData.GetLength(0);k++)
                {
                    for(int l=0;l<TextData.GetLength(1);l++)
                    {
                        if(TextData[k,l].Text==string.Empty)
                        {
                            double a = SelectScalar();
                            if (!(double.IsNaN(a)))
                            {
                                for (int i = 0; i < TextData.GetLength(0); i++)
                                {
                                    for (int j = 0; j < TextData.GetLength(1); j++)
                                    {
                                        if (TextData[i, j].Text == string.Empty)
                                        {
                                            if(cbFraction.Checked)
                                            {
                                                TextData[i, j].Text = Fraction(a);
                                            }
                                            else
                                            {
                                                TextData[i, j].Text = a.ToString();//any blank textboxes become the fraction
                                            }
                                        }
                                    }
                                }
                            }
                            return;
                        }
                    }
                }
                MessageBox.Show("No empty cells to fill!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this);
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                SetUpTextBox(Memory[a].row, Memory[a].col);
                for (int i = 0; i < Memory[a].row; i++)
                {
                    for (int j = 0; j < Memory[a].col; j++)
                    {
                        if (Memory[a].MatrixNum[i, j].ToString().Length >= 3 && cbFraction.Checked)
                        {
                            int max = 1000;//max amount to divide by 
                            for (int k = 2; k < max; k++)
                            {
                                if (k * Memory[a].MatrixNum[i, j] % 1 == 0 && Memory[a].MatrixNum[i, j] % 1 != 0)
                                {
                                    TextData[i, j].Text = Fraction(Memory[a].MatrixNum[i, j]);
                                    break;
                                }
                                if (k == max - 1)
                                {
                                    TextData[i, j].Text = Memory[a].MatrixNum[i, j].ToString();
                                }
                            }
                        }
                        else
                        {
                            TextData[i, j].Text = Memory[a].MatrixNum[i, j].ToString();
                        }
                    }
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pnlCalculations.Height = this.Height;
            pnlInput.Width = this.Width - pnlCalculations.Width;
            tCOperations.Height = pnlCalculations.Height - lblMatrixOperations.Height;
        }

        private void btnUpper_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(Verify(a))
            {
                Matrix newMatrix = new Matrix(Memory[a].row, Memory[a].col);
                newMatrix = Memory[a].LU(Memory[a].MatrixNum)[1];
                OutputResult(newMatrix.MatrixNum, "Matrix U(" +Convert.ToChar(a+65)+")");
            }
        }

        private void btnLower_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(Verify(a))
            {
                Matrix newMatrix = new Matrix(Memory[a].row, Memory[a].col);
                newMatrix = Memory[a].LU(Memory[a].MatrixNum)[0];
                OutputResult(newMatrix.MatrixNum, "Matrix L("+Convert.ToChar(a+65)+")");
            }
        }

        private void btnCholesky_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                if(VerifySymmetric(Memory[a]))
                {
                    if(Memory[a].Cholesky(Memory[a].MatrixNum)!=null)
                    {
                        OutputResult(Memory[a].Cholesky(Memory[a].MatrixNum), "Cholesky Decomposition of Matrix " + Convert.ToChar(a + 65));
                    }
                    else
                    {
                        MessageBox.Show("Matrix is not capable of being decomposed");
                    }
                }
            }
        }

        private void btnEValues_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(Verify(a))
            {
                if(VerifySquare(Memory[a].MatrixNum))
                {
                    OutputResult(Memory[a].Eigenvalues_Num(Memory[a].MatrixNum), "Eigenvalue of Matrix " + Convert.ToChar(a + 65));
                }
            }
        }

        private void btnDiagonal_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                if (VerifySquare(Memory[a].MatrixNum))
                {
                    //verify if it is diagonizable 
                    OutputResult(Memory[a].Diagonal(Memory[a].MatrixNum), "Matrix D(" + Convert.ToChar(a + 65)+")");
                }
            }
        }

        private void btnEvectors_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (Verify(a))
            {
                if (VerifySquare(Memory[a].MatrixNum))
                {
                    double[,] Evalues = Memory[a].Eigenvalues_Num(Memory[a].MatrixNum);
                    int b = SelectEigenvalue(Evalues);
                    if (b != -1)
                    {
                        OutputResult(Memory[a].Eigenvector(Memory[a].MatrixNum, Evalues[0, b]), "v" + Subscriptnum(b)+" of Matrix " + Convert.ToChar(a+65)+":");
                    }
                }
            }
        }

        private void btnEigenspace_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(Verify(a))
            {
                if(VerifySquare(Memory[a].MatrixNum))
                {
                    OutputResult(Memory[a].Eigenspace(Memory[a].MatrixNum), "Matrix P("+Convert.ToChar(a+65)+")");
                }
            }
        }

        private void btnVerifyDiagonal_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(Verify(a))
            {
                if(VerifySquare(Memory[a].MatrixNum))
                {
                    if(Memory[a].VerifyDiagonalizable(Memory[a].MatrixNum))
                    {
                        MessageBox.Show("Matrix "+ Convert.ToChar(a + 65) + " is diagonalizable");
                    }
                    else
                    {
                        MessageBox.Show("Matrix " + Convert.ToChar(a + 65) + " is not diagonalizable");
                    }
                }
            }
        }

        private void btnFrobNorm_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(Verify(a))
            {
                MessageBox.Show("Frobenius of Matrix " + Convert.ToChar(a + 65) + ": " + Math.Round(Memory[a].norm(Memory[a].MatrixNum)));
            }
        }
    }
}
