using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RSASignature signature = new RSASignature();
        public MainWindow()
        {
            InitializeComponent();
            btnSend.IsEnabled = false;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string text = tbxMessage.Text;
            try
            {
                _Sender.Send(text, signature.getMessageSignature(text));
                tbxMessage.Text = "";
            }
            catch
            {
            }
        }

        private void tbxMessage_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (tbxMessage.Text == "")
                btnSend.IsEnabled = false;
            else
                btnSend.IsEnabled = true;
        }
    }
}
