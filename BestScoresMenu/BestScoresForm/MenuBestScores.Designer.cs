
namespace CClick.BestScoresMenu
{
    partial class MenuBestScores
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
            this.clicks10 = new System.Windows.Forms.Label();
            this.clicks100 = new System.Windows.Forms.Label();
            this.clicks1000 = new System.Windows.Forms.Label();
            this.sec1 = new System.Windows.Forms.Label();
            this.sec10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clicks10
            // 
            this.clicks10.AutoSize = true;
            this.clicks10.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clicks10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.clicks10.Location = new System.Drawing.Point(12, 9);
            this.clicks10.Name = "clicks10";
            this.clicks10.Size = new System.Drawing.Size(155, 32);
            this.clicks10.TabIndex = 1;
            this.clicks10.Text = "10 clicks: null";
            // 
            // clicks100
            // 
            this.clicks100.AutoSize = true;
            this.clicks100.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clicks100.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.clicks100.Location = new System.Drawing.Point(12, 41);
            this.clicks100.Name = "clicks100";
            this.clicks100.Size = new System.Drawing.Size(168, 32);
            this.clicks100.TabIndex = 2;
            this.clicks100.Text = "100 clicks: null";
            // 
            // clicks1000
            // 
            this.clicks1000.AutoSize = true;
            this.clicks1000.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clicks1000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.clicks1000.Location = new System.Drawing.Point(12, 73);
            this.clicks1000.Name = "clicks1000";
            this.clicks1000.Size = new System.Drawing.Size(181, 32);
            this.clicks1000.TabIndex = 3;
            this.clicks1000.Text = "1000 clicks: null";
            // 
            // sec1
            // 
            this.sec1.AutoSize = true;
            this.sec1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sec1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.sec1.Location = new System.Drawing.Point(12, 105);
            this.sec1.Name = "sec1";
            this.sec1.Size = new System.Drawing.Size(162, 32);
            this.sec1.TabIndex = 4;
            this.sec1.Text = "1 second: null";
            // 
            // sec10
            // 
            this.sec10.AutoSize = true;
            this.sec10.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sec10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.sec10.Location = new System.Drawing.Point(12, 137);
            this.sec10.Name = "sec10";
            this.sec10.Size = new System.Drawing.Size(185, 32);
            this.sec10.TabIndex = 5;
            this.sec10.Text = "10 seconds: null";
            // 
            // MenuBestScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(348, 179);
            this.Controls.Add(this.sec10);
            this.Controls.Add(this.sec1);
            this.Controls.Add(this.clicks1000);
            this.Controls.Add(this.clicks100);
            this.Controls.Add(this.clicks10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MenuBestScores";
            this.Text = "Best Scores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label clicks10;
        public System.Windows.Forms.Label clicks100;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label sec1;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label clicks1000;
        public System.Windows.Forms.Label sec10;
    }
}