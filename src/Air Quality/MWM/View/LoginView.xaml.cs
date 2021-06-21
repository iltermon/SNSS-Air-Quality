﻿using AirQuality.MWM.ViewModel;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace AirQuality.MWM.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private string ipAddress;

        public LoginView()
        {
            InitializeComponent();
        }

        private void connectButton_click(object sender, RoutedEventArgs e)
        {
            //TODO: Save the latest IP in a file.
            Console.WriteLine(12);
            if (String.IsNullOrWhiteSpace(ipTextBox.Text) == false)
            {
                string answer;
                try
                {
                    ipAddress = ipTextBox.Text;
                    using (WebClient wc = new WebClient())
                    {
                        //TODO: 
                        //get connection response
                        answer = wc.DownloadString("http://" + ipAddress + "/connect");
                    }
                    statusLabel.Content = answer;
                }
                catch (ArgumentNullException A)
                {
                    Console.WriteLine("ArgumentNullException: {0}", A);
                }
                catch (SocketException A)
                {
                    Console.WriteLine("SocketException: {0}", A);
                }
                LoginViewModel loginViewModel = new LoginViewModel();
                loginViewModel.MainViewModel.CurrentView = loginViewModel.MainViewModel.HomeVM;
              
                //  this.Hide();
              //  OverviewForm form2 = new OverviewForm(this);
              //form2.Show();
            }
            else
            {
                statusLabel.Foreground = Brushes.Red;
                statusLabel.Content = "Please type an IP address";
            }
        }
    }
}
