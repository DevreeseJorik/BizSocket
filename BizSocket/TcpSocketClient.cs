using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using System.Windows.Forms;

namespace Net.MyStuff.BizSocket
{
    public class TcpSocketClient
    {
        private TcpClient? client;
        private NetworkStream? stream;
        private Thread? receiveThread;
        private int port = 12345;

        public event EventHandler<string>? MessageReceived;

        public TcpSocketClient()
        {
            try
            {
                client = new TcpClient();
                client.Connect("127.0.0.1", port);
                stream = client.GetStream();

                receiveThread = new Thread(ReceiveFromServer);
                receiveThread.Start();
            } catch (Exception ex)
            {
                Console.WriteLine("Error connecting to server: " + ex.Message);
                MessageBox.Show("Failed to connect to server. Is the server running on an available port?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream?.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending message to server: " + ex.Message);
            }
        }

        private void ReceiveFromServer()
        {
            try
            {
                if (stream == null) return;

                while (true)
                {
                    byte[] data = new byte[1024];
                    int bytesRead = stream.Read(data, 0, data.Length);
                    string responseData = Encoding.ASCII.GetString(data, 0, bytesRead);
                    MessageReceived?.Invoke(this, responseData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error receiving message from server: " + ex.Message);
            }
        }

        public void Disconnect()
        {
            stream?.Close();
            client?.Close();
        }
    }
}
