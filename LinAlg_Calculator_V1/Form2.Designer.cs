﻿namespace LinAlg_Calculator_V1
{
    partial class Form2
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
            this.lblSave = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.rbMatrixA = new System.Windows.Forms.RadioButton();
            this.rbMatrixB = new System.Windows.Forms.RadioButton();
            this.rbMatrixC = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Location = new System.Drawing.Point(19, 9);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(105, 17);
            this.lblSave.TabIndex = 3;
            this.lblSave.Text = "Save Matrix As:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(22, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save Selection";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rbMatrixA
            // 
            this.rbMatrixA.AutoSize = true;
            this.rbMatrixA.Location = new System.Drawing.Point(22, 29);
            this.rbMatrixA.Name = "rbMatrixA";
            this.rbMatrixA.Size = new System.Drawing.Size(79, 21);
            this.rbMatrixA.TabIndex = 5;
            this.rbMatrixA.TabStop = true;
            this.rbMatrixA.Text = "Matrix A";
            this.rbMatrixA.UseVisualStyleBackColor = true;
            // 
            // rbMatrixB
            // 
            this.rbMatrixB.AutoSize = true;
            this.rbMatrixB.Location = new System.Drawing.Point(22, 56);
            this.rbMatrixB.Name = "rbMatrixB";
            this.rbMatrixB.Size = new System.Drawing.Size(79, 21);
            this.rbMatrixB.TabIndex = 6;
            this.rbMatrixB.TabStop = true;
            this.rbMatrixB.Text = "Matrix B";
            this.rbMatrixB.UseVisualStyleBackColor = true;
            // 
            // rbMatrixC
            // 
            this.rbMatrixC.AutoSize = true;
            this.rbMatrixC.Location = new System.Drawing.Point(22, 83);
            this.rbMatrixC.Name = "rbMatrixC";
            this.rbMatrixC.Size = new System.Drawing.Size(79, 21);
            this.rbMatrixC.TabIndex = 7;
            this.rbMatrixC.TabStop = true;
            this.rbMatrixC.Text = "Matrix C";
            this.rbMatrixC.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 151);
            this.Controls.Add(this.rbMatrixC);
            this.Controls.Add(this.rbMatrixB);
            this.Controls.Add(this.rbMatrixA);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSave);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rbMatrixA;
        private System.Windows.Forms.RadioButton rbMatrixB;
        private System.Windows.Forms.RadioButton rbMatrixC;
    }
}