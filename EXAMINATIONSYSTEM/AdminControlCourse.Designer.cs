namespace EXAMINATIONSYSTEM
{
    partial class AdminControlCourse
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
            this.lblPass = new System.Windows.Forms.Label();
            this.txbSplit = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.txbHours = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.lblMaxtake = new System.Windows.Forms.Label();
            this.txbMaxTake = new System.Windows.Forms.TextBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txbGrade = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.FlatAppearance.BorderSize = 2;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnEdit.FlatAppearance.BorderSize = 2;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMaxtake);
            this.panel1.Controls.Add(this.txbMaxTake);
            this.panel1.Controls.Add(this.lblGrade);
            this.panel1.Controls.Add(this.txbGrade);
            this.panel1.Controls.Add(this.lblPass);
            this.panel1.Controls.Add(this.txbSplit);
            this.panel1.Controls.Add(this.lblHours);
            this.panel1.Controls.Add(this.txbHours);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.txbName);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.pictureBox1, 0);
            this.panel1.Controls.SetChildIndex(this.btnEdit, 0);
            this.panel1.Controls.SetChildIndex(this.btnDelete, 0);
            this.panel1.Controls.SetChildIndex(this.btnAdd, 0);
            this.panel1.Controls.SetChildIndex(this.txbName, 0);
            this.panel1.Controls.SetChildIndex(this.lblName, 0);
            this.panel1.Controls.SetChildIndex(this.txbHours, 0);
            this.panel1.Controls.SetChildIndex(this.lblHours, 0);
            this.panel1.Controls.SetChildIndex(this.txbSplit, 0);
            this.panel1.Controls.SetChildIndex(this.lblPass, 0);
            this.panel1.Controls.SetChildIndex(this.txbGrade, 0);
            this.panel1.Controls.SetChildIndex(this.lblGrade, 0);
            this.panel1.Controls.SetChildIndex(this.txbMaxTake, 0);
            this.panel1.Controls.SetChildIndex(this.lblMaxtake, 0);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(118, 32);
            this.label1.Text = "Courses";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(7, 266);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(107, 17);
            this.lblPass.TabIndex = 60;
            this.lblPass.Text = "Split Questions:";
            // 
            // txbSplit
            // 
            this.txbSplit.Location = new System.Drawing.Point(118, 266);
            this.txbSplit.Name = "txbSplit";
            this.txbSplit.Size = new System.Drawing.Size(122, 20);
            this.txbSplit.TabIndex = 59;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(35, 210);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(50, 17);
            this.lblHours.TabIndex = 58;
            this.lblHours.Text = "Hours:";
            // 
            // txbHours
            // 
            this.txbHours.Location = new System.Drawing.Point(118, 210);
            this.txbHours.Name = "txbHours";
            this.txbHours.Size = new System.Drawing.Size(122, 20);
            this.txbHours.TabIndex = 57;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(36, 154);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 56;
            this.lblName.Text = "Name:";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(118, 154);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(122, 20);
            this.txbName.TabIndex = 55;
            // 
            // lblMaxtake
            // 
            this.lblMaxtake.AutoSize = true;
            this.lblMaxtake.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxtake.Location = new System.Drawing.Point(24, 378);
            this.lblMaxtake.Name = "lblMaxtake";
            this.lblMaxtake.Size = new System.Drawing.Size(73, 17);
            this.lblMaxtake.TabIndex = 64;
            this.lblMaxtake.Text = "Max Take:";
            // 
            // txbMaxTake
            // 
            this.txbMaxTake.Location = new System.Drawing.Point(118, 378);
            this.txbMaxTake.Name = "txbMaxTake";
            this.txbMaxTake.Size = new System.Drawing.Size(122, 20);
            this.txbMaxTake.TabIndex = 63;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.Location = new System.Drawing.Point(7, 322);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(106, 17);
            this.lblGrade.TabIndex = 62;
            this.lblGrade.Text = "Passing Grade:";
            // 
            // txbGrade
            // 
            this.txbGrade.Location = new System.Drawing.Point(118, 322);
            this.txbGrade.Name = "txbGrade";
            this.txbGrade.Size = new System.Drawing.Size(122, 20);
            this.txbGrade.TabIndex = 61;
            // 
            // AdminControlCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminControlCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminControlCourse";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txbSplit;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.TextBox txbHours;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label lblMaxtake;
        private System.Windows.Forms.TextBox txbMaxTake;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.TextBox txbGrade;
    }
}