﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air_Quality
{
    public partial class Form1 : Form
    {
        private IPAddress ipAddress;//   The servers hostname or IP address need //need to find a way to get it  
        int PORT = 80;
        string responseData;
        public Form1()
        {
            //TODO: Read the latest IP from the file.
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            //TODO: Save the latest IP in a file.
            if (String.IsNullOrWhiteSpace(ipTextbox.Text)==false)
            {
                try
                {
                    ipAddress = IPAddress.Parse(ipTextbox.Text);
                    TcpClient client = new TcpClient(ipTextbox.Text, PORT);
                    Byte[] data = Encoding.ASCII.GetBytes("H");
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                    Byte[] data1 = new Byte[1024];
                    int hw = stream.Read(data1, 0, data1.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data1, 0, hw);
                    statusLabel.Text = responseData;
                }
                catch (ArgumentNullException A)
                {
                    Console.WriteLine("ArgumentNullException: {0}", A);
                }
                catch (SocketException A)
                {
                    Console.WriteLine("SocketException: {0}", A);
                }

            //Form2 form2 = new Form2(this);
            //form2.Show();
            //this.Hide();
            }
            else 
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Please type an IP address";
            }
        }
    }
}
