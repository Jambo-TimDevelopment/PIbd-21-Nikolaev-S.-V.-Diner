
namespace AbstractDinerView
{
    partial class FormReportOrders
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
            this.components = new System.ComponentModel.Container();
            this.labelFrom = new System.Windows.Forms.Label();
            this.buttonPDF = new System.Windows.Forms.Button();
            this.buttonMake = new System.Windows.Forms.Button();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.panel = new System.Windows.Forms.Panel();
            this.ReportOrdersViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(22, 19);
            this.labelFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(20, 20);
            this.labelFrom.TabIndex = 11;
            this.labelFrom.Text = "С";
            // 
            // buttonPDF
            // 
            this.buttonPDF.Location = new System.Drawing.Point(1074, 21);
            this.buttonPDF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPDF.Name = "buttonPDF";
            this.buttonPDF.Size = new System.Drawing.Size(112, 35);
            this.buttonPDF.TabIndex = 14;
            this.buttonPDF.Text = "В PDF";
            this.buttonPDF.UseVisualStyleBackColor = true;
            this.buttonPDF.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(800, 21);
            this.buttonMake.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(159, 35);
            this.buttonMake.TabIndex = 13;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(410, 19);
            this.labelTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(30, 20);
            this.labelTo.TabIndex = 12;
            this.labelTo.Text = "По";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(469, 19);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(298, 26);
            this.dateTimePickerTo.TabIndex = 10;
            this.dateTimePickerTo.Value = new System.DateTime(2021, 3, 14, 0, 0, 0, 0);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(85, 18);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(298, 26);
            this.dateTimePickerFrom.TabIndex = 9;
            this.dateTimePickerFrom.Value = new System.DateTime(2021, 3, 14, 0, 0, 0, 0);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(6, 6);
            this.panel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1194, 66);
            this.panel.TabIndex = 16;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AbstractDinerView.ReportOrders.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 80);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1194, 401);
            this.reportViewer1.TabIndex = 17;
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 488);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.buttonPDF);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.panel);
            this.Name = "FormReportOrders";
            this.Text = "Заказы клиентов ";
            this.Load += new System.EventHandler(this.FormReportOrders_Load);
            this.Click += new System.EventHandler(this.FormReportOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Button buttonPDF;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.BindingSource ReportOrdersViewModelBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}