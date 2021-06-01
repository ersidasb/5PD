using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Receiver
{
    class _Receiver
    {
        private static TcpListener listener = null;
        private string message = "";
        private List<int> keyAndSignature = new List<int>();
        public static Delegate update;

        public _Receiver()
        {
            listener = new TcpListener(IPAddress.Any, 2022);
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
                        stream.Read(keyAndSignatureBytes, 0, bufferLength - messageLength - 8);
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
    }
}
