
namespace CClick
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clickableButton = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.clickLabel = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.typeCheckBox = new System.Windows.Forms.CheckBox();
            this.battleTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.battleHealthTextBox = new System.Windows.Forms.TextBox();
            this.battleDamageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // clickableButton
            // 
            this.clickableButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.clickableButton.FlatAppearance.BorderSize = 0;
            this.clickableButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.clickableButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.clickableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clickableButton.Font = new System.Drawing.Font("Reem Kufi", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clickableButton.ForeColor = System.Drawing.SystemColors.Window;
            this.clickableButton.Location = new System.Drawing.Point(12, 194);
            this.clickableButton.Name = "clickableButton";
            this.clickableButton.Size = new System.Drawing.Size(342, 244);
            this.clickableButton.TabIndex = 0;
            this.clickableButton.Text = "START";
            this.clickableButton.UseVisualStyleBackColor = false;
            this.clickableButton.Click += new System.EventHandler(this.clickableButton_Click);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "10 clicks",
            "100 clicks",
            "1000 clicks",
            "10 seconds",
            "1 second",
            "Custom"});
            this.comboBox.Location = new System.Drawing.Point(13, 13);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(341, 23);
            this.comboBox.TabIndex = 1;
            this.comboBox.SelectionChangeCommitted += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(13, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(341, 103);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.Location = new System.Drawing.Point(13, 157);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 25);
            this.timeLabel.TabIndex = 3;
            // 
            // clickLabel
            // 
            this.clickLabel.AutoSize = true;
            this.clickLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clickLabel.Location = new System.Drawing.Point(360, 13);
            this.clickLabel.Name = "clickLabel";
            this.clickLabel.Size = new System.Drawing.Size(0, 25);
            this.clickLabel.TabIndex = 3;
            this.clickLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Enabled = false;
            this.typeTextBox.Location = new System.Drawing.Point(360, 241);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.PlaceholderText = "Max clicks";
            this.typeTextBox.Size = new System.Drawing.Size(112, 23);
            this.typeTextBox.TabIndex = 5;
            this.typeTextBox.Visible = false;
            // 
            // typeCheckBox
            // 
            this.typeCheckBox.AutoSize = true;
            this.typeCheckBox.Enabled = false;
            this.typeCheckBox.Location = new System.Drawing.Point(361, 194);
            this.typeCheckBox.Name = "typeCheckBox";
            this.typeCheckBox.Size = new System.Drawing.Size(259, 19);
            this.typeCheckBox.TabIndex = 6;
            this.typeCheckBox.Text = "Type (check: with Timer, default: clicks limit)";
            this.typeCheckBox.UseVisualStyleBackColor = true;
            this.typeCheckBox.Visible = false;
            this.typeCheckBox.CheckedChanged += new System.EventHandler(this.typeCheckBox_CheckedChanged);
            // 
            // battleTypeCheckBox
            // 
            this.battleTypeCheckBox.AutoSize = true;
            this.battleTypeCheckBox.Enabled = false;
            this.battleTypeCheckBox.Location = new System.Drawing.Point(360, 216);
            this.battleTypeCheckBox.Name = "battleTypeCheckBox";
            this.battleTypeCheckBox.Size = new System.Drawing.Size(83, 19);
            this.battleTypeCheckBox.TabIndex = 7;
            this.battleTypeCheckBox.Text = "Battle Type";
            this.battleTypeCheckBox.UseVisualStyleBackColor = true;
            this.battleTypeCheckBox.Visible = false;
            this.battleTypeCheckBox.CheckedChanged += new System.EventHandler(this.battleTypeCheckBox_CheckedChanged);
            // 
            // battleHealthTextBox
            // 
            this.battleHealthTextBox.Enabled = false;
            this.battleHealthTextBox.Location = new System.Drawing.Point(360, 270);
            this.battleHealthTextBox.Name = "battleHealthTextBox";
            this.battleHealthTextBox.PlaceholderText = "Health (Battle)";
            this.battleHealthTextBox.Size = new System.Drawing.Size(112, 23);
            this.battleHealthTextBox.TabIndex = 8;
            this.battleHealthTextBox.Visible = false;
            // 
            // battleDamageTextBox
            // 
            this.battleDamageTextBox.Enabled = false;
            this.battleDamageTextBox.Location = new System.Drawing.Point(360, 299);
            this.battleDamageTextBox.Name = "battleDamageTextBox";
            this.battleDamageTextBox.PlaceholderText = "Damage (Battle)";
            this.battleDamageTextBox.Size = new System.Drawing.Size(112, 23);
            this.battleDamageTextBox.TabIndex = 9;
            this.battleDamageTextBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 450);
            this.Controls.Add(this.battleDamageTextBox);
            this.Controls.Add(this.battleHealthTextBox);
            this.Controls.Add(this.battleTypeCheckBox);
            this.Controls.Add(this.typeCheckBox);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.clickLabel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.clickableButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "CClicker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clickableButton;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label clickLabel;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.CheckBox typeCheckBox;
        private System.Windows.Forms.CheckBox battleTypeCheckBox;
        private System.Windows.Forms.TextBox battleHealthTextBox;
        private System.Windows.Forms.TextBox battleDamageTextBox;
    }
}

