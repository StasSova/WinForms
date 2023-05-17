using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW16_Udp_Client_Server
{
    public partial class Chat : Form
    {
        static int RemotePort;
        static int LocalPort;
        string _Name;
        static IPAddress RemoteIPAddr;
        private SynchronizationContext uiContext;
        public Chat()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
            Init connect = new Init();
            DialogResult res = connect.ShowDialog();
            if (res == DialogResult.OK) 
            {
                RemoteIPAddr = connect._ip;
                RemotePort = Convert.ToInt16(connect._remport);
                LocalPort = Convert.ToInt16(connect._locport);
                _Name = connect._nick;
                this.Text = _Name;
            }
            else
            {
                this.Close();
            }
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(
                   new ThreadStart(ThreadFuncReceive)
            );
            //create a background thread
            thread.IsBackground = true;
            //start the thread
            thread.Start();
        }
        void ThreadFuncReceive()
        {
            UdpClient uClient = new UdpClient(LocalPort);
            try
            {
                while (true)
                {
                    //connection to the local host
                    IPEndPoint ipEnd = null;
                    //receiving datagramm
                    byte[] responce = uClient.Receive(ref ipEnd);
                    //conversion to a string
                    string strResult = Encoding.Unicode.GetString(responce);
                    if (strResult != null)
                        uiContext.Send(d =>
                        { 
                            lock (listBox1)
                            {
                                listBox1.Items.Add(strResult);
                            }
                        }, null);
                }
            }
            catch (SocketException sockEx)
            {
                Console.WriteLine("Socket exception: " + sockEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
            finally
            {
                uClient.Close();
            }
        }
        static void SendData(string datagramm)
        {
            UdpClient uClient = new UdpClient();
            //connecting to a remote host
            IPEndPoint ipEnd = new IPEndPoint(RemoteIPAddr, RemotePort);
            try
            {
                byte[] bytes = Encoding.Unicode.GetBytes(datagramm);
                uClient.Send(bytes, bytes.Length, ipEnd);
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show("Socket exception: " + sockEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex.Message);
            }
            finally
            {
                //close the UdpClient class instance
                uClient.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SendData(_Name + ": "+textBox1.Text);
                lock (listBox1)
                { listBox1.Items.Add(textBox1.Text); }
                textBox1.Text = string.Empty;
            }
        }
    }
}
