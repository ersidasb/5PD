using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        _Server server = new _Server();
        delegate void updateDelegate(string message, List<int> keyAndSignature);
        updateDelegate update;
        public MainWindow()
        {
            InitializeComponent();
            update = updateUI;
            _Server.update = update;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Thread serverThread = new Thread(() =>
            {
                server.Start();
            });
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateUI(string message, List<int> keyAndSignature)
        {
            Dispatcher.Invoke((Action)delegate
            {
                tblMessage.Text = "";
                tblPublicKey.Text = "";
                tblSignature.Text = "";

                tblMessage.Text = message;
                tblPublicKey.Text = $"{keyAndSignature[0]}, {keyAndSignature[1]}";
                int index = 0;
                foreach (int i in keyAndSignature)
                {
                    if(index>1)
                        tblSignature.Inlines.Add(i.ToString() + ", ");
                    index++;
                }
            });
        }
    }
}
