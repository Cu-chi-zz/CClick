
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
            this.soundEffectCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // clickableButton
            // 
            this.clickableButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(130)))), ((int)(((byte)(88)))));
            this.clickableButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.clickableButton.FlatAppearance.BorderSize = 5;
            this.clickableButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(118)))), ((int)(((byte)(72)))));
            this.clickableButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(145)))), ((int)(((byte)(109)))));
            this.clickableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clickableButton.Font = new System.Drawing.Font("Reem Kufi", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clickableButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.clickableButton.Location = new System.Drawing.Point(12, 194);
            this.clickableButton.Name = "clickableButton";
            this.clickableButton.Size = new System.Drawing.Size(342, 232);
            this.clickableButton.TabIndex = 0;
            this.clickableButton.Text = "START";
            this.clickableButton.UseVisualStyleBackColor = false;
            this.clickableButton.Click += new System.EventHandler(this.clickableButton_Click);
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.comboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(130)))), ((int)(((byte)(88)))));
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
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.richTextBox1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(130)))), ((int)(((byte)(88)))));
            this.richTextBox1.Location = new System.Drawing.Point(13, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(341, 103);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(130)))), ((int)(((byte)(88)))));
            this.timeLabel.Location = new System.Drawing.Point(13, 157);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 25);
            this.timeLabel.TabIndex = 3;
            // 
            // clickLabel
            // 
            this.clickLabel.AutoSize = true;
            this.clickLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clickLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(130)))), ((int)(((byte)(88)))));
            this.clickLabel.Location = new System.Drawing.Point(250, 157);
            this.clickLabel.Name = "clickLabel";
            this.clickLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clickLabel.Size = new System.Drawing.Size(0, 25);
            this.clickLabel.TabIndex = 3;
            this.clickLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // typeTextBox
            // 
            this.typeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
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
            this.typeCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.typeCheckBox.Enabled = false;
            this.typeCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.typeCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(130)))), ((int)(((byte)(88)))));
            this.typeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.typeCheckBox.Location = new System.Drawing.Point(360, 194);
            this.typeCheckBox.Name = "typeCheckBox";
            this.typeCheckBox.Size = new System.Drawing.Size(256, 19);
            this.typeCheckBox.TabIndex = 6;
            this.typeCheckBox.Text = "Type (check: with Timer, default: clicks limit)";
            this.typeCheckBox.UseVisualStyleBackColor = false;
            this.typeCheckBox.Visible = false;
            this.typeCheckBox.CheckedChanged += new System.EventHandler(this.typeCheckBox_CheckedChanged);
            // 
            // battleTypeCheckBox
            // 
            this.battleTypeCheckBox.AutoSize = true;
            this.battleTypeCheckBox.Enabled = false;
            this.battleTypeCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.battleTypeCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(130)))), ((int)(((byte)(88)))));
            this.battleTypeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.battleTypeCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.battleTypeCheckBox.Location = new System.Drawing.Point(360, 216);
            this.battleTypeCheckBox.Name = "battleTypeCheckBox";
            this.battleTypeCheckBox.Size = new System.Drawing.Size(80, 19);
            this.battleTypeCheckBox.TabIndex = 7;
            this.battleTypeCheckBox.Text = "Battle Type";
            this.battleTypeCheckBox.UseVisualStyleBackColor = true;
            this.battleTypeCheckBox.Visible = false;
            this.battleTypeCheckBox.CheckedChanged += new System.EventHandler(this.battleTypeCheckBox_CheckedChanged);
            // 
            // battleHealthTextBox
            // 
            this.battleHealthTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.battleHealthTextBox.Enabled = false;
            this.battleHealthTextBox.Location = new System.Drawing.Point(360, 241);
            this.battleHealthTextBox.Name = "battleHealthTextBox";
            this.battleHealthTextBox.PlaceholderText = "Health";
            this.battleHealthTextBox.Size = new System.Drawing.Size(112, 23);
            this.battleHealthTextBox.TabIndex = 8;
            this.battleHealthTextBox.Visible = false;
            // 
            // battleDamageTextBox
            // 
            this.battleDamageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.battleDamageTextBox.Enabled = false;
            this.battleDamageTextBox.Location = new System.Drawing.Point(360, 270);
            this.battleDamageTextBox.Name = "battleDamageTextBox";
            this.battleDamageTextBox.PlaceholderText = "Damage";
            this.battleDamageTextBox.Size = new System.Drawing.Size(112, 23);
            this.battleDamageTextBox.TabIndex = 9;
            this.battleDamageTextBox.Visible = false;
            // 
            // soundEffectCheckBox
            // 
            this.soundEffectCheckBox.AutoSize = true;
            this.soundEffectCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.soundEffectCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.soundEffectCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(130)))), ((int)(((byte)(88)))));
            this.soundEffectCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.soundEffectCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.soundEffectCheckBox.Location = new System.Drawing.Point(13, 431);
            this.soundEffectCheckBox.Name = "soundEffectCheckBox";
            this.soundEffectCheckBox.Size = new System.Drawing.Size(171, 19);
            this.soundEffectCheckBox.TabIndex = 10;
            this.soundEffectCheckBox.Text = "Enable sound effect on click";
            this.soundEffectCheckBox.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(364, 451);
            this.Controls.Add(this.soundEffectCheckBox);
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
        private System.Windows.Forms.CheckBox soundEffectCheckBox;
    }
}

