namespace HW03_BestOil
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CocaCola = new System.Windows.Forms.TextBox();
            this.Potato = new System.Windows.Forms.TextBox();
            this.Hamburger = new System.Windows.Forms.TextBox();
            this.HotDog = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.SumCafe = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SumOfFuel);
            this.groupBox1.Controls.Add(this.Count);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.SumOil);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.PriceFuel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TypeFuel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(83, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Автозаправка";
            // 
            // SumOfFuel
            // 
            this.SumOfFuel.Location = new System.Drawing.Point(171, 220);
            this.SumOfFuel.Name = "SumOfFuel";
            this.SumOfFuel.Size = new System.Drawing.Size(100, 22);
            this.SumOfFuel.TabIndex = 7;
            this.SumOfFuel.TextChanged += new System.EventHandler(this.SumOfFuel_TextChanged);
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(172, 191);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(100, 22);
            this.Count.TabIndex = 6;
            this.Count.TextChanged += new System.EventHandler(this.Count_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(24, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 39);
            this.label4.TabIndex = 5;
            this.label4.Text = "Сума: ";
            // 
            // SumOil
            // 
            this.SumOil.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SumOil.Location = new System.Drawing.Point(174, 317);
            this.SumOil.Name = "SumOil";
            this.SumOil.ReadOnly = true;
            this.SumOil.Size = new System.Drawing.Size(139, 45);
            this.SumOil.TabIndex = 4;
            this.SumOil.Text = "0";
            this.SumOil.TextChanged += new System.EventHandler(this.SumOil_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(35, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 72);
            this.panel1.TabIndex = 4;
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
            this.PriceFuel.Location = new System.Drawing.Point(121, 128);
            this.PriceFuel.Name = "PriceFuel";
            this.PriceFuel.ReadOnly = true;
            this.PriceFuel.Size = new System.Drawing.Size(100, 22);
            this.PriceFuel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ціна";
            // 
            // TypeFuel
            // 
            this.TypeFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeFuel.FormattingEnabled = true;
            this.TypeFuel.Location = new System.Drawing.Point(121, 53);
            this.TypeFuel.Name = "TypeFuel";
            this.TypeFuel.Size = new System.Drawing.Size(147, 24);
            this.TypeFuel.TabIndex = 1;
            this.TypeFuel.SelectedIndexChanged += new System.EventHandler(this.TypeFuel_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Паливо";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CocaCola);
            this.groupBox2.Controls.Add(this.Potato);
            this.groupBox2.Controls.Add(this.Hamburger);
            this.groupBox2.Controls.Add(this.HotDog);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.SumCafe);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(518, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 402);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Міні-кафе";
            // 
            // CocaCola
            // 
            this.CocaCola.Location = new System.Drawing.Point(237, 179);
            this.CocaCola.Name = "CocaCola";
            this.CocaCola.Size = new System.Drawing.Size(100, 22);
            this.CocaCola.TabIndex = 18;
            this.CocaCola.TextChanged += new System.EventHandler(this.HotDog_TextChanged);
            // 
            // Potato
            // 
            this.Potato.Location = new System.Drawing.Point(237, 133);
            this.Potato.Name = "Potato";
            this.Potato.Size = new System.Drawing.Size(100, 22);
            this.Potato.TabIndex = 17;
            this.Potato.TextChanged += new System.EventHandler(this.HotDog_TextChanged);
            // 
            // Hamburger
            // 
            this.Hamburger.Location = new System.Drawing.Point(237, 89);
            this.Hamburger.Name = "Hamburger";
            this.Hamburger.Size = new System.Drawing.Size(100, 22);
            this.Hamburger.TabIndex = 16;
            this.Hamburger.TextChanged += new System.EventHandler(this.HotDog_TextChanged);
            // 
            // HotDog
            // 
            this.HotDog.Location = new System.Drawing.Point(237, 60);
            this.HotDog.Name = "HotDog";
            this.HotDog.Size = new System.Drawing.Size(100, 22);
            this.HotDog.TabIndex = 15;
            this.HotDog.TextChanged += new System.EventHandler(this.HotDog_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(177, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "Ціна";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(177, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Ціна";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(177, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Ціна";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(177, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Ціна";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(30, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 39);
            this.label7.TabIndex = 7;
            this.label7.Text = "Сума: ";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(28, 179);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(95, 20);
            this.checkBox4.TabIndex = 10;
            this.checkBox4.Text = "Кока-кола";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // SumCafe
            // 
            this.SumCafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SumCafe.Location = new System.Drawing.Point(180, 320);
            this.SumCafe.Name = "SumCafe";
            this.SumCafe.ReadOnly = true;
            this.SumCafe.Size = new System.Drawing.Size(139, 45);
            this.SumCafe.TabIndex = 6;
            this.SumCafe.Text = "0";
            this.SumCafe.TextChanged += new System.EventHandler(this.SumOil_TextChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(28, 130);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(117, 20);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.Text = "Картопля-фрі";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(28, 89);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(99, 20);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Гамбургер";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(28, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 20);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Хот-дог";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Кількість";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ціна";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(400, 480);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(210, 45);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(250, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Сума: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 549);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox TypeFuel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SumOil;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox PriceFuel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CocaCola;
        private System.Windows.Forms.TextBox Potato;
        private System.Windows.Forms.TextBox Hamburger;
        private System.Windows.Forms.TextBox HotDog;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox SumCafe;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SumOfFuel;
        private System.Windows.Forms.TextBox Count;
    }
}

