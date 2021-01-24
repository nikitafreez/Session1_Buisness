namespace AirLines
{
    partial class AdministratorForm
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
            this.AddUserButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.EnaDisButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.OfficesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateDBButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddUserButton
            // 
            this.AddUserButton.Location = new System.Drawing.Point(1, 0);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(75, 23);
            this.AddUserButton.TabIndex = 0;
            this.AddUserButton.Text = "Add user";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(82, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(1, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(796, 2);
            this.label2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 75);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(743, 305);
            this.dataGridView1.TabIndex = 5;
            // 
            // ChangeButton
            // 
            this.ChangeButton.Location = new System.Drawing.Point(30, 404);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(109, 23);
            this.ChangeButton.TabIndex = 6;
            this.ChangeButton.Text = "Change Role";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // EnaDisButton
            // 
            this.EnaDisButton.Location = new System.Drawing.Point(166, 404);
            this.EnaDisButton.Name = "EnaDisButton";
            this.EnaDisButton.Size = new System.Drawing.Size(153, 23);
            this.EnaDisButton.TabIndex = 7;
            this.EnaDisButton.Text = "Enable/Disable Login";
            this.EnaDisButton.UseVisualStyleBackColor = true;
            this.EnaDisButton.Click += new System.EventHandler(this.EnaDisButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(209, 38);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(72, 23);
            this.AcceptButton.TabIndex = 8;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(287, 38);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(72, 23);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // OfficesComboBox
            // 
            this.OfficesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OfficesComboBox.FormattingEnabled = true;
            this.OfficesComboBox.Location = new System.Drawing.Point(82, 38);
            this.OfficesComboBox.Name = "OfficesComboBox";
            this.OfficesComboBox.Size = new System.Drawing.Size(121, 24);
            this.OfficesComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Office:";
            // 
            // UpdateDBButton
            // 
            this.UpdateDBButton.Location = new System.Drawing.Point(665, 38);
            this.UpdateDBButton.Name = "UpdateDBButton";
            this.UpdateDBButton.Size = new System.Drawing.Size(108, 23);
            this.UpdateDBButton.TabIndex = 10;
            this.UpdateDBButton.Text = "Update DB";
            this.UpdateDBButton.UseVisualStyleBackColor = true;
            this.UpdateDBButton.Click += new System.EventHandler(this.UpdateDBButton_Click);
            // 
            // AdministratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UpdateDBButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.EnaDisButton);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OfficesComboBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.AddUserButton);
            this.Name = "AdministratorForm";
            this.Text = "AdministratorForm";
            this.Load += new System.EventHandler(this.AdministratorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Button EnaDisButton;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.ComboBox OfficesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UpdateDBButton;
    }
}