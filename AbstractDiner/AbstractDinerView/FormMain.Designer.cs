namespace AbstractDinerView
{
    partial class FormMain
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
            this.ButtonCreateOrder = new System.Windows.Forms.Button();
            this.ButtonTakeOrderInWork = new System.Windows.Forms.Button();
            this.ButtonOrderReady = new System.Windows.Forms.Button();
            this.ButtonPayOrder = new System.Windows.Forms.Button();
            this.ButtonRef = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнениеСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonCreateOrder
            // 
            this.ButtonCreateOrder.Location = new System.Drawing.Point(941, 54);
            this.ButtonCreateOrder.Name = "ButtonCreateOrder";
            this.ButtonCreateOrder.Size = new System.Drawing.Size(223, 40);
            this.ButtonCreateOrder.TabIndex = 0;
            this.ButtonCreateOrder.Text = "Создать заказ";
            this.ButtonCreateOrder.UseVisualStyleBackColor = true;
            this.ButtonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // ButtonTakeOrderInWork
            // 
            this.ButtonTakeOrderInWork.Location = new System.Drawing.Point(941, 100);
            this.ButtonTakeOrderInWork.Name = "ButtonTakeOrderInWork";
            this.ButtonTakeOrderInWork.Size = new System.Drawing.Size(223, 46);
            this.ButtonTakeOrderInWork.TabIndex = 1;
            this.ButtonTakeOrderInWork.Text = "Отдать на выполнение";
            this.ButtonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.ButtonTakeOrderInWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
            // 
            // ButtonOrderReady
            // 
            this.ButtonOrderReady.Location = new System.Drawing.Point(941, 152);
            this.ButtonOrderReady.Name = "ButtonOrderReady";
            this.ButtonOrderReady.Size = new System.Drawing.Size(223, 40);
            this.ButtonOrderReady.TabIndex = 2;
            this.ButtonOrderReady.Text = "Заказ готов";
            this.ButtonOrderReady.UseVisualStyleBackColor = true;
            this.ButtonOrderReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            // 
            // ButtonPayOrder
            // 
            this.ButtonPayOrder.Location = new System.Drawing.Point(941, 198);
            this.ButtonPayOrder.Name = "ButtonPayOrder";
            this.ButtonPayOrder.Size = new System.Drawing.Size(223, 44);
            this.ButtonPayOrder.TabIndex = 3;
            this.ButtonPayOrder.Text = "Заказ оплачен";
            this.ButtonPayOrder.UseVisualStyleBackColor = true;
            this.ButtonPayOrder.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // ButtonRef
            // 
            this.ButtonRef.Location = new System.Drawing.Point(941, 248);
            this.ButtonRef.Name = "ButtonRef";
            this.ButtonRef.Size = new System.Drawing.Size(223, 45);
            this.ButtonRef.TabIndex = 4;
            this.ButtonRef.Text = "Обновить список";
            this.ButtonRef.UseVisualStyleBackColor = true;
            this.ButtonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 53);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(923, 385);
            this.dataGridView.TabIndex = 5;
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.пополнениеСкладовToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1177, 33);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.складыToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(129, 29);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.КомпонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.ИзделияToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // пополнениеСкладовToolStripMenuItem
            // 
            this.пополнениеСкладовToolStripMenuItem.Name = "пополнениеСкладовToolStripMenuItem";
            this.пополнениеСкладовToolStripMenuItem.Size = new System.Drawing.Size(201, 29);
            this.пополнениеСкладовToolStripMenuItem.Text = "Пополнение складов";
            this.пополнениеСкладовToolStripMenuItem.Click += new System.EventHandler(this.пополнениеСкладовToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.ButtonRef);
            this.Controls.Add(this.ButtonPayOrder);
            this.Controls.Add(this.ButtonOrderReady);
            this.Controls.Add(this.ButtonTakeOrderInWork);
            this.Controls.Add(this.ButtonCreateOrder);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Закусочная";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonCreateOrder;
        private System.Windows.Forms.Button ButtonTakeOrderInWork;
        private System.Windows.Forms.Button ButtonOrderReady;
        private System.Windows.Forms.Button ButtonPayOrder;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнениеСкладовToolStripMenuItem;
    }
}