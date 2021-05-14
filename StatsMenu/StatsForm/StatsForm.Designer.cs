
namespace CClick.StatsMenu.StatsForm
{
    partial class StatsForm
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
            this.totalClicksLabel = new System.Windows.Forms.Label();
            this.totalTestsLabel = new System.Windows.Forms.Label();
            this.clicksAverageLabel = new System.Windows.Forms.Label();
            this.timeElapsedLabel = new System.Windows.Forms.Label();
            this.clicksPerSecondsAverageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // totalClicksLabel
            // 
            this.totalClicksLabel.AutoSize = true;
            this.totalClicksLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalClicksLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.totalClicksLabel.Location = new System.Drawing.Point(13, 13);
            this.totalClicksLabel.Name = "totalClicksLabel";
            this.totalClicksLabel.Size = new System.Drawing.Size(157, 32);
            this.totalClicksLabel.TabIndex = 0;
            this.totalClicksLabel.Text = "Total Clicks: 0";
            // 
            // totalTestsLabel
            // 
            this.totalTestsLabel.AutoSize = true;
            this.totalTestsLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalTestsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.totalTestsLabel.Location = new System.Drawing.Point(13, 45);
            this.totalTestsLabel.Name = "totalTestsLabel";
            this.totalTestsLabel.Size = new System.Drawing.Size(149, 32);
            this.totalTestsLabel.TabIndex = 1;
            this.totalTestsLabel.Text = "Total Tests: 0";
            // 
            // clicksAverageLabel
            // 
            this.clicksAverageLabel.AutoSize = true;
            this.clicksAverageLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clicksAverageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.clicksAverageLabel.Location = new System.Drawing.Point(13, 77);
            this.clicksAverageLabel.Name = "clicksAverageLabel";
            this.clicksAverageLabel.Size = new System.Drawing.Size(278, 32);
            this.clicksAverageLabel.TabIndex = 2;
            this.clicksAverageLabel.Text = "Clicks per test average: 0";
            // 
            // timeElapsedLabel
            // 
            this.timeElapsedLabel.AutoSize = true;
            this.timeElapsedLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeElapsedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.timeElapsedLabel.Location = new System.Drawing.Point(13, 109);
            this.timeElapsedLabel.Name = "timeElapsedLabel";
            this.timeElapsedLabel.Size = new System.Drawing.Size(282, 32);
            this.timeElapsedLabel.TabIndex = 3;
            this.timeElapsedLabel.Text = "Time elapsed on tests: 0s";
            // 
            // clicksPerSecondsAverageLabel
            // 
            this.clicksPerSecondsAverageLabel.AutoSize = true;
            this.clicksPerSecondsAverageLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clicksPerSecondsAverageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.clicksPerSecondsAverageLabel.Location = new System.Drawing.Point(13, 141);
            this.clicksPerSecondsAverageLabel.Name = "clicksPerSecondsAverageLabel";
            this.clicksPerSecondsAverageLabel.Size = new System.Drawing.Size(344, 32);
            this.clicksPerSecondsAverageLabel.TabIndex = 4;
            this.clicksPerSecondsAverageLabel.Text = "Clicks per seconds average: 0/s";
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(496, 187);
            this.Controls.Add(this.clicksPerSecondsAverageLabel);
            this.Controls.Add(this.timeElapsedLabel);
            this.Controls.Add(this.clicksAverageLabel);
            this.Controls.Add(this.totalTestsLabel);
            this.Controls.Add(this.totalClicksLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StatsForm";
            this.Text = "StatsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label totalClicksLabel;
        public System.Windows.Forms.Label clicksAverageLabel;
        public System.Windows.Forms.Label timeElapsedLabel;
        public System.Windows.Forms.Label totalTestsLabel;
        public System.Windows.Forms.Label clicksPerSecondsAverageLabel;
    }
}