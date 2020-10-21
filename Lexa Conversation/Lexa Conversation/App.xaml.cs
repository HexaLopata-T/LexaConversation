using Lexa_Conversation.View;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lexa_Conversation
{
    public partial class App : Application
    {
        public static Socket client;
        private static MyShell shell;
        public App()
        {
            InitializeComponent();

            MainPage = new MyShell();
            shell = MainPage as MyShell;
            Run();
        }

        private static void Run()
        {
            try
            {
                string Host = System.Net.Dns.GetHostName();
                
                var socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //var ip = IPAddress.Parse("192.168.0.38");
                var ip = System.Net.Dns.GetHostByName(Host).AddressList[1];
                var ipstring = ip.ToString();
                var endPoint = new IPEndPoint(ip, 8080);
                socketServer.Bind(endPoint);
                socketServer.Listen(0);
                Task.Run(() =>
                {

                    while (true)
                    {
                        var socketClient = socketServer.Accept();
                        client = socketClient;
                        byte[] buffer = new byte[1024];
                        var request = socketClient.Receive(buffer);

                        string toSend = string.Empty;
                        toSend += "<HEAD><META charset = \"utf-8\"/></HEAD><BODY>";
                        foreach (var mes in shell.mv.Messages)
                        {
                            toSend += $"<p>{mes.Owner.Name}: \"{mes.Content}\"\n</p>";
                        }
                        toSend += "</BODY>";
                        var message = Encoding.UTF8.GetBytes(Response().header + toSend);
                        socketClient.Send(message);


                        socketClient.Disconnect(true);
                    }
                }
                );
            }
            catch
            {

            }
        }

        private static (string header, int code) Response()
        {
            return ("HTTP/1.1 200 OK\n Content-Type: text/html; charset=UTF-8\n\n", 200);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
