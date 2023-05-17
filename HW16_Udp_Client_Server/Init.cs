using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW16_Udp_Client_Server
{
    public partial class Init : Form
    {
        public IPAddress _ip { get; set; }
        public string _locport { get;set; }
        public string _remport { get; set; }
        public string _nick { get; set; }
        public Init()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    _nick = textBox4.Text;
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    _ip = IPAddress.Parse(textBox1.Text);
                else throw new Exception("Поле IP должно быть заполненно");
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                    _locport = textBox2.Text;
                else throw new Exception("Поле Local port должно быть заполненно");
                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                    _remport = textBox3.Text;
                else throw new Exception("Поле Remote port должно быть заполненно");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK); }
        }
    }
}
