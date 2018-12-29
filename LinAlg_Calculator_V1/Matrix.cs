using System;
using System.Data;

public struct Matrix
{
    public int row, col;
    public double[,] MatrixNum;

    public Matrix (int r, int c)
    {
        row = r;
        col = c;
        MatrixNum = new double[r, c];
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
    private int Rank (double[,] Matrix)//requires rref matrix
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
        for(int i=0;i<row;i++)
        {
            for(int j=0;j<col;j++)
            {
                if(i==j)
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
    public double[,] MMultiplciation(double[,] Matrix1, double[,] Matrix2)
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
        newMatrix = ScalarMultiplication(1 / Determinant(Matrix, Matrix.GetLength(0), Matrix.GetLength(1)), Adjugate(Matrix));
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
    public double[,] Nullspace (double[,] Matrix)
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
    public double[,] Rowspace (double [,] Matrix)
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
                double[,] newMatrix = new double[row-1, col-1];
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
                    newMatrix[i, j] = Determinant(TrimCol(j, TrimRow(i, Matrix)), row - 1, col - 1);
                }
            }
        }
        return newMatrix;
    }
    public double[,] Cofactor(double[,] Matrix)
    {
        double[,] newMatrix = new double[row, col];
        newMatrix = Minor(Matrix);
        for(int i=0;i<row;i++)
        {
            for(int j=0;j<col;j++)
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
        if (c==0)
        {
            newMatrix = IdentityMatrix();
        }
        else
        { 
            for (int i = 1; i < c; i++)
            {
                newMatrix = MMultiplciation(newMatrix, Matrix);
            }
        }
        return newMatrix;
    }
}