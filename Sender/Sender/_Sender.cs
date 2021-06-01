using System;
using System.Collections.Generic;
using System.IO;
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
        public static void Send(string message, List<int> keyAndSignature)
        {
            IPAddress receiverIP = IPAddress.Parse("127.0.0.1"); // receiver adresas
            IPEndPoint endPoint = new IPEndPoint(receiverIP, 2021);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            byte[] messageLengthBytes = BitConverter.GetBytes(messageBytes.Length);

            byte[] keyAndSignatureBytes = keyAndSignature.SelectMany(BitConverter.GetBytes).ToArray();
            byte[] fullBuffer = new byte[8 + messageBytes.Length + keyAndSignatureBytes.Length];
            byte[] fullBufferLengthBytes = BitConverter.GetBytes(fullBuffer.Length);

            fullBufferLengthBytes.CopyTo(fullBuffer, 0);
            messageLengthBytes.CopyTo(fullBuffer, 4);
            messageBytes.CopyTo(fullBuffer, 8);
            keyAndSignatureBytes.CopyTo(fullBuffer, 8 + messageBytes.Length);

            try
            {
                socket.Connect(endPoint);
            }
            catch(Exception exc)
            {
                MessageBox.Show("Server is offline. Please try again later.");
                throw new Exception();
            }
            socket.Send(fullBuffer);

            socket.Close();
            MessageBox.Show("Your message was sent successfully.");
        }
    }
}
