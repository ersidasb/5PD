using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Server
{
    class _Server
    {
        private static TcpListener listener = null;
        private string message = "";
        private List<int> keyAndSignature = new List<int>();
        public static Delegate update;

        public _Server()
        {
            listener = new TcpListener(IPAddress.Any, 2021);
        }
        public void Start()
        {
            try
            {
                listener.Start();
                Console.WriteLine("Started");
                while (true)
                {
                    using (TcpClient client = listener.AcceptTcpClient())
                    using (NetworkStream stream = client.GetStream())
                    {
                        Console.WriteLine("client sending message");
                        byte[] bufferLengthBytes = new byte[4];
                        stream.Read(bufferLengthBytes, 0, 4);
                        int bufferLength = BitConverter.ToInt32(bufferLengthBytes, 0);

                        byte[] messageLengthBytes = new byte[4];
                        stream.Read(messageLengthBytes, 0, 4);
                        int messageLength = BitConverter.ToInt32(messageLengthBytes, 0);

                        byte[] messageBytes = new byte[messageLength];
                        stream.Read(messageBytes, 0, messageLength);
                        message = Encoding.ASCII.GetString(messageBytes, 0, messageLength);

                        byte[] keyAndSignatureBytes = new byte[bufferLength - messageLength - 8];
                        stream.Read(keyAndSignatureBytes, 0 , bufferLength - messageLength - 8);
                        keyAndSignature = Enumerable.Range(0, keyAndSignatureBytes.Length / 4).Select(i => BitConverter.ToInt32(keyAndSignatureBytes, i * 4)).ToList();
                        update.DynamicInvoke(message, keyAndSignature);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
                Console.WriteLine("Stopped");
            }
        }

        public static void Send(string message, List<int> keyAndSignature)
        {
            IPAddress receiverIP = IPAddress.Parse("127.0.0.1"); // receiver adresas
            IPEndPoint endPoint = new IPEndPoint(receiverIP, 2022);
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
            catch (Exception exc)
            {
                MessageBox.Show("Receiver is offline. Please try again later.");
                throw new Exception();
            }
            socket.Send(fullBuffer);

            socket.Close();
            MessageBox.Show("Data was sent successfuly.");
        }
    }
}
