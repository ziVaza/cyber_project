using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;

namespace WinClient
{
    public partial class Client : Form
    {
        int portNo = 500;
        private string ipAddress = "127.0.0.1";
        TcpClient client;
        byte[] data;
        string password="";
        string username="";
        byte[] arr;
        //the split character is ;
        string userpass;

        public Client()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (btnSignIn.Text == "Sign In")
            {
                try
                {
                    // connect to the server
                    client = new TcpClient();
                    client.Connect(ipAddress,portNo);

                    data=new byte[client.ReceiveBufferSize];
                    username = txtNick.Text;
                    password = passwordBox.Text;
                    userpass = username + ";" + password;
                    SendMessage(userpass);
                    Thread.Sleep(1000);;
                    //SendMessage(password);

                    // read from server
                    client.GetStream().BeginRead(data,
                                                 0,
                                                 System.Convert.ToInt32(client.ReceiveBufferSize),
                                                 ReceiveMessage,
                                                 null);

                    btnSignIn.Text = "Sign Out";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                // disconnect from the server

                Disconnect();
                btnSignIn.Text = "Sign In";
            }
        }


        private void SendMessage(string message)
        {
            try
            {
                // send message to the server
                NetworkStream ns = client.GetStream();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // send the text
                ns.Write(data,0,data.Length);
                ns.Flush();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Asynchronously read data sent from the server in a seperate thread.
        /// Update the txtMessageHistory control using delegate.
        /// 
        /// Windows controls are not thread safed !
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;

                // read the data from the server
                bytesRead = client.GetStream().EndRead(ar);
                string str;
                if (bytesRead < 1)
                {
                    return;
                }
                else
                {
                    // invoke the delegate to display the recived data
                    object[] para = {
                                        System.Text.Encoding.ASCII.GetString(data,
                                                                             0,
                                                                             bytesRead)};
                    this.Invoke(new delUpdateHistory(UpdateHistory), para);
                    str=para.ToString();
                }


                // continue reading
                client.GetStream().BeginRead(data,
                                         0,
                                         System.Convert.ToInt32(client.ReceiveBufferSize),
                                         ReceiveMessage,
                                         null);
            }
            catch(Exception ex)
            {
                // ignor the error... fired when the user loggs off
            }
        }

        private delegate void delUpdateHistory(string str);

        void UpdateHistory(string str)
        {
            txtMessageHistory.AppendText(str);
            if (str == "OK\r\n")
            {
                OpenMainForm();
            }
        }

        void Disconnect()
        {
            try
            {
                // disconnect form the server
                client.GetStream().Close();
                client.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }


        private void OpenMainForm()
        {
            ClientInterfaceAndAnalysis frm2 = new ClientInterfaceAndAnalysis();
            frm2.FormClosed += new FormClosedEventHandler(frm2_FormClosed);
            frm2.Show();

            // Since this.Hide() for some reason doesn't work, i'll have to do this crap
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

    }
}