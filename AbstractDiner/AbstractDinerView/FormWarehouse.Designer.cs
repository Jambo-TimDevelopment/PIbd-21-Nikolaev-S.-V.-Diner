
namespace AbstractDinerView
{
    partial class FormWarehouse
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
            this.textBoxResposiblePerson = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelResposiblePerson = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxResposiblePerson
            // 
            this.textBoxResposiblePerson.Location = new System.Drawing.Point(217, 54);
            this.textBoxResposiblePerson.Name = "textBoxResposiblePerson";
            this.textBoxResposiblePerson.Size = new System.Drawing.Size(235, 26);
            this.textBoxResposiblePerson.TabIndex = 17;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(217, 13);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(235, 26);
            this.textBoxName.TabIndex = 16;
            // 
            // labelResposiblePerson
            // 
            this.labelResposiblePerson.AutoSize = true;
            this.labelResposiblePerson.Location = new System.Drawing.Point(29, 54);
            this.labelResposiblePerson.Name = "labelResposiblePerson";
            this.labelResposiblePerson.Size = new System.Drawing.Size(169, 20);
            this.labelResposiblePerson.TabIndex = 15;
            this.labelResposiblePerson.Text = "Ответсвтенное лицо";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(29, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(83, 20);
            this.labelName.TabIndex = 14;
            this.labelName.Text = "Название";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(206, 434);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(109, 31);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(343, 434);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(109, 31);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Count});
            this.dataGridView.Location = new System.Drawing.Point(7, 25);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(440, 297);
            this.dataGridView.TabIndex = 0;
            // 
            // Name
            // 
            this.Name.HeaderText = "Компонент";
            this.Name.MinimumWidth = 8;
            this.Name.Name = "Name";
            this.Name.Width = 150;
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.MinimumWidth = 8;
            this.Count.Name = "Count";
            this.Count.Width = 150;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.dataGridView);
            this.groupBox.Location = new System.Drawing.Point(5, 86);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(577, 342);
            this.groupBox.TabIndex = 11;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Компоненты";
            // 
            // FormWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 485);
            this.Controls.Add(this.textBoxResposiblePerson);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelResposiblePerson);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox);
            this.Text = "Создание склада";
            this.Load += new System.EventHandler(this.FormWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxResposiblePerson;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelResposiblePerson;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.GroupBox groupBox;
    }
}