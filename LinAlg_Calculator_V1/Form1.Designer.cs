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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.lblDimensions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCol)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(38, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(122, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Matrix Dimensions";
            // 
            // nudRow
            // 
            this.nudRow.Location = new System.Drawing.Point(19, 46);
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
            this.nudRow.TabIndex = 1;
            this.nudRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRow.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudCol
            // 
            this.nudCol.Location = new System.Drawing.Point(104, 46);
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
            this.nudCol.TabIndex = 2;
            this.nudCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCol.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(19, 71);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(162, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate Matrix";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(19, 100);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(162, 23);
            this.btnSave.TabIndex = 104;
            this.btnSave.Text = "Save Matrix as";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(19, 129);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(162, 23);
            this.btnView.TabIndex = 105;
            this.btnView.Text = "View Matrix";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnRREF
            // 
            this.btnRREF.Location = new System.Drawing.Point(19, 158);
            this.btnRREF.Name = "btnRREF";
            this.btnRREF.Size = new System.Drawing.Size(162, 23);
            this.btnRREF.TabIndex = 106;
            this.btnRREF.Text = "RREF";
            this.btnRREF.UseVisualStyleBackColor = true;
            this.btnRREF.Click += new System.EventHandler(this.btnRREF_Click);
            // 
            // btnAddition
            // 
            this.btnAddition.Location = new System.Drawing.Point(19, 187);
            this.btnAddition.Name = "btnAddition";
            this.btnAddition.Size = new System.Drawing.Size(162, 23);
            this.btnAddition.TabIndex = 107;
            this.btnAddition.Text = "Matrix Addition";
            this.btnAddition.UseVisualStyleBackColor = true;
            this.btnAddition.Click += new System.EventHandler(this.btnAddition_Click);
            // 
            // btnScalarMultiplication
            // 
            this.btnScalarMultiplication.Location = new System.Drawing.Point(23, 216);
            this.btnScalarMultiplication.Name = "btnScalarMultiplication";
            this.btnScalarMultiplication.Size = new System.Drawing.Size(158, 23);
            this.btnScalarMultiplication.TabIndex = 108;
            this.btnScalarMultiplication.Text = "Scalar Multiplication";
            this.btnScalarMultiplication.UseVisualStyleBackColor = true;
            this.btnScalarMultiplication.Click += new System.EventHandler(this.btnScalarMultiplication_Click);
            // 
            // btnMatrixMultiplication
            // 
            this.btnMatrixMultiplication.Location = new System.Drawing.Point(23, 245);
            this.btnMatrixMultiplication.Name = "btnMatrixMultiplication";
            this.btnMatrixMultiplication.Size = new System.Drawing.Size(158, 23);
            this.btnMatrixMultiplication.TabIndex = 109;
            this.btnMatrixMultiplication.Text = "Matrix Multiplication";
            this.btnMatrixMultiplication.UseVisualStyleBackColor = true;
            this.btnMatrixMultiplication.Click += new System.EventHandler(this.btnMatrixMultiplication_Click);
            // 
            // btnNullspace
            // 
            this.btnNullspace.Location = new System.Drawing.Point(23, 332);
            this.btnNullspace.Name = "btnNullspace";
            this.btnNullspace.Size = new System.Drawing.Size(158, 23);
            this.btnNullspace.TabIndex = 112;
            this.btnNullspace.Text = "Nullspace";
            this.btnNullspace.UseVisualStyleBackColor = true;
            this.btnNullspace.Click += new System.EventHandler(this.btnNullspace_Click);
            // 
            // btnInverse
            // 
            this.btnInverse.Location = new System.Drawing.Point(23, 274);
            this.btnInverse.Name = "btnInverse";
            this.btnInverse.Size = new System.Drawing.Size(158, 23);
            this.btnInverse.TabIndex = 110;
            this.btnInverse.Text = "Inverse";
            this.btnInverse.UseVisualStyleBackColor = true;
            this.btnInverse.Click += new System.EventHandler(this.btnInverse_Click);
            // 
            // btnColSpace
            // 
            this.btnColSpace.Location = new System.Drawing.Point(23, 361);
            this.btnColSpace.Name = "btnColSpace";
            this.btnColSpace.Size = new System.Drawing.Size(158, 23);
            this.btnColSpace.TabIndex = 113;
            this.btnColSpace.Text = "ColumnSpace";
            this.btnColSpace.UseVisualStyleBackColor = true;
            this.btnColSpace.Click += new System.EventHandler(this.btnColSpace_Click);
            // 
            // btnRowspace
            // 
            this.btnRowspace.Location = new System.Drawing.Point(23, 390);
            this.btnRowspace.Name = "btnRowspace";
            this.btnRowspace.Size = new System.Drawing.Size(158, 23);
            this.btnRowspace.TabIndex = 114;
            this.btnRowspace.Text = "Row Space";
            this.btnRowspace.UseVisualStyleBackColor = true;
            this.btnRowspace.Click += new System.EventHandler(this.btnRowspace_Click);
            // 
            // btnDeterminant
            // 
            this.btnDeterminant.Location = new System.Drawing.Point(23, 419);
            this.btnDeterminant.Name = "btnDeterminant";
            this.btnDeterminant.Size = new System.Drawing.Size(158, 23);
            this.btnDeterminant.TabIndex = 115;
            this.btnDeterminant.Text = "Determinant";
            this.btnDeterminant.UseVisualStyleBackColor = true;
            this.btnDeterminant.Click += new System.EventHandler(this.btnDeterminant_Click);
            // 
            // btnTranspose
            // 
            this.btnTranspose.Location = new System.Drawing.Point(23, 303);
            this.btnTranspose.Name = "btnTranspose";
            this.btnTranspose.Size = new System.Drawing.Size(158, 23);
            this.btnTranspose.TabIndex = 111;
            this.btnTranspose.Text = "Tranpose";
            this.btnTranspose.UseVisualStyleBackColor = true;
            this.btnTranspose.Click += new System.EventHandler(this.btnTranspose_Click);
            // 
            // btnCofactor
            // 
            this.btnCofactor.Location = new System.Drawing.Point(23, 477);
            this.btnCofactor.Name = "btnCofactor";
            this.btnCofactor.Size = new System.Drawing.Size(158, 23);
            this.btnCofactor.TabIndex = 116;
            this.btnCofactor.Text = "Cofactor";
            this.btnCofactor.UseVisualStyleBackColor = true;
            this.btnCofactor.Click += new System.EventHandler(this.btnCofactor_Click);
            // 
            // btnAdjugate
            // 
            this.btnAdjugate.Location = new System.Drawing.Point(23, 506);
            this.btnAdjugate.Name = "btnAdjugate";
            this.btnAdjugate.Size = new System.Drawing.Size(158, 23);
            this.btnAdjugate.TabIndex = 117;
            this.btnAdjugate.Text = "Adjugate";
            this.btnAdjugate.UseVisualStyleBackColor = true;
            this.btnAdjugate.Click += new System.EventHandler(this.btnAdjugate_Click);
            // 
            // btnPower
            // 
            this.btnPower.Location = new System.Drawing.Point(23, 535);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(158, 23);
            this.btnPower.TabIndex = 118;
            this.btnPower.Text = "Matrix Power";
            this.btnPower.UseVisualStyleBackColor = true;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // btnMinor
            // 
            this.btnMinor.Location = new System.Drawing.Point(23, 448);
            this.btnMinor.Name = "btnMinor";
            this.btnMinor.Size = new System.Drawing.Size(158, 23);
            this.btnMinor.TabIndex = 116;
            this.btnMinor.Text = "Minor";
            this.btnMinor.UseVisualStyleBackColor = true;
            this.btnMinor.Click += new System.EventHandler(this.btnMinor_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(437, 509);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(189, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear All Entries";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(437, 538);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(189, 23);
            this.btnFill.TabIndex = 3;
            this.btnFill.TabStop = false;
            this.btnFill.Text = "Fill Empty Entries with Zero";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // lblDimensions
            // 
            this.lblDimensions.AutoSize = true;
            this.lblDimensions.Location = new System.Drawing.Point(38, 26);
            this.lblDimensions.Name = "lblDimensions";
            this.lblDimensions.Size = new System.Drawing.Size(129, 17);
            this.lblDimensions.TabIndex = 119;
            this.lblDimensions.Text = "(Rows by Columns)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 569);
            this.Controls.Add(this.lblDimensions);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnMinor);
            this.Controls.Add(this.btnPower);
            this.Controls.Add(this.btnAdjugate);
            this.Controls.Add(this.btnCofactor);
            this.Controls.Add(this.btnTranspose);
            this.Controls.Add(this.btnDeterminant);
            this.Controls.Add(this.btnRowspace);
            this.Controls.Add(this.btnColSpace);
            this.Controls.Add(this.btnInverse);
            this.Controls.Add(this.btnNullspace);
            this.Controls.Add(this.btnMatrixMultiplication);
            this.Controls.Add(this.btnScalarMultiplication);
            this.Controls.Add(this.btnAddition);
            this.Controls.Add(this.btnRREF);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.nudCol);
            this.Controls.Add(this.nudRow);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Matrix Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.nudRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Label lblDimensions;
    }
}

