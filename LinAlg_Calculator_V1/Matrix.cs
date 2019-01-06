using System;
using System.Data;

public struct Matrix
{
    public int row, col, s;
    public double[,] MatrixNum;

    public Matrix(int r, int c)
    {
        row = r;
        col = c;
        MatrixNum = new double[r, c];
        s = 0;
    }

    private double[,] TrimCol(int columntoRemove, double[,] Matrix)
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
    private double[,] TrimRow(int rowtoRemove, double[,] Matrix)
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
    private double[,] IdentityMatrix()
    {
        double[,] newMatrix = new double[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (i == j)
                {
                    newMatrix[i, j] = 1;
                }
                else
                {
                    newMatrix[i, j] = 0;
                }
            }
        }
        return newMatrix;
    }
    private bool VerifyIdentical(double[,] Matrix1, double[,] Matrix2)
    {
        for(int i=0;i<row;i++)
        {
            for(int j=0;j<col;j++)
            {
                if(Math.Round(Matrix1[i,j],8)!=Math.Round(Matrix2[i,j],8))
                {
                    return false;
                }
            }
        }
        return true;
    }
    private bool VerifyDiagonal(double[,] Matrix)
    {
        int row = Matrix.GetLength(0);
        int col = Matrix.GetLength(1);
        for(int i=0;i<row;i++)
        {
            for(int j=0;j<col;j++)
            {
                if(i!=j && Matrix[i,j]!=0)//if not diagonal, all should be diagonal 
                {
                    return false;
                }
            }
        }
        return true;
    }
    private bool VerifySteadyState(double[,] Matrix)
    {
        double[,] A0 = new double[row, col];
        double[,] A = new double[row, col];
        double[,] Q = new double[row, col];
        double[,] R = new double[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                A0[i, j] = Matrix[i, j];
                A[i, j] = Matrix[i, j];
            }
        }

        for (int i=0;i<10;i++)//simulation of an arbitrary 10 iterations to test for steady state
        {
            Q = QRDecomp_Q(A);
            R = QRDecomp_R(A);
            A = MMultiplication(R, Q);
            if(i==0)
            {
                continue;
            }
            if (VerifyIdentical(A0, A))
            {
                return true;
            }
        }
        return false; 
    }

    public double[,] RREF(double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                newMatrix[i, j] = Matrix[i, j];//initializing new matrix such that the parameters are not passed by reference
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
                        return newMatrix;
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
            {
                for (int j = 0; j < col; j++)
                {
                    newMatrix[i, j] /= dividerow;
                }
            }
            for (int l = 0; l < row; l++)//subtracting all other rows by pivot
            {
                if (l != i)
                {
                    double scal = newMatrix[l, pivotj];
                    for (int k = 0; k < col; k++)
                    {
                        newMatrix[l, k] -= (scal * newMatrix[i, k]);
                        newMatrix[l, k] = Math.Round(newMatrix[l, k]);
                    }
                }
            }
            pivotj++;//updating new pivot
        }
        return newMatrix;
    }
    public Matrix[] LU(double[,] Matrix)
    {
        int row = Matrix.GetLength(0);
        int col = Matrix.GetLength(1);
        Matrix[] newMatrix = new Matrix[2];//0 is lower, 1 is upper
        newMatrix[1] = new Matrix(row, col);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                newMatrix[1].MatrixNum[i, j] = Matrix[i, j];
            }
        }
        newMatrix[0] = new Matrix(row, col);
        newMatrix[0].MatrixNum = newMatrix[0].IdentityMatrix();

        int pivotj = 0;
        for (int i = 0; i < row; i++)
        {
            if (col <= pivotj)//if the pivot goes beyond array boundary
            {
                break;
            }
            int pivoti = i; //set pivoti to the point of diagonal

            while (newMatrix[1].MatrixNum[pivoti, pivotj] == 0) //searching for new pivot if current is 0
            {
                pivoti++;
                if (pivoti == row)//if pivoti goes beyond row
                {
                    pivoti = i; //saves current address as pivotpoint
                    pivotj++;
                    if (col == pivotj)//if search is out of bounds
                    {
                        pivotj--;
                        return newMatrix;//there is nothing left to check/rowswap
                    }
                }
            }
            for (int j = 0; j < col; j++)//rowswap
            {
                double temp = newMatrix[1].MatrixNum[i, j];
                newMatrix[1].MatrixNum[i, j] = newMatrix[1].MatrixNum[pivoti, j];
                newMatrix[1].MatrixNum[pivoti, j] = temp;
            }
            if (pivoti != i)//counting number of rowswaps
            {
                s++;
            }

            double dividerow = newMatrix[1].MatrixNum[i, pivotj];//dividing the row such that the pivot is equal to 1

            for (int l = pivoti; l < row; l++)//subtracting all other rows by pivot
            {
                if (l != i)
                {
                    double scal = newMatrix[1].MatrixNum[l, pivotj];
                    newMatrix[0].MatrixNum[l, pivotj] = scal / dividerow;
                    //add the scalar divide row to the identity matrix for the lower
                    for (int k = 0; k < col; k++)
                    {
                        newMatrix[1].MatrixNum[l, k] -= (scal / dividerow * newMatrix[1].MatrixNum[i, k]);
                    }
                }
            }
            pivotj++;//updating new pivot
        }
        return newMatrix;
    }
    public double[] Addition(double[] V1, double[] V2)
    {
        double[] V3 = new double[V1.GetLength(0)];
        for (int i = 0; i < V1.GetLength(0); i++)
        {
            V3[i] = V1[i] + V2[i];
        }
        return V3;
    }
    public double[,] Addition(double[,] Matrix1, double[,] Matrix2)
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
    public double[] ScalarMultiplication(double scalar, double[] V)
    {
        double[] Vector = new double[V.GetLength(0)];
        for (int i = 0; i < V.GetLength(0); i++)
        {
            Vector[i] = scalar * V[i];
        }
        return Vector;
    }
    public double[,] ScalarMultiplication(double scalar, double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];

        //initializing a new matrix such that it isn't passed by reference
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                newMatrix[i, j] = scalar * Matrix[i, j];
            }
        }
        return newMatrix;
    }
    public double[,] MMultiplication(double[,] Matrix1, double[,] Matrix2)
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
    public double[,] Inverse(double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];
        newMatrix = ScalarMultiplication(1 / Determinant(Matrix), Adjugate(Matrix));
        return newMatrix;
    }
    public double[,] Transpose(double[,] Matrix)
    {
        double[,] T = new double[col, row];
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
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
    public double[,] Nullspace(double[,] Matrix)
    {
        double[,] newMatrix = RREF(Matrix);
        double[,] Nullspace = new double[newMatrix.GetLength(1), newMatrix.GetLength(1) - Rank(newMatrix)];
        int pivoti = 0, pivotj = 0, u = 0;

        while (pivoti < newMatrix.GetLength(0) && pivotj < newMatrix.GetLength(1))
        {
            if (newMatrix[pivoti, pivotj] != 1)//if point is not a pivot
            {
                for (int i = 0; i < newMatrix.GetLength(0); i++)//fill out the row
                {
                    Nullspace[i, u] = -newMatrix[i, pivotj];//negative when evaluating
                }
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    if (j == pivotj)//if pivot point is equal to the point of the column, that is the free variable
                    {
                        Nullspace[j, u] = 1;//adding free variables as part of the basis
                    }
                }
                u++;
            }
            else//if it is a pivot
            {
                if (pivoti != newMatrix.GetLength(0) - 1)//only add if the pivots can stay in array bounds
                {
                    pivoti++;
                }
            }
            pivotj++;
        }

        if (Nullspace.GetLength(1) == 0 || Nullspace.GetLength(1) == newMatrix.GetLength(1))//if nullspace is either empty or completely full, add one zero vector
        {
            Nullspace = new double[Nullspace.GetLength(0), 1];
            for (int i = 0; i < Nullspace.GetLength(0); i++)
            {
                Nullspace[i, 0] = 0;
            }
        }
        return Nullspace;
    }
    public double[,] Columnspace(double[,] Matrix)
    {
        double[,] newMatrix = RREF(Matrix);
        double[,] Colspace = new double[Matrix.GetLength(0), Rank(newMatrix)];//defined by number of rows and rank of matrix
        int pivoti = 0, pivotj = 0;

        while (pivoti < newMatrix.GetLength(0) && pivotj < newMatrix.GetLength(1))
        {
            if (newMatrix[pivoti, pivotj] == 1)//if point is pivot
            {
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    Colspace[i, pivoti] = Matrix[i, pivotj];//adding in column into matrix
                }
                pivoti++;

            }
            pivotj++;
        }
        if (Colspace.GetLength(1) == 0)//if empty, zero vector
        {
            Colspace = new double[Colspace.GetLength(0), 1];
            for (int i = 0; i < Colspace.GetLength(0); i++)
            {
                Colspace[i, 0] = 0;
            }

        }
        return Colspace;
    }
    public double[,] Rowspace(double[,] Matrix)
    {
        double[,] Rowspace = Transpose(RREF(Matrix));//finding row vectors

        for (int j = 0; j < Rowspace.GetLength(1); j++)
        {
            for (int i = 0; i < Rowspace.GetLength(0); i++)
            {
                if (Rowspace[i, j] != 0)//if there are non-zero values, is part of rowspace 
                {
                    break;
                }
                if (Rowspace[i, j] == 0 && i == Rowspace.GetLength(0) - 1)//if all entries are zero
                {
                    Rowspace = TrimCol(j, Rowspace);//remove 
                    j--;//fixing address
                }
            }
        }
        if (Rowspace.GetLength(1) == 0)//if empty, zero vector
        {
            Rowspace = new double[Rowspace.GetLength(0), 1];
            for (int i = 0; i < Rowspace.GetLength(0); i++)
            {
                Rowspace[i, 0] = 0;
            }

        }
        return Rowspace;
    }
    public double Determinant(double[,] Matrix)
    {
        Matrix[] Ref = LU(Matrix);//by method of LU Decomposition
        double Det = 1;
        for (int c = 0; c < Ref.Length; c++)
        {
            for (int i = 0; i < Ref[c].MatrixNum.GetLength(0); i++)
            {
                Det *= Ref[c].MatrixNum[i, i];
            }
        }
        int s = Ref[0].s + Ref[1].s;

        return Math.Pow(-1, s) * Det;
    }
    public double Determinant(double[,] Matrix, int row, int col)
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
                double[,] newMatrix = new double[row - 1, col - 1];
                newMatrix = TrimCol(i, TrimRow(0, Matrix));
                Det += Math.Pow(-1, i + 0) * Matrix[0, i] * Determinant(newMatrix, row - 1, col - 1);
            }
            return Det;
        }
    }
    public double[,] Minor(double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (newMatrix.GetLength(0) == 1)
                {
                    newMatrix[i, j] = 1;
                }
                else
                {
                    newMatrix[i, j] = Determinant(TrimCol(j, TrimRow(i, Matrix)));
                }
            }
        }
        return newMatrix;
    }
    public double[,] Cofactor(double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];
        newMatrix = Minor(Matrix);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                newMatrix[i, j] = Math.Pow(-1, i + j) * newMatrix[i, j];
            }
        }
        return newMatrix;
    }
    public double[,] Adjugate(double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];
        newMatrix = Transpose(Cofactor(Matrix));
        return newMatrix;
    }
    public double[,] Power(int c, double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];
        newMatrix = Matrix;
        if (c == 0)
        {
            newMatrix = IdentityMatrix();
        }
        else
        {
            for (int i = 1; i < c; i++)
            {
                newMatrix = MMultiplication(newMatrix, Matrix);
            }
        }
        return newMatrix;
    }
    public double[,] Power(double k, double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];
        newMatrix = IdentityMatrix();
        //only for diagonalizable matrices
        for(int i=0;i<row;i++)
        {
            newMatrix[i, i] = Math.Pow(Matrix[i, i], k);
        }
        return newMatrix;
    }
    public double[,] Cholesky(double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (i == j)//if they are on the diagonal
                {
                    double sum = 0;
                    for (int k = i; k >= 0; k--)
                    {
                        sum += Math.Pow(newMatrix[i, k], 2);
                    }
                    if (newMatrix[i, j] >= 0)
                    {
                        newMatrix[i, j] = Math.Sqrt(Matrix[i, j] - sum);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (newMatrix[j, j] != 0)
                    {
                        double sum = 0;
                        for (int k = i; k >= 0; k--)
                        {
                            sum += newMatrix[i, k] * newMatrix[j, k];
                        }
                        newMatrix[i, j] = (Matrix[i, j] - sum) / newMatrix[j, j];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        return newMatrix;
    }
    private double[,] Eigenvalues(double[,] Matrix)
    {
        double[,] A = new double[row, col];
        double[,] Q = new double[row, col];
        double[,] R = new double[row, col];
        for (int i=0;i<row;i++)
        {
            for(int j=0;j<col;j++)
            {
                A[i, j] = Matrix[i, j];
            }
        }
        if(!VerifyDiagonal(A)&&!VerifySteadyState(A))//or is changing between certain values
        {
            Q = QRDecomp_Q(A);
            R = QRDecomp_R(A);
            A = MMultiplication(R, Q);
            A = Eigenvalues(A);
        }
        else//if the matrix reaches steady state
        {
            return A;
        }
        return A;//passing the matrix up to the previous iteration
    }
    public double[,] Eigenvalues_Num (double[,] Matrix)
    {
        double[,] Evalues = new double[1,col];//setting up evalues for use in output
        double[,] newMatrix = new double[row, col];
        newMatrix = Matrix;
        newMatrix = Eigenvalues(newMatrix);
        for(int i=0;i<col;i++)
        {
            Evalues[0, i] = newMatrix[i, i];
        }
        return Evalues;
    }
    private double[,] QRDecomp_R (double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];
        newMatrix = MMultiplication(QRDecomp_Q(Matrix), Matrix);
        return newMatrix;//returns diagonal R matrix
    }
    private double[,] QRDecomp_Q(double[,]Matrix)
    {
        double[,] newMatrix = new double[row, col];
        newMatrix = Transpose(GrammSchmidt(Matrix));
        return newMatrix;//returns Q matrix
    }
    private double[,] GrammSchmidt(double[,] Matrix)
    {
        int row = Matrix.GetLength(0);
        int col = Matrix.GetLength(1);
        double[][] Vectors = new double[row][];
        double[,] newMatrix = new double[row, col];
        for (int i = 0; i < col; i++)
        {
            Vectors[i] = new double[col];
            for (int j = 0; j < row; j++)
            {
                Vectors[i][j] = Matrix[j, i];
            }
        }
        for (int i = 1; i < col; i++)
        {
            double[] sum = new double[col];
            for (int j = i - 1; j >= 0; j--)
            {
                sum = Addition(Projection(Vectors[j], Vectors[i]), sum);
            }
            Vectors[i] = Addition(Vectors[i], ScalarMultiplication(-1, sum));
        }
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                newMatrix[j, i] = Vectors[i][j];
            }
        }
        for(int j=0;j<col;j++)
        {
            double norm = 0;
            for(int i=0;i<row;i++)
            {
                norm += Math.Pow(newMatrix[i,j],2);
            }
            norm = Math.Sqrt(norm);//finding norm for each row
            if (norm ==0)
            {
                norm = 1;
            }
            for(int i =0;i<row;i++)
            {
                newMatrix[i, j] /= norm;
            }
        }
        return newMatrix;
    }
    private double[] Projection(double[] u, double[] v)
    {
        double[] V1 = new double[u.GetLength(0)];
        double[] V2 = new double[u.GetLength(0)];
        for(int i=0;i<u.GetLength(0);i++)
        {
            V1[i] = u[i];
            V2[i] = v[i];
        }
        //projection of u onto v
        double dot = 0, norm = 0;
        int length = u.GetLength(0);
        for (int i = 0; i < length; i++)//dot product
        {
            dot += V1[i] * V2[i];
            norm += Math.Pow(V1[i], 2);
        }
        for (int i = 0; i < length; i++)
        {
            V1[i] *= (dot / norm);
        }
        return V1;
    }
    public double[,] Eigenvector(double[,] Matrix, double Evalue)
    {
        double[,] newMatrix = new double[row, col];
        for(int i=0;i<row;i++)
        {
            for(int j=0;j<col;j++)
            {
                newMatrix[i, j] = Matrix[i, j];
            }
        }
        for (int i=0;i<row;i++)
        {
            newMatrix[i, i] -= Evalue;
        }
        return Nullspace(newMatrix);
    }
    public double[,] Diagonal(double[,] Matrix)
    {
        double[,] Diagonal = new double[row, col];
        double[,] Evalues = Eigenvalues_Num(Matrix);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (i != j)
                {
                    Diagonal[i, j] = 0;
                }
                else
                {

                    Diagonal[i, j] = Evalues[0, i];
                }
            }
        }
        return Diagonal;
    }
    public double[,] Eigenspace(double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];
        double[,] Evalues = Eigenvalues_Num(Matrix);
        for(int j=0;j<col;j++)
        {
            double[,] Evector = Eigenvector(Matrix, Evalues[0,j]);//make new eigenvector 
            for(int i=0;i<row;i++)
            {
                newMatrix[i, j] = Evector[i,0];
            }
        }
        return newMatrix;
    }
    public bool VerifyDiagonalizable(double[,] Matrix)
    {
        double[,] P = Eigenspace(Matrix);
        return (Determinant(P) != 0);
    }
    public bool VerifyPositiveDefinite(double[,] Matrix)
    {
        double[,] Evalues = Eigenvalues_Num(Matrix);
        for(int i=0;i<row;i++)
        {
            if(Evalues[0,i]<0)
            {
                return false;
            }
        }
        return true;
    }
    public double norm(double[,] Matrix)
    {
        double norm=0;
        for(int i=0;i<Matrix.GetLength(0);i++)
        {
            for(int j=0;j<Matrix.GetLength(1);j++)
            {
                norm += Math.Pow(Matrix[i, j], 2);
            }
        }
        return Math.Sqrt(norm);
    }
}