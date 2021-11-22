namespace LES
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioGauss = new System.Windows.Forms.RadioButton();
            this.radioHol = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(45, 27);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxSize.TabIndex = 0;
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(40, 117);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(115, 23);
            this.btnIn.TabIndex = 1;
            this.btnIn.Text = "Ввести данные";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Размерность СЛУ";
            // 
            // radioGauss
            // 
            this.radioGauss.AutoSize = true;
            this.radioGauss.Checked = true;
            this.radioGauss.Location = new System.Drawing.Point(48, 63);
            this.radioGauss.Name = "radioGauss";
            this.radioGauss.Size = new System.Drawing.Size(95, 17);
            this.radioGauss.TabIndex = 3;
            this.radioGauss.TabStop = true;
            this.radioGauss.Text = "Метод Гаусса";
            this.radioGauss.UseVisualStyleBackColor = true;
            // 
            // radioHol
            // 
            this.radioHol.AutoSize = true;
            this.radioHol.Location = new System.Drawing.Point(48, 86);
            this.radioHol.Name = "radioHol";
            this.radioHol.Size = new System.Drawing.Size(159, 17);
            this.radioHol.TabIndex = 4;
            this.radioHol.TabStop = true;
            this.radioHol.Text = "Метод квадратных корней";
            this.radioHol.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 152);
            this.Controls.Add(this.radioHol);
            this.Controls.Add(this.radioGauss);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.textBoxSize);
            this.Name = "Menu";
            this.Text = "Меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioGauss;
        private System.Windows.Forms.RadioButton radioHol;
    }
}

