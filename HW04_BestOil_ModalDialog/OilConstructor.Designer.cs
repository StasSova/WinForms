namespace HW04_BestOil_ModalDialog
{
    partial class OilConstructor
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
            this.PriceFuel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TypeFuel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PriceFuel
            // 
            this.PriceFuel.Location = new System.Drawing.Point(126, 101);
            this.PriceFuel.Name = "PriceFuel";
            this.PriceFuel.Size = new System.Drawing.Size(100, 22);
            this.PriceFuel.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ціна";
            // 
            // TypeFuel
            // 
            this.TypeFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeFuel.FormattingEnabled = true;
            this.TypeFuel.Location = new System.Drawing.Point(126, 40);
            this.TypeFuel.Name = "TypeFuel";
            this.TypeFuel.Size = new System.Drawing.Size(147, 24);
            this.TypeFuel.TabIndex = 13;
            this.TypeFuel.SelectedIndexChanged += new System.EventHandler(this.TypeFuel_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Паливо";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 50);
            this.button1.TabIndex = 16;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(248, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 50);
            this.button2.TabIndex = 17;
            this.button2.Text = "Завершить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // OilConstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 225);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PriceFuel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TypeFuel);
            this.Controls.Add(this.label2);
            this.Name = "OilConstructor";
            this.Text = "OilConstructor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PriceFuel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TypeFuel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}