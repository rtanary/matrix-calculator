namespace LinAlg_Calculator_V1
{
    partial class Form6
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelectEigenvalue = new System.Windows.Forms.Button();
            this.lblSave = new System.Windows.Forms.Label();
            this.pnl = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(17, 98);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelectEigenvalue
            // 
            this.btnSelectEigenvalue.Location = new System.Drawing.Point(16, 69);
            this.btnSelectEigenvalue.Name = "btnSelectEigenvalue";
            this.btnSelectEigenvalue.Size = new System.Drawing.Size(156, 23);
            this.btnSelectEigenvalue.TabIndex = 1;
            this.btnSelectEigenvalue.Text = "Select Eigenvalue";
            this.btnSelectEigenvalue.UseVisualStyleBackColor = true;
            this.btnSelectEigenvalue.Click += new System.EventHandler(this.btnSelectEigenvalue_Click);
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.lblSave.Location = new System.Drawing.Point(12, 9);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(159, 20);
            this.lblSave.TabIndex = 8;
            this.lblSave.Text = "Select Eigenvalue";
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.Gray;
            this.pnl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl.Location = new System.Drawing.Point(17, 32);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(155, 31);
            this.pnl.TabIndex = 0;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.ClientSize = new System.Drawing.Size(192, 139);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectEigenvalue);
            this.Controls.Add(this.lblSave);
            this.Name = "Form6";
            this.Text = "Select Eigenvalue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelectEigenvalue;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.FlowLayoutPanel pnl;
    }
}