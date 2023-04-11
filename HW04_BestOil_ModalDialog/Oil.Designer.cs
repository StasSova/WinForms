namespace HW04_BestOil_ModalDialog
{
    partial class Oil
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
            this.SumOfFuel = new System.Windows.Forms.TextBox();
            this.Count = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SumOil = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.PriceFuel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TypeFuel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SumOfFuel
            // 
            this.SumOfFuel.Enabled = false;
            this.SumOfFuel.Location = new System.Drawing.Point(168, 219);
            this.SumOfFuel.Name = "SumOfFuel";
            this.SumOfFuel.Size = new System.Drawing.Size(100, 22);
            this.SumOfFuel.TabIndex = 16;
            this.SumOfFuel.TextChanged += new System.EventHandler(this.SumOfFuel_TextChanged);
            // 
            // Count
            // 
            this.Count.Enabled = false;
            this.Count.Location = new System.Drawing.Point(168, 191);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(100, 22);
            this.Count.TabIndex = 15;
            this.Count.TextChanged += new System.EventHandler(this.Count_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(18, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 39);
            this.label4.TabIndex = 14;
            this.label4.Text = "Сума: ";
            // 
            // SumOil
            // 
            this.SumOil.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SumOil.Location = new System.Drawing.Point(168, 316);
            this.SumOil.Name = "SumOil";
            this.SumOil.ReadOnly = true;
            this.SumOil.Size = new System.Drawing.Size(139, 45);
            this.SumOil.TabIndex = 12;
            this.SumOil.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(29, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 72);
            this.panel1.TabIndex = 13;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 41);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Сума";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 15);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Кількість";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // PriceFuel
            // 
            this.PriceFuel.Location = new System.Drawing.Point(115, 113);
            this.PriceFuel.Name = "PriceFuel";
            this.PriceFuel.ReadOnly = true;
            this.PriceFuel.Size = new System.Drawing.Size(100, 22);
            this.PriceFuel.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ціна";
            // 
            // TypeFuel
            // 
            this.TypeFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeFuel.FormattingEnabled = true;
            this.TypeFuel.Location = new System.Drawing.Point(115, 52);
            this.TypeFuel.Name = "TypeFuel";
            this.TypeFuel.Size = new System.Drawing.Size(147, 24);
            this.TypeFuel.TabIndex = 9;
            this.TypeFuel.SelectedIndexChanged += new System.EventHandler(this.TypeFuel_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Паливо";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Segoe Print", 37.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(51, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 111);
            this.button1.TabIndex = 17;
            this.button1.Text = "Ок";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Oil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 510);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SumOfFuel);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SumOil);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PriceFuel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TypeFuel);
            this.Controls.Add(this.label2);
            this.Name = "Oil";
            this.Text = "Oil";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SumOfFuel;
        private System.Windows.Forms.TextBox Count;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SumOil;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox PriceFuel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TypeFuel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}