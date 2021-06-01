using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Receiver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        _Receiver receiver = new _Receiver();
        delegate void updateDelegate(string message, List<int> keyAndSignature);
        updateDelegate update;
        string message;
        List<int> keyAndSignature = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
            btnValidate.IsEnabled = false;
            update = updateUI;
            _Receiver.update = update;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Thread serverThread = new Thread(() =>
            {
                receiver.Start();
            });
            serverThread.IsBackground = true;
            serverThread.Start();
            btnStart.IsEnabled = false;
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            if(validateSignature())
            {
                MessageBox.Show("Signature is valid.");
            }
            else
            {
                MessageBox.Show("Signature is invalid.");
            }
        }

        private void updateUI(string message, List<int> keyAndSignature)
        {
            Dispatcher.Invoke((Action)delegate
            {
                tblMessage.Text = "";
                tblPublicKey.Text = "";
                tbxSignature.Document.Blocks.Clear();

                tblMessage.Text = message;
                tblPublicKey.Text = $"{keyAndSignature[0]}, {keyAndSignature[1]}";
                int index = 0;
                foreach (int i in keyAndSignature)
                {
                    if (index > 1 && index != keyAndSignature.Count - 1)
                        tbxSignature.AppendText(i.ToString() + ", ");
                    if (index == keyAndSignature.Count - 1)
                        tbxSignature.AppendText(i.ToString());
                    index++;
                }

                this.message = message;
                this.keyAndSignature = keyAndSignature;
                btnValidate.IsEnabled = true;
            });
        }

        private bool validateSignature()
        {
            int n = 0;
            int e = 0;
            bool valid = true;
            if (message.Length != keyAndSignature.Count - 2)
                return false;
            tbxSignature.Document.Blocks.Clear();
            for(int i=0; i<keyAndSignature.Count; i++)
            {
                if (i == 0)
                    n = keyAndSignature[i];
                if (i == 1)
                    e = keyAndSignature[i];
                if(i>1)
                {
                    int charValue = (int)message[i - 2];
                    int signatureCharValue = (Int32)BigInteger.ModPow(keyAndSignature[i], e, n);

                    TextRange rangeOfText2 = new TextRange(tbxSignature.Document.ContentEnd, tbxSignature.Document.ContentEnd);

                    if(i != keyAndSignature.Count -1)
                        rangeOfText2.Text = $"{keyAndSignature[i]}, ";
                    else
                        rangeOfText2.Text = $"{keyAndSignature[i]}";

                    if (charValue != signatureCharValue)
                    {
                        valid = false;
                        rangeOfText2.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
                    }
                    else
                    {
                        rangeOfText2.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Green);
                    }
                }
            }
            return valid;
        }
    }
}
