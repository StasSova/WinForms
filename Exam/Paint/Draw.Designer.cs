namespace Paint
{
    partial class Draw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Draw));
            this.panel3 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.очиститьФонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьЦветФонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьЦветToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button10 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button11 = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PictureMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Location = new System.Drawing.Point(926, 272);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(176, 100);
            this.panel3.TabIndex = 10;
            // 
            // button7
            // 
            this.button7.Image = global::Paint.Properties.Resources.Eraser;
            this.button7.Location = new System.Drawing.Point(46, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(37, 37);
            this.button7.TabIndex = 1;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Image = global::Paint.Properties.Resources.Pen;
            this.button6.Location = new System.Drawing.Point(3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(37, 37);
            this.button6.TabIndex = 0;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 50F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.World, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(448, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 60);
            this.label3.TabIndex = 9;
            this.label3.Text = "Текст";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Location = new System.Drawing.Point(923, 165);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 101);
            this.panel2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU-ExtB", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Толщина";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(-1, 41);
            this.trackBar1.Maximum = 15;
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(184, 56);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.ContextMenuStrip = this.PictureMenu;
            this.pictureBox1.Location = new System.Drawing.Point(29, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(890, 523);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // PictureMenu
            // 
            this.PictureMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PictureMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьФонToolStripMenuItem,
            this.изменитьЦветФонаToolStripMenuItem});
            this.PictureMenu.Name = "PictureMenu";
            this.PictureMenu.Size = new System.Drawing.Size(223, 52);
            // 
            // очиститьФонToolStripMenuItem
            // 
            this.очиститьФонToolStripMenuItem.Name = "очиститьФонToolStripMenuItem";
            this.очиститьФонToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.очиститьФонToolStripMenuItem.Text = "Очистить фон";
            this.очиститьФонToolStripMenuItem.Click += new System.EventHandler(this.очиститьФонToolStripMenuItem_Click);
            // 
            // изменитьЦветФонаToolStripMenuItem
            // 
            this.изменитьЦветФонаToolStripMenuItem.Name = "изменитьЦветФонаToolStripMenuItem";
            this.изменитьЦветФонаToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.изменитьЦветФонаToolStripMenuItem.Text = "Изменить цвет фона";
            this.изменитьЦветФонаToolStripMenuItem.Click += new System.EventHandler(this.изменитьЦветФонаToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(924, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 86);
            this.panel1.TabIndex = 6;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(130, 44);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(35, 35);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Fuchsia;
            this.button9.ContextMenuStrip = this.contextMenuStrip1;
            this.button9.Location = new System.Drawing.Point(48, 44);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(35, 35);
            this.button9.TabIndex = 6;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.ChangeColorPen);
            this.button9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьЦветToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 28);
            // 
            // изменитьЦветToolStripMenuItem
            // 
            this.изменитьЦветToolStripMenuItem.Name = "изменитьЦветToolStripMenuItem";
            this.изменитьЦветToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.изменитьЦветToolStripMenuItem.Text = "Изменить цвет";
            this.изменитьЦветToolStripMenuItem.Click += new System.EventHandler(this.изменитьЦветToolStripMenuItem_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Blue;
            this.button10.ContextMenuStrip = this.contextMenuStrip1;
            this.button10.Location = new System.Drawing.Point(7, 44);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(35, 35);
            this.button10.TabIndex = 5;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.ChangeColorPen);
            this.button10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.ContextMenuStrip = this.contextMenuStrip1;
            this.button5.Location = new System.Drawing.Point(89, 44);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 35);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.ChangeColorPen);
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lime;
            this.button4.ContextMenuStrip = this.contextMenuStrip1;
            this.button4.Location = new System.Drawing.Point(130, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 35);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.ChangeColorPen);
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Yellow;
            this.button3.ContextMenuStrip = this.contextMenuStrip1;
            this.button3.Location = new System.Drawing.Point(89, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 35);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.ChangeColorPen);
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.ContextMenuStrip = this.contextMenuStrip1;
            this.button2.Location = new System.Drawing.Point(48, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 35);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ChangeColorPen);
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ContextMenuStrip = this.contextMenuStrip1;
            this.button1.Location = new System.Drawing.Point(7, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ChangeColorPen);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(795, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 39);
            this.label2.TabIndex = 11;
            this.label2.Text = "Осталось: ";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button11
            // 
            this.button11.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button11.Location = new System.Drawing.Point(931, 449);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(171, 55);
            this.button11.TabIndex = 12;
            this.button11.Text = "Завершить";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // Draw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Paint.Properties.Resources.BackImage2;
            this.ClientSize = new System.Drawing.Size(1117, 638);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Draw";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PictureMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem изменитьЦветToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip PictureMenu;
        private System.Windows.Forms.ToolStripMenuItem очиститьФонToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьЦветФонаToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button11;
    }
}

