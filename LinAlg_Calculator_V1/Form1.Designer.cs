namespace LinAlg_Calculator_V1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTitle = new System.Windows.Forms.Label();
            this.nudRow = new System.Windows.Forms.NumericUpDown();
            this.nudCol = new System.Windows.Forms.NumericUpDown();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnRREF = new System.Windows.Forms.Button();
            this.btnAddition = new System.Windows.Forms.Button();
            this.btnScalarMultiplication = new System.Windows.Forms.Button();
            this.btnMatrixMultiplication = new System.Windows.Forms.Button();
            this.btnNullspace = new System.Windows.Forms.Button();
            this.btnInverse = new System.Windows.Forms.Button();
            this.btnColSpace = new System.Windows.Forms.Button();
            this.btnRowspace = new System.Windows.Forms.Button();
            this.btnDeterminant = new System.Windows.Forms.Button();
            this.btnTranspose = new System.Windows.Forms.Button();
            this.btnCofactor = new System.Windows.Forms.Button();
            this.btnAdjugate = new System.Windows.Forms.Button();
            this.btnPower = new System.Windows.Forms.Button();
            this.btnMinor = new System.Windows.Forms.Button();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlCalculations = new System.Windows.Forms.Panel();
            this.tCOperations = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnUpper = new System.Windows.Forms.Button();
            this.btnLower = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCholesky = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnVerifyDiagonal = new System.Windows.Forms.Button();
            this.btnEigenspace = new System.Windows.Forms.Button();
            this.btnDiagonal = new System.Windows.Forms.Button();
            this.btnEvectors = new System.Windows.Forms.Button();
            this.btnEValues = new System.Windows.Forms.Button();
            this.lblMatrixOperations = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.cbSqrt = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbFraction = new System.Windows.Forms.CheckBox();
            this.btnFill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCol)).BeginInit();
            this.pnlCalculations.SuspendLayout();
            this.tCOperations.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblTitle.Location = new System.Drawing.Point(5, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(148, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Matrix Dimensions";
            // 
            // nudRow
            // 
            this.nudRow.Location = new System.Drawing.Point(6, 42);
            this.nudRow.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRow.Name = "nudRow";
            this.nudRow.Size = new System.Drawing.Size(79, 22);
            this.nudRow.TabIndex = 0;
            this.nudRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRow.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudCol
            // 
            this.nudCol.Location = new System.Drawing.Point(91, 42);
            this.nudCol.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCol.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCol.Name = "nudCol";
            this.nudCol.Size = new System.Drawing.Size(77, 22);
            this.nudCol.TabIndex = 1;
            this.nudCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCol.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(174, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(142, 40);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate Matrix";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(174, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Matrix as";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(322, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(142, 40);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View Matrix";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnRREF
            // 
            this.btnRREF.Location = new System.Drawing.Point(3, 6);
            this.btnRREF.Name = "btnRREF";
            this.btnRREF.Size = new System.Drawing.Size(152, 23);
            this.btnRREF.TabIndex = 1;
            this.btnRREF.Text = "RREF";
            this.btnRREF.UseVisualStyleBackColor = true;
            this.btnRREF.Click += new System.EventHandler(this.btnRREF_Click);
            // 
            // btnAddition
            // 
            this.btnAddition.Location = new System.Drawing.Point(3, 6);
            this.btnAddition.Name = "btnAddition";
            this.btnAddition.Size = new System.Drawing.Size(152, 23);
            this.btnAddition.TabIndex = 0;
            this.btnAddition.Text = "Matrix Addition";
            this.btnAddition.UseVisualStyleBackColor = true;
            this.btnAddition.Click += new System.EventHandler(this.btnAddition_Click);
            // 
            // btnScalarMultiplication
            // 
            this.btnScalarMultiplication.Location = new System.Drawing.Point(3, 35);
            this.btnScalarMultiplication.Name = "btnScalarMultiplication";
            this.btnScalarMultiplication.Size = new System.Drawing.Size(152, 23);
            this.btnScalarMultiplication.TabIndex = 1;
            this.btnScalarMultiplication.Text = "Scalar Multiplication";
            this.btnScalarMultiplication.UseVisualStyleBackColor = true;
            this.btnScalarMultiplication.Click += new System.EventHandler(this.btnScalarMultiplication_Click);
            // 
            // btnMatrixMultiplication
            // 
            this.btnMatrixMultiplication.Location = new System.Drawing.Point(3, 64);
            this.btnMatrixMultiplication.Name = "btnMatrixMultiplication";
            this.btnMatrixMultiplication.Size = new System.Drawing.Size(152, 23);
            this.btnMatrixMultiplication.TabIndex = 2;
            this.btnMatrixMultiplication.Text = "Matrix Multiplication";
            this.btnMatrixMultiplication.UseVisualStyleBackColor = true;
            this.btnMatrixMultiplication.Click += new System.EventHandler(this.btnMatrixMultiplication_Click);
            // 
            // btnNullspace
            // 
            this.btnNullspace.Location = new System.Drawing.Point(3, 93);
            this.btnNullspace.Name = "btnNullspace";
            this.btnNullspace.Size = new System.Drawing.Size(152, 23);
            this.btnNullspace.TabIndex = 4;
            this.btnNullspace.Text = "Nullspace";
            this.btnNullspace.UseVisualStyleBackColor = true;
            this.btnNullspace.Click += new System.EventHandler(this.btnNullspace_Click);
            // 
            // btnInverse
            // 
            this.btnInverse.Location = new System.Drawing.Point(3, 93);
            this.btnInverse.Name = "btnInverse";
            this.btnInverse.Size = new System.Drawing.Size(152, 23);
            this.btnInverse.TabIndex = 3;
            this.btnInverse.Text = "Inverse";
            this.btnInverse.UseVisualStyleBackColor = true;
            this.btnInverse.Click += new System.EventHandler(this.btnInverse_Click);
            // 
            // btnColSpace
            // 
            this.btnColSpace.Location = new System.Drawing.Point(3, 122);
            this.btnColSpace.Name = "btnColSpace";
            this.btnColSpace.Size = new System.Drawing.Size(152, 23);
            this.btnColSpace.TabIndex = 5;
            this.btnColSpace.Text = "Column Space";
            this.btnColSpace.UseVisualStyleBackColor = true;
            this.btnColSpace.Click += new System.EventHandler(this.btnColSpace_Click);
            // 
            // btnRowspace
            // 
            this.btnRowspace.Location = new System.Drawing.Point(3, 151);
            this.btnRowspace.Name = "btnRowspace";
            this.btnRowspace.Size = new System.Drawing.Size(152, 23);
            this.btnRowspace.TabIndex = 6;
            this.btnRowspace.Text = "Row Space";
            this.btnRowspace.UseVisualStyleBackColor = true;
            this.btnRowspace.Click += new System.EventHandler(this.btnRowspace_Click);
            // 
            // btnDeterminant
            // 
            this.btnDeterminant.Location = new System.Drawing.Point(3, 6);
            this.btnDeterminant.Name = "btnDeterminant";
            this.btnDeterminant.Size = new System.Drawing.Size(155, 23);
            this.btnDeterminant.TabIndex = 0;
            this.btnDeterminant.Text = "Determinant";
            this.btnDeterminant.UseVisualStyleBackColor = true;
            this.btnDeterminant.Click += new System.EventHandler(this.btnDeterminant_Click);
            // 
            // btnTranspose
            // 
            this.btnTranspose.Location = new System.Drawing.Point(3, 122);
            this.btnTranspose.Name = "btnTranspose";
            this.btnTranspose.Size = new System.Drawing.Size(152, 23);
            this.btnTranspose.TabIndex = 4;
            this.btnTranspose.Text = "Tranpose";
            this.btnTranspose.UseVisualStyleBackColor = true;
            this.btnTranspose.Click += new System.EventHandler(this.btnTranspose_Click);
            // 
            // btnCofactor
            // 
            this.btnCofactor.Location = new System.Drawing.Point(3, 64);
            this.btnCofactor.Name = "btnCofactor";
            this.btnCofactor.Size = new System.Drawing.Size(155, 23);
            this.btnCofactor.TabIndex = 2;
            this.btnCofactor.Text = "Cofactor";
            this.btnCofactor.UseVisualStyleBackColor = true;
            this.btnCofactor.Click += new System.EventHandler(this.btnCofactor_Click);
            // 
            // btnAdjugate
            // 
            this.btnAdjugate.Location = new System.Drawing.Point(3, 93);
            this.btnAdjugate.Name = "btnAdjugate";
            this.btnAdjugate.Size = new System.Drawing.Size(155, 23);
            this.btnAdjugate.TabIndex = 3;
            this.btnAdjugate.Text = "Adjugate";
            this.btnAdjugate.UseVisualStyleBackColor = true;
            this.btnAdjugate.Click += new System.EventHandler(this.btnAdjugate_Click);
            // 
            // btnPower
            // 
            this.btnPower.Location = new System.Drawing.Point(5, 6);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(153, 23);
            this.btnPower.TabIndex = 0;
            this.btnPower.Text = "Matrix Power";
            this.btnPower.UseVisualStyleBackColor = true;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // btnMinor
            // 
            this.btnMinor.Location = new System.Drawing.Point(3, 35);
            this.btnMinor.Name = "btnMinor";
            this.btnMinor.Size = new System.Drawing.Size(155, 23);
            this.btnMinor.TabIndex = 1;
            this.btnMinor.Text = "Minor";
            this.btnMinor.UseVisualStyleBackColor = true;
            this.btnMinor.Click += new System.EventHandler(this.btnMinor_Click);
            // 
            // lblDimensions
            // 
            this.lblDimensions.AutoSize = true;
            this.lblDimensions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblDimensions.Location = new System.Drawing.Point(5, 22);
            this.lblDimensions.Name = "lblDimensions";
            this.lblDimensions.Size = new System.Drawing.Size(129, 17);
            this.lblDimensions.TabIndex = 119;
            this.lblDimensions.Text = "(Rows by Columns)";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(322, 50);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(142, 40);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit Matrix";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pnlCalculations
            // 
            this.pnlCalculations.BackColor = System.Drawing.Color.Gray;
            this.pnlCalculations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCalculations.Controls.Add(this.tCOperations);
            this.pnlCalculations.Controls.Add(this.lblMatrixOperations);
            this.pnlCalculations.Location = new System.Drawing.Point(0, 0);
            this.pnlCalculations.Name = "pnlCalculations";
            this.pnlCalculations.Size = new System.Drawing.Size(187, 441);
            this.pnlCalculations.TabIndex = 11;
            // 
            // tCOperations
            // 
            this.tCOperations.Controls.Add(this.tabPage1);
            this.tCOperations.Controls.Add(this.tabPage2);
            this.tCOperations.Controls.Add(this.tabPage3);
            this.tCOperations.Controls.Add(this.tabPage4);
            this.tCOperations.Location = new System.Drawing.Point(3, 42);
            this.tCOperations.Name = "tCOperations";
            this.tCOperations.SelectedIndex = 0;
            this.tCOperations.Size = new System.Drawing.Size(169, 353);
            this.tCOperations.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnUpper);
            this.tabPage1.Controls.Add(this.btnLower);
            this.tabPage1.Controls.Add(this.btnRREF);
            this.tabPage1.Controls.Add(this.btnColSpace);
            this.tabPage1.Controls.Add(this.btnNullspace);
            this.tabPage1.Controls.Add(this.btnRowspace);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(161, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "EROs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnUpper
            // 
            this.btnUpper.Location = new System.Drawing.Point(3, 35);
            this.btnUpper.Name = "btnUpper";
            this.btnUpper.Size = new System.Drawing.Size(152, 23);
            this.btnUpper.TabIndex = 2;
            this.btnUpper.Text = "Upper Triangular";
            this.btnUpper.UseVisualStyleBackColor = true;
            this.btnUpper.Click += new System.EventHandler(this.btnUpper_Click);
            // 
            // btnLower
            // 
            this.btnLower.Location = new System.Drawing.Point(3, 64);
            this.btnLower.Name = "btnLower";
            this.btnLower.Size = new System.Drawing.Size(152, 23);
            this.btnLower.TabIndex = 3;
            this.btnLower.Text = "Lower Triangular";
            this.btnLower.UseVisualStyleBackColor = true;
            this.btnLower.Click += new System.EventHandler(this.btnLower_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddition);
            this.tabPage2.Controls.Add(this.btnMatrixMultiplication);
            this.tabPage2.Controls.Add(this.btnCholesky);
            this.tabPage2.Controls.Add(this.btnScalarMultiplication);
            this.tabPage2.Controls.Add(this.btnInverse);
            this.tabPage2.Controls.Add(this.btnTranspose);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(161, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Matrix Algebra";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCholesky
            // 
            this.btnCholesky.Location = new System.Drawing.Point(3, 151);
            this.btnCholesky.Name = "btnCholesky";
            this.btnCholesky.Size = new System.Drawing.Size(153, 23);
            this.btnCholesky.TabIndex = 5;
            this.btnCholesky.Text = "Cholesky Decomp.";
            this.btnCholesky.UseVisualStyleBackColor = true;
            this.btnCholesky.Click += new System.EventHandler(this.btnCholesky_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnDeterminant);
            this.tabPage3.Controls.Add(this.btnMinor);
            this.tabPage3.Controls.Add(this.btnAdjugate);
            this.tabPage3.Controls.Add(this.btnCofactor);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(161, 324);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Determinant";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnVerifyDiagonal);
            this.tabPage4.Controls.Add(this.btnEigenspace);
            this.tabPage4.Controls.Add(this.btnDiagonal);
            this.tabPage4.Controls.Add(this.btnPower);
            this.tabPage4.Controls.Add(this.btnEvectors);
            this.tabPage4.Controls.Add(this.btnEValues);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(161, 324);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Diagonalization";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnVerifyDiagonal
            // 
            this.btnVerifyDiagonal.Location = new System.Drawing.Point(5, 122);
            this.btnVerifyDiagonal.Name = "btnVerifyDiagonal";
            this.btnVerifyDiagonal.Size = new System.Drawing.Size(153, 23);
            this.btnVerifyDiagonal.TabIndex = 4;
            this.btnVerifyDiagonal.Text = "Verify Diagonalizable";
            this.btnVerifyDiagonal.UseVisualStyleBackColor = true;
            this.btnVerifyDiagonal.Click += new System.EventHandler(this.btnVerifyDiagonal_Click);
            // 
            // btnEigenspace
            // 
            this.btnEigenspace.Location = new System.Drawing.Point(5, 93);
            this.btnEigenspace.Name = "btnEigenspace";
            this.btnEigenspace.Size = new System.Drawing.Size(153, 23);
            this.btnEigenspace.TabIndex = 3;
            this.btnEigenspace.Text = "Eigenspace";
            this.btnEigenspace.UseVisualStyleBackColor = true;
            this.btnEigenspace.Click += new System.EventHandler(this.btnEigenspace_Click);
            // 
            // btnDiagonal
            // 
            this.btnDiagonal.Location = new System.Drawing.Point(5, 151);
            this.btnDiagonal.Name = "btnDiagonal";
            this.btnDiagonal.Size = new System.Drawing.Size(153, 23);
            this.btnDiagonal.TabIndex = 5;
            this.btnDiagonal.Text = "Diagonalization";
            this.btnDiagonal.UseVisualStyleBackColor = true;
            this.btnDiagonal.Click += new System.EventHandler(this.btnDiagonal_Click);
            // 
            // btnEvectors
            // 
            this.btnEvectors.Location = new System.Drawing.Point(4, 64);
            this.btnEvectors.Name = "btnEvectors";
            this.btnEvectors.Size = new System.Drawing.Size(153, 23);
            this.btnEvectors.TabIndex = 2;
            this.btnEvectors.Text = "Eigenvectors";
            this.btnEvectors.UseVisualStyleBackColor = true;
            this.btnEvectors.Click += new System.EventHandler(this.btnEvectors_Click);
            // 
            // btnEValues
            // 
            this.btnEValues.Location = new System.Drawing.Point(5, 35);
            this.btnEValues.Name = "btnEValues";
            this.btnEValues.Size = new System.Drawing.Size(153, 23);
            this.btnEValues.TabIndex = 1;
            this.btnEValues.Text = "Eigenvalues";
            this.btnEValues.UseVisualStyleBackColor = true;
            this.btnEValues.Click += new System.EventHandler(this.btnEValues_Click);
            // 
            // lblMatrixOperations
            // 
            this.lblMatrixOperations.AutoSize = true;
            this.lblMatrixOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatrixOperations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblMatrixOperations.Location = new System.Drawing.Point(7, 4);
            this.lblMatrixOperations.Name = "lblMatrixOperations";
            this.lblMatrixOperations.Size = new System.Drawing.Size(174, 24);
            this.lblMatrixOperations.TabIndex = 119;
            this.lblMatrixOperations.Text = "Matrix Operations";
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.Gray;
            this.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInput.Controls.Add(this.cbSqrt);
            this.pnlInput.Controls.Add(this.btnClear);
            this.pnlInput.Controls.Add(this.btnSave);
            this.pnlInput.Controls.Add(this.cbFraction);
            this.pnlInput.Controls.Add(this.lblTitle);
            this.pnlInput.Controls.Add(this.nudRow);
            this.pnlInput.Controls.Add(this.btnFill);
            this.pnlInput.Controls.Add(this.btnEdit);
            this.pnlInput.Controls.Add(this.nudCol);
            this.pnlInput.Controls.Add(this.lblDimensions);
            this.pnlInput.Controls.Add(this.btnView);
            this.pnlInput.Controls.Add(this.btnGenerate);
            this.pnlInput.Location = new System.Drawing.Point(187, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(806, 97);
            this.pnlInput.TabIndex = 1;
            // 
            // cbSqrt
            // 
            this.cbSqrt.AutoSize = true;
            this.cbSqrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSqrt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cbSqrt.Location = new System.Drawing.Point(103, 66);
            this.cbSqrt.Name = "cbSqrt";
            this.cbSqrt.Size = new System.Drawing.Size(62, 24);
            this.cbSqrt.TabIndex = 3;
            this.cbSqrt.Text = "Sqrt";
            this.cbSqrt.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(470, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(142, 40);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear All Entries";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbFraction
            // 
            this.cbFraction.AutoSize = true;
            this.cbFraction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFraction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cbFraction.Location = new System.Drawing.Point(6, 66);
            this.cbFraction.Name = "cbFraction";
            this.cbFraction.Size = new System.Drawing.Size(92, 24);
            this.cbFraction.TabIndex = 2;
            this.cbFraction.Text = "Fraction";
            this.cbFraction.UseVisualStyleBackColor = true;
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(470, 50);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(142, 40);
            this.btnFill.TabIndex = 9;
            this.btnFill.Text = "Fill Empty Entries";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.ClientSize = new System.Drawing.Size(818, 559);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.pnlCalculations);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Matrix Calculator";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nudRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCol)).EndInit();
            this.pnlCalculations.ResumeLayout(false);
            this.pnlCalculations.PerformLayout();
            this.tCOperations.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.NumericUpDown nudRow;
        private System.Windows.Forms.NumericUpDown nudCol;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnRREF;
        private System.Windows.Forms.Button btnAddition;
        private System.Windows.Forms.Button btnScalarMultiplication;
        private System.Windows.Forms.Button btnMatrixMultiplication;
        private System.Windows.Forms.Button btnNullspace;
        private System.Windows.Forms.Button btnInverse;
        private System.Windows.Forms.Button btnColSpace;
        private System.Windows.Forms.Button btnRowspace;
        private System.Windows.Forms.Button btnDeterminant;
        private System.Windows.Forms.Button btnTranspose;
        private System.Windows.Forms.Button btnCofactor;
        private System.Windows.Forms.Button btnAdjugate;
        private System.Windows.Forms.Button btnPower;
        private System.Windows.Forms.Button btnMinor;
        private System.Windows.Forms.Label lblDimensions;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlCalculations;
        private System.Windows.Forms.Label lblMatrixOperations;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox cbFraction;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.TabControl tCOperations;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnUpper;
        private System.Windows.Forms.Button btnLower;
        private System.Windows.Forms.Button btnDiagonal;
        private System.Windows.Forms.Button btnEvectors;
        private System.Windows.Forms.Button btnCholesky;
        private System.Windows.Forms.Button btnEValues;
        private System.Windows.Forms.CheckBox cbSqrt;
        private System.Windows.Forms.Button btnVerifyDiagonal;
        private System.Windows.Forms.Button btnEigenspace;
    }
}

