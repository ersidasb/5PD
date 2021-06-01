using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sender
{
    class _Sender
    {
        /*public static void Send(string message, List<int> keyAndSignature)
        {
            IPAddress receiverIP = IPAddress.Parse("127.0.0.1"); // receiver adresas
            IPEndPoint endPoint = new IPEndPoint(receiverIP, 2021);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            byte[] fileNameBytes = Encoding.ASCII.GetBytes(Path.GetFileName(fileName));
            byte[] fileNameLength = BitConverter.GetBytes(Path.GetFileName(fileName).Length);
            byte[] fullBuffer = new byte[4 + fileNameBytes.Length];

            fileNameLength.CopyTo(fullBuffer, 0);
            fileNameBytes.CopyTo(fullBuffer, 4);
            try
            {
                socket.Connect(endPoint);
            }
            catch(Exception exc)
            {
                MessageBox.Show("Server is offline. Please try again later.");
            }
            socket.SendFile(fileName, fullBuffer, null, TransmitFileOptions.UseDefaultWorkerThread);
            socket.Close();
            MessageBox.Show("Your message was sent successfully.");
        }*/
    }
}
