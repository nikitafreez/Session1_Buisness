namespace AirLines
{
    partial class ChangeInfoForm
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.OfficesComboBox = new System.Windows.Forms.ComboBox();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserRadio = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.AdminRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(187, 224);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(72, 23);
            this.CancelButton.TabIndex = 44;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(109, 224);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(72, 23);
            this.SaveButton.TabIndex = 43;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "Office";
            // 
            // OfficesComboBox
            // 
            this.OfficesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OfficesComboBox.FormattingEnabled = true;
            this.OfficesComboBox.Location = new System.Drawing.Point(145, 113);
            this.OfficesComboBox.Name = "OfficesComboBox";
            this.OfficesComboBox.Size = new System.Drawing.Size(179, 24);
            this.OfficesComboBox.TabIndex = 39;
            // 
            // LastNameBox
            // 
            this.LastNameBox.Location = new System.Drawing.Point(145, 85);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(179, 22);
            this.LastNameBox.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 35;
            this.label3.Text = "Last Name";
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.Location = new System.Drawing.Point(145, 57);
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(179, 22);
            this.FirstNameBox.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "First Name";
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(145, 29);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(179, 22);
            this.EmailBox.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Email address";
            // 
            // UserRadio
            // 
            this.UserRadio.AutoSize = true;
            this.UserRadio.Location = new System.Drawing.Point(145, 158);
            this.UserRadio.Name = "UserRadio";
            this.UserRadio.Size = new System.Drawing.Size(59, 21);
            this.UserRadio.TabIndex = 45;
            this.UserRadio.TabStop = true;
            this.UserRadio.Text = "User";
            this.UserRadio.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "Role";
            // 
            // AdminRadio
            // 
            this.AdminRadio.AutoSize = true;
            this.AdminRadio.Location = new System.Drawing.Point(145, 185);
            this.AdminRadio.Name = "AdminRadio";
            this.AdminRadio.Size = new System.Drawing.Size(112, 21);
            this.AdminRadio.TabIndex = 47;
            this.AdminRadio.TabStop = true;
            this.AdminRadio.Text = "Administrator";
            this.AdminRadio.UseVisualStyleBackColor = true;
            // 
            // ChangeInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 269);
            this.Controls.Add(this.AdminRadio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UserRadio);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OfficesComboBox);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FirstNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.label1);
            this.Name = "ChangeInfoForm";
            this.Text = "ChangeInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox OfficesComboBox;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton UserRadio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton AdminRadio;
    }
}