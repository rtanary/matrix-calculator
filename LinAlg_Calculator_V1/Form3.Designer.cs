namespace LinAlg_Calculator_V1
{
    partial class Form3
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
            this.rbMatrixA1 = new System.Windows.Forms.RadioButton();
            this.rbMatrixB1 = new System.Windows.Forms.RadioButton();
            this.rbMatrixC1 = new System.Windows.Forms.RadioButton();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.rbMatrixA2 = new System.Windows.Forms.RadioButton();
            this.rbMatrixC2 = new System.Windows.Forms.RadioButton();
            this.rbMatrixB2 = new System.Windows.Forms.RadioButton();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelect = new System.Windows.Forms.Label();
            this.gb1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbMatrixA1
            // 
            this.rbMatrixA1.AutoSize = true;
            this.rbMatrixA1.Location = new System.Drawing.Point(16, 21);
            this.rbMatrixA1.Name = "rbMatrixA1";
            this.rbMatrixA1.Size = new System.Drawing.Size(79, 21);
            this.rbMatrixA1.TabIndex = 0;
            this.rbMatrixA1.TabStop = true;
            this.rbMatrixA1.Text = "Matrix A";
            this.rbMatrixA1.UseVisualStyleBackColor = true;
            // 
            // rbMatrixB1
            // 
            this.rbMatrixB1.AutoSize = true;
            this.rbMatrixB1.Location = new System.Drawing.Point(16, 48);
            this.rbMatrixB1.Name = "rbMatrixB1";
            this.rbMatrixB1.Size = new System.Drawing.Size(79, 21);
            this.rbMatrixB1.TabIndex = 1;
            this.rbMatrixB1.TabStop = true;
            this.rbMatrixB1.Text = "Matrix B";
            this.rbMatrixB1.UseVisualStyleBackColor = true;
            // 
            // rbMatrixC1
            // 
            this.rbMatrixC1.AutoSize = true;
            this.rbMatrixC1.Location = new System.Drawing.Point(16, 75);
            this.rbMatrixC1.Name = "rbMatrixC1";
            this.rbMatrixC1.Size = new System.Drawing.Size(79, 21);
            this.rbMatrixC1.TabIndex = 2;
            this.rbMatrixC1.TabStop = true;
            this.rbMatrixC1.Text = "Matrix C";
            this.rbMatrixC1.UseVisualStyleBackColor = true;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.rbMatrixA1);
            this.gb1.Controls.Add(this.rbMatrixC1);
            this.gb1.Controls.Add(this.rbMatrixB1);
            this.gb1.Location = new System.Drawing.Point(18, 39);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(105, 112);
            this.gb1.TabIndex = 1;
            this.gb1.TabStop = false;
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.rbMatrixA2);
            this.gb2.Controls.Add(this.rbMatrixC2);
            this.gb2.Controls.Add(this.rbMatrixB2);
            this.gb2.Location = new System.Drawing.Point(129, 39);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(112, 112);
            this.gb2.TabIndex = 2;
            this.gb2.TabStop = false;
            // 
            // rbMatrixA2
            // 
            this.rbMatrixA2.AutoSize = true;
            this.rbMatrixA2.Location = new System.Drawing.Point(16, 21);
            this.rbMatrixA2.Name = "rbMatrixA2";
            this.rbMatrixA2.Size = new System.Drawing.Size(79, 21);
            this.rbMatrixA2.TabIndex = 0;
            this.rbMatrixA2.TabStop = true;
            this.rbMatrixA2.Text = "Matrix A";
            this.rbMatrixA2.UseVisualStyleBackColor = true;
            // 
            // rbMatrixC2
            // 
            this.rbMatrixC2.AutoSize = true;
            this.rbMatrixC2.Location = new System.Drawing.Point(16, 75);
            this.rbMatrixC2.Name = "rbMatrixC2";
            this.rbMatrixC2.Size = new System.Drawing.Size(79, 21);
            this.rbMatrixC2.TabIndex = 2;
            this.rbMatrixC2.TabStop = true;
            this.rbMatrixC2.Text = "Matrix C";
            this.rbMatrixC2.UseVisualStyleBackColor = true;
            // 
            // rbMatrixB2
            // 
            this.rbMatrixB2.AutoSize = true;
            this.rbMatrixB2.Location = new System.Drawing.Point(16, 48);
            this.rbMatrixB2.Name = "rbMatrixB2";
            this.rbMatrixB2.Size = new System.Drawing.Size(79, 21);
            this.rbMatrixB2.TabIndex = 1;
            this.rbMatrixB2.TabStop = true;
            this.rbMatrixB2.Text = "Matrix B";
            this.rbMatrixB2.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(18, 157);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(223, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "Choose Selection";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(18, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(223, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(15, 19);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(104, 17);
            this.lblSelect.TabIndex = 7;
            this.lblSelect.Text = "Select Matrices";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 255);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbMatrixA1;
        private System.Windows.Forms.RadioButton rbMatrixB1;
        private System.Windows.Forms.RadioButton rbMatrixC1;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.RadioButton rbMatrixA2;
        private System.Windows.Forms.RadioButton rbMatrixC2;
        private System.Windows.Forms.RadioButton rbMatrixB2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSelect;
    }
}