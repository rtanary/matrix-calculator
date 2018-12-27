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
            btnClear.Visible = false;
            btnFill.Visible = false;
        }
        double[][,] Memory = new double[3][,];
        TextBox[,] TextData = new TextBox[0, 0];

        private double SelectScalar()
        {
            Form4 Form_4 = new Form4();
            Form_4.ShowDialog();
            if (Form_4.Saved)
            {
                return Form_4.Scalar;
            }
            return 0;
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
        private string OutputResult(double[,] Matrix, int row, int col)
        {
            int max = 0;
            for(int j=0;j<col;j++)//searching for "largest" matrix entry for formatting
            {
                for(int i=0;i<row;i++)
                {
                    if(Math.Round(Matrix[i,j],3).ToString().Length>max)
                    {
                        max = Math.Round(Matrix[i, j], 3).ToString().Length;
                    }
                }
            }

            string[] Line = new string[row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    string s = "";
                    for(int k= Math.Round(Matrix[i, j], 3).ToString().Length;k<max;k++)
                    {
                        s += " ";//add appropriate number of spaces in order to make even 
                    }
                    Line[i] += Math.Round(Matrix[i, j], 3).ToString() +s;//adding lines together 
                }
            }
            return (string.Join(Environment.NewLine, Line));//outputting as multi-line string
        }
        private double[,] RREF(double[,] Matrix, int row, int col)
        {
            double[,] newMatrix = new double[row, col];

            for(int i=0;i<row;i++)
            {
                for(int j=0;j<col;j++)
                {
                    newMatrix[i,j] = Matrix[i, j];//initializing new matrix such that the parameters are not passed by reference
                }
            }

            int pivotj = 0;
            for (int i = 0; i < row; i++)
            {
                if (col <= pivotj)//if the pivot goes beyond array boundary
                {
                    break;
                }
                int pivoti = i; //set pivoti to the point of diagonal

                while (newMatrix[pivoti, pivotj] == 0) //searching for new pivot if current is 0
                {
                    pivoti++;
                    if (pivoti == row)//if pivoti goes beyond row
                    {
                        pivoti = i; //saves current address as pivotpoint
                        pivotj++;
                        if (col == pivotj)//if search is out of bounds
                        {
                            pivotj--;
                            break;
                        }
                    }
                }
                for (int j = 0; j < col; j++)//rowswap
                {
                    double temp = newMatrix[i, j];
                    newMatrix[i, j] = newMatrix[pivoti, j];
                    newMatrix[pivoti, j] = temp;
                }

                double dividerow = newMatrix[i, pivotj];//dividing the row such that the pivot is equal to 1
                if (dividerow != 0)
                    for (int j = 0; j < col; j++)
                    {
                        newMatrix[i, j] /= dividerow;
                    }
                for (int l = 0; l < row; l++)//subtracting all other rows by pivot
                {
                    if (l != i)
                    {
                        double scal = newMatrix[l, pivotj];
                        for (int k = 0; k < col; k++)
                        {
                            newMatrix[l, k] -= (scal * newMatrix[i, k]);
                        }
                    }
                }
                pivotj++;//updating new pivot
            }
            return newMatrix;
        }
        private bool VerifySave(double[,] Matrix, TextBox[,] Text, int row, int col)
        {
            double number;
            if(row==0||col==0)
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
                        if (Text[i, j].Text.Contains("/"))
                        {
                            if (VerifyFraction(Text[i, j].Text))
                            {
                                return true;
                            }
                        }
                        MessageBox.Show("Ensure that your inputs are all numeric");
                        return false;
                    }
                }
            }
            return true;
        }
        private bool VerifyFraction(string str)
        {
            double number;
            if (str.Count(f => f == '/') <= 1)//if there is only one fraction sign
            {
                if (double.TryParse(str.Substring(0, str.IndexOf('/')), out number) && double.TryParse(str.Substring(str.IndexOf('/') + 1), out number)) //both sides are numbers that can be evaluated
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        private double[,] Save(double[,] Matrix, TextBox[,] Text, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
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
        private bool VerifyNonNull(double[,] Matrix)
        {
            if(Matrix==null)
            {
                MessageBox.Show("Matrix is empty, please input a matrix");
            }
            return (Matrix != null);
        }
        private bool VerifyAdd(double[,] Matrix1, double[,] Matrix2)
        {
            if (!(Matrix1.GetLength(0) == Matrix2.GetLength(0) && Matrix1.GetLength(1) == Matrix2.GetLength(1)))
            {
                MessageBox.Show("Addition is not possible, check dimensions");//testing if matrices can be added
            }
            return (Matrix1.GetLength(0) == Matrix2.GetLength(0) && Matrix1.GetLength(1) == Matrix2.GetLength(1));
        }
        private double[,] Addition(double[,] Matrix1, double[,] Matrix2, int row, int col)
        {
            double[,] Matrix3 = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Matrix3[i, j] = Matrix1[i, j] + Matrix2[i, j];//adding matrices by entry
                }
            }
            return Matrix3;
        }
        private double[,] ScalarMultiplication(double scalar, double[,] Matrix)
        {
            double[,] newMatrix = new double[Matrix.GetLength(0), Matrix.GetLength(1)];
            //initializing a new matrix such that it isn't passed by reference
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = scalar * Matrix[i,j];
                }
            }
            return newMatrix;
        }
        private double[,] Transpose(double[,] Matrix)//changing rows and columns 
        {
            double[,] T = new double[Matrix.GetLength(1), Matrix.GetLength(0)];
            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                for (int j = 0; j < Matrix.GetLength(0); j++)
                {
                    if (i == j)
                    {
                        T[i, j] = Matrix[i, j];
                    }
                    else
                    {
                        T[i, j] = Matrix[j, i];
                    }
                }
            }
            return T;
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
        private double[,] MMultiplication(double[,] Matrix1, double[,] Matrix2)
        {
            double[,] Product = new double[Matrix1.GetLength(0), Matrix2.GetLength(1)];

            for (int i = 0; i < Product.GetLength(0); i++)
            {
                for (int j = 0; j < Product.GetLength(1); j++)
                {
                    double sum = 0;
                    for (int k = 0; k < Matrix1.GetLength(1); k++)
                    {
                        sum += Matrix1[i, k] * Matrix2[k, j];//using dot product formula
                    }
                    Product[i, j] = sum;
                }
            }
            return Product;
        }
        private bool VerifySquare(double[,] Matrix)
        {
            if (!(Matrix.GetLength(0) == Matrix.GetLength(1)))//verifying if square 
            {
                MessageBox.Show("Matrix is not Square, operation cannot be performed");
            }
            return (Matrix.GetLength(0) == Matrix.GetLength(1));
        }
        private double Determinant(double[,] Matrix, int row, int col)//recursive algorithm of determinant
        {
            if (row == 1)
            {
                return Matrix[0, 0];
            }
            else
            {
                double Det = 0;
                for (int i = 0; i < col; i++)
                {
                    //cofactor expansion of the first row
                    double[,] newMatrix = TrimCol(i, TrimRow(0, Matrix));
                    Det += Math.Pow(-1, i + 0) * Matrix[0, i] * Determinant(newMatrix, row - 1, col - 1);
                }
                return Det;
            }
        }
        private double[,] TrimRow(int rowtoRemove, double[,] Matrix)//removing one row of the matrix
        {
            double[,] newMatrix = new double[Matrix.GetLength(0) - 1, Matrix.GetLength(1)];
            for (int i = 0, j = 0; i < Matrix.GetLength(0); i++)
            {
                if (i == rowtoRemove)
                {
                    continue;
                }
                for (int k = 0, u = 0; k < Matrix.GetLength(1); k++)
                {
                    newMatrix[j, u] = Matrix[i, k];
                    u++;
                }
                j++;
            }
            return newMatrix;
        }
        private double[,] TrimCol(int columntoRemove, double[,] Matrix)//removing one column of a matrix input
        {
            double[,] newMatrix = new double[Matrix.GetLength(0), Matrix.GetLength(1) - 1];
            for (int i = 0, j = 0; i < Matrix.GetLength(0); i++)
            {
                for (int k = 0, u = 0; k < Matrix.GetLength(1); k++)
                {
                    if (k == columntoRemove)
                    {
                        continue;
                    }
                    newMatrix[j, u] = Matrix[i, k];
                    u++;
                }
                j++;
            }
            return newMatrix;
        }
        private double[,] DetMatrix(double[,] Matrix)//finding cofactors of matrix
        {
            double[,] newMatrix = new double[Matrix.GetLength(0), Matrix.GetLength(1)];
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (newMatrix.GetLength(0) == 1)
                    {
                        newMatrix[i, j] = 1;
                    }
                    else
                    {
                        newMatrix[i, j] = Determinant(TrimCol(j, TrimRow(i, Matrix)), Matrix.GetLength(0) - 1, Matrix.GetLength(1) - 1);
                    }
                }
            }
            return newMatrix;

        }
        private bool VerifyInvertible(double[,] Matrix)//seeing if matrix can be inverted 
        {
            if (Determinant(Matrix, Matrix.GetLength(0), Matrix.GetLength(1)) == 0)
            {
                MessageBox.Show("Matrix cannot be inverted");
            }
            return (Determinant(Matrix, Matrix.GetLength(0), Matrix.GetLength(1)) != 0);

        }
        private int Rank(double[,] Matrix)//requires rref matrix
        {
            int pivoti = 0, pivotj = 0, counter = 0;
            while (pivoti < Matrix.GetLength(0) && pivotj < Matrix.GetLength(1))
            {
                if (Matrix[pivoti, pivotj] == 1)//if point is pivot
                {
                    counter++;
                    pivoti++;
                }
                pivotj++;
            }
            return counter;
        }
 
        private void btnGenerate_Click(object sender, EventArgs e)
            {
                ClearTextBoxes(this);//disposing of prior textboxes

                int row = Convert.ToInt32(nudRow.Value);
                int col = Convert.ToInt32(nudCol.Value);//converting data from inputs

                TextData = new TextBox[row, col];
                int width = 22;
                int space = 10;
                int length = 44;

                Point origin = new Point(145, 36);

                for (int i = 0; i < row; i++)
                     {
                         for (int j = 0; j < col; j++)
                            {
                                TextData[i, j] = new TextBox();
                                TextData[i, j].TabIndex = 4;
                                TextData[i, j].Name = "TextBox" + i.ToString() + j.ToString();
                                TextData[i, j].Location = new Point(origin.X + (length + space) * j, origin.Y + (width + space) * i);
                                TextData[i, j].Size = new Size(length, width);
                                TextData[i, j].TextAlign = HorizontalAlignment.Center;
                                this.Controls.Add(TextData[i, j]);//setting up each textbox for form
                             }
                    }
                btnClear.Location = new Point(origin.X, origin.Y + (width+space)*row + space/2);
                btnFill.Location = new Point(origin.X, origin.Y + (width + space) * row + btnFill.Height + space);
                btnClear.Visible = true;
                btnFill.Visible = true;
                btnClear.TabStop = true;
                btnFill.TabStop = true;
                btnClear.TabIndex = 5;
                btnFill.TabIndex = 5;//setting up buttons to be used for new matrix
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
           int a = SelectMatrix_1();
            if(a!=-1)//if actually selected
            {
                Memory[a] = new double[TextData.GetLength(0), TextData.GetLength(1)];
                if (VerifySave(Memory[a], TextData, TextData.GetLength(0), TextData.GetLength(1)))
                {
                    Memory[a]= Save(Memory[a], TextData, TextData.GetLength(0), TextData.GetLength(1));
                    MessageBox.Show("Matrix Saved as Matrix " + Convert.ToChar(a + 65));
                }
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(a!=-1)
            {
                if(Memory[a]!=null)//if not null
                {
                    MessageBox.Show("Matrix " + Convert.ToChar(a + 65) + ":" +"\n" + OutputResult(Memory[a],Memory[a].GetLength(0), Memory[a].GetLength(1)));
                }
                else
                {
                    MessageBox.Show("No matrix currently stored as Matrix " + Convert.ToChar(a + 65));
                }
            }
        }
        private void btnAddition_Click(object sender, EventArgs e)
        {
            int[] a = SelectMatrix_2();
            if (a[0]!=-1 || a[1]!=-1)//if both were selected
            {
                if (VerifyNonNull(Memory[a[0]]) && VerifyNonNull(Memory[a[1]]))
                {
                    if (VerifyAdd(Memory[a[0]], Memory[a[1]]))
                        {
                            MessageBox.Show("Matrix " + Convert.ToChar(a[0] + 65) + "+" + Convert.ToChar(a[1] + 65) + ": " + "\n" + OutputResult(Addition(Memory[a[0]], Memory[a[1]], Memory[a[0]].GetLength(0), Memory[a[0]].GetLength(1)), Memory[a[1]].GetLength(0), Memory[a[1]].GetLength(1)));
                        }
                }

            }
        }
        private void btnScalarMultiplication_Click(object sender, EventArgs e)
        {
            
            int a = SelectMatrix_1();
            if (a != -1)
            {
                double c = SelectScalar();
                if(c!=0)
                {
                    if (VerifyNonNull(Memory[a]))
                    {
                        MessageBox.Show("'"+c+"'" + " * Matrix " + Convert.ToChar(a + 65) + ":" + "\n" + OutputResult(ScalarMultiplication(c, Memory[a]), Memory[a].GetLength(0), Memory[a].GetLength(1)));
                    }
                }
            }
        }
        private void btnTranspose_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(a!=-1)
            {
                if(VerifyNonNull(Memory[a]))
                {
                    MessageBox.Show("Matrix " + Convert.ToChar(a + 65) + "^T:" + "\n" + OutputResult(Transpose(Memory[a]), Transpose(Memory[a]).GetLength(0), Transpose(Memory[a]).GetLength(1)));
                }
            }
        }
        private void btnMatrixMultiplication_Click(object sender, EventArgs e)
        {
            int[] a = SelectMatrix_2();
            if(a[0]!=-1 && a[1]!=-1)
            {
                if (VerifyNonNull(Memory[a[0]]))
                {
                    if(VerifyMultiplication(Memory[a[0]],Memory[a[1]]))
                    {
                        double[,] Product = MMultiplication(Memory[a[0]], Memory[a[1]]);
                        MessageBox.Show("Matrix " +Convert.ToChar(a[0]+65) +Convert.ToChar(a[1]+65) +" = " + "\n" + OutputResult(Product, Product.GetLength(0), Product.GetLength(1)));
                    }
                }
            }
        }
        private void btnPower_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(a!=-1)
            {
                double k = SelectScalar();
                if(k==0)
                {
                    if (k % 1 == 0)
                    {
                        if (VerifySquare(Memory[a]))
                        {
                            int c = Convert.ToInt32(k);
                            double[,] Matrix = new double[Memory[a].GetLength(0), Memory[a].GetLength(1)];
                            Matrix = Memory[a];
                            for (int i = 0; i < c - 1; i++)
                            {
                                Matrix = MMultiplication(Matrix, Memory[a]);
                            }
                            MessageBox.Show("Matrix " + Convert.ToChar(a + 65) + " to the power of " + c + ":" + "\n" + OutputResult(Matrix, Matrix.GetLength(0), Matrix.GetLength(1)));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can't evaluate non-integer matrix powers");
                    }
                }
            }
        }
        private void btnDeterminant_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(a!=-1)
            {
                if(VerifyNonNull(Memory[a]))
                {
                    if(VerifySquare(Memory[a]))
                    {
                        MessageBox.Show("Determinant of Matrix " + Convert.ToChar(a + 65) + ":" + "\n" + Determinant(Memory[a], Memory[a].GetLength(9), Memory[a].GetLength(1)));
                    }
                }
            }
        }
        private void btnCofactor_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(a!=-1)
            {
                if(VerifyNonNull(Memory[a]))
                {
                    if(VerifySquare(Memory[a]))
                    {
                        double[,] newMatrix = DetMatrix(Memory[a]);
                        for (int i = 0; i < newMatrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < newMatrix.GetLength(1); j++)
                            {
                                newMatrix[i, j] *= Math.Pow(-1, i + j); //definition of cofactor
                            }
                        }

                        MessageBox.Show("Cofactor of Matrix " + Convert.ToChar(a + 65) + ":" + "\n" + OutputResult(newMatrix, newMatrix.GetLength(0), newMatrix.GetLength(1)));
                    }
                }
            }
        }
        private void btnMinor_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (a != -1)
            {
                if (VerifyNonNull(Memory[a]))
                {
                    if (VerifySquare(Memory[a]))
                    {
                        double [,] newMatrix = DetMatrix(Memory[a]);
                        MessageBox.Show("Minor of Matrix " + Convert.ToChar(a + 65) + ":" + "\n" + OutputResult(newMatrix, newMatrix.GetLength(0), newMatrix.GetLength(1)));
                    }
                }
            }
        }
        private void btnAdjugate_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (a != -1)
            {
                if (VerifyNonNull(Memory[a]))
                {
                    if (VerifySquare(Memory[a]))
                    {
                        double[,] newMatrix = DetMatrix(Memory[a]);
                        for (int i = 0; i < newMatrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < newMatrix.GetLength(1); j++)
                            {
                                newMatrix[i, j] *= Math.Pow(-1, i + j);
                            }
                        }
                        newMatrix = Transpose(newMatrix);//changing cofactor matrix to adjugate
                        MessageBox.Show("Adjugate of Matrix " + Convert.ToChar(a + 65) + ":" + "\n" + OutputResult(newMatrix, newMatrix.GetLength(0), newMatrix.GetLength(1)));
                    }
                }
            }
        }
        private void btnInverse_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if (a != -1)
            {
                if (VerifyNonNull(Memory[a]))
                {
                    if (VerifySquare(Memory[a]))
                    {
                        if(VerifyInvertible(Memory[a]))
                        {
                            double[,] newMatrix = DetMatrix(Memory[a]);
                            for (int i = 0; i < newMatrix.GetLength(0); i++)
                            {
                                for (int j = 0; j < newMatrix.GetLength(1); j++)
                                {
                                    newMatrix[i, j] *= Math.Pow(-1, i + j);
                                }
                            }
                            newMatrix = Transpose(newMatrix);
                            //finding adjugate matrix, then using the determinant to find the inverse
                            newMatrix = ScalarMultiplication(1 / Determinant(Memory[a], Memory[a].GetLength(0), Memory[a].GetLength(1)), newMatrix);

                            MessageBox.Show("Matrix " + Convert.ToChar(a + 65) + "' :" + "\n" + OutputResult(newMatrix, newMatrix.GetLength(0), newMatrix.GetLength(1)));
                        }
                    }
                }
            }
        }
        private void btnRREF_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(a!=-1)
            {
                if(VerifyNonNull(Memory[a]))
                {
                    MessageBox.Show("RREF of Matrix " + Convert.ToChar(a + 65) + " : " + "\n" + OutputResult(Memory[a],Memory[a].GetLength(0),Memory[a].GetLength(1)));
                }
            }
        }
        private void btnRowspace_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(a!=-1)
            {
                if(VerifyNonNull(Memory[a]))
                {
                    double[,] RowSpace = Transpose(RREF(Memory[a], Memory[a].GetLength(0), Memory[a].GetLength(1)));//finding row vectors

                    for(int j=0;j<RowSpace.GetLength(1);j++)
                    {
                        for(int i=0;i<RowSpace.GetLength(0);i++)
                        {
                            if(RowSpace[i,j]!=0)//if there are non-zero values, is part of rowspace 
                            {
                                break;
                            }
                            if(RowSpace[i,j]==0 && i==RowSpace.GetLength(0)-1)//if all entries are zero
                            {
                                RowSpace = TrimCol(j, RowSpace);//remove 
                                j--;//fixing address
                            }
                        }
                    }
                    if (RowSpace.GetLength(1) == 0)//if empty, zero vector
                    {
                        RowSpace = new double[RowSpace.GetLength(0), 1];
                        for (int i = 0; i < RowSpace.GetLength(0); i++)
                        {
                            RowSpace[i, 0] = 0;
                        }

                    }
                    MessageBox.Show("Rowspace of Matrix " + Convert.ToChar(a + 65) + " : " + "\n" + OutputResult(RowSpace, RowSpace.GetLength(0), RowSpace.GetLength(1)));
                }
            }
        }
        private void btnColSpace_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(a!=-1)
            {
                if(VerifyNonNull(Memory[a]))
                {
                    double[,] newMatrix = RREF(Memory[a], Memory[a].GetLength(0), Memory[a].GetLength(1));

                    double[,] ColSpace = new double[Memory[a].GetLength(0), Rank(newMatrix)];//defined by number of rows and rank of matrix
                    int pivoti = 0, pivotj = 0;

                    while (pivoti < newMatrix.GetLength(0) && pivotj < newMatrix.GetLength(1))
                    {
                        if (newMatrix[pivoti, pivotj] == 1)//if point is pivot
                        {
                            for(int i=0;i<Memory[a].GetLength(0);i++)
                            {
                                ColSpace[i, pivoti] = Memory[a][i, pivotj];//adding in column into matrix
                            }
                            pivoti++;

                        }
                        pivotj++;
                    }
                    if(ColSpace.GetLength(1)==0)//if empty, zero vector
                    {
                        ColSpace = new double[ColSpace.GetLength(0), 1];
                        for(int i=0;i<ColSpace.GetLength(0);i++)
                        {
                            ColSpace[i, 0] = 0;
                        }

                    }
                    MessageBox.Show("Columnspace of Matrix " + Convert.ToChar(a + 65) + " : " + "\n" + OutputResult(ColSpace, ColSpace.GetLength(0), ColSpace.GetLength(1)));
                }
            }
        }
        private void btnNullspace_Click(object sender, EventArgs e)
        {
            int a = SelectMatrix_1();
            if(a!=-1)
            {
                if(VerifyNonNull(Memory[a]))
                {
                    double[,] newMatrix = RREF(Memory[a], Memory[a].GetLength(0), Memory[a].GetLength(1));
                    double[,] Nullspace = new double[newMatrix.GetLength(1), newMatrix.GetLength(1) - Rank(newMatrix)];
                    int pivoti = 0, pivotj = 0, u=0;

                    while (pivoti < newMatrix.GetLength(0) && pivotj < newMatrix.GetLength(1))
                    {
                        if (newMatrix[pivoti, pivotj] != 1)//if point is not a pivot
                        {
                            for(int i=0;i<newMatrix.GetLength(0);i++)//fill out the row
                            {
                                Nullspace[i, u] = -newMatrix[i,pivotj];//negative when evaluating
                            }
                            for(int j=0;j<newMatrix.GetLength(1);j++)
                            {
                                if(j==pivotj)//if pivot point is equal to the point of the column, that is the free variable
                                {
                                    Nullspace[j, u] = 1;//adding free variables as part of the basis
                                }
                            }
                            u++;
                        }
                        else//if it is a pivot
                        {
                            if(pivoti!=newMatrix.GetLength(0)-1)//only add if the pivots can stay in array bounds
                            {
                                pivoti++;
                            }
                        }
                        pivotj++;
                    }

                    if(Nullspace.GetLength(1)==0||Nullspace.GetLength(1)==newMatrix.GetLength(1))//if nullspace is either empty or completely full, add one zero vector
                    {
                        Nullspace = new double[Nullspace.GetLength(0), 1];
                        for(int i=0;i<Nullspace.GetLength(0);i++)
                        {
                            Nullspace[i, 0] = 0;
                        }
                    }

                    MessageBox.Show("Nullspace of Matrix " + Convert.ToChar(a + 65) + " : " + "\n" + OutputResult(Nullspace, Nullspace.GetLength(0), Nullspace.GetLength(1)));
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            for(int i=0;i<TextData.GetLength(0);i++)
            {
                for(int j=0;j<TextData.GetLength(1);j++)
                {
                    TextData[i, j].Text = string.Empty;//clear all current textbox inputs
                }
            }
        }
        private void btnFill_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TextData.GetLength(0); i++)
            {
                for (int j = 0; j < TextData.GetLength(1); j++)
                {
                    if(TextData[i, j].Text == string.Empty)
                    {
                        TextData[i, j].Text = 0.ToString();//any blank textboxes become 0
                    }
                }
            }
        }
    }
}
