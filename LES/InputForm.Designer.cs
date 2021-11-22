namespace LES
{
    partial class InputForm
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
        private void InitializeComponent(int size, bool f)
        {
            int k = 0;
            this.textBoxVal = new System.Windows.Forms.TextBox[size][];
            this.textBoxRes = new System.Windows.Forms.TextBox[size];
            this.labelX = new System.Windows.Forms.Label[size][];
            this.btnRes = new System.Windows.Forms.Button();
            // this.SuspendLayout();
            // 
            // textBoxVal
            // 
            for (int i = 0; i < size; i++)
            {
                this.textBoxVal[i] = new System.Windows.Forms.TextBox[size];
                for (int j = 0; j < size; j++)
                {
                    this.textBoxVal[i][j] = new System.Windows.Forms.TextBox();
                    this.textBoxVal[i][j].Location = new System.Drawing.Point(50 + (80 * j), 32 + (30 * i));
                    this.textBoxVal[i][j].Name = "textBoxVal" + i + j;
                    this.textBoxVal[i][j].Size = new System.Drawing.Size(40, 20);
                    this.textBoxVal[i][j].TabIndex = k;
                    k++;
                }
                this.textBoxRes[i] = new System.Windows.Forms.TextBox();
                this.textBoxRes[i].Location = new System.Drawing.Point(50 + (80 * size), 32 + (30 * i));
                this.textBoxRes[i].Name = "textBoxRes" + i;
                this.textBoxRes[i].Size = new System.Drawing.Size(40, 20);
                this.textBoxRes[i].TabIndex = size*size+1;
            }
            // 
            // labelX
            // 
            for (int i = 0; i < size; i++)
            {
                this.labelX[i] = new System.Windows.Forms.Label[size];
                for (int j = 0; j < size; j++)
                {
                    this.labelX[i][j] = new System.Windows.Forms.Label();
                    this.labelX[i][j].AutoSize = true;
                    this.labelX[i][j].Location = new System.Drawing.Point(90 + (80 * i), 34 + (30 * j));
                    this.labelX[i][j].Name = "labelX";
                    this.labelX[i][j].Size = new System.Drawing.Size(101, 13);
                    this.labelX[i][j].TabIndex = 2;
                    this.labelX[i][j].Text = "* X" + (i+1) + " ";
                    if (i != size - 1)
                    {
                        this.labelX[i][j].Text += "+";
                    }
                    else
                    {
                        this.labelX[i][j].Text += "=";
                    }
                }
            }
            // 
            // btnRes
            // 
            this.btnRes.Location = new System.Drawing.Point(36 , 64 + size * 30);
            this.btnRes.Name = "btnRes";
            this.btnRes.Size = new System.Drawing.Size(115, 23);
            this.btnRes.TabIndex = size*size+2;
            this.btnRes.Text = "Найти значение корней";
            this.btnRes.UseVisualStyleBackColor = true;

            this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
            // 
            // InputForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 150);
            
            for (int i = 0; i < size; i++)
            {
                this.Controls.Add(this.textBoxRes[i]);
                for (int j = 0; j < size; j++)
                {
                    this.Controls.Add(this.labelX[i][j]);
                    this.Controls.Add(this.textBoxVal[i][j]);
                }
            }
            this.Controls.Add(this.btnRes);
            this.SuspendLayout();
            // 
            // InputForm
            // 
            this.ClientSize = new System.Drawing.Size(300 + 60 * size, 100 + 30 * size);
            this.Name = "InputForm";
            this.Text = "Ввод данных для метода ";
            if (f)
            {
                this.Text += "Гаусса";
            }
            else
            {
                this.Text += "Квадратных корней";
            }
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox[][] textBoxVal;
        private System.Windows.Forms.TextBox[] textBoxRes;
        private System.Windows.Forms.Label[][] labelX;
        private System.Windows.Forms.Button btnRes;
    }
}