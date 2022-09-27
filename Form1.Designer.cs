
using System.Drawing;

namespace RazerKeyboardRecoloring
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
            this.lmbColorBtn = new System.Windows.Forms.Button();
            this.rmbColorBtn = new System.Windows.Forms.Button();
            this.mmbColorBtn = new System.Windows.Forms.Button();
            this.mb4ColorBtn = new System.Windows.Forms.Button();
            this.mb5ColorBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.recolorKeyboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lmbColorBtn
            // 
            this.lmbColorBtn.BackColor = System.Drawing.Color.Red;
            this.lmbColorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmbColorBtn.Location = new System.Drawing.Point(12, 44);
            this.lmbColorBtn.Name = "lmbColorBtn";
            this.lmbColorBtn.Size = new System.Drawing.Size(100, 100);
            this.lmbColorBtn.TabIndex = 0;
            this.lmbColorBtn.Text = "L";
            this.lmbColorBtn.UseVisualStyleBackColor = true;
            this.lmbColorBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lmbColorBtn_MouseDown);
            // 
            // rmbColorBtn
            // 
            this.rmbColorBtn.BackColor = System.Drawing.Color.Yellow;
            this.rmbColorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rmbColorBtn.Location = new System.Drawing.Point(112, 44);
            this.rmbColorBtn.Name = "rmbColorBtn";
            this.rmbColorBtn.Size = new System.Drawing.Size(100, 100);
            this.rmbColorBtn.TabIndex = 0;
            this.rmbColorBtn.Text = "R";
            this.rmbColorBtn.UseVisualStyleBackColor = true;
            this.rmbColorBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lmbColorBtn_MouseDown);
            // 
            // mmbColorBtn
            // 
            this.mmbColorBtn.BackColor = System.Drawing.Color.Green;
            this.mmbColorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmbColorBtn.Location = new System.Drawing.Point(212, 44);
            this.mmbColorBtn.Name = "mmbColorBtn";
            this.mmbColorBtn.Size = new System.Drawing.Size(100, 100);
            this.mmbColorBtn.TabIndex = 0;
            this.mmbColorBtn.Text = "M";
            this.mmbColorBtn.UseVisualStyleBackColor = true;
            this.mmbColorBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lmbColorBtn_MouseDown);
            // 
            // mb4ColorBtn
            // 
            this.mb4ColorBtn.BackColor = System.Drawing.Color.Cyan;
            this.mb4ColorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mb4ColorBtn.Location = new System.Drawing.Point(312, 44);
            this.mb4ColorBtn.Name = "mb4ColorBtn";
            this.mb4ColorBtn.Size = new System.Drawing.Size(100, 100);
            this.mb4ColorBtn.TabIndex = 0;
            this.mb4ColorBtn.Text = "4";
            this.mb4ColorBtn.UseVisualStyleBackColor = true;
            this.mb4ColorBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lmbColorBtn_MouseDown);
            // 
            // mb5ColorBtn
            // 
            this.mb5ColorBtn.BackColor = System.Drawing.Color.Purple;
            this.mb5ColorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mb5ColorBtn.Location = new System.Drawing.Point(412, 44);
            this.mb5ColorBtn.Name = "mb5ColorBtn";
            this.mb5ColorBtn.Size = new System.Drawing.Size(100, 100);
            this.mb5ColorBtn.TabIndex = 0;
            this.mb5ColorBtn.Text = "5";
            this.mb5ColorBtn.UseVisualStyleBackColor = true;
            this.mb5ColorBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lmbColorBtn_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(556, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mouse button colors: left, right, middle, 4, 5";
            // 
            // recolorKeyboard
            // 
            this.recolorKeyboard.BackColor = System.Drawing.Color.White;
            this.recolorKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recolorKeyboard.Location = new System.Drawing.Point(1488, 12);
            this.recolorKeyboard.Name = "recolorKeyboard";
            this.recolorKeyboard.Size = new System.Drawing.Size(200, 100);
            this.recolorKeyboard.TabIndex = 2;
            this.recolorKeyboard.Text = "Recolor keyboard";
            this.recolorKeyboard.UseVisualStyleBackColor = true;
            this.recolorKeyboard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.recolorKeyboard_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 629);
            this.Controls.Add(this.recolorKeyboard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lmbColorBtn);
            this.Controls.Add(this.rmbColorBtn);
            this.Controls.Add(this.mmbColorBtn);
            this.Controls.Add(this.mb4ColorBtn);
            this.Controls.Add(this.mb5ColorBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "RazerKeyboardRecoloring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lmbColorBtn;
        private System.Windows.Forms.Button rmbColorBtn;
        private System.Windows.Forms.Button mmbColorBtn;
        private System.Windows.Forms.Button mb4ColorBtn;
        private System.Windows.Forms.Button mb5ColorBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button recolorKeyboard;
    }
}